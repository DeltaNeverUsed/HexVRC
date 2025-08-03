// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Vegetation/Poly"
{
	Properties
	{
		_OcclusionColor( "Occlusion Color", Color ) = ( 0.4672615, 0.6064689, 0.2345775, 1 )
		_OcclusionMinRadius( "Occlusion Min Radius", Range( 0, 3 ) ) = 0.1
		_OcclusionMaxRadius( "Occlusion Max Radius", Range( 0, 6 ) ) = 1
		[Toggle( _OCCLUSION_ON )] _Occlusion( "Occlusion", Float ) = 0
		_BaseColor( "Base Color", Color ) = ( 1, 1, 1, 1 )
		[NoScaleOffset][SingleLineTexture] _MainTex( "Albedo", 2D ) = "white" {}
		[Space] _Metallic( "Metallic", Range( 0, 1 ) ) = 0
		_Smoothness( "Smoothness", Range( 0, 1 ) ) = 0.2909241
		[Enum(None,0,UV1,1,UV2,2)] _LocalPivotSource( "Local Pivot Source", Float ) = 0
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
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#pragma target 3.5
		#pragma shader_feature_local_vertex _MAINMOTION_ON
		#pragma shader_feature_local_vertex _DETAILMOTION1_ON
		#pragma shader_feature_local_vertex _DETAILMOTION2_ON
		#pragma shader_feature_local _OCCLUSION_ON
		#define ASE_VERSION 19901
		#pragma multi_compile_instancing
		#pragma only_renderers d3d11 glcore gles gles3 
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows dithercrossfade vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
			float3 vertexToFrag6_g374;
			float vertexToFrag12_g374;
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
		uniform float4 _BaseColor;
		uniform sampler2D _MainTex;
		uniform float4 _OcclusionColor;
		uniform float _OcclusionMaxRadius;
		uniform float _OcclusionMinRadius;
		uniform float _Metallic;
		uniform float _Smoothness;


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


		float3 LocalPivot4_g373( float Source, float3 None, float3 UV1, float3 UV2 )
		{
			if(Source ==0)
			    return None;
			else if(Source ==1)
			    return UV1;
			else
			    return UV2;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float temp_output_23_0_g377 = radians( ( 90.0 + ( v.texcoord2.xy.x * 360.0 ) ) );
			float3 appendResult25_g377 = (float3(cos( temp_output_23_0_g377 ) , 0.0 , sin( temp_output_23_0_g377 )));
			float3 DB_RotationAxis87_g375 = appendResult25_g377;
			float GV_AmplitudeScale175_g375 = _GVBendingScale;
			float lerpResult186_g375 = lerp( 1.0 , Nicrom_DM_AmpScale_Vegetation , GV_AmplitudeScale175_g375);
			float DM_AmplitudeScale168_g375 = lerpResult186_g375;
			float DM1_Amplitude28_g375 = _DM1Amplitude;
			float3 objToWorld80_g385 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float GV_Time174_g375 = _GVTime;
			float lerpResult187_g375 = lerp( _Time.y , Nicrom_DM_Time_Vegetation , GV_Time174_g375);
			float ApplicationIsPlaying241_g375 = Nicrom_ApplicationIsPlaying;
			float lerpResult256_g375 = lerp( _Time.y , lerpResult187_g375 , ApplicationIsPlaying241_g375);
			float DM_Time169_g375 = lerpResult256_g375;
			float Time90_g385 = DM_Time169_g375;
			float DM1_Speed29_g375 = _DM1Speed;
			float Speed45_g385 = DM1_Speed29_g375;
			float temp_output_244_0_g375 = Nicrom_DM_SpeedScale_Vegetation;
			float lerpResult261_g375 = lerp( temp_output_244_0_g375 , 1.0 , GV_Time174_g375);
			float lerpResult262_g375 = lerp( temp_output_244_0_g375 , lerpResult261_g375 , ApplicationIsPlaying241_g375);
			float DM_SpeedScale265_g375 = lerpResult262_g375;
			float SpeedScale95_g385 = DM_SpeedScale265_g375;
			float DM_PhaseShift91_g375 = v.color.a;
			float PhaseShift48_g385 = DM_PhaseShift91_g375;
			float3 ase_positionOS = v.vertex.xyz;
			float3 appendResult24_g377 = (float3(0.0 , v.texcoord2.xy.y , 0.0));
			float3 DM_PivotPosOnYAxis88_g375 = appendResult24_g377;
			float3 PivotPosOnYAxis56_g385 = DM_PivotPosOnYAxis88_g375;
			float DM1_FoliageLength32_g375 = _DM1FoliageLength;
			float3 rotatedValue29_g385 = RotateAroundAxis( PivotPosOnYAxis56_g385, ase_positionOS, DB_RotationAxis87_g375, radians( ( ( ( DM_AmplitudeScale168_g375 * DM1_Amplitude28_g375 ) * sin( ( ( ( objToWorld80_g385.x + objToWorld80_g385.z ) + ( ( Time90_g385 * ( Speed45_g385 * SpeedScale95_g385 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift48_g385 ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , PivotPosOnYAxis56_g385 ) / DM1_FoliageLength32_g375 ) ) ) );
			float DM1_MotionMask89_g375 = step( 1.5 , v.texcoord.xy.y );
			float3 DM1_VertexOffset231_g375 = ( ( rotatedValue29_g385 - ase_positionOS ) * DM1_MotionMask89_g375 );
			#ifdef _DETAILMOTION1_ON
				float3 staticSwitch104_g375 = DM1_VertexOffset231_g375;
			#else
				float3 staticSwitch104_g375 = float3( 0, 0, 0 );
			#endif
			float DM2_Amplitude30_g375 = _DM2Amplitude;
			float Amplitude58_g386 = DM2_Amplitude30_g375;
			float Source4_g373 = _LocalPivotSource;
			float3 None4_g373 = float3( 0,0,0 );
			float3 appendResult7_g373 = (float3(v.texcoord1.xy.x , 0.0 , v.texcoord1.xy.y));
			float3 UV14_g373 = -appendResult7_g373;
			float3 appendResult8_g373 = (float3(v.texcoord2.xy.x , 0.0 , v.texcoord2.xy.y));
			float3 UV24_g373 = -appendResult8_g373;
			float3 localLocalPivot4_g373 = LocalPivot4_g373( Source4_g373 , None4_g373 , UV14_g373 , UV24_g373 );
			float3 LocalPivot159_g375 = localLocalPivot4_g373;
			float3 PivotPoint49_g386 = LocalPivot159_g375;
			float3 objToWorld53_g386 = mul( unity_ObjectToWorld, float4( PivotPoint49_g386, 1 ) ).xyz;
			float Time87_g386 = DM_Time169_g375;
			float SpeedScale93_g386 = DM_SpeedScale265_g375;
			float DM2_Speed31_g375 = _DM2Speed;
			float Speed41_g386 = DM2_Speed31_g375;
			float PhaseShift54_g386 = DM_PhaseShift91_g375;
			float3 break52_g386 = PivotPoint49_g386;
			float3 appendResult20_g386 = (float3(break52_g386.x , ase_positionOS.y , break52_g386.z));
			float DM2_ObjectRadius33_g375 = _DM2ObjectRadius;
			float ObjectRadius60_g386 = DM2_ObjectRadius33_g375;
			float3 rotatedValue33_g386 = RotateAroundAxis( PivotPoint49_g386, ase_positionOS, float3( 0, 1, 0 ), radians( ( ( ( DM_AmplitudeScale168_g375 * Amplitude58_g386 ) * sin( ( ( ( objToWorld53_g386.x + objToWorld53_g386.z ) + ( ( Time87_g386 * ( SpeedScale93_g386 * Speed41_g386 ) ) + ( ( 2.0 * UNITY_PI ) * ( 1.0 - PhaseShift54_g386 ) ) ) ) * ( 2.0 * UNITY_PI ) ) ) ) * ( distance( ase_positionOS , appendResult20_g386 ) / ObjectRadius60_g386 ) ) ) );
			float DM2_MotionMask90_g375 = step( 1.5 , v.texcoord.xy.x );
			float BendingMask62_g386 = DM2_MotionMask90_g375;
			float3 DM2_VertexOffset232_g375 = ( ( rotatedValue33_g386 - ase_positionOS ) * BendingMask62_g386 );
			#ifdef _DETAILMOTION2_ON
				float3 staticSwitch103_g375 = DM2_VertexOffset232_g375;
			#else
				float3 staticSwitch103_g375 = float3( 0, 0, 0 );
			#endif
			float3 DM_VertexOffset128_g375 = ( staticSwitch104_g375 + staticSwitch103_g375 );
			float lerpResult56_g383 = lerp( _MMDirectionAngle , Nicrom_WindDirAngle , _GVDirectionAngle);
			float MM_DirAngle51_g375 = lerpResult56_g383;
			float MM_DirShift59_g375 = _MMDirectionShift;
			float MM_DirShiftOffset60_g375 = _MMDirectionShiftOffset;
			float3 objToWorld11_g380 = mul( unity_ObjectToWorld, float4( LocalPivot159_g375, 1 ) ).xyz;
			float2 appendResult10_g380 = (float2(objToWorld11_g380.x , objToWorld11_g380.z));
			float MotionNoiseTiling20_g375 = _MotionNoiseTiling;
			float4 temp_output_73_0_g375 = tex2Dlod( _MotionNoise, float4( ( appendResult10_g380 * MotionNoiseTiling20_g375 ), 0, 0.0) );
			float4 StaticWorldNoise78_g375 = temp_output_73_0_g375;
			float4 StaticWorldNoise55_g379 = StaticWorldNoise78_g375;
			float3 objToWorld50_g379 = mul( unity_ObjectToWorld, float4( LocalPivot159_g375, 1 ) ).xyz;
			float lerpResult182_g375 = lerp( _Time.y , Nicrom_MM_Time_Vegetation , GV_Time174_g375);
			float lerpResult246_g375 = lerp( _Time.y , lerpResult182_g375 , ApplicationIsPlaying241_g375);
			float MM_Time13_g375 = lerpResult246_g375;
			float Time76_g379 = MM_Time13_g375;
			float temp_output_243_0_g375 = Nicrom_MM_SpeedScale_Vegetation;
			float lerpResult245_g375 = lerp( temp_output_243_0_g375 , 1.0 , GV_Time174_g375);
			float lerpResult249_g375 = lerp( temp_output_243_0_g375 , lerpResult245_g375 , ApplicationIsPlaying241_g375);
			float MM_SpeedScale253_g375 = lerpResult249_g375;
			float SpeedScale_RA80_g379 = MM_SpeedScale253_g375;
			float MM_DirShiftSpeed56_g375 = _MMDirectionShiftSpeed;
			float MM_DirShiftNoiseScale57_g375 = _MMDirectionShiftNoiseScale;
			float temp_output_11_0_g379 = radians( ( ( MM_DirAngle51_g375 + ( ( MM_DirShift59_g375 + ( MM_DirShiftOffset60_g375 * (StaticWorldNoise55_g379).x ) ) * sin( ( ( objToWorld50_g379.x + objToWorld50_g379.z ) + ( ( Time76_g379 * ( SpeedScale_RA80_g379 * MM_DirShiftSpeed56_g375 ) ) + ( ( 2.0 * UNITY_PI ) * ( (StaticWorldNoise55_g379).z * MM_DirShiftNoiseScale57_g375 ) ) ) ) ) ) ) * -1.0 ) );
			float3 appendResult14_g379 = (float3(cos( temp_output_11_0_g379 ) , 0.0 , sin( temp_output_11_0_g379 )));
			float3 worldToObj35_g379 = mul( unity_WorldToObject, float4( appendResult14_g379, 1 ) ).xyz;
			float3 worldToObj36_g379 = mul( unity_WorldToObject, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 normalizeResult34_g379 = normalize( (( worldToObj35_g379 - worldToObj36_g379 )).xyz );
			float3 MB_RotationAxis129_g375 = normalizeResult34_g379;
			float3 RotationAxis56_g378 = MB_RotationAxis129_g375;
			float4 StaticWorldNoise31_g384 = StaticWorldNoise78_g375;
			float MM_BendingOfset37_g375 = _MMBendingOffset;
			float MM_Bending35_g375 = _MMBending;
			float GV_BendingScale176_g375 = _GVAmplitudeScale;
			float lerpResult188_g375 = lerp( 1.0 , Nicrom_MM_BendScale_Vegetation , GV_BendingScale176_g375);
			float MM_BendingScale17_g375 = lerpResult188_g375;
			float MM_AmplitudeOffset52_g375 = _MMAmplitudeOffset;
			float MM_Amplitude66_g375 = _MMAmplitude;
			float lerpResult189_g375 = lerp( 1.0 , Nicrom_MM_AmpScale_Vegetation , GV_AmplitudeScale175_g375);
			float MM_AmplitudeScale15_g375 = lerpResult189_g375;
			float3 objToWorld170_g384 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float Time167_g384 = MM_Time13_g375;
			float MM_Speed53_g375 = _MMSpeed;
			float Speed125_g384 = MM_Speed53_g375;
			float SpeedScale_RotAng201_g384 = MM_SpeedScale253_g375;
			float MM_SineWaveLength58_g375 = _MMSineWaveLength;
			float WaveLength63_g384 = MM_SineWaveLength58_g375;
			float MM_PhaseShiftSource207_g375 = _MMPhaseShiftSource;
			float lerpResult154_g375 = lerp( v.color.a , (StaticWorldNoise78_g375).g , MM_PhaseShiftSource207_g375);
			float MM_PhaseShiftScale39_g375 = _MMPhaseShiftScale;
			float MB_PhaseShift79_g375 = ( lerpResult154_g375 * MM_PhaseShiftScale39_g375 );
			float PhaseShift127_g384 = MB_PhaseShift79_g375;
			float temp_output_20_0_g384 = sin( ( ( ( objToWorld170_g384.x + objToWorld170_g384.z ) + ( ( Time167_g384 * ( ( Speed125_g384 * SpeedScale_RotAng201_g384 ) * WaveLength63_g384 ) ) + ( ( 2.0 * UNITY_PI ) * PhaseShift127_g384 ) ) ) * ( ( 2.0 * UNITY_PI ) / WaveLength63_g384 ) ) );
			float MM_MaxHeight55_g375 = _MMObjectHeight;
			float3 gammaToLinear56_g384 = GammaToLinearSpace( v.color.rgb );
			float MM_ObjectHeightSource54_g375 = _MMObjectHeightSource;
			float lerpResult57_g384 = lerp( ( ase_positionOS.y / MM_MaxHeight55_g375 ) , (gammaToLinear56_g384).x , MM_ObjectHeightSource54_g375);
			float BendingMask189_g384 = lerpResult57_g384;
			float MB_RotationAngle130_g375 = radians( ( ( ( ( ( (StaticWorldNoise31_g384).y * MM_BendingOfset37_g375 ) + MM_Bending35_g375 ) * MM_BendingScale17_g375 ) + ( ( ( ( (StaticWorldNoise31_g384).x * MM_AmplitudeOffset52_g375 ) + MM_Amplitude66_g375 ) * MM_AmplitudeScale15_g375 ) * temp_output_20_0_g384 ) ) * BendingMask189_g384 ) );
			float RotationAngle54_g378 = MB_RotationAngle130_g375;
			float3 LocalPivotPos60_g378 = LocalPivot159_g375;
			float3 break62_g378 = LocalPivotPos60_g378;
			float VertexPos_Y67_g378 = ase_positionOS.y;
			float3 appendResult45_g378 = (float3(break62_g378.x , VertexPos_Y67_g378 , break62_g378.z));
			float3 VertexPos66_g378 = ase_positionOS;
			float3 rotatedValue30_g378 = RotateAroundAxis( appendResult45_g378, VertexPos66_g378, RotationAxis56_g378, RotationAngle54_g378 );
			float3 DetailMotionVO73_g378 = DM_VertexOffset128_g375;
			float3 rotatedValue34_g378 = RotateAroundAxis( LocalPivotPos60_g378, ( rotatedValue30_g378 + DetailMotionVO73_g378 ), RotationAxis56_g378, RotationAngle54_g378 );
			#ifdef _MAINMOTION_ON
				float3 staticSwitch205_g375 = ( ( rotatedValue34_g378 - VertexPos66_g378 ) * step( 0.01 , VertexPos_Y67_g378 ) );
			#else
				float3 staticSwitch205_g375 = DM_VertexOffset128_g375;
			#endif
			v.vertex.xyz += staticSwitch205_g375;
			v.vertex.w = 1;
			o.vertexToFrag6_g374 = ase_positionOS;
			float3 gammaToLinear7_g374 = GammaToLinearSpace( v.color.rgb );
			o.vertexToFrag12_g374 = (gammaToLinear7_g374).x;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 BaseColor10_g372 = _BaseColor;
			float2 uv_MainTex31_g372 = i.uv_texcoord;
			float4 Albedo_Ccclusion39_g374 = ( BaseColor10_g372 * tex2D( _MainTex, uv_MainTex31_g372 ) );
			float4 OcclusionColor21_g374 = _OcclusionColor;
			float3 appendResult10_g374 = (float3(0.0 , i.vertexToFrag6_g374.y , 0.0));
			float OcclusionMaxRadius23_g374 = _OcclusionMaxRadius;
			float OcclusionMinRadius25_g374 = _OcclusionMinRadius;
			float lerpResult15_g374 = lerp( OcclusionMaxRadius23_g374 , OcclusionMinRadius25_g374 , i.vertexToFrag12_g374);
			float OclusionMask219_g374 = ( 1.0 - saturate( ( distance( i.vertexToFrag6_g374 , appendResult10_g374 ) / lerpResult15_g374 ) ) );
			float4 lerpResult27_g374 = lerp( Albedo_Ccclusion39_g374 , OcclusionColor21_g374 , OclusionMask219_g374);
			float4 lerpResult31_g374 = lerp( Albedo_Ccclusion39_g374 , lerpResult27_g374 , step( 1.0 , i.uv_texcoord.x ));
			#ifdef _OCCLUSION_ON
				float4 staticSwitch32_g374 = lerpResult31_g374;
			#else
				float4 staticSwitch32_g374 = Albedo_Ccclusion39_g374;
			#endif
			o.Albedo = staticSwitch32_g374.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Smoothness;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Vegetation_Poly"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2020;896,2080;Inherit;False;Nicrom - Vegetation - Motion - GP;-1;;302;2010567f31880844287a8b7519991b43;0;0;7;FLOAT;10;FLOAT;12;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;14;FLOAT;9
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2029;960,1792;Inherit;False;Nicrom - Vegetation - Poly - Main;5;;372;037c59b568e1a8c438a36ff9c8cad362;0;0;3;COLOR;0;FLOAT;50;FLOAT;51
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2030;960,2304;Inherit;False;Nicrom - Pivot From UVs;10;;373;210e3b1b5c35d40419d216fdbaceef46;0;0;1;FLOAT3;0
Node;AmplifyShaderEditor.OneMinusNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1330;-19002.03,10716.32;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1328;-19355.95,10790.4;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2028;1312,1792;Inherit;False;Nicrom - Vegetation - Occlusion;0;;374;d7ca7ff6f9d074e4eb6a5f354d3fcdc9;0;1;38;COLOR;1,1,1,0;False;1;COLOR;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;2031;1248,2080;Inherit;False;Nicrom - Motion;12;;375;ba60642b1d9af614f93c28cb2553ff1c;0;8;179;FLOAT;0;False;243;FLOAT;1;False;178;FLOAT;0;False;180;FLOAT;0;False;184;FLOAT;0;False;244;FLOAT;1;False;185;FLOAT;0;False;238;FLOAT3;0,0,0;False;2;FLOAT3;0;COLOR;215
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;0;1664,1792;Float;False;True;-1;3;Nicrom.CMI_Vegetation_Poly;0;0;Standard;Nicrom/ASE/Vegetation/Poly;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;False;False;Back;0;False;;0;False;;False;0;False;;0;False;;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;4;d3d11;glcore;gles;gles3;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;1;Pragma;multi_compile_instancing;False;;Custom;False;0;0;;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;2028;38;2029;0
WireConnection;2031;179;2020;10
WireConnection;2031;243;2020;12
WireConnection;2031;178;2020;6
WireConnection;2031;180;2020;7
WireConnection;2031;184;2020;8
WireConnection;2031;244;2020;14
WireConnection;2031;185;2020;9
WireConnection;2031;238;2030;0
WireConnection;0;0;2028;0
WireConnection;0;3;2029;50
WireConnection;0;4;2029;51
WireConnection;0;11;2031;0
ASEEND*/
//CHKSM=A434C1A75FE377A2738E2D999B9B8F1DCE6FC663