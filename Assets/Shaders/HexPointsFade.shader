Shader "Custom/HexDots"
{
    Properties
    {
        _DotCount("Dot Count", float) = 11
        _Distance("Size", Range(0,1)) = 1
        _TColor("Top Color", Color) = (1,1,1,1)
        _BColor("Bottom Color", Color) = (1,1,1,1)
        _GridDistance("Grid distance", Range(0,10)) = 3
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }
        Pass
        {
            ZTest LEqual
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 world_pos : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.world_pos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            float4 _TColor;
            float4 _BColor;
            float _DotCount;
            float _Distance;
            float3 _UdonWandLocation;
            float _GridDistance;

            float4 frag(v2f i) : SV_Target
            {
                // Convert fragment world position to object space
                float3 localPos = mul(unity_WorldToObject, float4(i.world_pos.xyz, 1.0)).xyz;
                float hexSize = 1.0 / _DotCount;

                // Calculate axial coordinates from local position
                float axialX = -localPos.x;
                float axialY = -localPos.y;
                float r = axialY / (hexSize * 1.5);
                float q = (axialX / (hexSize * 1.73205)) - (r / 2.0); // 1.73205 ≈ sqrt(3)

                // Convert to cube coordinates and round
                float3 cube = float3(q, -q - r, r);
                float3 roundedCube = round(cube);
                float3 diff = abs(cube - roundedCube);

                if (diff.x > diff.y && diff.x > diff.z)
                    roundedCube.x = -roundedCube.y - roundedCube.z;
                else if (diff.y > diff.z)
                    roundedCube.y = -roundedCube.x - roundedCube.z;
                else
                    roundedCube.z = -roundedCube.x - roundedCube.y;

                // Get rounded axial coordinates
                float roundedQ = roundedCube.x;
                float roundedR = roundedCube.z;

                // Calculate hex center position in object space
                float centerX = hexSize * 1.73205 * (roundedQ + roundedR / 2.0);
                float centerY = hexSize * 1.5 * roundedR;
                float2 centerLocalPos = float2(-centerX, -centerY);

                // Calculate distance and dot visibility
                float distanceToCenter = distance(localPos.xy, centerLocalPos);
                float radius = hexSize * 0.5 * _Distance;
                float dot = smoothstep(radius * 0.9, radius * 1.1, distanceToCenter);

                // Blend colors and apply distance fade
                float4 color = lerp(_BColor, _TColor, dot);
                color.a *= 1.0 - pow(distance(i.world_pos.xyz, _UdonWandLocation) * _GridDistance, 0.2);

                return saturate(color);
            }
            ENDCG
        }
    }
}