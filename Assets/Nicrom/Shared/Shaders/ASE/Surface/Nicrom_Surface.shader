// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Surface"
{
	Properties
	{
		[SingleLineTexture] _Albedo( "Albedo", 2D ) = "white" {}
		[SingleLineTexture] _Normal( "Normal", 2D ) = "bump" {}
		[SingleLineTexture] _MRAO( "Metalic (R), Smoothness (G), AO (B)", 2D ) = "white" {}
		_Color( "Color", Color ) = ( 1, 1, 1 )
		_Metallic( "Metallic", Range( 0, 1 ) ) = 0
		_Smoothness( "Smoothness", Range( 0, 1 ) ) = 0
		_NormalScale( "Normal Scale", Range( 0, 3 ) ) = 1
		_AmbientOcclusion( "Ambient Occlusion", Range( 0, 1 ) ) = 0.4
		[Enum(None,0,Edge Mask,1,Coverage Mask,2)] _Debug( "Debug", Float ) = 0
		[Toggle( _EDGEHIGHLIGHT_ON )] _EdgeHighlight( "Edge Highlight", Float ) = 1
		[SingleLineTexture] _CurvatureMap( "Curvature Map", 2D ) = "black" {}
		_EdgeHighlightColor( "Edge Highlight Color", Color ) = ( 1, 1, 1 )
		_EdgeHighlightSharpMin( "Edge Highlight Sharp Min", Range( 0, 1 ) ) = 0.5
		_EdgeHighlightSharpMax( "Edge Highlight Sharp Max", Range( 0, 1 ) ) = 1
		[Toggle( _TRIPLANARPROJECTION_ON )] _TriplanarProjection( "Triplanar Projection", Float ) = 1
		[SingleLineTexture] _TriplanarAlbedo( "Triplanar Albedo", 2D ) = "white" {}
		[SingleLineTexture] _TriplanarNormal( "Triplanar Normal", 2D ) = "bump" {}
		_TriplanarColor( "Triplanar Color", Color ) = ( 1, 1, 1 )
		_TriplanarTiling( "Triplanar Tiling", Range( 0, 6 ) ) = 1
		[Enum(World,0,Object,1)] _TriplanarTilingSpace( "Triplanar Tiling Space", Range( 0, 1 ) ) = 0
		_TriplanarAlbedoIntensity( "Triplanar Albedo Intensity", Range( 0, 1 ) ) = 0
		_TriplanarNormalScale( "Triplanar Normal Scale", Range( 0, 3 ) ) = 1
		[Toggle( _COVERAGE_ON )] _Coverage( "Coverage", Float ) = 1
		[SingleLineTexture] _CoverageAlbedo( "Coverage Albedo", 2D ) = "white" {}
		[SingleLineTexture] _CoverageNormal( "Coverage Normal", 2D ) = "bump" {}
		_CoverageColor( "Coverage Color", Color ) = ( 1, 1, 1 )
		_CoverageTiling( "Coverage Tiling", Range( 0, 2 ) ) = 0.5
		_CoverageSmoothness( "Coverage Smoothness", Range( 0, 1 ) ) = 0
		_CoverageNormalScale( "Coverage Normal Scale", Range( 0, 3 ) ) = 1
		[Enum(World,0,Object,1)] _CoverageSpace( "Coverage Space", Range( 0, 1 ) ) = 0
		_CoverageAmount( "Coverage Amount", Range( -1, 1 ) ) = 0
		_CoverageFalloff( "Coverage Falloff", Range( 0.01, 5 ) ) = 0.5
		_CoverageNormalBlend( "Coverage Normal Blend", Range( 0, 1 ) ) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGINCLUDE
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.5
		#pragma shader_feature_local _COVERAGE_ON
		#pragma shader_feature_local _TRIPLANARPROJECTION_ON
		#pragma shader_feature_local _EDGEHIGHLIGHT_ON
		#define ASE_VERSION 19901
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
			float3 worldNormal;
			INTERNAL_DATA
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform float _NormalScale;
		uniform sampler2D _TriplanarNormal;
		uniform float _TriplanarTiling;
		uniform float _TriplanarTilingSpace;
		uniform float _TriplanarNormalScale;
		uniform float _CoverageNormalBlend;
		uniform float _CoverageAmount;
		uniform float _CoverageFalloff;
		uniform sampler2D _CoverageNormal;
		uniform float _CoverageTiling;
		uniform float _CoverageNormalScale;
		uniform float _Debug;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float3 _Color;
		uniform float3 _EdgeHighlightColor;
		uniform float _EdgeHighlightSharpMin;
		uniform float _EdgeHighlightSharpMax;
		uniform sampler2D _CurvatureMap;
		uniform float4 _CurvatureMap_ST;
		uniform sampler2D _TriplanarAlbedo;
		uniform float3 _TriplanarColor;
		uniform float _TriplanarAlbedoIntensity;
		uniform sampler2D _CoverageAlbedo;
		uniform float3 _CoverageColor;
		uniform float _CoverageSpace;
		uniform sampler2D _MRAO;
		uniform float4 _MRAO_ST;
		uniform float _Metallic;
		uniform float _Smoothness;
		uniform float _CoverageSmoothness;
		uniform float _AmbientOcclusion;


		inline float3 TriplanarSampling35_g9( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
		{
			float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
			projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
			float3 nsign = sign( worldNormal );
			half4 xNorm; half4 yNorm; half4 zNorm;
			xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
			yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
			zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
			xNorm.xyz  = half3( UnpackScaleNormal( xNorm, normalScale.y ).xy * float2(  nsign.x, 1.0 ) + worldNormal.zy, worldNormal.x ).zyx;
			yNorm.xyz  = half3( UnpackScaleNormal( yNorm, normalScale.x ).xy * float2(  nsign.y, 1.0 ) + worldNormal.xz, worldNormal.y ).xzy;
			zNorm.xyz  = half3( UnpackScaleNormal( zNorm, normalScale.y ).xy * float2( -nsign.z, 1.0 ) + worldNormal.xy, worldNormal.z ).xyz;
			return normalize( xNorm.xyz * projNormal.x + yNorm.xyz * projNormal.y + zNorm.xyz * projNormal.z );
		}


		inline float3 TriplanarSampling32_g9( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
		{
			float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
			projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
			float3 nsign = sign( worldNormal );
			half4 xNorm; half4 yNorm; half4 zNorm;
			xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
			yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
			zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
			xNorm.xyz  = half3( UnpackScaleNormal( xNorm, normalScale.y ).xy * float2(  nsign.x, 1.0 ) + worldNormal.zy, worldNormal.x ).zyx;
			yNorm.xyz  = half3( UnpackScaleNormal( yNorm, normalScale.x ).xy * float2(  nsign.y, 1.0 ) + worldNormal.xz, worldNormal.y ).xzy;
			zNorm.xyz  = half3( UnpackScaleNormal( zNorm, normalScale.y ).xy * float2( -nsign.z, 1.0 ) + worldNormal.xy, worldNormal.z ).xyz;
			return normalize( xNorm.xyz * projNormal.x + yNorm.xyz * projNormal.y + zNorm.xyz * projNormal.z );
		}


		inline float4 TriplanarSampling78_g9( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
		{
			float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
			projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
			float3 nsign = sign( worldNormal );
			half4 xNorm; half4 yNorm; half4 zNorm;
			xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
			yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
			zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
			return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
		}


		inline float4 TriplanarSampling86_g9( sampler2D topTexMap, float3 worldPos, float3 worldNormal, float falloff, float2 tiling, float3 normalScale, float3 index )
		{
			float3 projNormal = ( pow( abs( worldNormal ), falloff ) );
			projNormal /= ( projNormal.x + projNormal.y + projNormal.z ) + 0.00001;
			float3 nsign = sign( worldNormal );
			half4 xNorm; half4 yNorm; half4 zNorm;
			xNorm = tex2D( topTexMap, tiling * worldPos.zy * float2(  nsign.x, 1.0 ) );
			yNorm = tex2D( topTexMap, tiling * worldPos.xz * float2(  nsign.y, 1.0 ) );
			zNorm = tex2D( topTexMap, tiling * worldPos.xy * float2( -nsign.z, 1.0 ) );
			return xNorm * projNormal.x + yNorm * projNormal.y + zNorm * projNormal.z;
		}


		float4 Debug263_g9( float Debug_Target, float4 Albedo, float EdgeMask, float CoverageMask )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return EdgeMask;
			else
			    return CoverageMask;
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			float3 MainNormalTex48_g9 = UnpackScaleNormal( tex2D( _Normal, uv_Normal ), _NormalScale );
			float TriplanarTiling16_g9 = _TriplanarTiling;
			float3 ase_objectScale = float3( length( unity_ObjectToWorld[ 0 ].xyz ), length( unity_ObjectToWorld[ 1 ].xyz ), length( unity_ObjectToWorld[ 2 ].xyz ) );
			float lerpResult245_g9 = lerp( TriplanarTiling16_g9 , ( TriplanarTiling16_g9 / ( ( ase_objectScale.x + ase_objectScale.y + ase_objectScale.z ) / 3.0 ) ) , _TriplanarTilingSpace);
			float TriplanarTiling_F237_g9 = lerpResult245_g9;
			float2 temp_cast_0 = (TriplanarTiling_F237_g9).xx;
			float3 ase_positionWS = i.worldPos;
			float3 ase_normalWS = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float3 ase_tangentWS = WorldNormalVector( i, float3( 1, 0, 0 ) );
			float3 ase_bitangentWS = WorldNormalVector( i, float3( 0, 1, 0 ) );
			float3x3 ase_worldToTangent = float3x3( ase_tangentWS, ase_bitangentWS, ase_normalWS );
			float TriplanarNormalScale15_g9 = _TriplanarNormalScale;
			float3 triplanar35_g9 = TriplanarSampling35_g9( _TriplanarNormal, ase_positionWS, ase_normalWS, 1.0, temp_cast_0, TriplanarNormalScale15_g9, 0 );
			float3 tanTriplanarNormal35_g9 = mul( ase_worldToTangent, triplanar35_g9 );
			float3 TriplanarNormal38_g9 = tanTriplanarNormal35_g9;
			#ifdef _TRIPLANARPROJECTION_ON
				float3 staticSwitch181_g9 = BlendNormals( TriplanarNormal38_g9 , MainNormalTex48_g9 );
			#else
				float3 staticSwitch181_g9 = MainNormalTex48_g9;
			#endif
			float3 MainNormalWithTriplanar1221_g9 = staticSwitch181_g9;
			float CoverageNormalBlend294_g9 = _CoverageNormalBlend;
			float Coverage_Amount11_g9 = _CoverageAmount;
			float Coverage_Falloff23_g9 = _CoverageFalloff;
			float CoverageNormalsMask41_g9 = pow( saturate( ( ase_normalWS.y + Coverage_Amount11_g9 ) ) , Coverage_Falloff23_g9 );
			float3 lerpResult286_g9 = lerp( MainNormalWithTriplanar1221_g9 , MainNormalTex48_g9 , ( ( 1.0 - CoverageNormalBlend294_g9 ) * CoverageNormalsMask41_g9 ));
			float3 MainNormalWithTriplanar2287_g9 = lerpResult286_g9;
			float CoverageTiling19_g9 = _CoverageTiling;
			float2 temp_cast_1 = (CoverageTiling19_g9).xx;
			float CoverageNormalScale18_g9 = _CoverageNormalScale;
			float3 triplanar32_g9 = TriplanarSampling32_g9( _CoverageNormal, ase_positionWS, ase_normalWS, 1.0, temp_cast_1, CoverageNormalScale18_g9, 0 );
			float3 tanTriplanarNormal32_g9 = mul( ase_worldToTangent, triplanar32_g9 );
			float3 CoverageNormal39_g9 = tanTriplanarNormal32_g9;
			float3 lerpResult200_g9 = lerp( MainNormalWithTriplanar2287_g9 , BlendNormals( MainNormalWithTriplanar2287_g9 , CoverageNormal39_g9 ) , CoverageNormalsMask41_g9);
			#ifdef _COVERAGE_ON
				float3 staticSwitch199_g9 = lerpResult200_g9;
			#else
				float3 staticSwitch199_g9 = MainNormalWithTriplanar1221_g9;
			#endif
			o.Normal = staticSwitch199_g9;
			float Debug_Target263_g9 = _Debug;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 MainAlbedoTex83_g9 = tex2D( _Albedo, uv_Albedo );
			float3 MainColor171_g9 = _Color;
			float3 CurvatureColor169_g9 = _EdgeHighlightColor;
			float CurvatureSharpnessMin176_g9 = _EdgeHighlightSharpMin;
			float CurvatureSharpnessMax177_g9 = _EdgeHighlightSharpMax;
			float2 uv_CurvatureMap = i.uv_texcoord * _CurvatureMap_ST.xy + _CurvatureMap_ST.zw;
			float T_Curvature148_g9 = tex2D( _CurvatureMap, uv_CurvatureMap ).r;
			float smoothstepResult135_g9 = smoothstep( CurvatureSharpnessMin176_g9 , CurvatureSharpnessMax177_g9 , T_Curvature148_g9);
			float EdgeMask140_g9 = smoothstepResult135_g9;
			float3 lerpResult147_g9 = lerp( MainColor171_g9 , CurvatureColor169_g9 , EdgeMask140_g9);
			#ifdef _EDGEHIGHLIGHT_ON
				float3 staticSwitch156_g9 = lerpResult147_g9;
			#else
				float3 staticSwitch156_g9 = MainColor171_g9;
			#endif
			float3 MainColor_F84_g9 = staticSwitch156_g9;
			float4 temp_output_212_0_g9 = ( MainAlbedoTex83_g9 * float4( MainColor_F84_g9 , 0.0 ) );
			float2 temp_cast_5 = (TriplanarTiling_F237_g9).xx;
			float4 triplanar78_g9 = TriplanarSampling78_g9( _TriplanarAlbedo, ase_positionWS, ase_normalWS, 1.0, temp_cast_5, 1.0, 0 );
			float3 TriplanarColor173_g9 = _TriplanarColor;
			float3 lerpResult134_g9 = lerp( TriplanarColor173_g9 , CurvatureColor169_g9 , EdgeMask140_g9);
			#ifdef _EDGEHIGHLIGHT_ON
				float3 staticSwitch155_g9 = lerpResult134_g9;
			#else
				float3 staticSwitch155_g9 = TriplanarColor173_g9;
			#endif
			float3 TriplanarColor_F67_g9 = staticSwitch155_g9;
			float4 TriplanarAlbedo94_g9 = ( triplanar78_g9 * float4( TriplanarColor_F67_g9 , 0.0 ) );
			float TriplanarAlbedoScale95_g9 = _TriplanarAlbedoIntensity;
			float4 lerpResult213_g9 = lerp( temp_output_212_0_g9 , TriplanarAlbedo94_g9 , TriplanarAlbedoScale95_g9);
			#ifdef _TRIPLANARPROJECTION_ON
				float4 staticSwitch205_g9 = lerpResult213_g9;
			#else
				float4 staticSwitch205_g9 = temp_output_212_0_g9;
			#endif
			float2 temp_cast_9 = (CoverageTiling19_g9).xx;
			float4 triplanar86_g9 = TriplanarSampling86_g9( _CoverageAlbedo, ase_positionWS, ase_normalWS, 1.0, temp_cast_9, 1.0, 0 );
			float3 CoverageColor75_g9 = _CoverageColor;
			float4 CoverageAlbedo100_g9 = ( triplanar86_g9 * float4( CoverageColor75_g9 , 0.0 ) );
			float3 PixelNormal54_g9 = (WorldNormalVector( i , staticSwitch199_g9 ));
			float WorldObjectSwitch55_g9 = _CoverageSpace;
			float3 lerpResult65_g9 = lerp( PixelNormal54_g9 , mul( unity_WorldToObject, float4( PixelNormal54_g9 , 0.0 ) ).xyz , WorldObjectSwitch55_g9);
			float3 temp_cast_13 = (Coverage_Falloff23_g9).xxx;
			float CoverageAlbedoMask96_g9 = (pow( saturate( ( lerpResult65_g9 + Coverage_Amount11_g9 ) ) , temp_cast_13 )).y;
			float4 lerpResult216_g9 = lerp( staticSwitch205_g9 , CoverageAlbedo100_g9 , CoverageAlbedoMask96_g9);
			#ifdef _COVERAGE_ON
				float4 staticSwitch217_g9 = lerpResult216_g9;
			#else
				float4 staticSwitch217_g9 = staticSwitch205_g9;
			#endif
			float4 Albedo264_g9 = staticSwitch217_g9;
			float4 Albedo263_g9 = Albedo264_g9;
			#ifdef _EDGEHIGHLIGHT_ON
				float staticSwitch268_g9 = EdgeMask140_g9;
			#else
				float staticSwitch268_g9 = 0.0;
			#endif
			float EdgeMask263_g9 = staticSwitch268_g9;
			#ifdef _COVERAGE_ON
				float staticSwitch270_g9 = CoverageAlbedoMask96_g9;
			#else
				float staticSwitch270_g9 = 0.0;
			#endif
			float CoverageMask263_g9 = staticSwitch270_g9;
			float4 localDebug263_g9 = Debug263_g9( Debug_Target263_g9 , Albedo263_g9 , EdgeMask263_g9 , CoverageMask263_g9 );
			o.Albedo = localDebug263_g9.xyz;
			float2 uv_MRAO = i.uv_texcoord * _MRAO_ST.xy + _MRAO_ST.zw;
			float4 tex2DNode115_g9 = tex2D( _MRAO, uv_MRAO );
			float T_Metalic125_g9 = tex2DNode115_g9.r;
			o.Metallic = ( T_Metalic125_g9 * _Metallic );
			float MainSmoothness229_g9 = _Smoothness;
			float CoverageSmoothness226_g9 = _CoverageSmoothness;
			float lerpResult228_g9 = lerp( MainSmoothness229_g9 , CoverageSmoothness226_g9 , CoverageAlbedoMask96_g9);
			#ifdef _COVERAGE_ON
				float staticSwitch232_g9 = lerpResult228_g9;
			#else
				float staticSwitch232_g9 = MainSmoothness229_g9;
			#endif
			o.Smoothness = staticSwitch232_g9;
			float T_AO123_g9 = tex2DNode115_g9.b;
			float lerpResult119_g9 = lerp( 1.0 , T_AO123_g9 , _AmbientOcclusion);
			o.Occlusion = lerpResult119_g9;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.5
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Surface"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.CommentaryNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;96;2432,-2432;Inherit;False;641.0271;576.2808;Master Node;1;330;;1,1,1,1;0;0
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;370;2464,-2368;Inherit;False;Nicrom - Surface;0;;9;3711592be41b7e74f8bf326e94adcddc;0;0;5;FLOAT4;0;FLOAT3;109;FLOAT;121;FLOAT;110;FLOAT;117
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;330;2816,-2368;Float;False;True;-1;3;Nicrom.CMI_Surface;0;0;Standard;Nicrom/ASE/Surface;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;;0;False;;False;0;False;;0;False;;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;0;0;False;;0;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;330;0;370;0
WireConnection;330;1;370;109
WireConnection;330;3;370;121
WireConnection;330;4;370;110
WireConnection;330;5;370;117
ASEEND*/
//CHKSM=13904E7B652865292FC03E8BC9AA172293705EEA