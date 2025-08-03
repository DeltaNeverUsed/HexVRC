// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Vegetation/Flower"
{
	Properties
	{
		_AlphaCutoff( "Alpha Cutoff", Range( 0, 1 ) ) = 0.5
		[NoScaleOffset][SingleLineTexture] _Albedo( "Albedo", 2D ) = "white" {}
		[KeywordEnum( Two,Four )] _FlowerColors( "Flower Colors", Float ) = 0
		_FlowerColor1A( "Flower Color 1A", Color ) = ( 0.9716981, 0.9698267, 0.9127676 )
		_FlowerColor1B( "Flower Color 1B", Color ) = ( 0.6784314, 0.4431373, 0.2196078 )
		_FlowerColor2A( "Flower Color 2A", Color ) = ( 0.9433962, 0.9309318, 0.3966841 )
		_FlowerColor2B( "Flower Color 2B", Color ) = ( 0.6784314, 0.4431373, 0.2196078 )
		[Enum(None,0,Color Mask 1  R,1,Color Mask 1  G,2,Color Mask 2,3,Scale Var Noise,4)] _Debug( "Debug", Float ) = 0
		[SingleLineTexture] _ColorMask1( "Color Mask 1", 2D ) = "white" {}
		[SingleLineTexture] _ColorMask2( "Color Mask 2", 2D ) = "white" {}
		[Toggle] _ColorMask2GV( "Color Mask 2 GV", Float ) = 0
		_ColorMask2Tiling( "Color Mask 2 Tiling", Range( 0.0001, 4 ) ) = 0.05
		_ColorMask2SharpMin( "Color Mask 2 Sharp Min", Range( 0, 1 ) ) = 0
		_ColorMask2SharpMax( "Color Mask 2 Sharp Max", Range( 0, 1 ) ) = 0.5
		_ColorMask2Opacity( "Color Mask 2 Opacity", Range( 0, 1 ) ) = 1
		[Toggle][Space] _STEM( "STEM", Range( 0, 1 ) ) = 0
		_StemColorTop( "Stem Color - Top", Color ) = ( 0.5294118, 0.6588235, 0.3098039 )
		_StemColorBottom( "Stem Color -  Bottom", Color ) = ( 0.3960784, 0.5294118, 0.1568628 )
		_StemColorMaskStart( "Stem Color Mask Start", Range( 0, 2 ) ) = 0
		_StemColorMaskEnd( "Stem Color Mask End", Range( 0, 2 ) ) = 1
		[Space][Toggle( _BLENDWITHTERRAIN_ON )] _BlendWithTerrain( "Blend With Terrain", Float ) = 0
		_BWTTop( "BWT Top", Range( 0, 1 ) ) = 0
		_BWTBottom( "BWT Bottom", Range( 0, 1 ) ) = 1
		[Space][Toggle( _DISTANCEFADE_ON )] _DistanceFade( "Distance Fade", Float ) = 1
		[Toggle] _DistanceFadeUseGV( "DistanceFade Use GV", Float ) = 0
		_DistanceFadeStart( "Distance Fade Start", Range( 0, 2000 ) ) = 50
		_DistanceFadeLength( "Distance Fade Length", Range( 0, 20000 ) ) = 50
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
		[Space][Toggle( _SLOPECORRECTION_ON )] _SlopeCorrection( "Slope Correction", Float ) = 1
		_SlopeCorrectionMagnitude( "Slope Correction Magnitude", Range( 0, 1 ) ) = 1
		_SlopeCorrectionOffset( "Slope Correction Offset", Range( 0, 1 ) ) = 0
		_ScaleOffset( "Scale Offset", Range( -1, 5 ) ) = 0
		[Toggle( _SCALEVARIATION_ON )] _ScaleVariation( "Scale Variation", Float ) = 0
		_ScaleVarMin( "Scale Var Min", Range( -1, 2 ) ) = 0
		_ScaleVarMax( "Scale Var Max", Range( -1, 2 ) ) = 0.2
		[SingleLineTexture][Space] _ScaleVarNoise( "Scale Var Noise", 2D ) = "white" {}
		_ScaleVarNoiseTiling( "Scale Var Noise Tiling", Range( 0.0001, 5 ) ) = 1
		_ScaleVarNoiseSharpMin( "Scale Var Noise Sharp Min", Range( 0, 1 ) ) = 0
		_ScaleVarNoiseSharpMax( "Scale Var Noise Sharp Max", Range( 0, 1 ) ) = 1
		[HideInInspector] _texcoord2( "", 2D ) = "white" {}
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
		#pragma target 4.5
		#pragma shader_feature_local_vertex _SCALEVARIATION_ON
		#pragma shader_feature_local_vertex _SLOPECORRECTION_ON
		#pragma shader_feature_local_vertex _MAINMOTION_ON
		#pragma shader_feature_local_vertex _DETAILMOTION1_ON
		#pragma shader_feature_local_vertex _DETAILMOTION2_ON
		#pragma shader_feature_local _FLOWERCOLORS_TWO _FLOWERCOLORS_FOUR
		#pragma shader_feature_local _BLENDWITHTERRAIN_ON
		#pragma shader_feature_local _DISTANCEFADE_ON
		#define ASE_VERSION 19901
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows nolightmap  dithercrossfade vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float2 uv2_texcoord2;
			float4 vertexToFrag19_g1478;
			float vertexToFrag230_g1474;
			float vertexToFrag71_g1469;
			float customSurfaceDepth3_g1479;
		};

		uniform float Nicrom_DM_AmpScale_Flower;
		uniform half _GVBendingScale;
		uniform float _DM1Amplitude;
		uniform float Nicrom_DM_Time_Flower;
		uniform float _GVTime;
		uniform half Nicrom_ApplicationIsPlaying;
		uniform float _DM1Speed;
		uniform float Nicrom_DM_SpeedScale_Flower;
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
		uniform float Nicrom_MM_Time_Flower;
		uniform float Nicrom_MM_SpeedScale_Flower;
		uniform half _MMDirectionShiftSpeed;
		uniform half _MMDirectionShiftNoiseScale;
		uniform half _MMBendingOffset;
		uniform half _MMBending;
		uniform float Nicrom_MM_BendScale_Flowers;
		uniform half _GVAmplitudeScale;
		uniform half _MMAmplitudeOffset;
		uniform half _MMAmplitude;
		uniform float Nicrom_MM_AmpScale_Flower;
		uniform half _MMSpeed;
		uniform half _MMSineWaveLength;
		uniform half _MMPhaseShiftSource;
		uniform half _MMPhaseShiftScale;
		uniform half _MMObjectHeight;
		uniform half _MMObjectHeightSource;
		uniform float _SlopeCorrectionOffset;
		uniform float _SlopeCorrectionMagnitude;
		uniform float _ScaleVarMin;
		uniform float _ScaleVarMax;
		uniform float _ScaleVarNoiseSharpMin;
		uniform float _ScaleVarNoiseSharpMax;
		uniform sampler2D _ScaleVarNoise;
		uniform float _ScaleVarNoiseTiling;
		uniform float _ScaleOffset;
		uniform float _Debug;
		uniform float3 _FlowerColor1B;
		uniform float3 _FlowerColor1A;
		uniform sampler2D _ColorMask1;
		uniform float4 _ColorMask1_ST;
		uniform float3 _FlowerColor2B;
		uniform float3 _FlowerColor2A;
		uniform float _ColorMask2SharpMin;
		uniform float Nicrom_Flower_CM2_SharpMin;
		uniform float _ColorMask2GV;
		uniform float _ColorMask2SharpMax;
		uniform float Nicrom_Flower_CM2_SharpMax;
		uniform sampler2D _ColorMask2;
		uniform float _ColorMask2Tiling;
		uniform float Nicrom_Flower_CM2_Tilling;
		uniform float _ColorMask2Opacity;
		uniform float3 _StemColorBottom;
		uniform sampler2D Nicrom_TerrainColorMap;
		uniform float2 Nicrom_TerrainPosition;
		uniform float Nicrom_TerrainSize;
		uniform float _BWTBottom;
		float4 Nicrom_TerrainColorMap_TexelSize;
		uniform float3 _StemColorTop;
		uniform float _BWTTop;
		uniform float _StemColorMaskStart;
		uniform float _StemColorMaskEnd;
		uniform float _STEM;
		uniform sampler2D _Albedo;
		uniform float _DistanceFadeLength;
		uniform float Nicrom_Flower_DF_Length;
		uniform float _DistanceFadeUseGV;
		uniform float Nicrom_Flower_DF_Start;
		uniform float _DistanceFadeStart;
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


		float3 ASESafeNormalize(float3 inVec)
		{
			float dp3 = max(1.175494351e-38, dot(inVec, inVec));
			return inVec* rsqrt(dp3);
		}


		float4 Debug203_g1474( float Debug_Target, float4 Albedo, float ColorMask1R, float ColorMask1G, float ColorMask2, float ScaleVarNoise )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return ColorMask1R;
			else if(Debug_Target ==2)
			    return ColorMask1G;
			else if(Debug_Target ==3)
			    return ColorMask2;
			else
			    return ScaleVarNoise;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float temp_output_23_0_g1447 = radians( ( 90.0 + ( v.texcoord2.xy.x * 360.0 ) ) );
			float3 appendResult25_g1447 = (float3(cos( temp_output_23_0_g1447 ) , 0.0 , sin( temp_output_23_0_g1447 )));
			float3 DB_RotationAxis87_g1445 = appendResult25_g1447;
			float GV_AmplitudeScale175_g1445 = _GVBendingScale;
			float lerpResult186_g1445 = lerp( 1.0 , Nicrom_DM_AmpScale_Flower , GV_AmplitudeScale175_g1445);
			float DM_AmplitudeScale168_g1445 = lerpResult186_g1445;
			float DM1_Amplitude28_g1445 = _DM1Amplitude;
			float3 objToWorld80_g1455 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float GV_Time174_g1445 = _GVTime;
			float lerpResult187_g1445 = lerp( _Time.y , Nicrom_DM_Time_Flower , GV_Time174_g1445);
			float ApplicationIsPlaying241_g1445 = Nicrom_ApplicationIsPlaying;
			float lerpResult256_g1445 = lerp( _Time.y , lerpResult187_g1445 , ApplicationIsPlaying241_g1445);
			float DM_Time169_g1445 = lerpResult256_g1445;
			float Time90_g1455 = DM_Time169_g1445;
			float DM1_Speed29_g1445 = _DM1Speed;
			float Speed45_g1455 = DM1_Speed29_g1445;
			float temp_output_244_0_g1445 = Nicrom_DM_SpeedScale_Flower;
			float lerpResult261_g1445 = lerp( temp_output_244_0_g1445 , 1.0 , GV_Time174_g1445);
			float lerpResult262_g1445 = lerp( temp_output_244_0_g1445 , lerpResult261_g1445 , ApplicationIsPlaying241_g1445);
			float DM_SpeedScale265_g1445 = lerpResult262_g1445;
			float SpeedScale95_g1455 = DM_SpeedScale265_g1445;
			float DM_PhaseShift91_g1445 = v.color.a;
			float PhaseShift48_g1455 = DM_PhaseShift91_g1445;
			float3 ase_positionOS = v.vertex.xyz;
			float3 appendResult24_g1447 = (float3(0.0 , v.texcoord2.xy.y , 0.0));
			float3 DM_PivotPosOnYAxis88_g1445 = appendResult24_g1447;
			float3 PivotPosOnYAxis56_g1455 = DM_PivotPosOnYAxis88_g1445;
			float DM1_FoliageLength32_g1445 = _DM1FoliageLength;
			float3 rotatedValue29_g1455 = RotateAroundAxis( PivotPosOnYAxis56_g1455, ase_positionOS, DB_RotationAxis87_g1445, radians( ( ( ( DM_AmplitudeScale168_g1445 * DM1_Amplitude28_g1445 ) * sin( ( ( ( objToWorld80_g1455.x + objToWorld80_g1455.z ) + ( ( Time90_g1455 * ( Speed45_g1455 * SpeedScale95_g1455 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift48_g1455 ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , PivotPosOnYAxis56_g1455 ) / DM1_FoliageLength32_g1445 ) ) ) );
			float DM1_MotionMask89_g1445 = step( 1.5 , v.texcoord.xy.y );
			float3 DM1_VertexOffset231_g1445 = ( ( rotatedValue29_g1455 - ase_positionOS ) * DM1_MotionMask89_g1445 );
			#ifdef _DETAILMOTION1_ON
				float3 staticSwitch104_g1445 = DM1_VertexOffset231_g1445;
			#else
				float3 staticSwitch104_g1445 = float3( 0, 0, 0 );
			#endif
			float DM2_Amplitude30_g1445 = _DM2Amplitude;
			float Amplitude58_g1456 = DM2_Amplitude30_g1445;
			float3 appendResult28_g1444 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 LocalPivot159_g1445 = -appendResult28_g1444;
			float3 PivotPoint49_g1456 = LocalPivot159_g1445;
			float3 objToWorld53_g1456 = mul( unity_ObjectToWorld, float4( PivotPoint49_g1456, 1 ) ).xyz;
			float Time87_g1456 = DM_Time169_g1445;
			float SpeedScale93_g1456 = DM_SpeedScale265_g1445;
			float DM2_Speed31_g1445 = _DM2Speed;
			float Speed41_g1456 = DM2_Speed31_g1445;
			float PhaseShift54_g1456 = DM_PhaseShift91_g1445;
			float3 break52_g1456 = PivotPoint49_g1456;
			float3 appendResult20_g1456 = (float3(break52_g1456.x , ase_positionOS.y , break52_g1456.z));
			float DM2_ObjectRadius33_g1445 = _DM2ObjectRadius;
			float ObjectRadius60_g1456 = DM2_ObjectRadius33_g1445;
			float3 rotatedValue33_g1456 = RotateAroundAxis( PivotPoint49_g1456, ase_positionOS, float3( 0, 1, 0 ), radians( ( ( ( DM_AmplitudeScale168_g1445 * Amplitude58_g1456 ) * sin( ( ( ( objToWorld53_g1456.x + objToWorld53_g1456.z ) + ( ( Time87_g1456 * ( SpeedScale93_g1456 * Speed41_g1456 ) ) + ( ( 2.0 * UNITY_PI ) * ( 1.0 - PhaseShift54_g1456 ) ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , appendResult20_g1456 ) / ObjectRadius60_g1456 ) ) ) );
			float DM2_MotionMask90_g1445 = step( 1.5 , v.texcoord.xy.x );
			float BendingMask62_g1456 = DM2_MotionMask90_g1445;
			float3 DM2_VertexOffset232_g1445 = ( ( rotatedValue33_g1456 - ase_positionOS ) * BendingMask62_g1456 );
			#ifdef _DETAILMOTION2_ON
				float3 staticSwitch103_g1445 = DM2_VertexOffset232_g1445;
			#else
				float3 staticSwitch103_g1445 = float3( 0, 0, 0 );
			#endif
			float3 DM_VertexOffset128_g1445 = ( staticSwitch104_g1445 + staticSwitch103_g1445 );
			float lerpResult56_g1453 = lerp( _MMDirectionAngle , Nicrom_WindDirAngle , _GVDirectionAngle);
			float MM_DirAngle51_g1445 = lerpResult56_g1453;
			float MM_DirShift59_g1445 = _MMDirectionShift;
			float MM_DirShiftOffset60_g1445 = _MMDirectionShiftOffset;
			float3 objToWorld11_g1450 = mul( unity_ObjectToWorld, float4( LocalPivot159_g1445, 1 ) ).xyz;
			float2 appendResult10_g1450 = (float2(objToWorld11_g1450.x , objToWorld11_g1450.z));
			float MotionNoiseTiling20_g1445 = _MotionNoiseTiling;
			float4 temp_output_73_0_g1445 = tex2Dlod( _MotionNoise, float4( ( appendResult10_g1450 * MotionNoiseTiling20_g1445 ), 0, 0.0) );
			float4 StaticWorldNoise78_g1445 = temp_output_73_0_g1445;
			float4 StaticWorldNoise55_g1449 = StaticWorldNoise78_g1445;
			float3 objToWorld50_g1449 = mul( unity_ObjectToWorld, float4( LocalPivot159_g1445, 1 ) ).xyz;
			float lerpResult182_g1445 = lerp( _Time.y , Nicrom_MM_Time_Flower , GV_Time174_g1445);
			float lerpResult246_g1445 = lerp( _Time.y , lerpResult182_g1445 , ApplicationIsPlaying241_g1445);
			float MM_Time13_g1445 = lerpResult246_g1445;
			float Time76_g1449 = MM_Time13_g1445;
			float temp_output_243_0_g1445 = Nicrom_MM_SpeedScale_Flower;
			float lerpResult245_g1445 = lerp( temp_output_243_0_g1445 , 1.0 , GV_Time174_g1445);
			float lerpResult249_g1445 = lerp( temp_output_243_0_g1445 , lerpResult245_g1445 , ApplicationIsPlaying241_g1445);
			float MM_SpeedScale253_g1445 = lerpResult249_g1445;
			float SpeedScale_RA80_g1449 = MM_SpeedScale253_g1445;
			float MM_DirShiftSpeed56_g1445 = _MMDirectionShiftSpeed;
			float MM_DirShiftNoiseScale57_g1445 = _MMDirectionShiftNoiseScale;
			float temp_output_11_0_g1449 = radians( ( ( MM_DirAngle51_g1445 + ( ( MM_DirShift59_g1445 + ( MM_DirShiftOffset60_g1445 * (StaticWorldNoise55_g1449).x ) ) * sin( ( ( objToWorld50_g1449.x + objToWorld50_g1449.z ) + ( ( Time76_g1449 * ( SpeedScale_RA80_g1449 * MM_DirShiftSpeed56_g1445 ) ) + ( ( 2.0 * UNITY_PI ) * ( (StaticWorldNoise55_g1449).z * MM_DirShiftNoiseScale57_g1445 ) ) ) ) ) ) ) * -1.0 ) );
			float3 appendResult14_g1449 = (float3(cos( temp_output_11_0_g1449 ) , 0.0 , sin( temp_output_11_0_g1449 )));
			float3 worldToObj35_g1449 = mul( unity_WorldToObject, float4( appendResult14_g1449, 1 ) ).xyz;
			float3 worldToObj36_g1449 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult34_g1449 = normalize( (( worldToObj35_g1449 - worldToObj36_g1449 )).xyz );
			float3 MB_RotationAxis129_g1445 = normalizeResult34_g1449;
			float3 RotationAxis56_g1448 = MB_RotationAxis129_g1445;
			float4 StaticWorldNoise31_g1454 = StaticWorldNoise78_g1445;
			float MM_BendingOfset37_g1445 = _MMBendingOffset;
			float MM_Bending35_g1445 = _MMBending;
			float GV_BendingScale176_g1445 = _GVAmplitudeScale;
			float lerpResult188_g1445 = lerp( 1.0 , Nicrom_MM_BendScale_Flowers , GV_BendingScale176_g1445);
			float MM_BendingScale17_g1445 = lerpResult188_g1445;
			float MM_AmplitudeOffset52_g1445 = _MMAmplitudeOffset;
			float MM_Amplitude66_g1445 = _MMAmplitude;
			float lerpResult189_g1445 = lerp( 1.0 , Nicrom_MM_AmpScale_Flower , GV_AmplitudeScale175_g1445);
			float MM_AmplitudeScale15_g1445 = lerpResult189_g1445;
			float3 objToWorld170_g1454 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float Time167_g1454 = MM_Time13_g1445;
			float MM_Speed53_g1445 = _MMSpeed;
			float Speed125_g1454 = MM_Speed53_g1445;
			float SpeedScale_RotAng201_g1454 = MM_SpeedScale253_g1445;
			float MM_SineWaveLength58_g1445 = _MMSineWaveLength;
			float WaveLength63_g1454 = MM_SineWaveLength58_g1445;
			float MM_PhaseShiftSource207_g1445 = _MMPhaseShiftSource;
			float lerpResult154_g1445 = lerp( v.color.a , (StaticWorldNoise78_g1445).g , MM_PhaseShiftSource207_g1445);
			float MM_PhaseShiftScale39_g1445 = _MMPhaseShiftScale;
			float MB_PhaseShift79_g1445 = ( lerpResult154_g1445 * MM_PhaseShiftScale39_g1445 );
			float PhaseShift127_g1454 = MB_PhaseShift79_g1445;
			float temp_output_20_0_g1454 = sin( ( ( ( objToWorld170_g1454.x + objToWorld170_g1454.z ) + ( ( Time167_g1454 * ( ( Speed125_g1454 * SpeedScale_RotAng201_g1454 ) * WaveLength63_g1454 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift127_g1454 ) ) ) * ( ( 2.0 * UNITY_PI ) / WaveLength63_g1454 ) ) );
			float MM_MaxHeight55_g1445 = _MMObjectHeight;
			float3 gammaToLinear56_g1454 = GammaToLinearSpace( v.color.rgb );
			float MM_ObjectHeightSource54_g1445 = _MMObjectHeightSource;
			float lerpResult57_g1454 = lerp( ( ase_positionOS.y / MM_MaxHeight55_g1445 ) , (gammaToLinear56_g1454).x , MM_ObjectHeightSource54_g1445);
			float BendingMask189_g1454 = lerpResult57_g1454;
			float MB_RotationAngle130_g1445 = radians( ( ( ( ( ( (StaticWorldNoise31_g1454).y * MM_BendingOfset37_g1445 ) + MM_Bending35_g1445 ) * MM_BendingScale17_g1445 ) + ( ( ( ( (StaticWorldNoise31_g1454).x * MM_AmplitudeOffset52_g1445 ) + MM_Amplitude66_g1445 ) * MM_AmplitudeScale15_g1445 ) * temp_output_20_0_g1454 ) ) * BendingMask189_g1454 ) );
			float RotationAngle54_g1448 = MB_RotationAngle130_g1445;
			float3 LocalPivotPos60_g1448 = LocalPivot159_g1445;
			float3 break62_g1448 = LocalPivotPos60_g1448;
			float VertexPos_Y67_g1448 = ase_positionOS.y;
			float3 appendResult45_g1448 = (float3(break62_g1448.x , VertexPos_Y67_g1448 , break62_g1448.z));
			float3 VertexPos66_g1448 = ase_positionOS;
			float3 rotatedValue30_g1448 = RotateAroundAxis( appendResult45_g1448, VertexPos66_g1448, RotationAxis56_g1448, RotationAngle54_g1448 );
			float3 DetailMotionVO73_g1448 = DM_VertexOffset128_g1445;
			float3 rotatedValue34_g1448 = RotateAroundAxis( LocalPivotPos60_g1448, ( rotatedValue30_g1448 + DetailMotionVO73_g1448 ), RotationAxis56_g1448, RotationAngle54_g1448 );
			#ifdef _MAINMOTION_ON
				float3 staticSwitch205_g1445 = ( ( rotatedValue34_g1448 - VertexPos66_g1448 ) * step( 0.01 , VertexPos_Y67_g1448 ) );
			#else
				float3 staticSwitch205_g1445 = DM_VertexOffset128_g1445;
			#endif
			float3 LocalVertexOffset89_g1457 = staticSwitch205_g1445;
			float3 appendResult15_g1457 = (float3(0.0 , 1.0 , 0.0));
			float3 objToWorld98_g1457 = mul( unity_ObjectToWorld, float4( appendResult15_g1457, 1 ) ).xyz;
			float3 objToWorld102_g1457 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 break20_g1457 = ( objToWorld98_g1457 - objToWorld102_g1457 );
			float3 appendResult24_g1457 = (float3(-break20_g1457.z , 0.0 , break20_g1457.x));
			float3 appendResult3_g1457 = (float3(0.0 , 1.0 , 0.0));
			float3 objToWorld100_g1457 = mul( unity_ObjectToWorld, float4( appendResult3_g1457, 1 ) ).xyz;
			float3 objToWorld106_g1457 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 temp_output_107_0_g1457 = ( objToWorld100_g1457 - objToWorld106_g1457 );
			float3 break108_g1457 = temp_output_107_0_g1457;
			float3 lerpResult84_g1457 = lerp( float3( 0, 1, 0 ) , temp_output_107_0_g1457 , step( 0.001 , ( abs( break108_g1457.x ) + abs( break108_g1457.z ) ) ));
			float3 normalizeResult7_g1457 = ASESafeNormalize( lerpResult84_g1457 );
			float dotResult9_g1457 = dot( normalizeResult7_g1457 , float3( 0, 1, 0 ) );
			float temp_output_12_0_g1457 = acos( dotResult9_g1457 );
			float NaNPrevention21_g1457 = step( 0.01 , abs( ( temp_output_12_0_g1457 * ( 180.0 / UNITY_PI ) ) ) );
			float3 lerpResult26_g1457 = lerp( float3( 1, 0, 0 ) , appendResult24_g1457 , NaNPrevention21_g1457);
			float3 worldToObj99_g1457 = mul( unity_WorldToObject, float4( lerpResult26_g1457, 1 ) ).xyz;
			float3 worldToObj105_g1457 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult49_g1457 = normalize( ( worldToObj99_g1457 - worldToObj105_g1457 ) );
			float3 RotationAxis30_g1457 = normalizeResult49_g1457;
			float4 WorldSpaceNoise126_g1457 = temp_output_73_0_g1445;
			float SlopeCorrectionOffset120_g1457 = _SlopeCorrectionOffset;
			float SlopeCorrectionMagnitude119_g1457 = _SlopeCorrectionMagnitude;
			float RotationAngle29_g1457 = ( saturate( (  (0.0 + ( (WorldSpaceNoise126_g1457).x - 0.0 ) * ( SlopeCorrectionOffset120_g1457 - 0.0 ) / ( 1.0 - 0.0 ) ) + SlopeCorrectionMagnitude119_g1457 ) ) * temp_output_12_0_g1457 );
			float3 appendResult28_g1458 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 rotatedValue35_g1457 = RotateAroundAxis( -appendResult28_g1458, ( ase_positionOS + LocalVertexOffset89_g1457 ), RotationAxis30_g1457, RotationAngle29_g1457 );
			float3 lerpResult52_g1457 = lerp( LocalVertexOffset89_g1457 , ( rotatedValue35_g1457 - ase_positionOS ) , NaNPrevention21_g1457);
			#ifdef _SLOPECORRECTION_ON
				float3 staticSwitch123_g1457 = lerpResult52_g1457;
			#else
				float3 staticSwitch123_g1457 = LocalVertexOffset89_g1457;
			#endif
			float3 appendResult28_g1472 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 Scale_Pivot15_g1469 = -appendResult28_g1472;
			float3 temp_output_5_0_g1469 = ( ( staticSwitch123_g1457 + ase_positionOS ) - Scale_Pivot15_g1469 );
			float ScaleVartMin40_g1469 = _ScaleVarMin;
			float ScaleVarMax41_g1469 = _ScaleVarMax;
			float ScaleNoiseSharpnessMin59_g1469 = _ScaleVarNoiseSharpMin;
			float ScaleNoiseSharpnessMax60_g1469 = _ScaleVarNoiseSharpMax;
			float3 objToWorld11_g1471 = mul( unity_ObjectToWorld, float4( Scale_Pivot15_g1469, 1 ) ).xyz;
			float2 appendResult10_g1471 = (float2(objToWorld11_g1471.x , objToWorld11_g1471.z));
			float2 Scale_WorldSpaceUVs30_g1469 = appendResult10_g1471;
			float Scale_VarNoiseTiling23_g1469 = _ScaleVarNoiseTiling;
			float4 Scale_WorldSpaceNoise32_g1469 = tex2Dlod( _ScaleVarNoise, float4( ( Scale_WorldSpaceUVs30_g1469 * Scale_VarNoiseTiling23_g1469 ), 0, 0.0) );
			float smoothstepResult56_g1469 = smoothstep( ScaleNoiseSharpnessMin59_g1469 , ScaleNoiseSharpnessMax60_g1469 , (Scale_WorldSpaceNoise32_g1469).r);
			float lerpResult44_g1469 = lerp( ScaleVartMin40_g1469 , ScaleVarMax41_g1469 , smoothstepResult56_g1469);
			float ScaleVar47_g1469 = lerpResult44_g1469;
			float clampResult63_g1469 = clamp( ( ScaleVar47_g1469 + 1.0 ) , 0.0 , 7.0 );
			#ifdef _SCALEVARIATION_ON
				float3 staticSwitch72_g1469 = ( temp_output_5_0_g1469 * clampResult63_g1469 );
			#else
				float3 staticSwitch72_g1469 = temp_output_5_0_g1469;
			#endif
			float ScaleOffset19_g1469 = _ScaleOffset;
			float clampResult64_g1469 = clamp( ( ScaleOffset19_g1469 + 1.0 ) , 0.0 , 7.0 );
			v.vertex.xyz += ( ( ( staticSwitch72_g1469 * clampResult64_g1469 ) + Scale_Pivot15_g1469 ) - ase_positionOS );
			v.vertex.w = 1;
			float2 TerrainPosition56_g1474 = ( Nicrom_TerrainPosition + float2( 1,1 ) );
			float2 TerrainPosition4_g1478 = TerrainPosition56_g1474;
			float TerrainSize55_g1474 = Nicrom_TerrainSize;
			float TerrainSize2_g1478 = TerrainSize55_g1474;
			float3 appendResult28_g1475 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 LocalPivot_Color15_g1474 = -appendResult28_g1475;
			float3 objToWorld11_g1477 = mul( unity_ObjectToWorld, float4( LocalPivot_Color15_g1474, 1 ) ).xyz;
			float2 appendResult10_g1477 = (float2(objToWorld11_g1477.x , objToWorld11_g1477.z));
			o.vertexToFrag19_g1478 = tex2Dlod( Nicrom_TerrainColorMap, float4( ( ( ( 1.0 - TerrainPosition4_g1478 ) / TerrainSize2_g1478 ) + ( ( TerrainSize2_g1478 / ( TerrainSize2_g1478 * TerrainSize2_g1478 ) ) * appendResult10_g1477 ) ), 0, 0.0) );
			o.vertexToFrag230_g1474 = ase_positionOS.y;
			#ifdef _SCALEVARIATION_ON
				float staticSwitch73_g1469 = smoothstepResult56_g1469;
			#else
				float staticSwitch73_g1469 = 0.0;
			#endif
			o.vertexToFrag71_g1469 = staticSwitch73_g1469;
			float3 customSurfaceDepth3_g1479 = ase_positionOS;
			o.customSurfaceDepth3_g1479 = -UnityObjectToViewPos( customSurfaceDepth3_g1479 ).z;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float Debug_Target203_g1474 = _Debug;
			float3 FlowerColor1B66_g1474 = _FlowerColor1B;
			float3 FlowerColor1A65_g1474 = _FlowerColor1A;
			float2 uv_ColorMask1 = i.uv_texcoord * _ColorMask1_ST.xy + _ColorMask1_ST.zw;
			float4 tex2DNode31_g1474 = tex2D( _ColorMask1, uv_ColorMask1 );
			float ColorMask1_R37_g1474 = tex2DNode31_g1474.r;
			float3 lerpResult87_g1474 = lerp( FlowerColor1B66_g1474 , FlowerColor1A65_g1474 , ColorMask1_R37_g1474);
			float3 FlowerColor1_F197_g1474 = lerpResult87_g1474;
			float3 FlowerColor2B68_g1474 = _FlowerColor2B;
			float3 FlowerColor2A67_g1474 = _FlowerColor2A;
			float3 lerpResult88_g1474 = lerp( FlowerColor2B68_g1474 , FlowerColor2A67_g1474 , ColorMask1_R37_g1474);
			float3 FlowerColor2_F198_g1474 = lerpResult88_g1474;
			float CM2_GVToggle213_g1474 = _ColorMask2GV;
			float lerpResult219_g1474 = lerp( _ColorMask2SharpMin , Nicrom_Flower_CM2_SharpMin , CM2_GVToggle213_g1474);
			float ColorMask2SharpMin98_g1474 = lerpResult219_g1474;
			float lerpResult221_g1474 = lerp( _ColorMask2SharpMax , Nicrom_Flower_CM2_SharpMax , CM2_GVToggle213_g1474);
			float ColorMask2SharpMax92_g1474 = lerpResult221_g1474;
			float3 appendResult28_g1475 = (float3(i.uv2_texcoord2.x , 0.0 , i.uv2_texcoord2.y));
			float3 LocalPivot_Color15_g1474 = -appendResult28_g1475;
			float3 objToWorld11_g1476 = mul( unity_ObjectToWorld, float4( LocalPivot_Color15_g1474, 1 ) ).xyz;
			float2 appendResult10_g1476 = (float2(objToWorld11_g1476.x , objToWorld11_g1476.z));
			float lerpResult215_g1474 = lerp( _ColorMask2Tiling , Nicrom_Flower_CM2_Tilling , CM2_GVToggle213_g1474);
			float ColorMask2Tiling21_g1474 = lerpResult215_g1474;
			float2 WorldSpaceUVs187_g1474 = ( appendResult10_g1476 * ColorMask2Tiling21_g1474 );
			float4 tex2DNode43_g1474 = tex2D( _ColorMask2, WorldSpaceUVs187_g1474 );
			float ColorMask2Noise78_g1474 = tex2DNode43_g1474.r;
			float smoothstepResult119_g1474 = smoothstep( ColorMask2SharpMin98_g1474 , ColorMask2SharpMax92_g1474 , ColorMask2Noise78_g1474);
			float ColorMask2Opacity122_g1474 = _ColorMask2Opacity;
			float lerpResult126_g1474 = lerp( 0.0 , smoothstepResult119_g1474 , ColorMask2Opacity122_g1474);
			float ColorMask2_F184_g1474 = lerpResult126_g1474;
			float3 lerpResult130_g1474 = lerp( FlowerColor1_F197_g1474 , FlowerColor2_F198_g1474 , ColorMask2_F184_g1474);
			#if defined( _FLOWERCOLORS_TWO )
				float3 staticSwitch196_g1474 = FlowerColor1_F197_g1474;
			#elif defined( _FLOWERCOLORS_FOUR )
				float3 staticSwitch196_g1474 = lerpResult130_g1474;
			#else
				float3 staticSwitch196_g1474 = FlowerColor1_F197_g1474;
			#endif
			float3 FlowerColor134_g1474 = staticSwitch196_g1474;
			float3 StemColorBottom93_g1474 = _StemColorBottom;
			float4 TerrainColor86_g1474 = i.vertexToFrag19_g1478;
			float TerrainBlendBottom97_g1474 = _BWTBottom;
			float IsTerrainAlbedoAssigned181_g1474 = step( 8.0 , Nicrom_TerrainColorMap_TexelSize.z );
			float lerpResult176_g1474 = lerp( 0.0 , TerrainBlendBottom97_g1474 , IsTerrainAlbedoAssigned181_g1474);
			float TerrainBlendBottom_F179_g1474 = lerpResult176_g1474;
			float4 lerpResult114_g1474 = lerp( float4( StemColorBottom93_g1474 , 0.0 ) , TerrainColor86_g1474 , TerrainBlendBottom_F179_g1474);
			#ifdef _BLENDWITHTERRAIN_ON
				float4 staticSwitch124_g1474 = lerpResult114_g1474;
			#else
				float4 staticSwitch124_g1474 = float4( StemColorBottom93_g1474 , 0.0 );
			#endif
			float3 StemColorTop91_g1474 = _StemColorTop;
			float TerrainBlendTop96_g1474 = _BWTTop;
			float lerpResult177_g1474 = lerp( 0.0 , TerrainBlendTop96_g1474 , IsTerrainAlbedoAssigned181_g1474);
			float TerrainBlendTop_F178_g1474 = lerpResult177_g1474;
			float4 lerpResult115_g1474 = lerp( float4( StemColorTop91_g1474 , 0.0 ) , TerrainColor86_g1474 , TerrainBlendTop_F178_g1474);
			#ifdef _BLENDWITHTERRAIN_ON
				float4 staticSwitch123_g1474 = lerpResult115_g1474;
			#else
				float4 staticSwitch123_g1474 = float4( StemColorTop91_g1474 , 0.0 );
			#endif
			float StemColorMaskStart112_g1474 = _StemColorMaskStart;
			float StemColorMaskEnd113_g1474 = _StemColorMaskEnd;
			float VertexPos_Y231_g1474 = i.vertexToFrag230_g1474;
			float smoothstepResult125_g1474 = smoothstep( StemColorMaskStart112_g1474 , StemColorMaskEnd113_g1474 , VertexPos_Y231_g1474);
			float4 lerpResult129_g1474 = lerp( staticSwitch124_g1474 , staticSwitch123_g1474 , smoothstepResult125_g1474);
			float4 StemColor133_g1474 = lerpResult129_g1474;
			float ColorMask1_G183_g1474 = tex2DNode31_g1474.g;
			float4 lerpResult149_g1474 = lerp( float4( FlowerColor134_g1474 , 0.0 ) , StemColor133_g1474 , ColorMask1_G183_g1474);
			float FlowerStemToggle145_g1474 = _STEM;
			float4 lerpResult158_g1474 = lerp( float4( FlowerColor134_g1474 , 0.0 ) , lerpResult149_g1474 , FlowerStemToggle145_g1474);
			float2 uv_Albedo137_g1474 = i.uv_texcoord;
			float4 tex2DNode137_g1474 = tex2D( _Albedo, uv_Albedo137_g1474 );
			float4 AlbedoTex144_g1474 = tex2DNode137_g1474;
			float4 Albedo203_g1474 = ( lerpResult158_g1474 * AlbedoTex144_g1474 );
			float ColorMask1R203_g1474 = ColorMask1_R37_g1474;
			float ColorMask1G203_g1474 = ColorMask1_G183_g1474;
			#if defined( _FLOWERCOLORS_TWO )
				float staticSwitch208_g1474 = 0.0;
			#elif defined( _FLOWERCOLORS_FOUR )
				float staticSwitch208_g1474 = ColorMask2_F184_g1474;
			#else
				float staticSwitch208_g1474 = 0.0;
			#endif
			float ColorMask2203_g1474 = staticSwitch208_g1474;
			float ScaleVarNoise2237 = i.vertexToFrag71_g1469;
			float ScaleVarNoise203_g1474 = ScaleVarNoise2237;
			float4 localDebug203_g1474 = Debug203_g1474( Debug_Target203_g1474 , Albedo203_g1474 , ColorMask1R203_g1474 , ColorMask1G203_g1474 , ColorMask2203_g1474 , ScaleVarNoise203_g1474 );
			o.Albedo = localDebug203_g1474.xyz;
			float temp_output_2300_0 = 0.0;
			o.Metallic = temp_output_2300_0;
			o.Smoothness = temp_output_2300_0;
			o.Alpha = 1;
			float temp_output_31_0_g1479 = tex2DNode137_g1474.a;
			float DF_Length_Local38_g1479 = _DistanceFadeLength;
			float DF_Length_Global45_g1479 = Nicrom_Flower_DF_Length;
			float DF_Start_Global43_g1479 = Nicrom_Flower_DF_Start;
			float lerpResult49_g1479 = lerp( 0.0 , _DistanceFadeUseGV , step( 0.1 , DF_Start_Global43_g1479 ));
			float DF_UseGV28_g1479 = lerpResult49_g1479;
			float lerpResult26_g1479 = lerp( DF_Length_Local38_g1479 , DF_Length_Global45_g1479 , DF_UseGV28_g1479);
			float DistanceFadeLength23_g1479 = lerpResult26_g1479;
			float DF_Start_Local36_g1479 = _DistanceFadeStart;
			float lerpResult20_g1479 = lerp( DF_Start_Local36_g1479 , DF_Start_Global43_g1479 , DF_UseGV28_g1479);
			float DistanceFadeStart27_g1479 = lerpResult20_g1479;
			float cameraDepthFade3_g1479 = (( i.customSurfaceDepth3_g1479 -_ProjectionParams.y - DistanceFadeStart27_g1479 ) / DistanceFadeLength23_g1479);
			#ifdef _DISTANCEFADE_ON
				float staticSwitch33_g1479 = ( temp_output_31_0_g1479 * saturate( ( 1.0 - cameraDepthFade3_g1479 ) ) );
			#else
				float staticSwitch33_g1479 = temp_output_31_0_g1479;
			#endif
			clip( staticSwitch33_g1479 - _AlphaCutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Flower"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2292;2560,2864;Inherit;False;Nicrom - Flower - Motion - GP;-1;;1394;0947e61a284d6ce44bc8a21d32d9ac74;0;0;7;FLOAT;10;FLOAT;17;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;19;FLOAT;9
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2298;2528,3088;Inherit;False;Nicrom - Pivot From UV1 - Local;-1;;1444;df723c9d5f0b2944f9c2a494e9780ebb;0;0;1;FLOAT3;33
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2295;2880,2864;Inherit;False;Nicrom - Motion;30;;1445;ba60642b1d9af614f93c28cb2553ff1c;0;8;179;FLOAT;0;False;243;FLOAT;1;False;178;FLOAT;0;False;180;FLOAT;0;False;184;FLOAT;0;False;244;FLOAT;1;False;185;FLOAT;0;False;238;FLOAT3;0,0,0;False;2;FLOAT3;0;COLOR;215
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2296;3296,2864;Inherit;False;Nicrom - Slope Correction;64;;1457;af072765142b7b4418aadc0762673233;0;2;87;FLOAT3;0,0,0;False;93;FLOAT4;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2299;3616,2864;Inherit;False;Nicrom - Scale;68;;1469;8d53ba1ace8e1014986c3779ab835fd1;0;1;13;FLOAT3;0,0,0;False;2;FLOAT3;0;FLOAT;70
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2237;3968,3024;Inherit;False;ScaleVarNoise;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2238;3072,2560;Inherit;False;2237;ScaleVarNoise;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2251;3328,2704;Inherit;False;Nicrom - Flower - DF - GP;-1;;1473;3a564424836b8a54ba36421e5ea0ba33;0;0;2;FLOAT;0;FLOAT;3
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2290;3296,2560;Inherit;False;Nicrom - Flower - Main;1;;1474;ba91e28e4f998ef49a560b850e8e9087;0;1;211;FLOAT;0;False;2;FLOAT4;0;FLOAT;164
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1330;-19002.03,10716.32;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1328;-19355.95,10790.4;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2191;3968,3104;Inherit;False;Property;_AlphaCutoff;Alpha Cutoff;0;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2228;3616,2704;Inherit;False;Nicrom - Distance Fade;25;;1479;05e2fd54e656b694286271db4b0312fc;0;3;31;FLOAT;0;False;34;FLOAT;0;False;35;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2300;3712,2624;Inherit;False;Constant;_Float3;Float 3;9;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;0;3968,2560;Float;False;True;-1;5;Nicrom.CMI_Flower;0;0;Standard;Nicrom/ASE/Vegetation/Flower;False;False;False;False;False;False;True;False;False;False;False;False;True;False;False;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;True;0;True;Opaque;;AlphaTest;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;True;_AlphaCutoff;1;Pragma;multi_compile_instancing;False;;Custom;False;0;0;;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2295;179;2292;10
WireConnection;2295;243;2292;17
WireConnection;2295;178;2292;6
WireConnection;2295;180;2292;7
WireConnection;2295;184;2292;8
WireConnection;2295;244;2292;19
WireConnection;2295;185;2292;9
WireConnection;2295;238;2298;33
WireConnection;2296;87;2295;0
WireConnection;2296;93;2295;215
WireConnection;2299;13;2296;0
WireConnection;2237;0;2299;70
WireConnection;2290;211;2238;0
WireConnection;2228;31;2290;164
WireConnection;2228;34;2251;0
WireConnection;2228;35;2251;3
WireConnection;0;0;2290;0
WireConnection;0;3;2300;0
WireConnection;0;4;2300;0
WireConnection;0;10;2228;0
WireConnection;0;11;2299;0
ASEEND*/
//CHKSM=73F4B42491AF19B11FCDF456AF8827854D3BD708