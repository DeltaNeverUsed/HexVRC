Shader "Pristine Triplanar Grid"
{
    Properties
    {
        [KeywordEnum(World,Object,ObjectAlignedWorld)] _GridSpace ("Grid Space", Float) = 0.0
        _GridScale ("Grid Scale", Float) = 1.0

        [Toggle(USE_VERTEX_NORMALS)] _UseVertexNormals ("Use Vertex Normals", Float) = 0.0
        [Toggle] _ShowOnlyTwo ("Show Only Two Grid Axis", Float) = 0.0
        
        _LineWidthX ("Line Width X", Range(0,1.0)) = 0.01
        _LineWidthY ("Line Width Y", Range(0,1.0)) = 0.01
        _LineWidthZ ("Line Width Y", Range(0,1.0)) = 0.01

        _LineColor ("Line Color", Color) = (1,1,1,1)
        _BaseColor ("Base Color", Color) = (0,0,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma shader_feature _ USE_VERTEX_NORMALS
            #pragma shader_feature _ _GRIDSPACE_OBJECT _GRIDSPACE_OBJECTALIGNEDWORLD

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 uvw : TEXCOORD0;
            #if defined(USE_VERTEX_NORMALS)
                float3 normal : TEXCOORD1;
            #endif
            };

            float _GridScale;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

            #if defined(_GRIDSPACE_OBJECTALIGNEDWORLD)
                float3 scale = float3(
                    length(unity_ObjectToWorld._m00_m10_m20),
                    length(unity_ObjectToWorld._m01_m11_m21),
                    length(unity_ObjectToWorld._m02_m12_m22)
                    );
            #endif

            #if defined(USE_VERTEX_NORMALS)
            #if defined(_GRIDSPACE_OBJECTALIGNEDWORLD)
                o.normal = normalize(v.normal / scale);
            #elif defined(_GRIDSPACE_OBJECT)
                o.normal = v.normal;
            #else // _GRIDSPACE_WORLD
                o.normal = UnityObjectToWorldNormal(v.normal);
            #endif
            #endif

            #if defined(_GRIDSPACE_OBJECTALIGNEDWORLD)
                o.uvw = v.vertex.xyz * scale;
            #elif defined(_GRIDSPACE_OBJECT)
                o.uvw = v.vertex.xyz;
            #else // _GRIDSPACE_WORLD
                // trick to reduce visual artifacts when far from the world origin
                float3 worldPos = mul(unity_ObjectToWorld, float4(v.vertex.xyz, 1.0)).xyz;
                float3 cameraCenteringOffset = floor(_WorldSpaceCameraPos * _GridScale);
                o.uvw = worldPos * _GridScale - cameraCenteringOffset;
            #endif

                return o;
            }

            bool _UseDerivNormals, _ShowOnlyTwo;
            float _LineWidthX, _LineWidthY, _LineWidthZ;
            half4 _LineColor, _BaseColor;

            fixed4 frag (v2f i) : SV_Target
            {
            #if defined(USE_VERTEX_NORMALS)
                float3 blendNormal = abs(normalize(i.normal));
            #else
                float3 blendNormal = abs(normalize(cross(ddy(i.uvw), ddx(i.uvw))));
            #endif

                float3 uvw = i.uvw;
                float3 lineWidth = float3(_LineWidthX, _LineWidthY, _LineWidthZ);

                // adjust line width based on surface angle
                // this is a cos to sin conversion
                lineWidth *= sqrt(saturate(1.0 - blendNormal * blendNormal));

                float3 uvwDDX = ddx(uvw);
                float3 uvwDDY = ddy(uvw);
                float3 uvwDeriv = float3(
                    length(float2(uvwDDX.x,uvwDDY.x)),
                    length(float2(uvwDDX.y,uvwDDY.y)),
                    length(float2(uvwDDX.z,uvwDDY.z))
                    );
                uvwDeriv = max(uvwDeriv, 0.00001);

                bool3 invertLine = lineWidth > 0.5;
                float3 targetWidth = invertLine ? 1.0 - lineWidth : lineWidth;
                float3 drawWidth = clamp(targetWidth, uvwDeriv, 0.5);
                float3 lineAA = uvwDeriv * 1.5;
                float3 gridUV = abs(frac(uvw) * 2.0 - 1.0);
                gridUV = invertLine ? gridUV : 1.0 - gridUV;
                float3 grid3 = smoothstep(drawWidth + lineAA, drawWidth - lineAA, gridUV);
                grid3 *= saturate(targetWidth / drawWidth);
                grid3 = lerp(grid3, targetWidth, saturate(uvwDeriv * 2.0 - 1.0));
                grid3 = invertLine ? 1.0 - grid3 : grid3;

                // return float4(grid3, 1.0);

                float3 blendFactor = blendNormal / dot(float3(1,1,1), blendNormal);
                float3 blendFwidth = max(fwidth(blendFactor), 0.0001);

                // 0.8 is an arbitrary offset to hide the line when the surface is
                // almost axis aligned
                float3 blendEdge = 0.8;

                // otherwise limit to two lines
                if (_ShowOnlyTwo)
                    blendEdge = float3(
                        max(blendFactor.y, blendFactor.z),
                        max(blendFactor.x, blendFactor.z),
                        max(blendFactor.x, blendFactor.y)
                        );

                grid3 *= saturate((blendEdge - blendFactor) / blendFwidth + 1.0);

                float grid = lerp(lerp(grid3.x, 1.0, grid3.y), 1.0, grid3.z);

                // accurate way handle colored grid in gamma color space
            #if defined(UNITY_COLORSPACE_GAMMA)
                half4 linearBaseColor = half4(GammaToLinearSpace(_BaseColor.rgb), _BaseColor.a);
                half4 linearLineColor = half4(GammaToLinearSpace(_LineColor.rgb), _LineColor.a);
                half4 col = lerp(linearBaseColor, linearLineColor, grid * _LineColor.a);
                return half4(LinearToGammaSpace(col.rgb), col.a);
            #endif

                // lerp between base and line color
                return lerp(_BaseColor, _LineColor, grid * _LineColor.a);
            }
            ENDCG
        }
    }
}