// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Vegetation/Grass"
{
	Properties
	{
		_AlphaCutoff( "Alpha Cutoff", Range( 0, 1 ) ) = 0.5
		[KeywordEnum( Two,Three,Four )] _Colors( "Colors", Float ) = 1
		_Color1A( "Color 1A", Color ) = ( 0.5254902, 0.6588235, 0.1960784 )
		_Color1B( "Color 1B", Color ) = ( 0.4352941, 0.6039216, 0.01960784 )
		_Color2A( "Color 2A", Color ) = ( 0.5254902, 0.6588235, 0.1960784 )
		_Color2B( "Color 2B", Color ) = ( 0.4352941, 0.6039216, 0.01960784 )
		[KeywordEnum( A,B )] _ColorBlendingMode( "Color Blending Mode", Float ) = 0
		[Enum(None,0,Color Mask 1,1,Color Mask 2,2,Color Mask 3,3,Motion Wave,4,Scale Var Noise,5)] _Debug( "Debug", Float ) = 0
		[SingleLineTexture][Space] _Albedo( "Albedo", 2D ) = "white" {}
		_Metallic( "Metallic", Range( 0, 1 ) ) = 0
		[SingleLineTexture] _ColorMask1( "Color Mask 1", 2D ) = "white" {}
		_Smoothness( "Smoothness", Range( 0, 1 ) ) = 0
		[SingleLineTexture] _ColorMask2( "Color Mask 2", 2D ) = "white" {}
		[KeywordEnum( Texture,Vertex )] _ColorMask1Source( "Color Mask 1 Source", Float ) = 0
		_ColorMask1Start( "Color Mask 1 Start", Range( 0, 2 ) ) = 0.3
		_ColorMask3Start( "Color Mask 3 Start", Range( 0, 2 ) ) = 0.3
		_ColorMask1End( "Color Mask 1 End", Range( 0, 2 ) ) = 1
		_ColorMask3End( "Color Mask 3 End", Range( 0, 2 ) ) = 1
		_ColorMask2Tiling( "Color Mask 2 Tiling", Range( 0.0001, 4 ) ) = 0.0001
		_ColorMask2Speed( "Color Mask 2 Speed", Range( 0, 3 ) ) = 1
		_ColorMask2SharpnessMin( "Color Mask 2 Sharpness Min", Range( 0, 1 ) ) = 0.2
		_ColorMask2SharpnessMax( "Color Mask 2 Sharpness Max", Range( 0, 1 ) ) = 0.45
		[Toggle( _BLENDWITHTERRAIN_ON )] _BlendWithTerrain( "Blend With Terrain", Float ) = 0
		_BWTTop( "BWT Top", Range( 0, 1 ) ) = 0
		_BWTBottom( "BWT Bottom", Range( 0, 1 ) ) = 1
		[Toggle] _BWTMask( "BWT Mask", Float ) = 0
		_BWTMaskStart( "BWT Mask Start", Range( 0, 2 ) ) = 1
		_BWTMaskEnd( "BWT Mask End", Range( 0, 2 ) ) = 1
		_ColorMask2Opacity( "Color Mask 2 Opacity", Range( 0, 1 ) ) = 1
		[Toggle] _ColorMask2GV( "Color Mask 2 GV", Float ) = 0
		[Space][Toggle( _DISTANCEFADE_ON )] _DistanceFade( "Distance Fade", Float ) = 1
		[Toggle] _DistanceFadeUseGV( "DistanceFade Use GV", Float ) = 0
		_DistanceFadeStart( "Distance Fade Start", Range( 0, 2000 ) ) = 50
		_DistanceFadeLength( "Distance Fade Length", Range( 0, 20000 ) ) = 50
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
		[KeywordEnum( Simple,Accurate )] _MMBendingMethod( "MM Bending Method", Float ) = 0
		[SingleLineTexture][Space] _MotionNoise( "Motion Noise", 2D ) = "white" {}
		_StaticNoiseTiling( "Static Noise Tiling", Range( 0.0001, 1 ) ) = 1
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
		#pragma target 3.5
		#pragma shader_feature_local_fragment _BLENDWITHTERRAIN_ON
		#pragma shader_feature_local_vertex _SCALEVARIATION_ON
		#pragma shader_feature_local_vertex _SLOPECORRECTION_ON
		#pragma shader_feature_local _MMBENDINGMETHOD_SIMPLE _MMBENDINGMETHOD_ACCURATE
		#pragma shader_feature_local _COLORS_TWO _COLORS_THREE _COLORS_FOUR
		#pragma shader_feature_local _COLORMASK1SOURCE_TEXTURE _COLORMASK1SOURCE_VERTEX
		#pragma shader_feature_local _COLORBLENDINGMODE_A _COLORBLENDINGMODE_B
		#pragma shader_feature_local _DISTANCEFADE_ON
		#define ASE_VERSION 19901
		#pragma multi_compile_instancing
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexToFrag19_g1450;
			float vertexToFrag421_g1448;
			float2 uv2_texcoord2;
			float4 vertexColor : COLOR;
			float vertexToFrag71_g1444;
			float customSurfaceDepth3_g1455;
		};

		uniform float Nicrom_Grass_DF_Start;
		uniform float Nicrom_Grass_DF_Length;
		uniform half _MMDirectionAngle;
		uniform half Nicrom_WindDirAngle;
		uniform half _GVDirectionAngle;
		uniform half _MMDirectionShift;
		uniform half _MMDirectionShiftOffset;
		uniform sampler2D _MotionNoise;
		uniform float _StaticNoiseTiling;
		uniform float Nicrom_MM_Time_Grass;
		uniform float _GVTime;
		uniform half Nicrom_ApplicationIsPlaying;
		uniform float Nicrom_MM_SpeedScale_Grass;
		uniform half _MMDirectionShiftSpeed;
		uniform half _MMDirectionShiftNoiseScale;
		uniform half _MMBendingOffset;
		uniform half _MMBending;
		uniform float Nicrom_MM_BendScale_Grass;
		uniform half _GVBendingScale;
		uniform half _MMAmplitudeOffset;
		uniform half _MMAmplitude;
		uniform float Nicrom_MM_AmpScale_Grass;
		uniform half _GVAmplitudeScale;
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
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float3 _Color1A;
		uniform sampler2D Nicrom_TerrainColorMap;
		uniform float2 Nicrom_TerrainPosition;
		uniform float Nicrom_TerrainSize;
		uniform float _BWTTop;
		float4 Nicrom_TerrainColorMap_TexelSize;
		uniform float _BWTMaskStart;
		uniform float _BWTMaskEnd;
		uniform float _BWTMask;
		uniform float3 _Color1B;
		uniform float _BWTBottom;
		uniform sampler2D _ColorMask1;
		uniform float4 _ColorMask1_ST;
		uniform float _ColorMask1End;
		uniform float _ColorMask1Start;
		uniform float3 _Color2A;
		uniform float _ColorMask2SharpnessMin;
		uniform float Nicrom_Grass_CM2_SharpMin;
		uniform float _ColorMask2GV;
		uniform float _ColorMask2SharpnessMax;
		uniform float Nicrom_Grass_CM2_SharpMax;
		uniform sampler2D _ColorMask2;
		uniform float _ColorMask2Tiling;
		uniform float Nicrom_Grass_CM2_Tilling;
		uniform float2 Nicrom_Grass_CM2_UVOffset;
		uniform float _ColorMask2Speed;
		uniform float Nicrom_Grass_CM2_Speed;
		uniform float _ColorMask2Opacity;
		uniform float _ColorMask3Start;
		uniform float _ColorMask3End;
		uniform float3 _Color2B;
		uniform float _Metallic;
		uniform float _Smoothness;
		uniform float _DistanceFadeLength;
		uniform float _DistanceFadeUseGV;
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


		float4 Debug308_g1448( float Debug_Target, float4 Albedo, float ColorMask1, float ColorMask2, float ColorMask3, float MotionWave, float ScaleVarNoise )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return ColorMask1;
			else if(Debug_Target ==2)
			    return ColorMask2;
			else if(Debug_Target ==3)
			    return ColorMask3;
			else if(Debug_Target ==4)
			    return MotionWave;
			else
			    return ScaleVarNoise;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float lerpResult56_g1436 = lerp( _MMDirectionAngle , Nicrom_WindDirAngle , _GVDirectionAngle);
			float MM_DirectionAngle35_g1434 = lerpResult56_g1436;
			float MM_DirectionShift68_g1434 = _MMDirectionShift;
			float MM_DirectionShiftOffset69_g1434 = _MMDirectionShiftOffset;
			float3 appendResult28_g1441 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 MM_LocalPivot3_g1434 = -appendResult28_g1441;
			float3 objToWorld11_g1438 = mul( unity_ObjectToWorld, float4( MM_LocalPivot3_g1434, 1 ) ).xyz;
			float2 appendResult10_g1438 = (float2(objToWorld11_g1438.x , objToWorld11_g1438.z));
			float2 WorldSpaceUVs9_g1434 = appendResult10_g1438;
			float StaticNoiseTiling11_g1434 = _StaticNoiseTiling;
			float4 temp_output_16_0_g1434 = tex2Dlod( _MotionNoise, float4( ( WorldSpaceUVs9_g1434 * StaticNoiseTiling11_g1434 ), 0, 0.0) );
			float4 WorldSpaceStaticNoise23_g1434 = temp_output_16_0_g1434;
			float4 StaticWorldNoise55_g1439 = WorldSpaceStaticNoise23_g1434;
			float3 objToWorld50_g1439 = mul( unity_ObjectToWorld, float4( MM_LocalPivot3_g1434, 1 ) ).xyz;
			float GVTime160_g1434 = _GVTime;
			float lerpResult146_g1434 = lerp( _Time.y , Nicrom_MM_Time_Grass , GVTime160_g1434);
			float ApplicationIsPlaying227_g1434 = Nicrom_ApplicationIsPlaying;
			float lerpResult221_g1434 = lerp( _Time.y , lerpResult146_g1434 , ApplicationIsPlaying227_g1434);
			float MM_Time140_g1434 = lerpResult221_g1434;
			float Time76_g1439 = MM_Time140_g1434;
			float temp_output_205_0_g1434 = Nicrom_MM_SpeedScale_Grass;
			float lerpResult208_g1434 = lerp( temp_output_205_0_g1434 , 1.0 , GVTime160_g1434);
			float lerpResult210_g1434 = lerp( temp_output_205_0_g1434 , lerpResult208_g1434 , ApplicationIsPlaying227_g1434);
			float MM_SpeedScale206_g1434 = lerpResult210_g1434;
			float SpeedScale_RA80_g1439 = MM_SpeedScale206_g1434;
			float MM_DirectionShiftSpeed70_g1434 = _MMDirectionShiftSpeed;
			float MM_DirectionShiftNoiseScale71_g1434 = _MMDirectionShiftNoiseScale;
			float temp_output_11_0_g1439 = radians( ( ( MM_DirectionAngle35_g1434 + ( ( MM_DirectionShift68_g1434 + ( MM_DirectionShiftOffset69_g1434 * (StaticWorldNoise55_g1439).x ) ) * sin( ( ( objToWorld50_g1439.x + objToWorld50_g1439.z ) + ( ( Time76_g1439 * ( SpeedScale_RA80_g1439 * MM_DirectionShiftSpeed70_g1434 ) ) + ( ( 2.0 * UNITY_PI ) * ( (StaticWorldNoise55_g1439).z * MM_DirectionShiftNoiseScale71_g1434 ) ) ) ) ) ) ) * -1.0 ) );
			float3 appendResult14_g1439 = (float3(cos( temp_output_11_0_g1439 ) , 0.0 , sin( temp_output_11_0_g1439 )));
			float3 worldToObj35_g1439 = mul( unity_WorldToObject, float4( appendResult14_g1439, 1 ) ).xyz;
			float3 worldToObj36_g1439 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult34_g1439 = normalize( (( worldToObj35_g1439 - worldToObj36_g1439 )).xyz );
			float3 MM_RotationAxis101_g1434 = normalizeResult34_g1439;
			float4 StaticWorldNoise31_g1440 = WorldSpaceStaticNoise23_g1434;
			float MM_BendingOfset73_g1434 = _MMBendingOffset;
			float MM_Bending67_g1434 = _MMBending;
			float GVBendingScale164_g1434 = _GVBendingScale;
			float lerpResult155_g1434 = lerp( 1.0 , Nicrom_MM_BendScale_Grass , GVBendingScale164_g1434);
			float MM_BendingScale141_g1434 = lerpResult155_g1434;
			float MM_AmplitudeOffset62_g1434 = _MMAmplitudeOffset;
			float MM_Amplitude61_g1434 = _MMAmplitude;
			float GVAmplitudeScale162_g1434 = _GVAmplitudeScale;
			float lerpResult152_g1434 = lerp( 1.0 , Nicrom_MM_AmpScale_Grass , GVAmplitudeScale162_g1434);
			float MM_AmplitudeScale139_g1434 = lerpResult152_g1434;
			float3 objToWorld170_g1440 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float Time167_g1440 = MM_Time140_g1434;
			float MM_Speed63_g1434 = _MMSpeed;
			float Speed125_g1440 = MM_Speed63_g1434;
			float SpeedScale_RotAng201_g1440 = MM_SpeedScale206_g1434;
			float MM_SineWaveLength64_g1434 = _MMSineWaveLength;
			float WaveLength63_g1440 = MM_SineWaveLength64_g1434;
			float MM_PhaseShiftSource26_g1434 = _MMPhaseShiftSource;
			float lerpResult38_g1434 = lerp( v.color.a , (WorldSpaceStaticNoise23_g1434).g , MM_PhaseShiftSource26_g1434);
			float MM_PhaseShiftScale34_g1434 = _MMPhaseShiftScale;
			float MM_PhaseShift60_g1434 = ( lerpResult38_g1434 * MM_PhaseShiftScale34_g1434 );
			float PhaseShift127_g1440 = MM_PhaseShift60_g1434;
			float temp_output_20_0_g1440 = sin( ( ( ( objToWorld170_g1440.x + objToWorld170_g1440.z ) + ( ( Time167_g1440 * ( ( Speed125_g1440 * SpeedScale_RotAng201_g1440 ) * WaveLength63_g1440 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift127_g1440 ) ) ) * ( ( 2.0 * UNITY_PI ) / WaveLength63_g1440 ) ) );
			float3 ase_positionOS = v.vertex.xyz;
			float MM_ObjectHeight66_g1434 = _MMObjectHeight;
			float3 gammaToLinear56_g1440 = GammaToLinearSpace( v.color.rgb );
			float MM_ObjectHeightSource65_g1434 = _MMObjectHeightSource;
			float lerpResult57_g1440 = lerp( ( ase_positionOS.y / MM_ObjectHeight66_g1434 ) , (gammaToLinear56_g1440).x , MM_ObjectHeightSource65_g1434);
			float BendingMask189_g1440 = lerpResult57_g1440;
			float MM_RotationAngle102_g1434 = radians( ( ( ( ( ( (StaticWorldNoise31_g1440).y * MM_BendingOfset73_g1434 ) + MM_Bending67_g1434 ) * MM_BendingScale141_g1434 ) + ( ( ( ( (StaticWorldNoise31_g1440).x * MM_AmplitudeOffset62_g1434 ) + MM_Amplitude61_g1434 ) * MM_AmplitudeScale139_g1434 ) * temp_output_20_0_g1440 ) ) * BendingMask189_g1440 ) );
			float3 appendResult103_g1434 = (float3(ase_positionOS.x , 0.0 , ase_positionOS.z));
			float3 VertexPosition179_g1434 = ase_positionOS;
			float3 rotatedValue108_g1434 = RotateAroundAxis( appendResult103_g1434, VertexPosition179_g1434, MM_RotationAxis101_g1434, MM_RotationAngle102_g1434 );
			float3 RotationAxis56_g1435 = MM_RotationAxis101_g1434;
			float RotationAngle54_g1435 = MM_RotationAngle102_g1434;
			float3 LocalPivotPos60_g1435 = MM_LocalPivot3_g1434;
			float3 break62_g1435 = LocalPivotPos60_g1435;
			float VertexPos_Y67_g1435 = ase_positionOS.y;
			float3 appendResult45_g1435 = (float3(break62_g1435.x , VertexPos_Y67_g1435 , break62_g1435.z));
			float3 VertexPos66_g1435 = ase_positionOS;
			float3 rotatedValue30_g1435 = RotateAroundAxis( appendResult45_g1435, VertexPos66_g1435, RotationAxis56_g1435, RotationAngle54_g1435 );
			float3 DetailMotionVO73_g1435 = float3( 0,0,0 );
			float3 rotatedValue34_g1435 = RotateAroundAxis( LocalPivotPos60_g1435, ( rotatedValue30_g1435 + DetailMotionVO73_g1435 ), RotationAxis56_g1435, RotationAngle54_g1435 );
			#if defined( _MMBENDINGMETHOD_SIMPLE )
				float3 staticSwitch186_g1434 = ( ( rotatedValue108_g1434 - VertexPosition179_g1434 ) * step( 0.01 , (VertexPosition179_g1434).y ) );
			#elif defined( _MMBENDINGMETHOD_ACCURATE )
				float3 staticSwitch186_g1434 = ( ( rotatedValue34_g1435 - VertexPos66_g1435 ) * step( 0.01 , VertexPos_Y67_g1435 ) );
			#else
				float3 staticSwitch186_g1434 = ( ( rotatedValue108_g1434 - VertexPosition179_g1434 ) * step( 0.01 , (VertexPosition179_g1434).y ) );
			#endif
			float3 LocalVertexOffset89_g1442 = staticSwitch186_g1434;
			float3 appendResult15_g1442 = (float3(0.0 , 1.0 , 0.0));
			float3 objToWorld98_g1442 = mul( unity_ObjectToWorld, float4( appendResult15_g1442, 1 ) ).xyz;
			float3 objToWorld102_g1442 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 break20_g1442 = ( objToWorld98_g1442 - objToWorld102_g1442 );
			float3 appendResult24_g1442 = (float3(-break20_g1442.z , 0.0 , break20_g1442.x));
			float3 appendResult3_g1442 = (float3(0.0 , 1.0 , 0.0));
			float3 objToWorld100_g1442 = mul( unity_ObjectToWorld, float4( appendResult3_g1442, 1 ) ).xyz;
			float3 objToWorld106_g1442 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 temp_output_107_0_g1442 = ( objToWorld100_g1442 - objToWorld106_g1442 );
			float3 break108_g1442 = temp_output_107_0_g1442;
			float3 lerpResult84_g1442 = lerp( float3( 0, 1, 0 ) , temp_output_107_0_g1442 , step( 0.001 , ( abs( break108_g1442.x ) + abs( break108_g1442.z ) ) ));
			float3 normalizeResult7_g1442 = ASESafeNormalize( lerpResult84_g1442 );
			float dotResult9_g1442 = dot( normalizeResult7_g1442 , float3( 0, 1, 0 ) );
			float temp_output_12_0_g1442 = acos( dotResult9_g1442 );
			float NaNPrevention21_g1442 = step( 0.01 , abs( ( temp_output_12_0_g1442 * ( 180.0 / UNITY_PI ) ) ) );
			float3 lerpResult26_g1442 = lerp( float3( 1, 0, 0 ) , appendResult24_g1442 , NaNPrevention21_g1442);
			float3 worldToObj99_g1442 = mul( unity_WorldToObject, float4( lerpResult26_g1442, 1 ) ).xyz;
			float3 worldToObj105_g1442 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult49_g1442 = normalize( ( worldToObj99_g1442 - worldToObj105_g1442 ) );
			float3 RotationAxis30_g1442 = normalizeResult49_g1442;
			float4 WorldSpaceNoise126_g1442 = temp_output_16_0_g1434;
			float SlopeCorrectionOffset120_g1442 = _SlopeCorrectionOffset;
			float SlopeCorrectionMagnitude119_g1442 = _SlopeCorrectionMagnitude;
			float RotationAngle29_g1442 = ( saturate( (  (0.0 + ( (WorldSpaceNoise126_g1442).x - 0.0 ) * ( SlopeCorrectionOffset120_g1442 - 0.0 ) / ( 1.0 - 0.0 ) ) + SlopeCorrectionMagnitude119_g1442 ) ) * temp_output_12_0_g1442 );
			float3 appendResult28_g1443 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 rotatedValue35_g1442 = RotateAroundAxis( -appendResult28_g1443, ( ase_positionOS + LocalVertexOffset89_g1442 ), RotationAxis30_g1442, RotationAngle29_g1442 );
			float3 lerpResult52_g1442 = lerp( LocalVertexOffset89_g1442 , ( rotatedValue35_g1442 - ase_positionOS ) , NaNPrevention21_g1442);
			#ifdef _SLOPECORRECTION_ON
				float3 staticSwitch123_g1442 = lerpResult52_g1442;
			#else
				float3 staticSwitch123_g1442 = LocalVertexOffset89_g1442;
			#endif
			float3 appendResult28_g1447 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 Scale_Pivot15_g1444 = -appendResult28_g1447;
			float3 temp_output_5_0_g1444 = ( ( staticSwitch123_g1442 + ase_positionOS ) - Scale_Pivot15_g1444 );
			float ScaleVartMin40_g1444 = _ScaleVarMin;
			float ScaleVarMax41_g1444 = _ScaleVarMax;
			float ScaleNoiseSharpnessMin59_g1444 = _ScaleVarNoiseSharpMin;
			float ScaleNoiseSharpnessMax60_g1444 = _ScaleVarNoiseSharpMax;
			float3 objToWorld11_g1446 = mul( unity_ObjectToWorld, float4( Scale_Pivot15_g1444, 1 ) ).xyz;
			float2 appendResult10_g1446 = (float2(objToWorld11_g1446.x , objToWorld11_g1446.z));
			float2 Scale_WorldSpaceUVs30_g1444 = appendResult10_g1446;
			float Scale_VarNoiseTiling23_g1444 = _ScaleVarNoiseTiling;
			float4 Scale_WorldSpaceNoise32_g1444 = tex2Dlod( _ScaleVarNoise, float4( ( Scale_WorldSpaceUVs30_g1444 * Scale_VarNoiseTiling23_g1444 ), 0, 0.0) );
			float smoothstepResult56_g1444 = smoothstep( ScaleNoiseSharpnessMin59_g1444 , ScaleNoiseSharpnessMax60_g1444 , (Scale_WorldSpaceNoise32_g1444).r);
			float lerpResult44_g1444 = lerp( ScaleVartMin40_g1444 , ScaleVarMax41_g1444 , smoothstepResult56_g1444);
			float ScaleVar47_g1444 = lerpResult44_g1444;
			float clampResult63_g1444 = clamp( ( ScaleVar47_g1444 + 1.0 ) , 0.0 , 7.0 );
			#ifdef _SCALEVARIATION_ON
				float3 staticSwitch72_g1444 = ( temp_output_5_0_g1444 * clampResult63_g1444 );
			#else
				float3 staticSwitch72_g1444 = temp_output_5_0_g1444;
			#endif
			float ScaleOffset19_g1444 = _ScaleOffset;
			float clampResult64_g1444 = clamp( ( ScaleOffset19_g1444 + 1.0 ) , 0.0 , 7.0 );
			v.vertex.xyz += ( ( ( staticSwitch72_g1444 * clampResult64_g1444 ) + Scale_Pivot15_g1444 ) - ase_positionOS );
			v.vertex.w = 1;
			float2 TerrainPosition29_g1448 = ( Nicrom_TerrainPosition + float2( 1,1 ) );
			float2 TerrainPosition4_g1450 = TerrainPosition29_g1448;
			float TerrainSize28_g1448 = Nicrom_TerrainSize;
			float TerrainSize2_g1450 = TerrainSize28_g1448;
			float3 appendResult28_g1449 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 temp_output_3_33_g1448 = -appendResult28_g1449;
			float3 LocalPivot6_g1448 = temp_output_3_33_g1448;
			float3 objToWorld11_g1453 = mul( unity_ObjectToWorld, float4( LocalPivot6_g1448, 1 ) ).xyz;
			float2 appendResult10_g1453 = (float2(objToWorld11_g1453.x , objToWorld11_g1453.z));
			o.vertexToFrag19_g1450 = tex2Dlod( Nicrom_TerrainColorMap, float4( ( ( ( 1.0 - TerrainPosition4_g1450 ) / TerrainSize2_g1450 ) + ( ( TerrainSize2_g1450 / ( TerrainSize2_g1450 * TerrainSize2_g1450 ) ) * appendResult10_g1453 ) ), 0, 0.0) );
			o.vertexToFrag421_g1448 = ase_positionOS.y;
			#ifdef _SCALEVARIATION_ON
				float staticSwitch73_g1444 = smoothstepResult56_g1444;
			#else
				float staticSwitch73_g1444 = 0.0;
			#endif
			o.vertexToFrag71_g1444 = staticSwitch73_g1444;
			float3 customSurfaceDepth3_g1455 = ase_positionOS;
			o.customSurfaceDepth3_g1455 = -UnityObjectToViewPos( customSurfaceDepth3_g1455 ).z;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float Debug_Target308_g1448 = _Debug;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode111_g1448 = tex2D( _Albedo, uv_Albedo );
			float4 FoliageTexture123_g1448 = tex2DNode111_g1448;
			float3 Color1A78_g1448 = _Color1A;
			float4 TerrainColor76_g1448 = i.vertexToFrag19_g1450;
			float BWT_Top44_g1448 = _BWTTop;
			float IsTerrainAlbedoAssigned36_g1448 = step( 8.0 , Nicrom_TerrainColorMap_TexelSize.z );
			float lerpResult62_g1448 = lerp( 0.0 , BWT_Top44_g1448 , IsTerrainAlbedoAssigned36_g1448);
			float BWT_MaskStart434_g1448 = _BWTMaskStart;
			float BWT_MaskEnd435_g1448 = _BWTMaskEnd;
			float VertexPos_Y430_g1448 = i.vertexToFrag421_g1448;
			float smoothstepResult273_g1448 = smoothstep( BWT_MaskStart434_g1448 , BWT_MaskEnd435_g1448 , VertexPos_Y430_g1448);
			float BWT_MaskToggle461_g1448 = _BWTMask;
			float lerpResult462_g1448 = lerp( 1.0 , ( 1.0 - smoothstepResult273_g1448 ) , BWT_MaskToggle461_g1448);
			float BWT_Mask277_g1448 = lerpResult462_g1448;
			float lerpResult278_g1448 = lerp( 0.0 , lerpResult62_g1448 , BWT_Mask277_g1448);
			float BWT_Top_F74_g1448 = lerpResult278_g1448;
			float4 lerpResult104_g1448 = lerp( float4( Color1A78_g1448 , 0.0 ) , TerrainColor76_g1448 , BWT_Top_F74_g1448);
			#ifdef _BLENDWITHTERRAIN_ON
				float4 staticSwitch114_g1448 = lerpResult104_g1448;
			#else
				float4 staticSwitch114_g1448 = float4( Color1A78_g1448 , 0.0 );
			#endif
			float4 Color1A_Top_BWT167_g1448 = staticSwitch114_g1448;
			float3 Color1B81_g1448 = _Color1B;
			float BWT_Bottom45_g1448 = _BWTBottom;
			float lerpResult61_g1448 = lerp( 0.0 , BWT_Bottom45_g1448 , IsTerrainAlbedoAssigned36_g1448);
			float lerpResult281_g1448 = lerp( 0.0 , lerpResult61_g1448 , BWT_Mask277_g1448);
			float BWT_Bottom_F75_g1448 = lerpResult281_g1448;
			float4 lerpResult105_g1448 = lerp( float4( Color1B81_g1448 , 0.0 ) , TerrainColor76_g1448 , BWT_Bottom_F75_g1448);
			#ifdef _BLENDWITHTERRAIN_ON
				float4 staticSwitch115_g1448 = lerpResult105_g1448;
			#else
				float4 staticSwitch115_g1448 = float4( Color1B81_g1448 , 0.0 );
			#endif
			float4 Color1B_Bot_BWT169_g1448 = staticSwitch115_g1448;
			float2 uv_ColorMask1 = i.uv_texcoord * _ColorMask1_ST.xy + _ColorMask1_ST.zw;
			float ColorMask1_Tex66_g1448 = ( 1.0 - tex2D( _ColorMask1, uv_ColorMask1 ).r );
			float ColorMask1_End43_g1448 = _ColorMask1End;
			float ColorMask1_Start42_g1448 = _ColorMask1Start;
			float smoothstepResult427_g1448 = smoothstep( ColorMask1_End43_g1448 , ColorMask1_Start42_g1448 , VertexPos_Y430_g1448);
			#if defined( _COLORMASK1SOURCE_TEXTURE )
				float staticSwitch377_g1448 = ColorMask1_Tex66_g1448;
			#elif defined( _COLORMASK1SOURCE_VERTEX )
				float staticSwitch377_g1448 = smoothstepResult427_g1448;
			#else
				float staticSwitch377_g1448 = ColorMask1_Tex66_g1448;
			#endif
			float ColorMask1101_g1448 = staticSwitch377_g1448;
			float4 lerpResult226_g1448 = lerp( Color1A_Top_BWT167_g1448 , Color1B_Bot_BWT169_g1448 , ColorMask1101_g1448);
			float4 Colors2306_g1448 = lerpResult226_g1448;
			float3 Color2A82_g1448 = _Color2A;
			float4 lerpResult106_g1448 = lerp( float4( Color2A82_g1448 , 0.0 ) , TerrainColor76_g1448 , BWT_Top_F74_g1448);
			#ifdef _BLENDWITHTERRAIN_ON
				float4 staticSwitch117_g1448 = lerpResult106_g1448;
			#else
				float4 staticSwitch117_g1448 = float4( Color2A82_g1448 , 0.0 );
			#endif
			float4 Color2A_Top_BWT171_g1448 = staticSwitch117_g1448;
			float CM2_GVToggle400_g1448 = _ColorMask2GV;
			float lerpResult409_g1448 = lerp( _ColorMask2SharpnessMin , Nicrom_Grass_CM2_SharpMin , CM2_GVToggle400_g1448);
			float ColorMask2_SharpMin88_g1448 = lerpResult409_g1448;
			float lerpResult412_g1448 = lerp( _ColorMask2SharpnessMax , Nicrom_Grass_CM2_SharpMax , CM2_GVToggle400_g1448);
			float ColorMask2_SharpMax87_g1448 = lerpResult412_g1448;
			float3 appendResult28_g1449 = (float3(i.uv2_texcoord2.x , 0.0 , i.uv2_texcoord2.y));
			float3 temp_output_3_33_g1448 = -appendResult28_g1449;
			float3 objToWorld11_g1451 = mul( unity_ObjectToWorld, float4( temp_output_3_33_g1448, 1 ) ).xyz;
			float2 appendResult10_g1451 = (float2(objToWorld11_g1451.x , objToWorld11_g1451.z));
			float2 ColorMask2_WSUVs23_g1448 = appendResult10_g1451;
			float lerpResult402_g1448 = lerp( _ColorMask2Tiling , Nicrom_Grass_CM2_Tilling , CM2_GVToggle400_g1448);
			float ColorMask2_Tiling24_g1448 = lerpResult402_g1448;
			float2 CM2_UVOffset_GV159_g1448 = Nicrom_Grass_CM2_UVOffset;
			float lerpResult406_g1448 = lerp( _ColorMask2Speed , Nicrom_Grass_CM2_Speed , CM2_GVToggle400_g1448);
			float ColorMask2_Speed151_g1448 = lerpResult406_g1448;
			float ColorMask2_Noise85_g1448 = (tex2D( _ColorMask2, ( ( ColorMask2_WSUVs23_g1448 * ColorMask2_Tiling24_g1448 ) + ( CM2_UVOffset_GV159_g1448 * ColorMask2_Speed151_g1448 * 0.1 ) ) )).r;
			float smoothstepResult120_g1448 = smoothstep( ColorMask2_SharpMin88_g1448 , ColorMask2_SharpMax87_g1448 , ColorMask2_Noise85_g1448);
			float ColorMask2_Opacity415_g1448 = _ColorMask2Opacity;
			float ColorMask2_F196_g1448 = ( smoothstepResult120_g1448 * ColorMask2_Opacity415_g1448 );
			float4 lerpResult341_g1448 = lerp( Color1A_Top_BWT167_g1448 , Color2A_Top_BWT171_g1448 , ColorMask2_F196_g1448);
			float4 lerpResult344_g1448 = lerp( lerpResult341_g1448 , Color1B_Bot_BWT169_g1448 , ColorMask1101_g1448);
			float4 Colors3_BMA348_g1448 = lerpResult344_g1448;
			float ColorMask3_Start438_g1448 = _ColorMask3Start;
			float ColorMask3_End439_g1448 = _ColorMask3End;
			float smoothstepResult442_g1448 = smoothstep( ColorMask3_Start438_g1448 , ColorMask3_End439_g1448 , VertexPos_Y430_g1448);
			#if defined( _COLORBLENDINGMODE_A )
				float staticSwitch449_g1448 = 0.0;
			#elif defined( _COLORBLENDINGMODE_B )
				float staticSwitch449_g1448 = ( 1.0 - smoothstepResult442_g1448 );
			#else
				float staticSwitch449_g1448 = 0.0;
			#endif
			float ColorMask3446_g1448 = staticSwitch449_g1448;
			float4 lerpResult352_g1448 = lerp( Color1A_Top_BWT167_g1448 , Color1B_Bot_BWT169_g1448 , ColorMask3446_g1448);
			float4 lerpResult353_g1448 = lerp( lerpResult352_g1448 , float4( Color2A82_g1448 , 0.0 ) , ( 1.0 - ColorMask1_Tex66_g1448 ));
			float4 Colors3_BMB357_g1448 = lerpResult353_g1448;
			#if defined( _COLORBLENDINGMODE_A )
				float4 staticSwitch366_g1448 = Colors3_BMA348_g1448;
			#elif defined( _COLORBLENDINGMODE_B )
				float4 staticSwitch366_g1448 = Colors3_BMB357_g1448;
			#else
				float4 staticSwitch366_g1448 = Colors3_BMA348_g1448;
			#endif
			float4 Colors3362_g1448 = staticSwitch366_g1448;
			float3 Color2B83_g1448 = _Color2B;
			float4 lerpResult269_g1448 = lerp( float4( Color2B83_g1448 , 0.0 ) , TerrainColor76_g1448 , BWT_Bottom_F75_g1448);
			#ifdef _BLENDWITHTERRAIN_ON
				float4 staticSwitch270_g1448 = lerpResult269_g1448;
			#else
				float4 staticSwitch270_g1448 = float4( Color2B83_g1448 , 0.0 );
			#endif
			float4 Color2B_Bot_BWT271_g1448 = staticSwitch270_g1448;
			float4 lerpResult227_g1448 = lerp( Color2A_Top_BWT171_g1448 , Color2B_Bot_BWT271_g1448 , ColorMask1101_g1448);
			float4 lerpResult225_g1448 = lerp( Colors2306_g1448 , lerpResult227_g1448 , ColorMask2_F196_g1448);
			float4 Colors4_BMA256_g1448 = lerpResult225_g1448;
			float4 lerpResult242_g1448 = lerp( Color1A_Top_BWT167_g1448 , Color1B_Bot_BWT169_g1448 , ColorMask3446_g1448);
			float3 lerpResult249_g1448 = lerp( Color2A82_g1448 , Color2B83_g1448 , ColorMask2_F196_g1448);
			float4 lerpResult246_g1448 = lerp( lerpResult242_g1448 , float4( lerpResult249_g1448 , 0.0 ) , ( 1.0 - ColorMask1_Tex66_g1448 ));
			float4 Colors4_BMB257_g1448 = lerpResult246_g1448;
			#if defined( _COLORBLENDINGMODE_A )
				float4 staticSwitch373_g1448 = Colors4_BMA256_g1448;
			#elif defined( _COLORBLENDINGMODE_B )
				float4 staticSwitch373_g1448 = Colors4_BMB257_g1448;
			#else
				float4 staticSwitch373_g1448 = Colors4_BMA256_g1448;
			#endif
			float4 Colors4363_g1448 = staticSwitch373_g1448;
			#if defined( _COLORS_TWO )
				float4 staticSwitch303_g1448 = Colors2306_g1448;
			#elif defined( _COLORS_THREE )
				float4 staticSwitch303_g1448 = Colors3362_g1448;
			#elif defined( _COLORS_FOUR )
				float4 staticSwitch303_g1448 = Colors4363_g1448;
			#else
				float4 staticSwitch303_g1448 = Colors3362_g1448;
			#endif
			float4 Albedo453_g1448 = ( FoliageTexture123_g1448 * staticSwitch303_g1448 );
			float4 Albedo308_g1448 = Albedo453_g1448;
			#if defined( _COLORBLENDINGMODE_A )
				float staticSwitch456_g1448 = ( 1.0 - ColorMask1101_g1448 );
			#elif defined( _COLORBLENDINGMODE_B )
				float staticSwitch456_g1448 = ( 1.0 - ColorMask1_Tex66_g1448 );
			#else
				float staticSwitch456_g1448 = ( 1.0 - ColorMask1101_g1448 );
			#endif
			float ColorMask1308_g1448 = staticSwitch456_g1448;
			#if defined( _COLORS_TWO )
				float staticSwitch381_g1448 = 0.0;
			#elif defined( _COLORS_THREE )
				float staticSwitch381_g1448 = ColorMask2_F196_g1448;
			#elif defined( _COLORS_FOUR )
				float staticSwitch381_g1448 = ColorMask2_F196_g1448;
			#else
				float staticSwitch381_g1448 = ColorMask2_F196_g1448;
			#endif
			float ColorMask2308_g1448 = staticSwitch381_g1448;
			#if defined( _COLORS_TWO )
				float staticSwitch452_g1448 = 0.0;
			#elif defined( _COLORS_THREE )
				float staticSwitch452_g1448 = ColorMask3446_g1448;
			#elif defined( _COLORS_FOUR )
				float staticSwitch452_g1448 = ColorMask3446_g1448;
			#else
				float staticSwitch452_g1448 = ColorMask3446_g1448;
			#endif
			float ColorMask3308_g1448 = staticSwitch452_g1448;
			float3 objToWorld170_g1440 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float GVTime160_g1434 = _GVTime;
			float lerpResult146_g1434 = lerp( _Time.y , Nicrom_MM_Time_Grass , GVTime160_g1434);
			float ApplicationIsPlaying227_g1434 = Nicrom_ApplicationIsPlaying;
			float lerpResult221_g1434 = lerp( _Time.y , lerpResult146_g1434 , ApplicationIsPlaying227_g1434);
			float MM_Time140_g1434 = lerpResult221_g1434;
			float Time167_g1440 = MM_Time140_g1434;
			float MM_Speed63_g1434 = _MMSpeed;
			float Speed125_g1440 = MM_Speed63_g1434;
			float temp_output_205_0_g1434 = Nicrom_MM_SpeedScale_Grass;
			float lerpResult208_g1434 = lerp( temp_output_205_0_g1434 , 1.0 , GVTime160_g1434);
			float lerpResult210_g1434 = lerp( temp_output_205_0_g1434 , lerpResult208_g1434 , ApplicationIsPlaying227_g1434);
			float MM_SpeedScale206_g1434 = lerpResult210_g1434;
			float SpeedScale_RotAng201_g1440 = MM_SpeedScale206_g1434;
			float MM_SineWaveLength64_g1434 = _MMSineWaveLength;
			float WaveLength63_g1440 = MM_SineWaveLength64_g1434;
			float3 appendResult28_g1441 = (float3(i.uv2_texcoord2.x , 0.0 , i.uv2_texcoord2.y));
			float3 MM_LocalPivot3_g1434 = -appendResult28_g1441;
			float3 objToWorld11_g1438 = mul( unity_ObjectToWorld, float4( MM_LocalPivot3_g1434, 1 ) ).xyz;
			float2 appendResult10_g1438 = (float2(objToWorld11_g1438.x , objToWorld11_g1438.z));
			float2 WorldSpaceUVs9_g1434 = appendResult10_g1438;
			float StaticNoiseTiling11_g1434 = _StaticNoiseTiling;
			float4 temp_output_16_0_g1434 = tex2D( _MotionNoise, ( WorldSpaceUVs9_g1434 * StaticNoiseTiling11_g1434 ) );
			float4 WorldSpaceStaticNoise23_g1434 = temp_output_16_0_g1434;
			float MM_PhaseShiftSource26_g1434 = _MMPhaseShiftSource;
			float lerpResult38_g1434 = lerp( i.vertexColor.a , (WorldSpaceStaticNoise23_g1434).g , MM_PhaseShiftSource26_g1434);
			float MM_PhaseShiftScale34_g1434 = _MMPhaseShiftScale;
			float MM_PhaseShift60_g1434 = ( lerpResult38_g1434 * MM_PhaseShiftScale34_g1434 );
			float PhaseShift127_g1440 = MM_PhaseShift60_g1434;
			float temp_output_20_0_g1440 = sin( ( ( ( objToWorld170_g1440.x + objToWorld170_g1440.z ) + ( ( Time167_g1440 * ( ( Speed125_g1440 * SpeedScale_RotAng201_g1440 ) * WaveLength63_g1440 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift127_g1440 ) ) ) * ( ( 2.0 * UNITY_PI ) / WaveLength63_g1440 ) ) );
			float MotionSineWave5 =  (0.0 + ( temp_output_20_0_g1440 - -1.0 ) * ( 1.0 - 0.0 ) / ( 1.0 - -1.0 ) );
			float MotionWave308_g1448 = MotionSineWave5;
			float ScaleVarNoise6 = i.vertexToFrag71_g1444;
			float ScaleVarNoise308_g1448 = ScaleVarNoise6;
			float4 localDebug308_g1448 = Debug308_g1448( Debug_Target308_g1448 , Albedo308_g1448 , ColorMask1308_g1448 , ColorMask2308_g1448 , ColorMask3308_g1448 , MotionWave308_g1448 , ScaleVarNoise308_g1448 );
			o.Albedo = localDebug308_g1448.xyz;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Alpha = 1;
			float temp_output_31_0_g1455 = tex2DNode111_g1448.a;
			float DF_Length_Local38_g1455 = _DistanceFadeLength;
			float DF_Length_Global45_g1455 = Nicrom_Grass_DF_Length;
			float DF_Start_Global43_g1455 = Nicrom_Grass_DF_Start;
			float lerpResult49_g1455 = lerp( 0.0 , _DistanceFadeUseGV , step( 0.1 , DF_Start_Global43_g1455 ));
			float DF_UseGV28_g1455 = lerpResult49_g1455;
			float lerpResult26_g1455 = lerp( DF_Length_Local38_g1455 , DF_Length_Global45_g1455 , DF_UseGV28_g1455);
			float DistanceFadeLength23_g1455 = lerpResult26_g1455;
			float DF_Start_Local36_g1455 = _DistanceFadeStart;
			float lerpResult20_g1455 = lerp( DF_Start_Local36_g1455 , DF_Start_Global43_g1455 , DF_UseGV28_g1455);
			float DistanceFadeStart27_g1455 = lerpResult20_g1455;
			float cameraDepthFade3_g1455 = (( i.customSurfaceDepth3_g1455 -_ProjectionParams.y - DistanceFadeStart27_g1455 ) / DistanceFadeLength23_g1455);
			#ifdef _DISTANCEFADE_ON
				float staticSwitch33_g1455 = ( temp_output_31_0_g1455 * saturate( ( 1.0 - cameraDepthFade3_g1455 ) ) );
			#else
				float staticSwitch33_g1455 = temp_output_31_0_g1455;
			#endif
			clip( staticSwitch33_g1455 - _AlphaCutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Grass"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;70;-1600,32;Inherit;False;Nicrom - Grass - Motion - GP;-1;;470;68dce5914ef6ba4418bc01519e972983;0;0;4;FLOAT;0;FLOAT;7;FLOAT;4;FLOAT;5
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;82;-1312,32;Inherit;False;Nicrom - Grass - Motion;37;;1434;d7cb44a0013d9e84a87b655f189eee6d;0;4;133;FLOAT;0;False;205;FLOAT;1;False;143;FLOAT;0;False;144;FLOAT;1;False;3;FLOAT3;0;COLOR;197;FLOAT;132
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;3;-928,32;Inherit;False;Nicrom - Slope Correction;61;;1442;af072765142b7b4418aadc0762673233;0;2;87;FLOAT3;0,0,0;False;93;FLOAT4;0,0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;29;-608,32;Inherit;False;Nicrom - Scale;65;;1444;8d53ba1ace8e1014986c3779ab835fd1;0;1;13;FLOAT3;0,0,0;False;2;FLOAT3;0;FLOAT;70
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;5;-928,128;Inherit;False;MotionSineWave;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;6;-288,96;Inherit;False;ScaleVarNoise;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;7;-928,-256;Inherit;False;6;ScaleVarNoise;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;8;-928,-192;Inherit;False;5;MotionSineWave;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;53;-672,-256;Inherit;False;Nicrom - Grass - Main;1;;1448;62a1cdac75bdea94380b1bdaa4a29bd6;0;2;286;FLOAT;0;False;155;FLOAT;0;False;4;FLOAT4;0;FLOAT;398;FLOAT;397;FLOAT;154
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;62;-608,-80;Inherit;False;Nicrom - Grass - DF - GP;-1;;1454;91399c2db953a9045923ce80682c110c;0;0;2;FLOAT;0;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;10;0,224;Inherit;False;Property;_AlphaCutoff;Alpha Cutoff;0;0;Create;True;0;0;0;False;0;False;0.5;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;65;-288,-64;Inherit;False;Nicrom - Distance Fade;32;;1455;05e2fd54e656b694286271db4b0312fc;0;3;31;FLOAT;0;False;34;FLOAT;50;False;35;FLOAT;30;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;0;0,-256;Float;False;True;-1;3;Nicrom.CMI_Grass;0;0;Standard;Nicrom/ASE/Vegetation/Grass;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;;0;False;;False;0;False;;0;False;;False;0;Custom;0.5;True;True;0;True;Opaque;;AlphaTest;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;_Cull;-1;0;True;_AlphaCutoff;1;Pragma;multi_compile_instancing;False;;Custom;False;0;0;;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;82;133;70;0
WireConnection;82;205;70;7
WireConnection;82;143;70;4
WireConnection;82;144;70;5
WireConnection;3;87;82;0
WireConnection;3;93;82;197
WireConnection;29;13;3;0
WireConnection;5;0;82;132
WireConnection;6;0;29;70
WireConnection;53;286;7;0
WireConnection;53;155;8;0
WireConnection;65;31;53;154
WireConnection;65;34;62;0
WireConnection;65;35;62;3
WireConnection;0;0;53;0
WireConnection;0;3;53;398
WireConnection;0;4;53;397
WireConnection;0;10;65;0
WireConnection;0;11;29;0
ASEEND*/
//CHKSM=D318F95FE46988C922422265BC693AB0FF167632