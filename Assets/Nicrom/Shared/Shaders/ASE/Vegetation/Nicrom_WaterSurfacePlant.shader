// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Vegetation//WSP"
{
	Properties
	{
		_AlphaCutoff( "Alpha Cutoff", Range( 0, 1 ) ) = 0.5
		[NoScaleOffset][SingleLineTexture] _Albedo( "Albedo", 2D ) = "white" {}
		[NoScaleOffset][Normal][SingleLineTexture] _Normal( "Normal", 2D ) = "bump" {}
		_NormalScale( "Normal Scale", Range( 0, 3 ) ) = 1
		_Metallic( "Metallic", Range( 0, 1 ) ) = 0
		[SingleLineTexture] _Smoothness( "Smoothness", 2D ) = "white" {}
		_SmoothnessScale( "Smoothness Scale", Range( 0, 1 ) ) = 0
		[KeywordEnum( One,Two,Four )] _Colors( "Colors", Float ) = 0
		_Color1A( "Color 1A", Color ) = ( 1, 1, 1 )
		_Color1B( "Color 1B", Color ) = ( 1, 1, 1 )
		_Color2A( "Color 2A", Color ) = ( 1, 1, 1 )
		_Color2B( "Color 2B", Color ) = ( 1, 1, 1 )
		[Enum(None,0,Color Mask 1,1,Color Mask 2,2)] _Debug( "Debug", Float ) = 0
		[KeywordEnum( UVs,VertexPos )] _ColorMask1Source( "Color Mask 1 Source ", Float ) = 0
		_ColorMask1StartV( "Color Mask 1 Start V", Range( 0, 1 ) ) = 0
		_ColorMask1EndV( "Color Mask 1 End V", Range( 0, 1 ) ) = 1
		_ColorMask1StartVert( "Color Mask 1 Start Vert", Range( -6, 1 ) ) = -0.5
		_ColorMask1EndVert( "Color Mask 1 End Vert", Range( -6, 1 ) ) = 0.1
		[SingleLineTexture] _ColorMask2( "Color Mask 2", 2D ) = "white" {}
		_ColorMask2Tiling( "Color Mask 2 Tiling", Range( 0.0001, 4 ) ) = 0.05
		_ColorMask2SharpMin( "Color Mask 2 Sharp Min", Range( 0, 1 ) ) = 0
		_ColorMask2SharpMax( "Color Mask 2 Sharp Max", Range( 0, 1 ) ) = 0.5
		[Toggle( _MAINMOTION_ON )] _MainMotion( "MainMotion", Float ) = 1
		[Toggle] _GVTime( "GV Time", Float ) = 1
		[Toggle] _GVAmplitudeScale( "GV Amplitude Scale", Float ) = 1
		[Toggle] _GVDirectionAngle( "GV Direction Angle", Float ) = 1
		_MMSpeed( "MM Speed", Range( 0, 3 ) ) = 0.4
		_MMAmplitude( "MM Amplitude", Range( 0, 90 ) ) = 1.5
		_MMAmplitudeOffset( "MM Amplitude Offset", Range( 0, 90 ) ) = 2
		[Enum(Vertex Colors,0,Noise Texture,1)] _MMPhaseShiftSource( "MM Phase Shift Source", Float ) = 1
		_MMPhaseShiftScale( "MM Phase Shift Scale", Range( 0, 1 ) ) = 1
		_MMDirectionShift( "MM Direction Shift", Range( 0, 90 ) ) = 20
		_MMDirectionShiftOffset( "MM Direction Shift Offset", Range( 0, 90 ) ) = 10
		_MMDirectionShiftSpeed( "MM Direction Shift Speed", Range( 0, 5 ) ) = 1
		_MMDirectionShiftNoiseScale( "MM Direction Shift Noise Scale", Range( 0, 1 ) ) = 1
		_MMDirectionAngle( "MM Direction Angle", Range( 0, 360 ) ) = 0
		_MMSineWaveLength( "MM Sine Wave Length", Range( 0.001, 20 ) ) = 6
		_MMObjectHeight( "MM Object Height", Range( 0, 100 ) ) = 1
		[Space][Toggle( _DETAILMOTION1_ON )] _DetailMotion1( "Detail Motion 1", Float ) = 1
		_DM1Speed( "DM1 Speed", Range( 0, 10 ) ) = 2
		_DM1Amplitude( "DM1 Amplitude", Range( 0, 40 ) ) = 0.5
		_DM1AmplitudeOffset( "DM1 Amplitude Offset", Range( 0, 40 ) ) = 3
		[SingleLineTexture] _MotionNoise( "Motion Noise", 2D ) = "white" {}
		_MotionNoiseTiling( "Motion Noise Tiling", Range( 0.0001, 4 ) ) = 1
		_ScaleOffset( "Scale Offset", Range( -1, 5 ) ) = 0
		[Toggle( _SCALEVARIATION_ON )] _ScaleVariation( "Scale Variation", Float ) = 0
		_ScaleVarMin( "Scale Var Min", Range( -1, 2 ) ) = 0
		_ScaleVarMax( "Scale Var Max", Range( -1, 2 ) ) = 0.2
		[SingleLineTexture][Space] _ScaleVarNoise( "Scale Var Noise", 2D ) = "white" {}
		_ScaleVarNoiseTiling( "Scale Var Noise Tiling", Range( 0.0001, 5 ) ) = 1
		_ScaleVarNoiseSharpMin( "Scale Var Noise Sharp Min", Range( 0, 1 ) ) = 0
		_ScaleVarNoiseSharpMax( "Scale Var Noise Sharp Max", Range( 0, 1 ) ) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityStandardUtils.cginc"
		#pragma target 3.5
		#pragma shader_feature_local_vertex _SCALEVARIATION_ON
		#pragma shader_feature_local _MAINMOTION_ON
		#pragma shader_feature_local _DETAILMOTION1_ON
		#pragma shader_feature_local _COLORS_ONE _COLORS_TWO _COLORS_FOUR
		#pragma shader_feature_local _COLORMASK1SOURCE_UVS _COLORMASK1SOURCE_VERTEXPOS
		#define ASE_VERSION 19901
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows nolightmap  dithercrossfade vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float4 ase_positionOS4f;
			float vertexToFrag25_g581;
		};

		uniform half _MMObjectHeight;
		uniform half _MMAmplitudeOffset;
		uniform sampler2D _MotionNoise;
		uniform float _MotionNoiseTiling;
		uniform half _MMAmplitude;
		uniform float Nicrom_MM_AmpScale_WSP;
		uniform half _GVAmplitudeScale;
		uniform float Nicrom_MM_Time_WSP;
		uniform float _GVTime;
		uniform half Nicrom_ApplicationIsPlaying;
		uniform half _MMSpeed;
		uniform float Nicrom_MM_SpeedScale_WSP;
		uniform half _MMSineWaveLength;
		uniform half _MMPhaseShiftSource;
		uniform half _MMPhaseShiftScale;
		uniform half _MMDirectionAngle;
		uniform half Nicrom_WindDirAngle;
		uniform half _GVDirectionAngle;
		uniform half _MMDirectionShift;
		uniform half _MMDirectionShiftOffset;
		uniform half _MMDirectionShiftSpeed;
		uniform half _MMDirectionShiftNoiseScale;
		uniform float _DM1AmplitudeOffset;
		uniform float _DM1Amplitude;
		uniform float Nicrom_DM_AmpScale_WSP;
		uniform float Nicrom_DM_Time_WSP;
		uniform float Nicrom_DM_SpeedScale_WSP;
		uniform float _DM1Speed;
		uniform float _ScaleVarMin;
		uniform float _ScaleVarMax;
		uniform float _ScaleVarNoiseSharpMin;
		uniform float _ScaleVarNoiseSharpMax;
		uniform sampler2D _ScaleVarNoise;
		uniform float _ScaleVarNoiseTiling;
		uniform float _ScaleOffset;
		uniform sampler2D _Normal;
		uniform float _NormalScale;
		uniform float _Debug;
		uniform float3 _Color1A;
		uniform float3 _Color1B;
		uniform float _ColorMask1StartV;
		uniform float _ColorMask1EndV;
		uniform float _ColorMask1StartVert;
		uniform float _ColorMask1EndVert;
		uniform float3 _Color2B;
		uniform float3 _Color2A;
		uniform float _ColorMask2SharpMin;
		uniform float _ColorMask2SharpMax;
		uniform sampler2D _ColorMask2;
		uniform float _ColorMask2Tiling;
		uniform sampler2D _Albedo;
		uniform float _Metallic;
		uniform sampler2D _Smoothness;
		uniform float4 _Smoothness_ST;
		uniform float _SmoothnessScale;
		uniform float _AlphaCutoff;


		float3 RotateAroundAxis( float3 center, float3 original, float3 u, float angle )
		{
			original -= center;
			float C = cos( angle );
			float S = sin( angle );
			float t = 1 - C;
			float m00 = t * u.x * u.x + C;
			float m01 = t * u.x * u.y - S * u.z;
			float m02 = t * u.x * u.z + S * u.y;
			float m10 = t * u.x * u.y + S * u.z;
			float m11 = t * u.y * u.y + C;
			float m12 = t * u.y * u.z - S * u.x;
			float m20 = t * u.x * u.z - S * u.y;
			float m21 = t * u.y * u.z + S * u.x;
			float m22 = t * u.z * u.z + C;
			float3x3 finalMatrix = float3x3( m00, m01, m02, m10, m11, m12, m20, m21, m22 );
			return mul( finalMatrix, original ) + center;
		}


		float4 Debug90_g581( float Debug_Target, float4 Albedo, float ColorMask1, float ColorMask2 )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return ColorMask1;
			else
			    return ColorMask2;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_positionOS = v.vertex.xyz;
			float MM_ObjectHeight196_g571 = _MMObjectHeight;
			float lerpResult201_g571 = lerp( 1.0 , ( 1.0 - saturate( ( abs( ase_positionOS.y ) / MM_ObjectHeight196_g571 ) ) ) , step( ase_positionOS.y , 0.0 ));
			float MM_Mask198_g571 = lerpResult201_g571;
			float MM_AmplitudeOffset77_g571 = _MMAmplitudeOffset;
			float3 appendResult28_g574 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 LocalPivot16_g571 = -appendResult28_g574;
			float3 objToWorld11_g575 = mul( unity_ObjectToWorld, float4( LocalPivot16_g571, 1 ) ).xyz;
			float2 appendResult10_g575 = (float2(objToWorld11_g575.x , objToWorld11_g575.z));
			float MotionNoiseTiling20_g571 = _MotionNoiseTiling;
			float4 WorldSpaceStaticNoise28_g571 = tex2Dlod( _MotionNoise, float4( ( appendResult10_g575 * MotionNoiseTiling20_g571 ), 0, 0.0) );
			float MM_Amplitude85_g571 = _MMAmplitude;
			float GV_AmplitudeScale175_g571 = _GVAmplitudeScale;
			float lerpResult181_g571 = lerp( 1.0 , Nicrom_MM_AmpScale_WSP , GV_AmplitudeScale175_g571);
			float MM_AmplitudeScale87_g571 = lerpResult181_g571;
			float3 objToWorld134_g571 = mul( unity_ObjectToWorld, float4( LocalPivot16_g571, 1 ) ).xyz;
			float MM_Time_G46_g571 = Nicrom_MM_Time_WSP;
			float GV_Time174_g571 = _GVTime;
			float lerpResult59_g571 = lerp( _Time.y , MM_Time_G46_g571 , GV_Time174_g571);
			float ApplicationIsPlaying208_g571 = Nicrom_ApplicationIsPlaying;
			float lerpResult227_g571 = lerp( _Time.y , lerpResult59_g571 , ApplicationIsPlaying208_g571);
			float MM_Time65_g571 = lerpResult227_g571;
			float MM_Speed58_g571 = _MMSpeed;
			float MM_SpeedScale_GV212_g571 = Nicrom_MM_SpeedScale_WSP;
			float lerpResult220_g571 = lerp( MM_SpeedScale_GV212_g571 , 1.0 , GV_Time174_g571);
			float lerpResult221_g571 = lerp( MM_SpeedScale_GV212_g571 , lerpResult220_g571 , ApplicationIsPlaying208_g571);
			float MM_SpeedScale222_g571 = lerpResult221_g571;
			float MM_SineWaveLength57_g571 = _MMSineWaveLength;
			float MM_PhaseShiftSource34_g571 = _MMPhaseShiftSource;
			float lerpResult47_g571 = lerp( v.color.a , (WorldSpaceStaticNoise28_g571).g , MM_PhaseShiftSource34_g571);
			float MM_PhaseShiftScale43_g571 = _MMPhaseShiftScale;
			float MB_PhaseShift61_g571 = ( lerpResult47_g571 * MM_PhaseShiftScale43_g571 );
			float lerpResult56_g572 = lerp( _MMDirectionAngle , Nicrom_WindDirAngle , _GVDirectionAngle);
			float MM_DirectionAngle80_g571 = lerpResult56_g572;
			float MM_DirShift81_g571 = _MMDirectionShift;
			float MM_DirShiftOffset82_g571 = _MMDirectionShiftOffset;
			float4 StaticWorldNoise55_g573 = WorldSpaceStaticNoise28_g571;
			float3 objToWorld50_g573 = mul( unity_ObjectToWorld, float4( LocalPivot16_g571, 1 ) ).xyz;
			float Time76_g573 = MM_Time65_g571;
			float SpeedScale_RA80_g573 = 1.0;
			float MM_DirShiftSpeed83_g571 = _MMDirectionShiftSpeed;
			float MM_DirShiftNoiseScale84_g571 = _MMDirectionShiftNoiseScale;
			float temp_output_11_0_g573 = radians( ( ( ( 90.0 + MM_DirectionAngle80_g571 ) + ( ( MM_DirShift81_g571 + ( MM_DirShiftOffset82_g571 * (StaticWorldNoise55_g573).x ) ) * sin( ( ( objToWorld50_g573.x + objToWorld50_g573.z ) + ( ( Time76_g573 * ( SpeedScale_RA80_g573 * MM_DirShiftSpeed83_g571 ) ) + ( ( 2.0 * UNITY_PI ) * ( (StaticWorldNoise55_g573).z * MM_DirShiftNoiseScale84_g571 ) ) ) ) ) ) ) * -1.0 ) );
			float3 appendResult14_g573 = (float3(cos( temp_output_11_0_g573 ) , 0.0 , sin( temp_output_11_0_g573 )));
			float3 worldToObj35_g573 = mul( unity_WorldToObject, float4( appendResult14_g573, 1 ) ).xyz;
			float3 worldToObj36_g573 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult34_g573 = normalize( (( worldToObj35_g573 - worldToObj36_g573 )).xyz );
			float3 DirectionVector165_g571 = normalizeResult34_g573;
			#ifdef _MAINMOTION_ON
				float3 staticSwitch188_g571 = ( ( ( MM_Mask198_g571 * ( ( ( MM_AmplitudeOffset77_g571 * (WorldSpaceStaticNoise28_g571).r ) + MM_Amplitude85_g571 ) * MM_AmplitudeScale87_g571 ) ) * sin( ( ( ( objToWorld134_g571.x + objToWorld134_g571.z ) + ( ( MM_Time65_g571 * ( ( MM_Speed58_g571 * MM_SpeedScale222_g571 ) * MM_SineWaveLength57_g571 ) ) + ( ( 2.0 * UNITY_PI ) * MB_PhaseShift61_g571 ) ) ) * ( ( 2.0 * UNITY_PI ) / MM_SineWaveLength57_g571 ) ) ) ) * DirectionVector165_g571 );
			#else
				float3 staticSwitch188_g571 = float3( 0, 0, 0 );
			#endif
			float3 HorizontalMovement157_g571 = staticSwitch188_g571;
			float DM1_AmplitudeOffset66_g571 = _DM1AmplitudeOffset;
			float DM1_Amplitude70_g571 = _DM1Amplitude;
			float lerpResult184_g571 = lerp( 1.0 , Nicrom_DM_AmpScale_WSP , GV_AmplitudeScale175_g571);
			float DM_AmplitudeScale79_g571 = lerpResult184_g571;
			float3 objToWorld96_g571 = mul( unity_ObjectToWorld, float4( LocalPivot16_g571, 1 ) ).xyz;
			float DM_Time_G31_g571 = Nicrom_DM_Time_WSP;
			float lerpResult45_g571 = lerp( _Time.y , DM_Time_G31_g571 , GV_Time174_g571);
			float lerpResult239_g571 = lerp( _Time.y , lerpResult45_g571 , ApplicationIsPlaying208_g571);
			float DM_Time53_g571 = lerpResult239_g571;
			float DM_SpeedScale_GV213_g571 = Nicrom_DM_SpeedScale_WSP;
			float lerpResult231_g571 = lerp( DM_SpeedScale_GV213_g571 , 1.0 , GV_Time174_g571);
			float lerpResult235_g571 = lerp( DM_SpeedScale_GV213_g571 , lerpResult231_g571 , ApplicationIsPlaying208_g571);
			float DM_SpeedScale236_g571 = lerpResult235_g571;
			float DM1_Speed50_g571 = _DM1Speed;
			float VC_PhaseShift42_g571 = v.color.a;
			float3 rotatedValue126_g571 = RotateAroundAxis( LocalPivot16_g571, ase_positionOS, float3( 0, 1, 0 ), radians( ( ( ( ( DM1_AmplitudeOffset66_g571 * (WorldSpaceStaticNoise28_g571).r ) + DM1_Amplitude70_g571 ) * DM_AmplitudeScale79_g571 ) * sin( ( ( ( objToWorld96_g571.x + objToWorld96_g571.z ) + ( ( DM_Time53_g571 * ( DM_SpeedScale236_g571 * DM1_Speed50_g571 ) ) + ( ( 2.0 * UNITY_PI ) * ( 1.0 - VC_PhaseShift42_g571 ) ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) ) );
			#ifdef _DETAILMOTION1_ON
				float3 staticSwitch130_g571 = ( rotatedValue126_g571 - ase_positionOS );
			#else
				float3 staticSwitch130_g571 = float3( 0, 0, 0 );
			#endif
			float3 RotationMovement131_g571 = staticSwitch130_g571;
			float3 appendResult28_g580 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 Scale_Pivot15_g577 = -appendResult28_g580;
			float3 temp_output_5_0_g577 = ( ( ( HorizontalMovement157_g571 + RotationMovement131_g571 ) + ase_positionOS ) - Scale_Pivot15_g577 );
			float ScaleVartMin40_g577 = _ScaleVarMin;
			float ScaleVarMax41_g577 = _ScaleVarMax;
			float ScaleNoiseSharpnessMin59_g577 = _ScaleVarNoiseSharpMin;
			float ScaleNoiseSharpnessMax60_g577 = _ScaleVarNoiseSharpMax;
			float3 objToWorld11_g579 = mul( unity_ObjectToWorld, float4( Scale_Pivot15_g577, 1 ) ).xyz;
			float2 appendResult10_g579 = (float2(objToWorld11_g579.x , objToWorld11_g579.z));
			float2 Scale_WorldSpaceUVs30_g577 = appendResult10_g579;
			float Scale_VarNoiseTiling23_g577 = _ScaleVarNoiseTiling;
			float4 Scale_WorldSpaceNoise32_g577 = tex2Dlod( _ScaleVarNoise, float4( ( Scale_WorldSpaceUVs30_g577 * Scale_VarNoiseTiling23_g577 ), 0, 0.0) );
			float smoothstepResult56_g577 = smoothstep( ScaleNoiseSharpnessMin59_g577 , ScaleNoiseSharpnessMax60_g577 , (Scale_WorldSpaceNoise32_g577).r);
			float lerpResult44_g577 = lerp( ScaleVartMin40_g577 , ScaleVarMax41_g577 , smoothstepResult56_g577);
			float ScaleVar47_g577 = lerpResult44_g577;
			float clampResult63_g577 = clamp( ( ScaleVar47_g577 + 1.0 ) , 0.0 , 7.0 );
			#ifdef _SCALEVARIATION_ON
				float3 staticSwitch72_g577 = ( temp_output_5_0_g577 * clampResult63_g577 );
			#else
				float3 staticSwitch72_g577 = temp_output_5_0_g577;
			#endif
			float ScaleOffset19_g577 = _ScaleOffset;
			float clampResult64_g577 = clamp( ( ScaleOffset19_g577 + 1.0 ) , 0.0 , 7.0 );
			v.vertex.xyz += ( ( ( staticSwitch72_g577 * clampResult64_g577 ) + Scale_Pivot15_g577 ) - ase_positionOS );
			v.vertex.w = 1;
			float4 ase_positionOS4f = v.vertex;
			o.ase_positionOS4f = ase_positionOS4f;
			float3 appendResult28_g582 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 objToWorld11_g583 = mul( unity_ObjectToWorld, float4( -appendResult28_g582, 1 ) ).xyz;
			float2 appendResult10_g583 = (float2(objToWorld11_g583.x , objToWorld11_g583.z));
			float ColorMask2Tiling17_g581 = _ColorMask2Tiling;
			float2 ColorMask2UVs83_g581 = ( appendResult10_g583 * ColorMask2Tiling17_g581 );
			o.vertexToFrag25_g581 = (tex2Dlod( _ColorMask2, float4( ColorMask2UVs83_g581, 0, 0.0) )).r;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal103_g581 = i.uv_texcoord;
			o.Normal = UnpackScaleNormal( tex2D( _Normal, uv_Normal103_g581 ), _NormalScale );
			float Debug_Target90_g581 = _Debug;
			float3 Color1A35_g581 = _Color1A;
			float3 Color1B36_g581 = _Color1B;
			float ColorMask1StartV54_g581 = _ColorMask1StartV;
			float ColorMask1EndV55_g581 = _ColorMask1EndV;
			float smoothstepResult51_g581 = smoothstep( ( 1.0 - ColorMask1StartV54_g581 ) , ( 1.0 - ColorMask1EndV55_g581 ) , ( 1.0 - i.uv_texcoord.y ));
			float ColorMask1StartVert58_g581 = _ColorMask1StartVert;
			float ColorMask1EndVert59_g581 = _ColorMask1EndVert;
			float3 ase_positionOS = i.ase_positionOS4f.xyz;
			float smoothstepResult60_g581 = smoothstep( ColorMask1StartVert58_g581 , ColorMask1EndVert59_g581 , ase_positionOS.y);
			#if defined( _COLORMASK1SOURCE_UVS )
				float staticSwitch44_g581 = smoothstepResult51_g581;
			#elif defined( _COLORMASK1SOURCE_VERTEXPOS )
				float staticSwitch44_g581 = smoothstepResult60_g581;
			#else
				float staticSwitch44_g581 = smoothstepResult51_g581;
			#endif
			float ColorMask1_F64_g581 = staticSwitch44_g581;
			float3 lerpResult67_g581 = lerp( Color1B36_g581 , Color1A35_g581 , ColorMask1_F64_g581);
			float3 Color175_g581 = lerpResult67_g581;
			float3 Color2B74_g581 = _Color2B;
			float3 Color2A73_g581 = _Color2A;
			float3 lerpResult76_g581 = lerp( Color2B74_g581 , Color2A73_g581 , ColorMask1_F64_g581);
			float3 Color280_g581 = lerpResult76_g581;
			float ColorMask2SharpMin30_g581 = _ColorMask2SharpMin;
			float ColorMask2SharpMax29_g581 = _ColorMask2SharpMax;
			float smoothstepResult87_g581 = smoothstep( ColorMask2SharpMin30_g581 , ColorMask2SharpMax29_g581 , i.vertexToFrag25_g581);
			float ColorMask2_F26_g581 = smoothstepResult87_g581;
			float3 lerpResult11_g581 = lerp( Color175_g581 , Color280_g581 , ColorMask2_F26_g581);
			#if defined( _COLORS_ONE )
				float3 staticSwitch81_g581 = Color1A35_g581;
			#elif defined( _COLORS_TWO )
				float3 staticSwitch81_g581 = Color175_g581;
			#elif defined( _COLORS_FOUR )
				float3 staticSwitch81_g581 = lerpResult11_g581;
			#else
				float3 staticSwitch81_g581 = Color1A35_g581;
			#endif
			float2 uv_Albedo34_g581 = i.uv_texcoord;
			float4 tex2DNode34_g581 = tex2D( _Albedo, uv_Albedo34_g581 );
			float4 TextureColor37_g581 = tex2DNode34_g581;
			float4 Albedo90_g581 = ( float4( staticSwitch81_g581 , 0.0 ) * TextureColor37_g581 );
			#if defined( _COLORS_ONE )
				float staticSwitch100_g581 = 0.0;
			#elif defined( _COLORS_TWO )
				float staticSwitch100_g581 = ColorMask1_F64_g581;
			#elif defined( _COLORS_FOUR )
				float staticSwitch100_g581 = ColorMask1_F64_g581;
			#else
				float staticSwitch100_g581 = 0.0;
			#endif
			float ColorMask190_g581 = staticSwitch100_g581;
			#if defined( _COLORS_ONE )
				float staticSwitch95_g581 = 0.0;
			#elif defined( _COLORS_TWO )
				float staticSwitch95_g581 = 0.0;
			#elif defined( _COLORS_FOUR )
				float staticSwitch95_g581 = ColorMask2_F26_g581;
			#else
				float staticSwitch95_g581 = 0.0;
			#endif
			float ColorMask290_g581 = staticSwitch95_g581;
			float4 localDebug90_g581 = Debug90_g581( Debug_Target90_g581 , Albedo90_g581 , ColorMask190_g581 , ColorMask290_g581 );
			o.Albedo = localDebug90_g581.xyz;
			o.Metallic = _Metallic;
			float2 uv_Smoothness = i.uv_texcoord * _Smoothness_ST.xy + _Smoothness_ST.zw;
			o.Smoothness = ( tex2D( _Smoothness, uv_Smoothness ).r * _SmoothnessScale );
			o.Alpha = 1;
			clip( tex2DNode34_g581.a - _AlphaCutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_WaterSurfacePlant"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1970;2464,1952;Inherit;False;Nicrom - WSP - Motion;23;;571;99f4962385c468c4ca519d7a5042f6a0;0;0;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1330;-19002.03,10716.32;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1948;2720,1952;Inherit;False;Nicrom - Scale;51;;577;8d53ba1ace8e1014986c3779ab835fd1;0;1;13;FLOAT3;0,0,0;False;2;FLOAT3;0;FLOAT;70
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1932;3072,2128;Inherit;False;Property;_AlphaCutoff;Alpha Cutoff;0;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1963;2752,1664;Inherit;False;Nicrom - WSP - Main;1;;581;f68b2bfe998374742a3f787a29e76c16;0;0;5;FLOAT4;0;FLOAT3;105;FLOAT;42;FLOAT;43;FLOAT;39
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;0;3072,1664;Float;False;True;-1;3;Nicrom.CMI_WaterSurfacePlant;0;0;Standard;Nicrom/ASE/Vegetation//WSP;False;False;False;False;False;False;True;False;False;False;False;False;True;False;False;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;True;0;True;Opaque;;AlphaTest;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;True;_AlphaCutoff;1;Pragma;multi_compile_instancing;False;;Custom;False;0;0;;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;1948;13;1970;0
WireConnection;0;0;1963;0
WireConnection;0;1;1963;105
WireConnection;0;3;1963;42
WireConnection;0;4;1963;43
WireConnection;0;10;1963;39
WireConnection;0;11;1948;0
ASEEND*/
//CHKSM=4AFEBE76E9E29E523B032DB5BDE970BC62F95C4D