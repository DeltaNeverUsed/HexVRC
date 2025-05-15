Shader "Pristine Radial Grid"
{
    Properties
    {
        [Toggle] _WorldUV ("Use World Space UV", Float) = 1.0
        _GridScale ("Grid Scale", Float) = 1.0

        [Toggle] _UseAdaptiveAngularSegments ("Use Adaptive Angular Segment Count", Float) = 0.0
        [IntRange] _AngularSegments ("Angular Segments", Range(1,360)) = 4.0
        
        _LineWidthX ("Line Width X", Range(0,1.0)) = 0.01
        _LineWidthY ("Line Width Y", Range(0,1.0)) = 0.01

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

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // needed for fine derivatives
            #pragma target 5.0

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            bool _WorldUV;
            float _GridScale;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);

                if (_WorldUV)
                {
                    float3 worldPos = mul(unity_ObjectToWorld, float4(v.vertex.xyz, 1.0)).xyz;
                    o.uv = worldPos.xz * _GridScale;
                }
                else
                    o.uv = v.uv * _GridScale;

                return o;
            }

            bool _UseAdaptiveAngularSegments;
            float _AngularSegments;
            float _LineWidthX, _LineWidthY;
            half4 _LineColor, _BaseColor;

            float ddLength_fine(float x) { return length(float2(ddx_fine(x), ddy_fine(x))); }

            fixed4 frag (v2f i) : SV_Target
            {
                float angle = atan2(i.uv.y, i.uv.x) / UNITY_TWO_PI;

                // fix for derivative discontinuities in atan gradient
                float angleFrac = frac(angle);
                float ddAngle = ddLength_fine(angle);
                float ddAngleFrac = ddLength_fine(angleFrac);
                ddAngle = ddAngle - 0.00001 < ddAngleFrac ? ddAngle : ddAngleFrac;

                float dist = length(i.uv);

                float segments = max(1,round(_AngularSegments));

                // set number of angular grid lines depending on log distance from center
                if (_UseAdaptiveAngularSegments)
                {
                    float logDist = log2(dist);
                    segments = pow(2.0, max(2.0, ceil(logDist) + 2.0));
                }

                float2 lineWidth = float2(_LineWidthX * segments / (dist * UNITY_TWO_PI), _LineWidthY);
                float2 uv = float2(angle * segments, dist);
                float2 uvDeriv = float2(ddAngle * segments, ddLength_fine(dist));

                // prestine grid
                bool2 invertLine = lineWidth > 0.5;
                float2 targetWidth = invertLine ? 1.0 - lineWidth : lineWidth;
                float2 drawWidth = clamp(targetWidth, uvDeriv, 0.5);
                float2 lineAA = uvDeriv * 1.5;
                float2 gridUV = abs(frac(uv) * 2.0 - 1.0);
                gridUV = invertLine ? gridUV : 1.0 - gridUV;
                float2 grid2 = smoothstep(drawWidth + lineAA, drawWidth - lineAA, gridUV);
                grid2 *= saturate(targetWidth / drawWidth);
                grid2 = lerp(grid2, targetWidth, saturate(uvDeriv * 2.0 - 1.0));
                grid2 = invertLine ? 1.0 - grid2 : grid2;
                float grid = lerp(grid2.x, 1.0, grid2.y);

                // accurate way handle colored grid in gamma color space
            #if defined(UNITY_COLORSPACE_GAMMA)
                half4 linearBaseColor = half4(GammaToLinearSpace(_BaseColor.rgb), _BaseColor.a);
                half4 linearLineColor = half4(GammaToLinearSpace(_LineColor.rgb), _LineColor.a);
                half4 col = lerp(linearBaseColor, linearLineColor, grid * _LineColor.a);
                return half4(LinearToGammaSpace(col.rgb), col.a);
            #endif

                // cheap way to handle colored grid in gamma color space
                // accurate for black and white grid, wrong for anything else
            // #if defined(UNITY_COLORSPACE_GAMMA)
            //     grid = LinearToGammaSpaceExact(grid);
            // #endif

                // lerp between base and line color
                return lerp(_BaseColor, _LineColor, grid * _LineColor.a);
            }
            ENDCG
        }
    }
}