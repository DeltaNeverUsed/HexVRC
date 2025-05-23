// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Legacy Shaders/Particles/Alpha Blended Premultiply UI"
{
    Properties
    {
        
        
        _MainTex ("Particle Texture", 2D) = "white" {}
        _InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
        _Speed ("Animation Speed", Range(0, 10)) = 1
        
        _ColorMask ("Color Mask", Float) = 15
        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
        
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
    }

    Category
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="False"
        }
        
        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }


        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        SubShader
        {
            Pass
            {

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 2.0
                //  #pragma multi_compile_particles
                #pragma multi_compile_local _ UNITY_UI_CLIP_RECT
                #pragma multi_compile_local _ UNITY_UI_ALPHACLIP

                #include "UnityCG.cginc"
                #include "UnityUI.cginc"

                sampler2D _MainTex;
                fixed4 _TintColor;

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    fixed4 color : COLOR;
                    float2 texcoord : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                struct v2f
                {
                    float4 vertex : SV_POSITION;
                    fixed4 color : COLOR;
                    float2 texcoord : TEXCOORD0;
                    float4 worldPosition : TEXCOORD2;
                    #ifdef SOFTPARTICLES_ON
                float4 projPos : TEXCOORD1;
                    #endif
                    UNITY_VERTEX_OUTPUT_STEREO
                };

                float4 _MainTex_ST;
                float _Speed;
                float4 _ClipRect;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    UNITY_SETUP_INSTANCE_ID(v);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                    o.worldPosition = v.vertex;
                    o.vertex = UnityObjectToClipPos(o.worldPosition);
                    #ifdef SOFTPARTICLES_ON
                o.projPos = ComputeScreenPos (o.vertex);
                COMPUTE_EYEDEPTH(o.projPos.z);
                    #endif
                    o.color = v.color;
                    o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }

                UNITY_DECLARE_DEPTH_TEXTURE(_CameraDepthTexture);
                float _InvFade;

                fixed4 frag(v2f i) : SV_Target
                {
                    #ifdef SOFTPARTICLES_ON
                    float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
                    float partZ = i.projPos.z;
                    float fade = saturate (_InvFade * (sceneZ-partZ));
                    i.color.a *= fade;
                    #endif


                    float4 color = i.color;

                    #ifdef UNITY_UI_CLIP_RECT
                    color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                    #endif

                    #ifdef UNITY_UI_ALPHACLIP
                    clip (color.a - 0.001);
                    #endif


                    return color;
                }
                ENDCG
            }
        }
    }
}