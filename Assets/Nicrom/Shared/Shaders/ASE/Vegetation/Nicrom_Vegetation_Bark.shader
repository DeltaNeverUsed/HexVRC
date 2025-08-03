// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Vegetation/Bark"
{
	Properties
	{
		_Color( "Color", Color ) = ( 0.6117647, 0.4509804, 0.282353, 1 )
		[NoScaleOffset][SingleLineTexture][Space] _Albedo( "Albedo", 2D ) = "white" {}
		[NoScaleOffset][Normal][SingleLineTexture] _Normal( "Normal", 2D ) = "bump" {}
		[SingleLineTexture] _MRAO( "MRAO", 2D ) = "white" {}
		[Space] _Metallic( "Metallic", Range( 0, 1 ) ) = 0
		_Smoothness( "Smoothness", Range( 0, 1 ) ) = 0.2909241
		_NormalScale( "Normal Scale", Range( 0, 3 ) ) = 1
		_AmbientOcclusion( "Ambient Occlusion", Range( 0, 1 ) ) = 0.4
		_TextureTiling( "Texture Tiling", Vector ) = ( 1, 1, 0, 0 )
		[Toggle( _TRUNKMOSS_ON )] _TrunkMoss( "Trunk Moss", Float ) = 0
		[Enum(None,0,Moss Mask,1,Moss Noise 1,2)] _MossDebug( "Moss Debug", Float ) = 0
		_MossColor( "Moss Color", Color ) = ( 0.3190155, 0.4716981, 0.07819252, 1 )
		[SingleLineTexture] _MossAlbedo( "Moss Albedo", 2D ) = "white" {}
		[NoScaleOffset][Normal][SingleLineTexture] _MossNormal( "Moss Normal", 2D ) = "bump" {}
		_MossNormalScale( "Moss Normal Scale", Range( 0, 5 ) ) = 1
		_MossTiling( "Moss Tiling", Vector ) = ( 1, 1, 0, 0 )
		_MossOpacity( "Moss Opacity", Range( 0, 1 ) ) = 1
		_MossHeight( "Moss Height", Range( 0, 5 ) ) = 1
		_MossHeightOffset( "Moss Height Offset", Range( 0, 3 ) ) = 0.5
		_MossFadeLength( "Moss Fade Length", Range( 0, 5 ) ) = 0.5
		_MossFadeLengthOffset( "Moss Fade Length Offset", Range( 0, 3 ) ) = 0.5
		_MossCoverageMin( "Moss Coverage Min", Range( 0, 1 ) ) = 0
		_MossCoverageMax( "Moss Coverage Max", Range( 0, 1 ) ) = 1
		[NoScaleOffset][SingleLineTexture] _MossNoise( "Moss Noise", 2D ) = "white" {}
		_MossNoise1Tiling( "Moss Noise 1 Tiling", Range( 0, 3 ) ) = 1
		_MossNoise1SharpMin( "Moss Noise 1 Sharp Min", Range( 0, 1 ) ) = 0
		_MossNoise1SharpMax( "Moss Noise 1 Sharp Max", Range( 0, 1 ) ) = 1
		_MossNoise2Tiling( "Moss Noise 2 Tiling", Vector ) = ( 1, 1, 0, 0 )
		[Toggle( _MAINMOTION_ON )] _MainMotion( "Main Motion", Float ) = 1
		[Toggle] _GVTime( "GV Time", Float ) = 1
		[Toggle] _GVBendingScale( "GV Bending Scale", Float ) = 1
		[Toggle] _GVAmplitudeScale( "GV Amplitude Scale", Float ) = 1
		[Toggle] _GVDirectionAngle( "GV Direction Angle", Float ) = 1
		_MMSpeed( "MM Speed", Range( 0, 3 ) ) = 0.4
		_MMAmplitude( "MM Amplitude", Range( 0, 90 ) ) = 1.5
		_MMAmplitudeOffset( "MM Amplitude Offset", Range( 0, 90 ) ) = 2
		_MMBending( "MM Bending", Range( 0, 90 ) ) = 30
		_MMBendingOffset( "MM Bending Offset", Range( 0, 90 ) ) = 10
		[Enum(Vertex Colors,0,Noise Texture,1)] _MMPhaseShiftSource( "MM Phase Shift Source", Float ) = 1
		_MMPhaseShiftScale( "MM Phase Shift Scale", Range( 0, 1 ) ) = 1
		_MMDirectionShift( "MM Direction Shift", Range( 0, 90 ) ) = 20
		_MMDirectionShiftOffset( "MM Direction Shift Offset", Range( 0, 90 ) ) = 10
		_MMDirectionShiftSpeed( "MM Direction Shift Speed", Range( 0, 5 ) ) = 1
		_MMDirectionShiftNoiseScale( "MM Direction Shift Noise Scale", Range( 0, 1 ) ) = 1
		_MMDirectionAngle( "MM Direction Angle", Range( 0, 360 ) ) = 0
		_MMSineWaveLength( "MM Sine Wave Length", Range( 0.001, 20 ) ) = 6
		[Enum(Material Property,0,Vertex Colors,1)] _MMObjectHeightSource( "MM Object Height Source", Range( 0, 1 ) ) = 1
		_MMObjectHeight( "MM Object Height", Range( 0, 100 ) ) = 1
		[Toggle( _DETAILMOTION1_ON )] _DetailMotion1( "Detail Motion 1", Float ) = 1
		_DM1Amplitude( "DM1 Amplitude", Range( 0, 30 ) ) = 1
		_DM1Speed( "DM1 Speed", Range( 0, 5 ) ) = 1
		_DM1FoliageLength( "DM1 Foliage Length", Range( 0.001, 10 ) ) = 1
		[Toggle( _DETAILMOTION2_ON )] _DetailMotion2( "Detail Motion 2", Float ) = 1
		_DM2Amplitude( "DM2 Amplitude", Range( 0, 45 ) ) = 2
		_DM2Speed( "DM2 Speed", Range( 0, 5 ) ) = 1
		_DM2ObjectRadius( "DM2 Object Radius", Range( 0.001, 10 ) ) = 1
		[NoScaleOffset][SingleLineTexture] _MotionNoise( "Motion Noise", 2D ) = "white" {}
		_MotionNoiseTiling( "Motion Noise Tiling", Range( 0, 4 ) ) = 0.1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "UnityStandardUtils.cginc"
		#pragma target 3.5
		#pragma shader_feature_local_vertex _MAINMOTION_ON
		#pragma shader_feature_local_vertex _DETAILMOTION1_ON
		#pragma shader_feature_local_vertex _DETAILMOTION2_ON
		#pragma shader_feature_local _TRUNKMOSS_ON
		#define ASE_VERSION 19901
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows dithercrossfade vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float4 ase_positionOS4f;
		};

		uniform float Nicrom_DM_AmpScale_Vegetation;
		uniform half _GVBendingScale;
		uniform float _DM1Amplitude;
		uniform float Nicrom_DM_Time_Vegetation;
		uniform float _GVTime;
		uniform half Nicrom_ApplicationIsPlaying;
		uniform float _DM1Speed;
		uniform float Nicrom_DM_SpeedScale_Vegetation;
		uniform float _DM1FoliageLength;
		uniform float _DM2Amplitude;
		uniform float _DM2Speed;
		uniform float _DM2ObjectRadius;
		uniform half _MMDirectionAngle;
		uniform half Nicrom_WindDirAngle;
		uniform half _GVDirectionAngle;
		uniform half _MMDirectionShift;
		uniform half _MMDirectionShiftOffset;
		uniform sampler2D _MotionNoise;
		uniform float _MotionNoiseTiling;
		uniform float Nicrom_MM_Time_Vegetation;
		uniform float Nicrom_MM_SpeedScale_Vegetation;
		uniform half _MMDirectionShiftSpeed;
		uniform half _MMDirectionShiftNoiseScale;
		uniform half _MMBendingOffset;
		uniform half _MMBending;
		uniform float Nicrom_MM_BendScale_Vegetation;
		uniform half _GVAmplitudeScale;
		uniform half _MMAmplitudeOffset;
		uniform half _MMAmplitude;
		uniform float Nicrom_MM_AmpScale_Vegetation;
		uniform half _MMSpeed;
		uniform half _MMSineWaveLength;
		uniform half _MMPhaseShiftSource;
		uniform half _MMPhaseShiftScale;
		uniform half _MMObjectHeight;
		uniform half _MMObjectHeightSource;
		uniform sampler2D _Normal;
		uniform float2 _TextureTiling;
		uniform float _NormalScale;
		uniform sampler2D _MossNormal;
		uniform float2 _MossTiling;
		uniform float _MossNormalScale;
		uniform float _MossCoverageMin;
		uniform float _MossCoverageMax;
		uniform float _MossNoise1SharpMin;
		uniform float _MossNoise1SharpMax;
		uniform sampler2D _MossNoise;
		uniform float _MossNoise1Tiling;
		uniform float _MossHeightOffset;
		uniform float _MossHeight;
		uniform float _MossFadeLength;
		uniform float _MossFadeLengthOffset;
		uniform float2 _MossNoise2Tiling;
		uniform float _MossOpacity;
		uniform float _MossDebug;
		uniform float4 _Color;
		uniform sampler2D _Albedo;
		uniform float4 _MossColor;
		uniform sampler2D _MossAlbedo;
		uniform sampler2D _MRAO;
		uniform float _Metallic;
		uniform float _Smoothness;
		uniform float _AmbientOcclusion;


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


		float4 Debug138_g427( float Debug_Target, float4 Albedo, float MossMask, float MossNoise1 )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return MossMask;
			else
			    return MossNoise1;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float temp_output_23_0_g417 = radians( ( 90.0 + ( v.texcoord2.xy.x * 360.0 ) ) );
			float3 appendResult25_g417 = (float3(cos( temp_output_23_0_g417 ) , 0.0 , sin( temp_output_23_0_g417 )));
			float3 DB_RotationAxis87_g415 = appendResult25_g417;
			float GV_AmplitudeScale175_g415 = _GVBendingScale;
			float lerpResult186_g415 = lerp( 1.0 , Nicrom_DM_AmpScale_Vegetation , GV_AmplitudeScale175_g415);
			float DM_AmplitudeScale168_g415 = lerpResult186_g415;
			float DM1_Amplitude28_g415 = _DM1Amplitude;
			float3 objToWorld80_g425 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float GV_Time174_g415 = _GVTime;
			float lerpResult187_g415 = lerp( _Time.y , Nicrom_DM_Time_Vegetation , GV_Time174_g415);
			float ApplicationIsPlaying241_g415 = Nicrom_ApplicationIsPlaying;
			float lerpResult256_g415 = lerp( _Time.y , lerpResult187_g415 , ApplicationIsPlaying241_g415);
			float DM_Time169_g415 = lerpResult256_g415;
			float Time90_g425 = DM_Time169_g415;
			float DM1_Speed29_g415 = _DM1Speed;
			float Speed45_g425 = DM1_Speed29_g415;
			float temp_output_244_0_g415 = Nicrom_DM_SpeedScale_Vegetation;
			float lerpResult261_g415 = lerp( temp_output_244_0_g415 , 1.0 , GV_Time174_g415);
			float lerpResult262_g415 = lerp( temp_output_244_0_g415 , lerpResult261_g415 , ApplicationIsPlaying241_g415);
			float DM_SpeedScale265_g415 = lerpResult262_g415;
			float SpeedScale95_g425 = DM_SpeedScale265_g415;
			float DM_PhaseShift91_g415 = v.color.a;
			float PhaseShift48_g425 = DM_PhaseShift91_g415;
			float3 ase_positionOS = v.vertex.xyz;
			float3 appendResult24_g417 = (float3(0.0 , v.texcoord2.xy.y , 0.0));
			float3 DM_PivotPosOnYAxis88_g415 = appendResult24_g417;
			float3 PivotPosOnYAxis56_g425 = DM_PivotPosOnYAxis88_g415;
			float DM1_FoliageLength32_g415 = _DM1FoliageLength;
			float3 rotatedValue29_g425 = RotateAroundAxis( PivotPosOnYAxis56_g425, ase_positionOS, DB_RotationAxis87_g415, radians( ( ( ( DM_AmplitudeScale168_g415 * DM1_Amplitude28_g415 ) * sin( ( ( ( objToWorld80_g425.x + objToWorld80_g425.z ) + ( ( Time90_g425 * ( Speed45_g425 * SpeedScale95_g425 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift48_g425 ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , PivotPosOnYAxis56_g425 ) / DM1_FoliageLength32_g415 ) ) ) );
			float DM1_MotionMask89_g415 = step( 1.5 , v.texcoord.xy.y );
			float3 DM1_VertexOffset231_g415 = ( ( rotatedValue29_g425 - ase_positionOS ) * DM1_MotionMask89_g415 );
			#ifdef _DETAILMOTION1_ON
				float3 staticSwitch104_g415 = DM1_VertexOffset231_g415;
			#else
				float3 staticSwitch104_g415 = float3( 0, 0, 0 );
			#endif
			float DM2_Amplitude30_g415 = _DM2Amplitude;
			float Amplitude58_g426 = DM2_Amplitude30_g415;
			float3 LocalPivot159_g415 = float3( 0,0,0 );
			float3 PivotPoint49_g426 = LocalPivot159_g415;
			float3 objToWorld53_g426 = mul( unity_ObjectToWorld, float4( PivotPoint49_g426, 1 ) ).xyz;
			float Time87_g426 = DM_Time169_g415;
			float SpeedScale93_g426 = DM_SpeedScale265_g415;
			float DM2_Speed31_g415 = _DM2Speed;
			float Speed41_g426 = DM2_Speed31_g415;
			float PhaseShift54_g426 = DM_PhaseShift91_g415;
			float3 break52_g426 = PivotPoint49_g426;
			float3 appendResult20_g426 = (float3(break52_g426.x , ase_positionOS.y , break52_g426.z));
			float DM2_ObjectRadius33_g415 = _DM2ObjectRadius;
			float ObjectRadius60_g426 = DM2_ObjectRadius33_g415;
			float3 rotatedValue33_g426 = RotateAroundAxis( PivotPoint49_g426, ase_positionOS, float3( 0, 1, 0 ), radians( ( ( ( DM_AmplitudeScale168_g415 * Amplitude58_g426 ) * sin( ( ( ( objToWorld53_g426.x + objToWorld53_g426.z ) + ( ( Time87_g426 * ( SpeedScale93_g426 * Speed41_g426 ) ) + ( ( 2.0 * UNITY_PI ) * ( 1.0 - PhaseShift54_g426 ) ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , appendResult20_g426 ) / ObjectRadius60_g426 ) ) ) );
			float DM2_MotionMask90_g415 = step( 1.5 , v.texcoord.xy.x );
			float BendingMask62_g426 = DM2_MotionMask90_g415;
			float3 DM2_VertexOffset232_g415 = ( ( rotatedValue33_g426 - ase_positionOS ) * BendingMask62_g426 );
			#ifdef _DETAILMOTION2_ON
				float3 staticSwitch103_g415 = DM2_VertexOffset232_g415;
			#else
				float3 staticSwitch103_g415 = float3( 0, 0, 0 );
			#endif
			float3 DM_VertexOffset128_g415 = ( staticSwitch104_g415 + staticSwitch103_g415 );
			float lerpResult56_g423 = lerp( _MMDirectionAngle , Nicrom_WindDirAngle , _GVDirectionAngle);
			float MM_DirAngle51_g415 = lerpResult56_g423;
			float MM_DirShift59_g415 = _MMDirectionShift;
			float MM_DirShiftOffset60_g415 = _MMDirectionShiftOffset;
			float3 objToWorld11_g420 = mul( unity_ObjectToWorld, float4( LocalPivot159_g415, 1 ) ).xyz;
			float2 appendResult10_g420 = (float2(objToWorld11_g420.x , objToWorld11_g420.z));
			float MotionNoiseTiling20_g415 = _MotionNoiseTiling;
			float4 temp_output_73_0_g415 = tex2Dlod( _MotionNoise, float4( ( appendResult10_g420 * MotionNoiseTiling20_g415 ), 0, 0.0) );
			float4 StaticWorldNoise78_g415 = temp_output_73_0_g415;
			float4 StaticWorldNoise55_g419 = StaticWorldNoise78_g415;
			float3 objToWorld50_g419 = mul( unity_ObjectToWorld, float4( LocalPivot159_g415, 1 ) ).xyz;
			float lerpResult182_g415 = lerp( _Time.y , Nicrom_MM_Time_Vegetation , GV_Time174_g415);
			float lerpResult246_g415 = lerp( _Time.y , lerpResult182_g415 , ApplicationIsPlaying241_g415);
			float MM_Time13_g415 = lerpResult246_g415;
			float Time76_g419 = MM_Time13_g415;
			float temp_output_243_0_g415 = Nicrom_MM_SpeedScale_Vegetation;
			float lerpResult245_g415 = lerp( temp_output_243_0_g415 , 1.0 , GV_Time174_g415);
			float lerpResult249_g415 = lerp( temp_output_243_0_g415 , lerpResult245_g415 , ApplicationIsPlaying241_g415);
			float MM_SpeedScale253_g415 = lerpResult249_g415;
			float SpeedScale_RA80_g419 = MM_SpeedScale253_g415;
			float MM_DirShiftSpeed56_g415 = _MMDirectionShiftSpeed;
			float MM_DirShiftNoiseScale57_g415 = _MMDirectionShiftNoiseScale;
			float temp_output_11_0_g419 = radians( ( ( MM_DirAngle51_g415 + ( ( MM_DirShift59_g415 + ( MM_DirShiftOffset60_g415 * (StaticWorldNoise55_g419).x ) ) * sin( ( ( objToWorld50_g419.x + objToWorld50_g419.z ) + ( ( Time76_g419 * ( SpeedScale_RA80_g419 * MM_DirShiftSpeed56_g415 ) ) + ( ( 2.0 * UNITY_PI ) * ( (StaticWorldNoise55_g419).z * MM_DirShiftNoiseScale57_g415 ) ) ) ) ) ) ) * -1.0 ) );
			float3 appendResult14_g419 = (float3(cos( temp_output_11_0_g419 ) , 0.0 , sin( temp_output_11_0_g419 )));
			float3 worldToObj35_g419 = mul( unity_WorldToObject, float4( appendResult14_g419, 1 ) ).xyz;
			float3 worldToObj36_g419 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult34_g419 = normalize( (( worldToObj35_g419 - worldToObj36_g419 )).xyz );
			float3 MB_RotationAxis129_g415 = normalizeResult34_g419;
			float3 RotationAxis56_g418 = MB_RotationAxis129_g415;
			float4 StaticWorldNoise31_g424 = StaticWorldNoise78_g415;
			float MM_BendingOfset37_g415 = _MMBendingOffset;
			float MM_Bending35_g415 = _MMBending;
			float GV_BendingScale176_g415 = _GVAmplitudeScale;
			float lerpResult188_g415 = lerp( 1.0 , Nicrom_MM_BendScale_Vegetation , GV_BendingScale176_g415);
			float MM_BendingScale17_g415 = lerpResult188_g415;
			float MM_AmplitudeOffset52_g415 = _MMAmplitudeOffset;
			float MM_Amplitude66_g415 = _MMAmplitude;
			float lerpResult189_g415 = lerp( 1.0 , Nicrom_MM_AmpScale_Vegetation , GV_AmplitudeScale175_g415);
			float MM_AmplitudeScale15_g415 = lerpResult189_g415;
			float3 objToWorld170_g424 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float Time167_g424 = MM_Time13_g415;
			float MM_Speed53_g415 = _MMSpeed;
			float Speed125_g424 = MM_Speed53_g415;
			float SpeedScale_RotAng201_g424 = MM_SpeedScale253_g415;
			float MM_SineWaveLength58_g415 = _MMSineWaveLength;
			float WaveLength63_g424 = MM_SineWaveLength58_g415;
			float MM_PhaseShiftSource207_g415 = _MMPhaseShiftSource;
			float lerpResult154_g415 = lerp( v.color.a , (StaticWorldNoise78_g415).g , MM_PhaseShiftSource207_g415);
			float MM_PhaseShiftScale39_g415 = _MMPhaseShiftScale;
			float MB_PhaseShift79_g415 = ( lerpResult154_g415 * MM_PhaseShiftScale39_g415 );
			float PhaseShift127_g424 = MB_PhaseShift79_g415;
			float temp_output_20_0_g424 = sin( ( ( ( objToWorld170_g424.x + objToWorld170_g424.z ) + ( ( Time167_g424 * ( ( Speed125_g424 * SpeedScale_RotAng201_g424 ) * WaveLength63_g424 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift127_g424 ) ) ) * ( ( 2.0 * UNITY_PI ) / WaveLength63_g424 ) ) );
			float MM_MaxHeight55_g415 = _MMObjectHeight;
			float3 gammaToLinear56_g424 = GammaToLinearSpace( v.color.rgb );
			float MM_ObjectHeightSource54_g415 = _MMObjectHeightSource;
			float lerpResult57_g424 = lerp( ( ase_positionOS.y / MM_MaxHeight55_g415 ) , (gammaToLinear56_g424).x , MM_ObjectHeightSource54_g415);
			float BendingMask189_g424 = lerpResult57_g424;
			float MB_RotationAngle130_g415 = radians( ( ( ( ( ( (StaticWorldNoise31_g424).y * MM_BendingOfset37_g415 ) + MM_Bending35_g415 ) * MM_BendingScale17_g415 ) + ( ( ( ( (StaticWorldNoise31_g424).x * MM_AmplitudeOffset52_g415 ) + MM_Amplitude66_g415 ) * MM_AmplitudeScale15_g415 ) * temp_output_20_0_g424 ) ) * BendingMask189_g424 ) );
			float RotationAngle54_g418 = MB_RotationAngle130_g415;
			float3 LocalPivotPos60_g418 = LocalPivot159_g415;
			float3 break62_g418 = LocalPivotPos60_g418;
			float VertexPos_Y67_g418 = ase_positionOS.y;
			float3 appendResult45_g418 = (float3(break62_g418.x , VertexPos_Y67_g418 , break62_g418.z));
			float3 VertexPos66_g418 = ase_positionOS;
			float3 rotatedValue30_g418 = RotateAroundAxis( appendResult45_g418, VertexPos66_g418, RotationAxis56_g418, RotationAngle54_g418 );
			float3 DetailMotionVO73_g418 = DM_VertexOffset128_g415;
			float3 rotatedValue34_g418 = RotateAroundAxis( LocalPivotPos60_g418, ( rotatedValue30_g418 + DetailMotionVO73_g418 ), RotationAxis56_g418, RotationAngle54_g418 );
			#ifdef _MAINMOTION_ON
				float3 staticSwitch205_g415 = ( ( rotatedValue34_g418 - VertexPos66_g418 ) * step( 0.01 , VertexPos_Y67_g418 ) );
			#else
				float3 staticSwitch205_g415 = DM_VertexOffset128_g415;
			#endif
			v.vertex.xyz += staticSwitch205_g415;
			v.vertex.w = 1;
			float4 ase_positionOS4f = v.vertex;
			o.ase_positionOS4f = ase_positionOS4f;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 TextureTiling19_g411 = _TextureTiling;
			float2 uv_TexCoord82_g411 = i.uv_texcoord * TextureTiling19_g411;
			float NormalScale73_g411 = _NormalScale;
			float3 Main_Normal151_g427 = UnpackScaleNormal( tex2D( _Normal, uv_TexCoord82_g411 ), NormalScale73_g411 );
			float2 MossTiling111_g427 = _MossTiling;
			float3 objToWorld93_g427 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float2 appendResult94_g427 = (float2(objToWorld93_g427.x , objToWorld93_g427.z));
			float2 WorldSpaceUVs_Mos117_g427 = appendResult94_g427;
			float2 uv_TexCoord88_g427 = i.uv_texcoord * MossTiling111_g427 + WorldSpaceUVs_Mos117_g427;
			float MossNormalScale112_g427 = _MossNormalScale;
			float3 MossNormals144_g427 = UnpackScaleNormal( tex2D( _MossNormal, uv_TexCoord88_g427 ), MossNormalScale112_g427 );
			float MossCoverageMin60_g427 = _MossCoverageMin;
			float MossCoverageMax61_g427 = _MossCoverageMax;
			float MossNoise1Tiling110_g427 = _MossNoise1Tiling;
			float smoothstepResult181_g427 = smoothstep( _MossNoise1SharpMin , _MossNoise1SharpMax , (tex2D( _MossNoise, ( WorldSpaceUVs_Mos117_g427 * MossNoise1Tiling110_g427 ) )).r);
			float WorldSpaceNoise47_g427 = smoothstepResult181_g427;
			float MossHeightOffset49_g427 = _MossHeightOffset;
			float MossHeight51_g427 = _MossHeight;
			float MossHeight_F43_g427 = ( ( WorldSpaceNoise47_g427 * MossHeightOffset49_g427 ) + MossHeight51_g427 );
			float MossFadeLength53_g427 = _MossFadeLength;
			float MossFadeLengthOffset55_g427 = _MossFadeLengthOffset;
			float MossFadeLength_F44_g427 = ( MossFadeLength53_g427 - ( WorldSpaceNoise47_g427 * MossFadeLengthOffset55_g427 ) );
			float clampResult19_g427 = clamp( ( MossHeight_F43_g427 - MossFadeLength_F44_g427 ) , 0.0 , MossHeight_F43_g427 );
			float3 ase_positionOS = i.ase_positionOS4f.xyz;
			float smoothstepResult21_g427 = smoothstep( clampResult19_g427 , MossHeight_F43_g427 , ase_positionOS.y);
			float MossArea45_g427 = ( 1.0 - smoothstepResult21_g427 );
			float2 uv_TexCoord119_g427 = i.uv_texcoord * _MossNoise2Tiling + WorldSpaceUVs_Mos117_g427;
			float MossNoise57_g427 = tex2D( _MossNoise, uv_TexCoord119_g427 ).r;
			float lerpResult29_g427 = lerp( 0.0 , saturate( ( MossArea45_g427 +  (-0.5 + ( MossNoise57_g427 - 0.0 ) * ( 0.5 - -0.5 ) / ( 1.0 - 0.0 ) ) ) ) , MossArea45_g427);
			float smoothstepResult32_g427 = smoothstep( MossCoverageMin60_g427 , MossCoverageMax61_g427 , lerpResult29_g427);
			float MossOpacity65_g427 = _MossOpacity;
			float MossMask128_g427 = ( smoothstepResult32_g427 * MossOpacity65_g427 );
			float3 lerpResult142_g427 = lerp( Main_Normal151_g427 , BlendNormals( Main_Normal151_g427 , MossNormals144_g427 ) , MossMask128_g427);
			#ifdef _TRUNKMOSS_ON
				float3 staticSwitch148_g427 = lerpResult142_g427;
			#else
				float3 staticSwitch148_g427 = Main_Normal151_g427;
			#endif
			o.Normal = staticSwitch148_g427;
			float Debug_Target138_g427 = _MossDebug;
			float4 BaseColor44_g411 = _Color;
			float2 uv_TexCoord49_g411 = i.uv_texcoord * TextureTiling19_g411;
			float4 Main_Albedo155_g427 = ( BaseColor44_g411 * tex2D( _Albedo, uv_TexCoord49_g411 ) );
			float4 MossColor98_g427 = _MossColor;
			float2 uv_TexCoord83_g427 = i.uv_texcoord * MossTiling111_g427 + WorldSpaceUVs_Mos117_g427;
			float4 MossColor_F86_g427 = ( MossColor98_g427 * tex2D( _MossAlbedo, uv_TexCoord83_g427 ) );
			float4 lerpResult130_g427 = lerp( Main_Albedo155_g427 , MossColor_F86_g427 , MossMask128_g427);
			#ifdef _TRUNKMOSS_ON
				float4 staticSwitch147_g427 = lerpResult130_g427;
			#else
				float4 staticSwitch147_g427 = Main_Albedo155_g427;
			#endif
			float4 Albedo138_g427 = staticSwitch147_g427;
			float MossMask138_g427 = MossMask128_g427;
			float MossNoise1138_g427 = WorldSpaceNoise47_g427;
			float4 localDebug138_g427 = Debug138_g427( Debug_Target138_g427 , Albedo138_g427 , MossMask138_g427 , MossNoise1138_g427 );
			o.Albedo = localDebug138_g427.xyz;
			float2 uv_TexCoord68_g411 = i.uv_texcoord * TextureTiling19_g411;
			float4 tex2DNode77_g411 = tex2D( _MRAO, uv_TexCoord68_g411 );
			float Tex_Metalic92_g411 = tex2DNode77_g411.r;
			float Metallic158_g411 = _Metallic;
			o.Metallic = ( Tex_Metalic92_g411 * Metallic158_g411 );
			float Tex_Roughness86_g411 = tex2DNode77_g411.g;
			float Smoothness160_g411 = _Smoothness;
			o.Smoothness = ( ( 1.0 - Tex_Roughness86_g411 ) * Smoothness160_g411 );
			float Tex_AO93_g411 = tex2DNode77_g411.b;
			float AmbientOcclusion162_g411 = _AmbientOcclusion;
			float lerpResult108_g411 = lerp( 1.0 , Tex_AO93_g411 , AmbientOcclusion162_g411);
			o.Occlusion = lerpResult108_g411;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Vegetation_Bark"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2069;2080,2560;Inherit;False;Nicrom - Vegetation - Bark - Main;0;;411;e64859c632d2fee45ab9360dd464f78b;0;0;5;COLOR;129;FLOAT3;128;FLOAT;0;FLOAT;126;FLOAT;127
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2005;1920,2848;Inherit;False;Nicrom - Vegetation - Motion - GP;-1;;412;2010567f31880844287a8b7519991b43;0;0;7;FLOAT;10;FLOAT;12;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;14;FLOAT;9
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1330;-19002.03,10716.32;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1328;-19355.95,10790.4;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2070;2272,2848;Inherit;False;Nicrom - Motion;31;;415;ba60642b1d9af614f93c28cb2553ff1c;0;8;179;FLOAT;0;False;243;FLOAT;1;False;178;FLOAT;0;False;180;FLOAT;0;False;184;FLOAT;0;False;244;FLOAT;1;False;185;FLOAT;0;False;238;FLOAT3;0,0,0;False;2;FLOAT3;0;COLOR;215
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2071;2432,2560;Inherit;False;Nicrom - Trunk Moss;10;;427;3da9f5e84fa2f424e945715a3ce0d646;0;2;126;COLOR;0,0,0,0;False;127;FLOAT3;0,0,0;False;2;FLOAT4;139;FLOAT3;146
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;0;2688,2560;Float;False;True;-1;3;Nicrom.CMI_Vegetation_Bark;0;0;Standard;Nicrom/ASE/Vegetation/Bark;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;1;Pragma;multi_compile_instancing;False;;Custom;False;0;0;;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2070;179;2005;10
WireConnection;2070;243;2005;12
WireConnection;2070;178;2005;6
WireConnection;2070;180;2005;7
WireConnection;2070;184;2005;8
WireConnection;2070;244;2005;14
WireConnection;2070;185;2005;9
WireConnection;2071;126;2069;129
WireConnection;2071;127;2069;128
WireConnection;0;0;2071;139
WireConnection;0;1;2071;146
WireConnection;0;3;2069;0
WireConnection;0;4;2069;126
WireConnection;0;5;2069;127
WireConnection;0;11;2070;0
ASEEND*/
//CHKSM=DF466F6AD9188477CC81DE52B179747320EF79BA