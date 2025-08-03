// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Water"
{
	Properties
	{
		_ShallowWaterColor( "Shallow Water Color", Color ) = ( 0.4823529, 0.7411765, 0.6509804, 0.6980392 )
		_DeepWaterColor( "Deep Water Color", Color ) = ( 0.1098039, 0.3098039, 0.4823529, 1 )
		_OpacityAbove( "Opacity Above", Range( 0, 1 ) ) = 1
		_OpacityUnder( "Opacity Under", Range( 0, 1 ) ) = 0.8
		[Enum(None,0,Depth Mask,1,Refraction Fade Mask,2,Edge Opacity Mask,3,Foam Mask,4)] _Debug( "Debug", Float ) = 0
		_Depth( "Depth", Range( 0, 10 ) ) = 0.9
		_EdgeFade( "Edge Fade", Range( 0, 1 ) ) = 0.3
		_EdgeFadeOffset( "Edge Fade Offset", Range( 0, 1 ) ) = 0.1
		_EdgeFadeOffsetSpeed( "Edge Fade Offset Speed", Range( 0, 5 ) ) = 1.5
		_Metallic( "Metallic", Range( 0, 1 ) ) = 1
		_Smoothness( "Smoothness", Range( 0, 1 ) ) = 0
		[SingleLineTexture] _NormalMap1( "Normal Map 1", 2D ) = "bump" {}
		_NormalMap1Speed( "Normal Map 1 Speed", Range( -1, 1 ) ) = 0.1
		_NormalMap1Strength( "Normal Map 1 Strength", Range( 0, 1 ) ) = 0.08
		_NormalMap1Tiling( "Normal Map 1 Tiling", Vector ) = ( 0.05, 0.1, 0, 0 )
		[SingleLineTexture] _NormalMap2( "Normal Map 2", 2D ) = "white" {}
		_NormalMap2Speed( "Normal Map 2 Speed", Range( -1, 1 ) ) = 0.1
		_NormalMap2Strength( "Normal Map 2 Strength", Range( 0, 1 ) ) = 0.07
		_NormalMap2Tiling( "Normal Map 2 Tiling", Vector ) = ( 0.05, 0.1, 0, 0 )
		[Toggle( _REFRACTION_ON )] _REFRACTION( "REFRACTION", Float ) = 1
		_RefractionStrength( "Refraction Strength", Range( 0, 1 ) ) = 0.3
		_RefractionFadeStart( "Refraction Fade Start", Range( 0, 100 ) ) = 20
		_RefractionFadeLength( "Refraction Fade Length", Range( 0, 100 ) ) = 30
		[SingleLineTexture] _RefractionMap( "Refraction Map", 2D ) = "bump" {}
		_RefractionMap1Tiling( "Refraction Map 1 Tiling", Vector ) = ( 0.2, 0.2, 0, 0 )
		_RefractionMap1Speed( "Refraction Map 1 Speed", Vector ) = ( 0.1, -0.1, 0, 0 )
		_RefractionMap2Tiling( "Refraction Map 2 Tiling", Vector ) = ( 0.4, 0.4, 0, 0 )
		_RefractionMap2Speed( "Refraction Map 2 Speed", Vector ) = ( -0.2, 0.1, 0, 0 )
		[Toggle( _FOAM_ON )] _FOAM( "FOAM", Float ) = 1
		_FoamColor( "Foam Color", Color ) = ( 1, 1, 1, 1 )
		_FoamOpacity( "Foam Opacity", Range( 0, 1 ) ) = 0.6
		_FoamWidth( "Foam Width", Range( 0, 20 ) ) = 2
		_FoamDepth( "Foam Depth", Range( 0, 20 ) ) = 2
		_FoamCoverage( "Foam Coverage", Range( 0, 1 ) ) = 0.5
		_FoamSharpnessMin( "Foam Sharpness Min", Range( 0, 1 ) ) = 1
		_FoamSharpnessMax( "Foam Sharpness Max", Range( 0, 1 ) ) = 1
		_FoamEdgeRoughness( "Foam Edge Roughness", Range( 0, 10 ) ) = 5
		[SingleLineTexture][Space] _FoamMap1( "Foam Map 1", 2D ) = "white" {}
		_FoamMap1Speed( "Foam Map 1 Speed", Range( -1, 1 ) ) = 0.08
		_FoamMap1Tiling( "Foam Map 1 Tiling", Vector ) = ( 0.05, 0.1, 0, 0 )
		[SingleLineTexture] _FoamMap2( "Foam Map 2", 2D ) = "white" {}
		_FoamMap2Speed( "Foam Map 2 Speed", Range( -1, 1 ) ) = -0.06
		_FoamMap2Tiling( "Foam Map 2 Tiling", Vector ) = ( 0.05, 0.1, 0, 0 )
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Off
		GrabPass{ }
		CGINCLUDE
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 4.6
		#pragma shader_feature_local _REFRACTION_ON
		#pragma shader_feature_local _FOAM_ON
		#define ASE_VERSION 19901
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		struct Input
		{
			float3 worldPos;
			float4 screenPos;
			half ASEIsFrontFacing : VFACE;
			float eyeDepth;
		};

		uniform sampler2D _NormalMap1;
		uniform float2 _NormalMap1Tiling;
		uniform float2 Nicrom_WaterN_DirVector1;
		uniform float2 Nicrom_WaterN_UVOffset1;
		uniform half Nicrom_ApplicationIsPlaying;
		uniform float _NormalMap1Speed;
		uniform float Nicrom_WaterN_SpeedScale1;
		uniform float _NormalMap1Strength;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _Depth;
		uniform sampler2D _NormalMap2;
		uniform float2 _NormalMap2Tiling;
		uniform float2 Nicrom_WaterN_DirVector2;
		uniform float2 Nicrom_WaterN_UVOffset2;
		uniform float _NormalMap2Speed;
		uniform float Nicrom_WaterN_SpeedScale2;
		uniform float _NormalMap2Strength;
		uniform float _Debug;
		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform sampler2D _RefractionMap;
		uniform float2 _RefractionMap1Tiling;
		uniform float2 _RefractionMap1Speed;
		uniform float2 _RefractionMap2Tiling;
		uniform float2 _RefractionMap2Speed;
		uniform float _RefractionStrength;
		uniform float _RefractionFadeLength;
		uniform float _RefractionFadeStart;
		uniform float _EdgeFade;
		uniform float _EdgeFadeOffsetSpeed;
		uniform float _EdgeFadeOffset;
		uniform float4 _FoamColor;
		uniform float _FoamSharpnessMin;
		uniform float _FoamSharpnessMax;
		uniform float _FoamCoverage;
		uniform sampler2D _FoamMap1;
		uniform float2 _FoamMap1Tiling;
		uniform float2 Nicrom_WaterF_DirVector1;
		uniform float2 Nicrom_WaterF_UVOffset1;
		uniform float _FoamMap1Speed;
		uniform float Nicrom_WaterF_SpeedScale1;
		uniform sampler2D _FoamMap2;
		uniform float2 _FoamMap2Tiling;
		uniform float2 Nicrom_WaterF_DirVector2;
		uniform float2 Nicrom_WaterF_UVOffset2;
		uniform float _FoamMap2Speed;
		uniform float Nicrom_WaterF_SpeedScale2;
		uniform float _FoamEdgeRoughness;
		uniform float _FoamWidth;
		uniform float _FoamDepth;
		uniform float _FoamOpacity;
		uniform float4 _DeepWaterColor;
		uniform float4 _ShallowWaterColor;
		uniform float _OpacityAbove;
		uniform float _OpacityUnder;
		uniform float _Metallic;
		uniform float _Smoothness;


		inline float4 ASE_ComputeGrabScreenPos( float4 pos )
		{
			#if UNITY_UV_STARTS_AT_TOP
			float scale = -1.0;
			#else
			float scale = 1.0;
			#endif
			float4 o = pos;
			o.y = pos.w * 0.5f;
			o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
			return o;
		}


		float4 Debug39_g1( float Debug_Target, float4 Albedo, float DepthMask, float RefractionFadeMask, float EdgeOpacityMask, float FoamMask )
		{
			if(Debug_Target ==0)
			    return Albedo;
			else if(Debug_Target ==1)
			    return DepthMask;
			else if(Debug_Target ==2)
			    return RefractionFadeMask;
			else if(Debug_Target ==3)
			    return EdgeOpacityMask;
			else
			    return FoamMask;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			o.eyeDepth = -UnityObjectToViewPos( v.vertex.xyz ).z;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_positionWS = i.worldPos;
			float2 WN_WP_XZ81_g53 = (ase_positionWS).xz;
			float2 NormalMap1Tiling14_g53 = _NormalMap1Tiling;
			float2 WN_DirVect1_GV75_g53 = Nicrom_WaterN_DirVector1;
			float2 WaterNormalsOffset1_G69_g53 = Nicrom_WaterN_UVOffset1;
			float ApplicationIsPlaying70_g1 = Nicrom_ApplicationIsPlaying;
			float N_ApplicationIsPlaying85_g53 = ApplicationIsPlaying70_g1;
			float2 lerpResult87_g53 = lerp( ( _Time.y * WN_DirVect1_GV75_g53 ) , WaterNormalsOffset1_G69_g53 , N_ApplicationIsPlaying85_g53);
			float NormalMap1Speed13_g53 = _NormalMap1Speed;
			float WN_SpeedScale1_GV78_g53 = Nicrom_WaterN_SpeedScale1;
			float lerpResult93_g53 = lerp( WN_SpeedScale1_GV78_g53 , 1.0 , N_ApplicationIsPlaying85_g53);
			float2 NormalsUV148_g53 = ( ( WN_WP_XZ81_g53 * NormalMap1Tiling14_g53 ) + ( lerpResult87_g53 * ( NormalMap1Speed13_g53 * lerpResult93_g53 ) ) );
			float NormalMap1Strength38_g53 = _NormalMap1Strength;
			float3 ase_viewVectorWS = ( _WorldSpaceCameraPos.xyz - ase_positionWS );
			float3 ase_viewDirWS = normalize( ase_viewVectorWS );
			float Normals_ViewDir_Y61_g53 = ase_viewDirWS.y;
			float4 ase_positionSS = float4( i.screenPos.xyz , i.screenPos.w + 1e-7 );
			float4 ase_positionSSNorm = ase_positionSS / ase_positionSS.w;
			ase_positionSSNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_positionSSNorm.z : ase_positionSSNorm.z * 0.5 + 0.5;
			float Depth16_g1 = _Depth;
			float screenDepth10_g53 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_positionSSNorm.xy ));
			float distanceDepth10_g53 = abs( ( screenDepth10_g53 - LinearEyeDepth( ase_positionSSNorm.z ) ) / ( Depth16_g1 ) );
			float switchResult28_g53 = (((i.ASEIsFrontFacing>0)?(( Normals_ViewDir_Y61_g53 * distanceDepth10_g53 )):(( distanceDepth10_g53 * -Normals_ViewDir_Y61_g53 ))));
			float DepthFade42_g53 = saturate( switchResult28_g53 );
			float2 NormalMap2Tiling16_g53 = _NormalMap2Tiling;
			float2 WN_DirVect2_GV76_g53 = Nicrom_WaterN_DirVector2;
			float2 WaterNormalsOffset2_G68_g53 = Nicrom_WaterN_UVOffset2;
			float2 lerpResult102_g53 = lerp( ( _Time.y * WN_DirVect2_GV76_g53 ) , WaterNormalsOffset2_G68_g53 , N_ApplicationIsPlaying85_g53);
			float NormalMap2Speed15_g53 = _NormalMap2Speed;
			float WN_SpeedScale2_GV80_g53 = Nicrom_WaterN_SpeedScale2;
			float lerpResult107_g53 = lerp( WN_SpeedScale2_GV80_g53 , 1.0 , N_ApplicationIsPlaying85_g53);
			float2 NormalsUV247_g53 = ( ( WN_WP_XZ81_g53 * NormalMap2Tiling16_g53 ) + ( lerpResult102_g53 * ( NormalMap2Speed15_g53 * lerpResult107_g53 ) ) );
			float NormalMap2Strength39_g53 = _NormalMap2Strength;
			o.Normal = BlendNormals( UnpackScaleNormal( tex2D( _NormalMap1, NormalsUV148_g53 ), ( NormalMap1Strength38_g53 * DepthFade42_g53 ) ) , UnpackScaleNormal( tex2D( _NormalMap2, NormalsUV247_g53 ), ( NormalMap2Strength39_g53 * DepthFade42_g53 ) ) );
			float Debug_Target39_g1 = _Debug;
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_positionSS );
			float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
			float2 appendResult75_g52 = (float2(ase_grabScreenPosNorm.r , ase_grabScreenPosNorm.g));
			float2 appendResult62_g50 = (float2(ase_grabScreenPosNorm.r , ase_grabScreenPosNorm.g));
			float2 WorldPosUVs25_g50 = (ase_positionWS).xz;
			float2 RefractionMap1Tiling15_g50 = _RefractionMap1Tiling;
			float2 RefractionMap1Speed19_g50 = _RefractionMap1Speed;
			float2 RefractionMap2Tiling17_g50 = _RefractionMap2Tiling;
			float2 RefractionMap2Speed21_g50 = _RefractionMap2Speed;
			float RefractionStrength11_g50 = _RefractionStrength;
			float DistortionFadeLength9_g50 = _RefractionFadeLength;
			float DistortionFadeStart13_g50 = _RefractionFadeStart;
			float cameraDepthFade44_g50 = (( i.eyeDepth -_ProjectionParams.y - DistortionFadeStart13_g50 ) / DistortionFadeLength9_g50);
			float temp_output_48_0_g50 = ( 1.0 - saturate( cameraDepthFade44_g50 ) );
			float lerpResult63_g50 = lerp( 0.0 , RefractionStrength11_g50 , temp_output_48_0_g50);
			float EO_ViewDir_Y31_g46 = ase_viewDirWS.y;
			float EdgeBlend26_g46 = _EdgeFade;
			float EdgeFadeOffsetSpeed27_g46 = _EdgeFadeOffsetSpeed;
			float EdgeFadeOffset25_g46 = _EdgeFadeOffset;
			float screenDepth12_g46 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_positionSSNorm.xy ));
			float distanceDepth12_g46 = abs( ( screenDepth12_g46 - LinearEyeDepth( ase_positionSSNorm.z ) ) / ( ( EdgeBlend26_g46 + ( sin( ( _Time.y * EdgeFadeOffsetSpeed27_g46 ) ) * EdgeFadeOffset25_g46 ) ) ) );
			float switchResult17_g46 = (((i.ASEIsFrontFacing>0)?(( abs( EO_ViewDir_Y31_g46 ) * distanceDepth12_g46 )):(( distanceDepth12_g46 * -EO_ViewDir_Y31_g46 ))));
			float EdgeOpacity5_g1 = saturate( switchResult17_g46 );
			#ifdef _REFRACTION_ON
				float2 staticSwitch6_g50 = ( appendResult62_g50 - ( ( ( 0.5 * ( (UnpackNormal( tex2D( _RefractionMap, ( ( WorldPosUVs25_g50 * RefractionMap1Tiling15_g50 ) + ( RefractionMap1Speed19_g50 * _Time.y ) ) ) )).xy + (UnpackNormal( tex2D( _RefractionMap, ( ( WorldPosUVs25_g50 * RefractionMap2Tiling17_g50 ) + ( _Time.y * RefractionMap2Speed21_g50 ) ) ) )).xy ) ) * 0.1 * lerpResult63_g50 ) * EdgeOpacity5_g1 ) );
			#else
				float2 staticSwitch6_g50 = appendResult62_g50;
			#endif
			float2 RefractionUVs14_g1 = staticSwitch6_g50;
			float2 Albedo_RefractionUVs62_g52 = RefractionUVs14_g1;
			float Albedo_ScreenPos_W65_g52 = ase_positionSS.w;
			float depthLinearEye7_g52 = LinearEyeDepth( SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, float4( Albedo_RefractionUVs62_g52, 0.0 , 0.0 ).xy ) );
			float2 lerpResult12_g52 = lerp( appendResult75_g52 , Albedo_RefractionUVs62_g52 , step( Albedo_ScreenPos_W65_g52 , depthLinearEye7_g52 ));
			float2 RefractedUVs13_g52 = lerpResult12_g52;
			float4 screenColor39_g52 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,RefractedUVs13_g52);
			float4 ScreenColor40_g52 = screenColor39_g52;
			float4 temp_cast_1 = (0.0).xxxx;
			float4 FoamColor87_g49 = _FoamColor;
			float FoamSharpnessMin77_g49 = _FoamSharpnessMin;
			float FoamSharpnessMax78_g49 = _FoamSharpnessMax;
			float FoamCoverage73_g49 = _FoamCoverage;
			float2 F_WP_XZ118_g49 = (ase_positionWS).xz;
			float2 FoamMap1Tiling68_g49 = _FoamMap1Tiling;
			float2 F_DirVect1_GV112_g49 = Nicrom_WaterF_DirVector1;
			float2 F_UVOffset1_GV98_g49 = Nicrom_WaterF_UVOffset1;
			float F_ApplicationIsPlaying115_g49 = 0.0;
			float2 lerpResult123_g49 = lerp( ( _Time.y * F_DirVect1_GV112_g49 ) , F_UVOffset1_GV98_g49 , F_ApplicationIsPlaying115_g49);
			float FoamMap1Speed69_g49 = _FoamMap1Speed;
			float F_SpeedScale1_GV110_g49 = Nicrom_WaterF_SpeedScale1;
			float lerpResult132_g49 = lerp( F_SpeedScale1_GV110_g49 , 1.0 , F_ApplicationIsPlaying115_g49);
			float2 FoamUVs122_g49 = ( ( F_WP_XZ118_g49 * FoamMap1Tiling68_g49 ) + ( lerpResult123_g49 * ( FoamMap1Speed69_g49 * lerpResult132_g49 ) ) );
			float2 FoamMap2Tiling70_g49 = _FoamMap2Tiling;
			float2 F_DirVect2_GV113_g49 = Nicrom_WaterF_DirVector2;
			float2 F_UVOffset2_GV99_g49 = Nicrom_WaterF_UVOffset2;
			float2 lerpResult129_g49 = lerp( ( _Time.y * F_DirVect2_GV113_g49 ) , F_UVOffset2_GV99_g49 , F_ApplicationIsPlaying115_g49);
			float FoamMap2Speed71_g49 = _FoamMap2Speed;
			float F_SpeedScale2_GV111_g49 = Nicrom_WaterF_SpeedScale2;
			float lerpResult139_g49 = lerp( F_SpeedScale2_GV111_g49 , 1.0 , F_ApplicationIsPlaying115_g49);
			float2 FoamUVs221_g49 = ( ( F_WP_XZ118_g49 * FoamMap2Tiling70_g49 ) + ( lerpResult129_g49 * ( FoamMap2Speed71_g49 * lerpResult139_g49 ) ) );
			float smoothstepResult36_g49 = smoothstep( FoamSharpnessMin77_g49 , FoamSharpnessMax78_g49 , (  (-1.0 + ( FoamCoverage73_g49 - 0.0 ) * ( 1.0 - -1.0 ) / ( 1.0 - 0.0 ) ) + ( ( tex2D( _FoamMap1, FoamUVs122_g49 ).r + tex2D( _FoamMap2, FoamUVs221_g49 ).r ) * 0.5 ) ));
			float FoamTextureColor40_g49 = smoothstepResult36_g49;
			float FoamEdgeRoughness82_g49 = _FoamEdgeRoughness;
			float FoamWidth83_g49 = _FoamWidth;
			float Foam_VewDir_Y91_g49 = ase_viewDirWS.y;
			float FoamDepth79_g49 = _FoamDepth;
			float screenDepth37_g49 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_positionSSNorm.xy ));
			float distanceDepth37_g49 = abs( ( screenDepth37_g49 - LinearEyeDepth( ase_positionSSNorm.z ) ) / ( FoamDepth79_g49 ) );
			float switchResult45_g49 = (((i.ASEIsFrontFacing>0)?(( Foam_VewDir_Y91_g49 * distanceDepth37_g49 )):(( distanceDepth37_g49 * -Foam_VewDir_Y91_g49 ))));
			float lerpResult54_g49 = lerp( ( 1.0 - saturate( ( ( ( FoamTextureColor40_g49 * FoamEdgeRoughness82_g49 ) + FoamWidth83_g49 ) * saturate( switchResult45_g49 ) ) ) ) , 0.0 , FoamTextureColor40_g49);
			float FoamMaskOpacity85_g49 = _FoamOpacity;
			float FoamMask103_g49 = ( EdgeOpacity5_g1 * ( lerpResult54_g49 * FoamMaskOpacity85_g49 ) );
			#ifdef _FOAM_ON
				float4 staticSwitch62_g49 = ( FoamColor87_g49 * FoamMask103_g49 );
			#else
				float4 staticSwitch62_g49 = temp_cast_1;
			#endif
			float4 Foam15_g1 = staticSwitch62_g49;
			float4 DeepWaterColor19_g52 = _DeepWaterColor;
			float4 ShallowWaterColor18_g52 = _ShallowWaterColor;
			float Depth15_g52 = Depth16_g1;
			float depthLinearEye25_g52 = LinearEyeDepth( SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, float4( RefractedUVs13_g52, 0.0 , 0.0 ).xy ) );
			float DepthMask32_g52 = saturate( ( Depth15_g52 / abs( ( depthLinearEye25_g52 - Albedo_ScreenPos_W65_g52 ) ) ) );
			float4 lerpResult37_g52 = lerp( DeepWaterColor19_g52 , ShallowWaterColor18_g52 , DepthMask32_g52);
			float4 DepthColor38_g52 = lerpResult37_g52;
			float4 lerpResult45_g52 = lerp( ScreenColor40_g52 , DepthColor38_g52 , (DepthColor38_g52).a);
			float4 lerpResult58_g52 = lerp( ScreenColor40_g52 , saturate( ( Foam15_g1 + lerpResult45_g52 ) ) , EdgeOpacity5_g1);
			float OpacityAbove23_g52 = _OpacityAbove;
			float4 lerpResult55_g52 = lerp( ScreenColor40_g52 , lerpResult58_g52 , OpacityAbove23_g52);
			float OpacityUnder22_g52 = _OpacityUnder;
			float4 lerpResult54_g52 = lerp( ScreenColor40_g52 , DepthColor38_g52 , OpacityUnder22_g52);
			float4 switchResult56_g52 = (((i.ASEIsFrontFacing>0)?(lerpResult55_g52):(lerpResult54_g52)));
			float4 Albedo41_g1 = switchResult56_g52;
			float4 Albedo39_g1 = Albedo41_g1;
			float DepthMask27_g1 = DepthMask32_g52;
			float DepthMask39_g1 = DepthMask27_g1;
			float RefractionFadeMask48_g1 = lerpResult63_g50;
			float RefractionFadeMask39_g1 = RefractionFadeMask48_g1;
			float EdgeOpacityMask39_g1 = EdgeOpacity5_g1;
			float FoamMask_252_g1 = FoamMask103_g49;
			float FoamMask39_g1 = FoamMask_252_g1;
			float4 localDebug39_g1 = Debug39_g1( Debug_Target39_g1 , Albedo39_g1 , DepthMask39_g1 , RefractionFadeMask39_g1 , EdgeOpacityMask39_g1 , FoamMask39_g1 );
			o.Albedo = localDebug39_g1.xyz;
			float Metallic_MP23_g1 = _Metallic;
			o.Metallic = Metallic_MP23_g1;
			float switchResult21_g1 = (((i.ASEIsFrontFacing>0)?(_Smoothness):(0.0)));
			float Smoothness_MP24_g1 = switchResult21_g1;
			o.Smoothness = Smoothness_MP24_g1;
			o.Alpha = EdgeOpacity5_g1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows nolightmap  vertex:vertexDataFunc 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 4.6
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
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float1 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				float4 screenPos : TEXCOORD3;
				float4 tSpace0 : TEXCOORD4;
				float4 tSpace1 : TEXCOORD5;
				float4 tSpace2 : TEXCOORD6;
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
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.x = customInputData.eyeDepth;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				o.screenPos = ComputeScreenPos( o.pos );
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
				surfIN.eyeDepth = IN.customPack1.x;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.screenPos = IN.screenPos;
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "Nicrom.CMI_Water"
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;1097;6880,-320;Inherit;False;Nicrom - Water;0;;1;be7d9e63055487e488963cb902c5f267;0;0;5;FLOAT4;0;FLOAT3;34;FLOAT;35;FLOAT;36;FLOAT;37
Node;AmplifyShaderEditor.StandardSurfaceOutputNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;0;7168,-320;Float;False;True;-1;6;Nicrom.CMI_Water;0;0;Standard;Nicrom/ASE/Water;False;False;False;False;False;False;True;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Off;1;False;;0;False;;False;0;False;;0;False;;False;0;Transparent;0.5;True;True;0;False;Transparent;;Transparent;All;12;all;True;True;True;True;0;False;;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;2;15;10;25;False;0.5;True;2;5;False;;10;False;;0;0;False;;0;False;;0;False;;0;False;;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;;-1;0;False;;0;0;0;False;0.1;False;;0;False;;False;17;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;16;FLOAT4;0,0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;0;0;1097;0
WireConnection;0;1;1097;34
WireConnection;0;3;1097;35
WireConnection;0;4;1097;36
WireConnection;0;9;1097;37
ASEEND*/
//CHKSM=AECFBD28A009172BADB3C3590BA40E22D798C755