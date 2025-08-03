// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Vegetation/Leaves"
{
	Properties
	{
		_AlphaCutoff( "Alpha Cutoff", Range( 0, 1 ) ) = 0.5
		[Enum(None,0,UV1,1,UV2,2)] _LocalPivotSource( "Local Pivot Source", Float ) = 0
		[KeywordEnum( Two,Four )] _Colors( "Colors", Float ) = 0
		_Color1A( "Color 1A", Color ) = ( 0.4666667, 0.6313726, 0.2470588 )
		_Color1B( "Color 1B", Color ) = ( 0.2588235, 0.3882353, 0.09411765 )
		_Color2A( "Color 2A", Color ) = ( 0.6196079, 0.7607843, 0.1333333 )
		_Color2B( "Color 2B", Color ) = ( 0.4862745, 0.5960785, 0.1058824 )
		[Space][KeywordEnum( Y,XZ )] _ColorBlendAxis( "Color Blend Axis", Float ) = 0
		[Enum(None,0,Color Mask 1,1,Color Mask 2,2,Color Mask Noise,3)] _Debug( "Debug", Float ) = 0
		[NoScaleOffset][Normal][SingleLineTexture] _Normal( "Normal", 2D ) = "bump" {}
		[NoScaleOffset][SingleLineTexture][Space] _Albedo( "Albedo", 2D ) = "white" {}
		_Metallic( "Metallic", Range( 0, 1 ) ) = 0
		_Smoothness( "Smoothness", Range( 0, 1 ) ) = 0
		[NoScaleOffset][SingleLineTexture] _ColorMask1( "Color Mask 1", 2D ) = "white" {}
		_NormalScale( "Normal Scale", Range( 0, 3 ) ) = 1
		_ColorMask1Start( "Color Mask 1 Start", Range( 0, 1 ) ) = 0.1
		_ColorMask1End( "Color Mask 1 End", Range( 0, 1 ) ) = 0.5
		_ColorMask1FadeStart( "Color Mask 1 Fade Start", Range( 0, 1 ) ) = 0.8
		_ColorMask1FadeEnd( "Color Mask 1 Fade End", Range( 0, 1 ) ) = 1
		[Space] _ColorMask2Start( "Color Mask 2 Start", Range( 0, 1 ) ) = 0.4
		_ColorMask2StartOffset( "Color Mask 2 Start Offset", Range( -1, 1 ) ) = 0.15
		_ColorMask2End( "Color Mask 2 End", Range( 0, 1 ) ) = 0.8
		_ColorMask2Alpha( "Color Mask 2 Alpha", Range( 0, 1 ) ) = 1
		_ColorMask2AlphaOffset( "Color Mask 2 Alpha Offset", Range( -1, 1 ) ) = -0.3
		[NoScaleOffset][SingleLineTexture][Space] _MaskNoise( "Mask Noise", 2D ) = "white" {}
		_MaskNoiseTiling( "Mask Noise Tiling", Range( 0.0001, 4 ) ) = 0.05
		_MaskNoiseSharpMin( "Mask Noise Sharp Min", Range( 0, 1 ) ) = 0
		_MaskNoiseSharpMax( "Mask Noise Sharp Max", Range( 0, 1 ) ) = 0.5
		[KeywordEnum( Texture,UVs )] _ColorMask1Source( "Color Mask 1 Source", Float ) = 0
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
		Tags{ "RenderType" = "Opaque"  "Queue" = "AlphaTest+0" }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "UnityStandardUtils.cginc"
		#pragma target 3.5
		#pragma shader_feature_local_vertex _MAINMOTION_ON
		#pragma shader_feature_local_vertex _DETAILMOTION1_ON
		#pragma shader_feature_local_vertex _DETAILMOTION2_ON
		#pragma shader_feature_local _COLORS_TWO _COLORS_FOUR
		#pragma shader_feature_local _COLORMASK1SOURCE_TEXTURE _COLORMASK1SOURCE_UVS
		#pragma shader_feature_local _COLORBLENDAXIS_Y _COLORBLENDAXIS_XZ
		#define ASE_VERSION 19901
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float vertexToFrag16_g611;
			float4 vertexColor : COLOR;
			float vertexToFrag88_g611;
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
		uniform float _LocalPivotSource;
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
		uniform float _NormalScale;
		uniform float _Debug;
		uniform sampler2D _Albedo;
		uniform float3 _Color1B;
		uniform float3 _Color1A;
		uniform sampler2D _ColorMask1;
		uniform float _ColorMask1End;
		uniform float _ColorMask1Start;
		uniform float _ColorMask1FadeStart;
		uniform float _ColorMask1FadeEnd;
		uniform float3 _Color2B;
		uniform float3 _Color2A;
		uniform float _ColorMask2Start;
		uniform float _ColorMask2StartOffset;
		uniform float _MaskNoiseSharpMin;
		uniform float _MaskNoiseSharpMax;
		uniform sampler2D _MaskNoise;
		uniform float _MaskNoiseTiling;
		uniform float _ColorMask2End;
		uniform float _ColorMask2AlphaOffset;
		uniform float _ColorMask2Alpha;
		uniform float _Metallic;
		uniform float _Smoothness;
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


		float3 LocalPivot4_g610( float Source, float3 None, float3 UV1, float3 UV2 )
		{
			if(Source ==0)
			    return None;
			else if(Source ==1)
			    return UV1;
			else
			    return UV2;
		}


		float4 Debug139_g611( float Debug_Target, float4 Albedo, float ColorMask1, float ColorMask2, float MaskNoise )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return ColorMask1;
			else if(Debug_Target ==2)
			    return ColorMask2;
			else
			    return MaskNoise;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float temp_output_23_0_g615 = radians( ( 90.0 + ( v.texcoord2.xy.x * 360.0 ) ) );
			float3 appendResult25_g615 = (float3(cos( temp_output_23_0_g615 ) , 0.0 , sin( temp_output_23_0_g615 )));
			float3 DB_RotationAxis87_g613 = appendResult25_g615;
			float GV_AmplitudeScale175_g613 = _GVBendingScale;
			float lerpResult186_g613 = lerp( 1.0 , Nicrom_DM_AmpScale_Vegetation , GV_AmplitudeScale175_g613);
			float DM_AmplitudeScale168_g613 = lerpResult186_g613;
			float DM1_Amplitude28_g613 = _DM1Amplitude;
			float3 objToWorld80_g623 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float GV_Time174_g613 = _GVTime;
			float lerpResult187_g613 = lerp( _Time.y , Nicrom_DM_Time_Vegetation , GV_Time174_g613);
			float ApplicationIsPlaying241_g613 = Nicrom_ApplicationIsPlaying;
			float lerpResult256_g613 = lerp( _Time.y , lerpResult187_g613 , ApplicationIsPlaying241_g613);
			float DM_Time169_g613 = lerpResult256_g613;
			float Time90_g623 = DM_Time169_g613;
			float DM1_Speed29_g613 = _DM1Speed;
			float Speed45_g623 = DM1_Speed29_g613;
			float temp_output_244_0_g613 = Nicrom_DM_SpeedScale_Vegetation;
			float lerpResult261_g613 = lerp( temp_output_244_0_g613 , 1.0 , GV_Time174_g613);
			float lerpResult262_g613 = lerp( temp_output_244_0_g613 , lerpResult261_g613 , ApplicationIsPlaying241_g613);
			float DM_SpeedScale265_g613 = lerpResult262_g613;
			float SpeedScale95_g623 = DM_SpeedScale265_g613;
			float DM_PhaseShift91_g613 = v.color.a;
			float PhaseShift48_g623 = DM_PhaseShift91_g613;
			float3 ase_positionOS = v.vertex.xyz;
			float3 appendResult24_g615 = (float3(0.0 , v.texcoord2.xy.y , 0.0));
			float3 DM_PivotPosOnYAxis88_g613 = appendResult24_g615;
			float3 PivotPosOnYAxis56_g623 = DM_PivotPosOnYAxis88_g613;
			float DM1_FoliageLength32_g613 = _DM1FoliageLength;
			float3 rotatedValue29_g623 = RotateAroundAxis( PivotPosOnYAxis56_g623, ase_positionOS, DB_RotationAxis87_g613, radians( ( ( ( DM_AmplitudeScale168_g613 * DM1_Amplitude28_g613 ) * sin( ( ( ( objToWorld80_g623.x + objToWorld80_g623.z ) + ( ( Time90_g623 * ( Speed45_g623 * SpeedScale95_g623 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift48_g623 ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , PivotPosOnYAxis56_g623 ) / DM1_FoliageLength32_g613 ) ) ) );
			float DM1_MotionMask89_g613 = step( 1.5 , v.texcoord.xy.y );
			float3 DM1_VertexOffset231_g613 = ( ( rotatedValue29_g623 - ase_positionOS ) * DM1_MotionMask89_g613 );
			#ifdef _DETAILMOTION1_ON
				float3 staticSwitch104_g613 = DM1_VertexOffset231_g613;
			#else
				float3 staticSwitch104_g613 = float3( 0, 0, 0 );
			#endif
			float DM2_Amplitude30_g613 = _DM2Amplitude;
			float Amplitude58_g624 = DM2_Amplitude30_g613;
			float Source4_g610 = _LocalPivotSource;
			float3 None4_g610 = float3( 0,0,0 );
			float3 appendResult7_g610 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 UV14_g610 = -appendResult7_g610;
			float3 appendResult8_g610 = (float3(v.texcoord2.xy.x , 0.0 , v.texcoord2.xy.y));
			float3 UV24_g610 = -appendResult8_g610;
			float3 localLocalPivot4_g610 = LocalPivot4_g610( Source4_g610 , None4_g610 , UV14_g610 , UV24_g610 );
			float3 LocalPivot159_g613 = localLocalPivot4_g610;
			float3 PivotPoint49_g624 = LocalPivot159_g613;
			float3 objToWorld53_g624 = mul( unity_ObjectToWorld, float4( PivotPoint49_g624, 1 ) ).xyz;
			float Time87_g624 = DM_Time169_g613;
			float SpeedScale93_g624 = DM_SpeedScale265_g613;
			float DM2_Speed31_g613 = _DM2Speed;
			float Speed41_g624 = DM2_Speed31_g613;
			float PhaseShift54_g624 = DM_PhaseShift91_g613;
			float3 break52_g624 = PivotPoint49_g624;
			float3 appendResult20_g624 = (float3(break52_g624.x , ase_positionOS.y , break52_g624.z));
			float DM2_ObjectRadius33_g613 = _DM2ObjectRadius;
			float ObjectRadius60_g624 = DM2_ObjectRadius33_g613;
			float3 rotatedValue33_g624 = RotateAroundAxis( PivotPoint49_g624, ase_positionOS, float3( 0, 1, 0 ), radians( ( ( ( DM_AmplitudeScale168_g613 * Amplitude58_g624 ) * sin( ( ( ( objToWorld53_g624.x + objToWorld53_g624.z ) + ( ( Time87_g624 * ( SpeedScale93_g624 * Speed41_g624 ) ) + ( ( 2.0 * UNITY_PI ) * ( 1.0 - PhaseShift54_g624 ) ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , appendResult20_g624 ) / ObjectRadius60_g624 ) ) ) );
			float DM2_MotionMask90_g613 = step( 1.5 , v.texcoord.xy.x );
			float BendingMask62_g624 = DM2_MotionMask90_g613;
			float3 DM2_VertexOffset232_g613 = ( ( rotatedValue33_g624 - ase_positionOS ) * BendingMask62_g624 );
			#ifdef _DETAILMOTION2_ON
				float3 staticSwitch103_g613 = DM2_VertexOffset232_g613;
			#else
				float3 staticSwitch103_g613 = float3( 0, 0, 0 );
			#endif
			float3 DM_VertexOffset128_g613 = ( staticSwitch104_g613 + staticSwitch103_g613 );
			float lerpResult56_g621 = lerp( _MMDirectionAngle , Nicrom_WindDirAngle , _GVDirectionAngle);
			float MM_DirAngle51_g613 = lerpResult56_g621;
			float MM_DirShift59_g613 = _MMDirectionShift;
			float MM_DirShiftOffset60_g613 = _MMDirectionShiftOffset;
			float3 objToWorld11_g618 = mul( unity_ObjectToWorld, float4( LocalPivot159_g613, 1 ) ).xyz;
			float2 appendResult10_g618 = (float2(objToWorld11_g618.x , objToWorld11_g618.z));
			float MotionNoiseTiling20_g613 = _MotionNoiseTiling;
			float4 temp_output_73_0_g613 = tex2Dlod( _MotionNoise, float4( ( appendResult10_g618 * MotionNoiseTiling20_g613 ), 0, 0.0) );
			float4 StaticWorldNoise78_g613 = temp_output_73_0_g613;
			float4 StaticWorldNoise55_g617 = StaticWorldNoise78_g613;
			float3 objToWorld50_g617 = mul( unity_ObjectToWorld, float4( LocalPivot159_g613, 1 ) ).xyz;
			float lerpResult182_g613 = lerp( _Time.y , Nicrom_MM_Time_Vegetation , GV_Time174_g613);
			float lerpResult246_g613 = lerp( _Time.y , lerpResult182_g613 , ApplicationIsPlaying241_g613);
			float MM_Time13_g613 = lerpResult246_g613;
			float Time76_g617 = MM_Time13_g613;
			float temp_output_243_0_g613 = Nicrom_MM_SpeedScale_Vegetation;
			float lerpResult245_g613 = lerp( temp_output_243_0_g613 , 1.0 , GV_Time174_g613);
			float lerpResult249_g613 = lerp( temp_output_243_0_g613 , lerpResult245_g613 , ApplicationIsPlaying241_g613);
			float MM_SpeedScale253_g613 = lerpResult249_g613;
			float SpeedScale_RA80_g617 = MM_SpeedScale253_g613;
			float MM_DirShiftSpeed56_g613 = _MMDirectionShiftSpeed;
			float MM_DirShiftNoiseScale57_g613 = _MMDirectionShiftNoiseScale;
			float temp_output_11_0_g617 = radians( ( ( MM_DirAngle51_g613 + ( ( MM_DirShift59_g613 + ( MM_DirShiftOffset60_g613 * (StaticWorldNoise55_g617).x ) ) * sin( ( ( objToWorld50_g617.x + objToWorld50_g617.z ) + ( ( Time76_g617 * ( SpeedScale_RA80_g617 * MM_DirShiftSpeed56_g613 ) ) + ( ( 2.0 * UNITY_PI ) * ( (StaticWorldNoise55_g617).z * MM_DirShiftNoiseScale57_g613 ) ) ) ) ) ) ) * -1.0 ) );
			float3 appendResult14_g617 = (float3(cos( temp_output_11_0_g617 ) , 0.0 , sin( temp_output_11_0_g617 )));
			float3 worldToObj35_g617 = mul( unity_WorldToObject, float4( appendResult14_g617, 1 ) ).xyz;
			float3 worldToObj36_g617 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult34_g617 = normalize( (( worldToObj35_g617 - worldToObj36_g617 )).xyz );
			float3 MB_RotationAxis129_g613 = normalizeResult34_g617;
			float3 RotationAxis56_g616 = MB_RotationAxis129_g613;
			float4 StaticWorldNoise31_g622 = StaticWorldNoise78_g613;
			float MM_BendingOfset37_g613 = _MMBendingOffset;
			float MM_Bending35_g613 = _MMBending;
			float GV_BendingScale176_g613 = _GVAmplitudeScale;
			float lerpResult188_g613 = lerp( 1.0 , Nicrom_MM_BendScale_Vegetation , GV_BendingScale176_g613);
			float MM_BendingScale17_g613 = lerpResult188_g613;
			float MM_AmplitudeOffset52_g613 = _MMAmplitudeOffset;
			float MM_Amplitude66_g613 = _MMAmplitude;
			float lerpResult189_g613 = lerp( 1.0 , Nicrom_MM_AmpScale_Vegetation , GV_AmplitudeScale175_g613);
			float MM_AmplitudeScale15_g613 = lerpResult189_g613;
			float3 objToWorld170_g622 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float Time167_g622 = MM_Time13_g613;
			float MM_Speed53_g613 = _MMSpeed;
			float Speed125_g622 = MM_Speed53_g613;
			float SpeedScale_RotAng201_g622 = MM_SpeedScale253_g613;
			float MM_SineWaveLength58_g613 = _MMSineWaveLength;
			float WaveLength63_g622 = MM_SineWaveLength58_g613;
			float MM_PhaseShiftSource207_g613 = _MMPhaseShiftSource;
			float lerpResult154_g613 = lerp( v.color.a , (StaticWorldNoise78_g613).g , MM_PhaseShiftSource207_g613);
			float MM_PhaseShiftScale39_g613 = _MMPhaseShiftScale;
			float MB_PhaseShift79_g613 = ( lerpResult154_g613 * MM_PhaseShiftScale39_g613 );
			float PhaseShift127_g622 = MB_PhaseShift79_g613;
			float temp_output_20_0_g622 = sin( ( ( ( objToWorld170_g622.x + objToWorld170_g622.z ) + ( ( Time167_g622 * ( ( Speed125_g622 * SpeedScale_RotAng201_g622 ) * WaveLength63_g622 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift127_g622 ) ) ) * ( ( 2.0 * UNITY_PI ) / WaveLength63_g622 ) ) );
			float MM_MaxHeight55_g613 = _MMObjectHeight;
			float3 gammaToLinear56_g622 = GammaToLinearSpace( v.color.rgb );
			float MM_ObjectHeightSource54_g613 = _MMObjectHeightSource;
			float lerpResult57_g622 = lerp( ( ase_positionOS.y / MM_MaxHeight55_g613 ) , (gammaToLinear56_g622).x , MM_ObjectHeightSource54_g613);
			float BendingMask189_g622 = lerpResult57_g622;
			float MB_RotationAngle130_g613 = radians( ( ( ( ( ( (StaticWorldNoise31_g622).y * MM_BendingOfset37_g613 ) + MM_Bending35_g613 ) * MM_BendingScale17_g613 ) + ( ( ( ( (StaticWorldNoise31_g622).x * MM_AmplitudeOffset52_g613 ) + MM_Amplitude66_g613 ) * MM_AmplitudeScale15_g613 ) * temp_output_20_0_g622 ) ) * BendingMask189_g622 ) );
			float RotationAngle54_g616 = MB_RotationAngle130_g613;
			float3 LocalPivotPos60_g616 = LocalPivot159_g613;
			float3 break62_g616 = LocalPivotPos60_g616;
			float VertexPos_Y67_g616 = ase_positionOS.y;
			float3 appendResult45_g616 = (float3(break62_g616.x , VertexPos_Y67_g616 , break62_g616.z));
			float3 VertexPos66_g616 = ase_positionOS;
			float3 rotatedValue30_g616 = RotateAroundAxis( appendResult45_g616, VertexPos66_g616, RotationAxis56_g616, RotationAngle54_g616 );
			float3 DetailMotionVO73_g616 = DM_VertexOffset128_g613;
			float3 rotatedValue34_g616 = RotateAroundAxis( LocalPivotPos60_g616, ( rotatedValue30_g616 + DetailMotionVO73_g616 ), RotationAxis56_g616, RotationAngle54_g616 );
			#ifdef _MAINMOTION_ON
				float3 staticSwitch205_g613 = ( ( rotatedValue34_g616 - VertexPos66_g616 ) * step( 0.01 , VertexPos_Y67_g616 ) );
			#else
				float3 staticSwitch205_g613 = DM_VertexOffset128_g613;
			#endif
			v.vertex.xyz += staticSwitch205_g613;
			v.vertex.w = 1;
			float ColorMask1FadeStart100_g611 = _ColorMask1FadeStart;
			float ColorMask1FadeEnd101_g611 = _ColorMask1FadeEnd;
			float3 gammaToLinear84_g611 = GammaToLinearSpace( v.color.rgb );
			float VC_R86_g611 = (gammaToLinear84_g611).x;
			float smoothstepResult13_g611 = smoothstep( ColorMask1FadeStart100_g611 , ColorMask1FadeEnd101_g611 , VC_R86_g611);
			o.vertexToFrag16_g611 = smoothstepResult13_g611;
			float3 objToWorld78_g611 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float2 appendResult79_g611 = (float2(objToWorld78_g611.x , objToWorld78_g611.z));
			float MaskNoiseTiling93_g611 = _MaskNoiseTiling;
			o.vertexToFrag88_g611 = (tex2Dlod( _MaskNoise, float4( ( appendResult79_g611 * MaskNoiseTiling93_g611 ), 0, 0.0) )).r;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal196_g611 = i.uv_texcoord;
			o.Normal = UnpackScaleNormal( tex2D( _Normal, uv_Normal196_g611 ), _NormalScale );
			float Debug_Target139_g611 = _Debug;
			float2 uv_Albedo128_g611 = i.uv_texcoord;
			float4 tex2DNode128_g611 = tex2D( _Albedo, uv_Albedo128_g611 );
			float4 AlbedoTex129_g611 = tex2DNode128_g611;
			float3 Color1B121_g611 = _Color1B;
			float3 Color1A118_g611 = _Color1A;
			float2 uv_ColorMask1103_g611 = i.uv_texcoord;
			float ColorMask1Tex105_g611 = tex2D( _ColorMask1, uv_ColorMask1103_g611 ).r;
			float ColorMask1End98_g611 = _ColorMask1End;
			float ColorMask1Start99_g611 = _ColorMask1Start;
			float smoothstepResult11_g611 = smoothstep( ColorMask1End98_g611 , ColorMask1Start99_g611 , ( 1.0 - ( i.uv_texcoord.y - 2.0 ) ));
			#if defined( _COLORMASK1SOURCE_TEXTURE )
				float staticSwitch184_g611 = ColorMask1Tex105_g611;
			#elif defined( _COLORMASK1SOURCE_UVS )
				float staticSwitch184_g611 = smoothstepResult11_g611;
			#else
				float staticSwitch184_g611 = ColorMask1Tex105_g611;
			#endif
			float lerpResult22_g611 = lerp( staticSwitch184_g611 , 1.0 , i.vertexToFrag16_g611);
			float ColorMask175_g611 = lerpResult22_g611;
			float3 lerpResult40_g611 = lerp( Color1B121_g611 , Color1A118_g611 , ColorMask175_g611);
			float3 Color145_g611 = lerpResult40_g611;
			float3 Color2B123_g611 = _Color2B;
			float3 Color2A122_g611 = _Color2A;
			float3 lerpResult39_g611 = lerp( Color2B123_g611 , Color2A122_g611 , ColorMask175_g611);
			float3 Color244_g611 = lerpResult39_g611;
			float3 gammaToLinear84_g611 = GammaToLinearSpace( i.vertexColor.rgb );
			float VC_R86_g611 = (gammaToLinear84_g611).x;
			float ColorMask2Start117_g611 = _ColorMask2Start;
			float ColorMask2StartOffset110_g611 = _ColorMask2StartOffset;
			float MaskNoiseSharpMin111_g611 = _MaskNoiseSharpMin;
			float MaskNoiseSharpMax112_g611 = _MaskNoiseSharpMax;
			float smoothstepResult25_g611 = smoothstep( MaskNoiseSharpMin111_g611 , MaskNoiseSharpMax112_g611 , i.vertexToFrag88_g611);
			#if defined( _COLORS_TWO )
				float staticSwitch172_g611 = 0.0;
			#elif defined( _COLORS_FOUR )
				float staticSwitch172_g611 = smoothstepResult25_g611;
			#else
				float staticSwitch172_g611 = 0.0;
			#endif
			float ColorMaskSharpNoise27_g611 = staticSwitch172_g611;
			float ColorMask2End124_g611 = _ColorMask2End;
			float ColorMask2AlphaOffset126_g611 = _ColorMask2AlphaOffset;
			float ColorMask2Alpha127_g611 = _ColorMask2Alpha;
			float ColorMask2Opacity_F148_g611 = saturate( ( ( ColorMask2AlphaOffset126_g611 * ColorMaskSharpNoise27_g611 ) + ColorMask2Alpha127_g611 ) );
			float lerpResult158_g611 = lerp( 0.0 , saturate(  (0.0 + ( VC_R86_g611 - saturate( ( ColorMask2Start117_g611 + ( ColorMask2StartOffset110_g611 * ColorMaskSharpNoise27_g611 ) ) ) ) * ( 1.0 - 0.0 ) / ( ColorMask2End124_g611 - saturate( ( ColorMask2Start117_g611 + ( ColorMask2StartOffset110_g611 * ColorMaskSharpNoise27_g611 ) ) ) ) ) ) , ColorMask2Opacity_F148_g611);
			#if defined( _COLORBLENDAXIS_Y )
				float staticSwitch160_g611 = lerpResult158_g611;
			#elif defined( _COLORBLENDAXIS_XZ )
				float staticSwitch160_g611 = ( ColorMask2Opacity_F148_g611 * ColorMaskSharpNoise27_g611 );
			#else
				float staticSwitch160_g611 = lerpResult158_g611;
			#endif
			#if defined( _COLORS_TWO )
				float staticSwitch170_g611 = 0.0;
			#elif defined( _COLORS_FOUR )
				float staticSwitch170_g611 = staticSwitch160_g611;
			#else
				float staticSwitch170_g611 = 0.0;
			#endif
			float ColorMask2145_g611 = staticSwitch170_g611;
			float3 lerpResult56_g611 = lerp( Color145_g611 , Color244_g611 , ColorMask2145_g611);
			#if defined( _COLORS_TWO )
				float3 staticSwitch168_g611 = Color145_g611;
			#elif defined( _COLORS_FOUR )
				float3 staticSwitch168_g611 = lerpResult56_g611;
			#else
				float3 staticSwitch168_g611 = Color145_g611;
			#endif
			float4 Albedo166_g611 = ( AlbedoTex129_g611 * float4( staticSwitch168_g611 , 0.0 ) );
			float4 Albedo139_g611 = Albedo166_g611;
			float ColorMask1139_g611 = ColorMask175_g611;
			float ColorMask2139_g611 = ColorMask2145_g611;
			float MaskNoise139_g611 = ColorMaskSharpNoise27_g611;
			float4 localDebug139_g611 = Debug139_g611( Debug_Target139_g611 , Albedo139_g611 , ColorMask1139_g611 , ColorMask2139_g611 , MaskNoise139_g611 );
			o.Albedo = localDebug139_g611.xyz;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Alpha = 1;
			clip( tex2DNode128_g611.a - _AlphaCutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Vegetation_Leaves"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2155;2368,2208;Inherit;False;Nicrom - Vegetation - Motion - GP;-1;;609;2010567f31880844287a8b7519991b43;0;0;7;FLOAT;10;FLOAT;12;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;14;FLOAT;9
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2153;2432,2432;Inherit;False;Nicrom - Pivot From UVs;1;;610;210e3b1b5c35d40419d216fdbaceef46;0;0;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1330;-19002.03,10716.32;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1328;-19355.95,10790.4;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1593;3200,2400;Inherit;False;Property;_AlphaCutoff;Alpha Cutoff;0;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2149;2784,1920;Inherit;False;Nicrom - Vegetation - Leaves - Main;3;;611;68e3b7fe7db0a9940b2e5eae22653de7;0;0;5;FLOAT4;133;FLOAT3;201;FLOAT;177;FLOAT;178;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2154;2720,2208;Inherit;False;Nicrom - Motion;32;;613;ba60642b1d9af614f93c28cb2553ff1c;0;8;179;FLOAT;0;False;243;FLOAT;1;False;178;FLOAT;0;False;180;FLOAT;0;False;184;FLOAT;0;False;244;FLOAT;1;False;185;FLOAT;0;False;238;FLOAT3;0,0,0;False;2;FLOAT3;0;COLOR;215
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2132;3200,1920;Float;False;True;-1;3;Nicrom.CMI_Vegetation_Leaves;0;0;Standard;Nicrom/ASE/Vegetation/Leaves;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;True;0;True;Opaque;;AlphaTest;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;True;_AlphaCutoff;1;Pragma;multi_compile_instancing;False;;Custom;False;0;0;;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2154;179;2155;10
WireConnection;2154;243;2155;12
WireConnection;2154;178;2155;6
WireConnection;2154;180;2155;7
WireConnection;2154;184;2155;8
WireConnection;2154;244;2155;14
WireConnection;2154;185;2155;9
WireConnection;2154;238;2153;0
WireConnection;2132;0;2149;133
WireConnection;2132;1;2149;201
WireConnection;2132;3;2149;177
WireConnection;2132;4;2149;178
WireConnection;2132;10;2149;0
WireConnection;2132;11;2154;0
ASEEND*/
//CHKSM=0C87F09C783472DF747F9ACA736BF8E32C4FC0AC