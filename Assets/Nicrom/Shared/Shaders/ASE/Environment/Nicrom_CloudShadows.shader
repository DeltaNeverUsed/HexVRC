// Made with Amplify Shader Editor v1.9.9.1
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Nicrom/ASE/Cloud Shadows"
{
    Properties
    {
		_ShadowStrength( "Shadow Strength", Range( 0, 1 ) ) = 0.5
		_ShadowCoverage( "Shadow Coverage", Range( 0, 1 ) ) = 0.65
		_ShadowSharpMin( "Shadow Sharp Min", Range( 0, 1 ) ) = 0.3
		_ShadowSharpMax( "Shadow Sharp Max", Range( 0, 1 ) ) = 0.7
		[KeywordEnum( Two,Three )] _ShadowLayers( "Shadow Layers", Float ) = 1
		[SingleLineTexture] _SL1Noise( "SL1 Noise", 2D ) = "white" {}
		_SL1Speed( "SL1 Speed", Range( 0, 2 ) ) = 0.5
		_SL1Opacity( "SL1 Opacity", Range( 0, 1 ) ) = 1
		[Toggle( _SL1SHARPNESS_ON )] _SL1Sharpness( "SL1 Sharpness", Float ) = 0
		_SL1SharpMin( "SL1 Sharp Min", Range( 0, 1 ) ) = 0
		_SL1SharpMax( "SL1 Sharp Max", Range( 0, 1 ) ) = 1
		_SL1RemapMin( "SL1 Remap Min", Range( -1, 1 ) ) = 0
		_SL1RemapMax( "SL1 Remap Max", Range( -1, 1 ) ) = 1
		[SingleLineTexture] _SL2Noise( "SL2 Noise", 2D ) = "white" {}
		_SL2Speed( "SL2 Speed", Range( 0, 2 ) ) = 0.48
		_SL2Opacity( "SL2 Opacity", Range( 0, 1 ) ) = 1
		[Toggle( _SL2SHARPNESS_ON )] _SL2Sharpness( "SL2 Sharpness", Float ) = 0
		_SL2SharpMin( "SL2 Sharp Min", Range( 0, 1 ) ) = 0
		_SL2SharpMax( "SL2 Sharp Max", Range( 0, 1 ) ) = 1
		_SL2RemapMin( "SL2 Remap Min", Range( -1, 1 ) ) = 0
		_SL2RemapMax( "SL2 Remap Max", Range( -1, 1 ) ) = 1
		[SingleLineTexture] _SL3Noise( "SL3 Noise", 2D ) = "white" {}
		_SL3Speed( "SL3 Speed", Range( 0, 2 ) ) = 0.46
		_SL3Opacity( "SL3 Opacity", Range( 0, 1 ) ) = 1
		[Toggle( _SL3SHARPNESS_ON )] _SL3Sharpness( "SL3 Sharpness", Float ) = 0
		_SL3SharpMin( "SL3 Sharp Min", Range( 0, 1 ) ) = 0
		_SL3SharpMax( "SL3 Sharp Max", Range( 0, 1 ) ) = 1
		_SL3RemapMin( "SL3 Remap Min", Range( -1, 1 ) ) = 0
		_SL3RemapMax( "SL3 Remap Max", Range( -1, 1 ) ) = 1

    }

	SubShader
	{
		LOD 0

		
		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		AlphaToMask Off
		Cull Back
		ColorMask RGBA
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		
		
        Pass
        {
			Name "Custom RT Update"
            CGPROGRAM
            #define ASE_VERSION 19901

            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex ASECustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.5
			#include "UnityShaderVariables.cginc"
			#define ASE_NEEDS_TEXTURE_COORDINATES0
			#define ASE_NEEDS_FRAG_TEXTURE_COORDINATES0
			#pragma shader_feature_local _SHADOWLAYERS_TWO _SHADOWLAYERS_THREE
			#pragma shader_feature_local _SL1SHARPNESS_ON
			#pragma shader_feature_local _SL2SHARPNESS_ON
			#pragma shader_feature_local _SL3SHARPNESS_ON


			struct ase_appdata_customrendertexture
			{
				uint vertexID : SV_VertexID;
				
			};

			struct ase_v2f_customrendertexture
			{
				float4 vertex           : SV_POSITION;
				float3 localTexcoord    : TEXCOORD0;    // Texcoord local to the update zone (== globalTexcoord if no partial update zone is specified)
				float3 globalTexcoord   : TEXCOORD1;    // Texcoord relative to the complete custom texture
				uint primitiveID        : TEXCOORD2;    // Index of the update zone (correspond to the index in the updateZones of the Custom Texture)
				float3 direction        : TEXCOORD3;    // For cube textures, direction of the pixel being rendered in the cubemap
				
			};

			uniform float _ShadowStrength;
			uniform float _ShadowSharpMin;
			uniform float _ShadowSharpMax;
			uniform sampler2D _SL1Noise;
			uniform float2 Nicrom_CS_SL1_DirVector;
			uniform float2 Nicrom_CS_SL1_UVOffset;
			uniform half Nicrom_ApplicationIsPlaying;
			uniform float _SL1Speed;
			uniform float Nicrom_CS_SL1_SpeedScale;
			uniform float _SL1SharpMin;
			uniform float _SL1SharpMax;
			uniform float _SL1RemapMin;
			uniform float _SL1RemapMax;
			uniform float _SL1Opacity;
			uniform sampler2D _SL2Noise;
			uniform float2 Nicrom_CS_SL2_DirVector;
			uniform float2 Nicrom_CS_SL2_UVOffset;
			uniform float _SL2Speed;
			uniform float Nicrom_CS_SL2_SpeedScale;
			uniform float _SL2SharpMin;
			uniform float _SL2SharpMax;
			uniform float _SL2RemapMin;
			uniform float _SL2RemapMax;
			uniform float _SL2Opacity;
			uniform sampler2D _SL3Noise;
			uniform float2 Nicrom_CS_SL3_DirVector;
			uniform float2 Nicrom_CS_SL3_UVOffset;
			uniform float _SL3Speed;
			uniform float Nicrom_CS_SL3_SpeedScale;
			uniform float _SL3SharpMin;
			uniform float _SL3SharpMax;
			uniform float _SL3RemapMin;
			uniform float _SL3RemapMax;
			uniform float _SL3Opacity;
			uniform float _ShadowCoverage;


			ase_v2f_customrendertexture ASECustomRenderTextureVertexShader(ase_appdata_customrendertexture IN  )
			{
				ase_v2f_customrendertexture OUT;
				
			#if UNITY_UV_STARTS_AT_TOP
				const float2 vertexPositions[6] =
				{
					{ -1.0f,  1.0f },
					{ -1.0f, -1.0f },
					{  1.0f, -1.0f },
					{  1.0f,  1.0f },
					{ -1.0f,  1.0f },
					{  1.0f, -1.0f }
				};

				const float2 texCoords[6] =
				{
					{ 0.0f, 0.0f },
					{ 0.0f, 1.0f },
					{ 1.0f, 1.0f },
					{ 1.0f, 0.0f },
					{ 0.0f, 0.0f },
					{ 1.0f, 1.0f }
				};
			#else
				const float2 vertexPositions[6] =
				{
					{  1.0f,  1.0f },
					{ -1.0f, -1.0f },
					{ -1.0f,  1.0f },
					{ -1.0f, -1.0f },
					{  1.0f,  1.0f },
					{  1.0f, -1.0f }
				};

				const float2 texCoords[6] =
				{
					{ 1.0f, 1.0f },
					{ 0.0f, 0.0f },
					{ 0.0f, 1.0f },
					{ 0.0f, 0.0f },
					{ 1.0f, 1.0f },
					{ 1.0f, 0.0f }
				};
			#endif

				uint primitiveID = IN.vertexID / 6;
				uint vertexID = IN.vertexID % 6;
				float3 updateZoneCenter = CustomRenderTextureCenters[primitiveID].xyz;
				float3 updateZoneSize = CustomRenderTextureSizesAndRotations[primitiveID].xyz;
				float rotation = CustomRenderTextureSizesAndRotations[primitiveID].w * UNITY_PI / 180.0f;

			#if !UNITY_UV_STARTS_AT_TOP
				rotation = -rotation;
			#endif

				// Normalize rect if needed
				if (CustomRenderTextureUpdateSpace > 0.0) // Pixel space
				{
					// Normalize xy because we need it in clip space.
					updateZoneCenter.xy /= _CustomRenderTextureInfo.xy;
					updateZoneSize.xy /= _CustomRenderTextureInfo.xy;
				}
				else // normalized space
				{
					// Un-normalize depth because we need actual slice index for culling
					updateZoneCenter.z *= _CustomRenderTextureInfo.z;
					updateZoneSize.z *= _CustomRenderTextureInfo.z;
				}

				// Compute rotation

				// Compute quad vertex position
				float2 clipSpaceCenter = updateZoneCenter.xy * 2.0 - 1.0;
				float2 pos = vertexPositions[vertexID] * updateZoneSize.xy;
				pos = CustomRenderTextureRotate2D(pos, rotation);
				pos.x += clipSpaceCenter.x;
			#if UNITY_UV_STARTS_AT_TOP
				pos.y += clipSpaceCenter.y;
			#else
				pos.y -= clipSpaceCenter.y;
			#endif

				// For 3D texture, cull quads outside of the update zone
				// This is neeeded in additional to the preliminary minSlice/maxSlice done on the CPU because update zones can be disjointed.
				// ie: slices [1..5] and [10..15] for two differents zones so we need to cull out slices 0 and [6..9]
				if (CustomRenderTextureIs3D > 0.0)
				{
					int minSlice = (int)(updateZoneCenter.z - updateZoneSize.z * 0.5);
					int maxSlice = minSlice + (int)updateZoneSize.z;
					if (_CustomRenderTexture3DSlice < minSlice || _CustomRenderTexture3DSlice >= maxSlice)
					{
						pos.xy = float2(1000.0, 1000.0); // Vertex outside of ncs
					}
				}

				OUT.vertex = float4(pos, 0.0, 1.0);
				OUT.primitiveID = asuint(CustomRenderTexturePrimitiveIDs[primitiveID]);
				OUT.localTexcoord = float3(texCoords[vertexID], CustomRenderTexture3DTexcoordW);
				OUT.globalTexcoord = float3(pos.xy * 0.5 + 0.5, CustomRenderTexture3DTexcoordW);
			#if UNITY_UV_STARTS_AT_TOP
				OUT.globalTexcoord.y = 1.0 - OUT.globalTexcoord.y;
			#endif
				OUT.direction = CustomRenderTextureComputeCubeDirection(OUT.globalTexcoord.xy);

				return OUT;
			}

            float4 frag(ase_v2f_customrendertexture IN ) : COLOR
            {
				float4 finalColor;
				float ShadowStrength73_g2 = _ShadowStrength;
				float ShadowSharpMin68_g2 = _ShadowSharpMin;
				float ShadowSharpMax67_g2 = _ShadowSharpMax;
				float2 SL1_DirVector_GV283_g2 = Nicrom_CS_SL1_DirVector;
				float2 SL1_UVOffset18_g2 = Nicrom_CS_SL1_UVOffset;
				float ApplicationIsPlaying285_g2 = Nicrom_ApplicationIsPlaying;
				float2 lerpResult289_g2 = lerp( ( _Time.y * SL1_DirVector_GV283_g2 ) , SL1_UVOffset18_g2 , ApplicationIsPlaying285_g2);
				float SL1_Speed6_g2 = _SL1Speed;
				float SL1_SpeedScale_GV278_g2 = Nicrom_CS_SL1_SpeedScale;
				float lerpResult304_g2 = lerp( SL1_SpeedScale_GV278_g2 , 1.0 , ApplicationIsPlaying285_g2);
				float2 texCoord12_g2 = IN.localTexcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float2 UVs19_g2 = texCoord12_g2;
				float2 SL1_UVs84_g2 = ( ( lerpResult289_g2 * ( SL1_Speed6_g2 * 0.1 * lerpResult304_g2 ) ) + UVs19_g2 );
				float SL1_Noise_Tex193_g2 = tex2D( _SL1Noise, SL1_UVs84_g2 ).r;
				float SL1_SharpMin174_g2 = _SL1SharpMin;
				float SL1_SharpMax175_g2 = _SL1SharpMax;
				float smoothstepResult190_g2 = smoothstep( SL1_SharpMin174_g2 , SL1_SharpMax175_g2 , SL1_Noise_Tex193_g2);
				#ifdef _SL1SHARPNESS_ON
				float staticSwitch206_g2 = smoothstepResult190_g2;
				#else
				float staticSwitch206_g2 = SL1_Noise_Tex193_g2;
				#endif
				float SL1_RemapMin253_g2 = _SL1RemapMin;
				float SL1_RemapMax254_g2 = _SL1RemapMax;
				float SL1_Opacity92_g2 = _SL1Opacity;
				float SL1_Noise48_g2 = (  (SL1_RemapMin253_g2 + ( staticSwitch206_g2 - 0.0 ) * ( SL1_RemapMax254_g2 - SL1_RemapMin253_g2 ) / ( 1.0 - 0.0 ) ) * SL1_Opacity92_g2 );
				float2 SL2_DirVector_GV282_g2 = Nicrom_CS_SL2_DirVector;
				float2 SL2_UVOffset17_g2 = Nicrom_CS_SL2_UVOffset;
				float2 lerpResult296_g2 = lerp( ( _Time.y * SL2_DirVector_GV282_g2 ) , SL2_UVOffset17_g2 , ApplicationIsPlaying285_g2);
				float SL2_Speed7_g2 = _SL2Speed;
				float SL2_SpeedScale_GV279_g2 = Nicrom_CS_SL2_SpeedScale;
				float lerpResult307_g2 = lerp( SL2_SpeedScale_GV279_g2 , 1.0 , ApplicationIsPlaying285_g2);
				float2 SL2_UVs86_g2 = ( ( lerpResult296_g2 * ( SL2_Speed7_g2 * 0.1 * lerpResult307_g2 ) ) + UVs19_g2 );
				float SL2_Noise_Tex194_g2 = tex2D( _SL2Noise, SL2_UVs86_g2 ).r;
				float SL2_SharpMin182_g2 = _SL2SharpMin;
				float SL2_SharpMax183_g2 = _SL2SharpMax;
				float smoothstepResult202_g2 = smoothstep( SL2_SharpMin182_g2 , SL2_SharpMax183_g2 , SL2_Noise_Tex194_g2);
				#ifdef _SL2SHARPNESS_ON
				float staticSwitch248_g2 = smoothstepResult202_g2;
				#else
				float staticSwitch248_g2 = SL2_Noise_Tex194_g2;
				#endif
				float SL2_RemapMin258_g2 = _SL2RemapMin;
				float SL2_RemapMax257_g2 = _SL2RemapMax;
				float SL2_Opacity103_g2 = _SL2Opacity;
				float SL2_Noise49_g2 = (  (SL2_RemapMin258_g2 + ( staticSwitch248_g2 - 0.0 ) * ( SL2_RemapMax257_g2 - SL2_RemapMin258_g2 ) / ( 1.0 - 0.0 ) ) * SL2_Opacity103_g2 );
				float CS_2L243_g2 = ( ( SL1_Noise48_g2 + SL2_Noise49_g2 ) / 2.0 );
				float2 SL3_DirVector_GV281_g2 = Nicrom_CS_SL3_DirVector;
				float2 SL3_UVOffset16_g2 = Nicrom_CS_SL3_UVOffset;
				float2 lerpResult302_g2 = lerp( ( _Time.y * SL3_DirVector_GV281_g2 ) , SL3_UVOffset16_g2 , ApplicationIsPlaying285_g2);
				float SL3_Speed8_g2 = _SL3Speed;
				float SL3_SpeedScale_GV280_g2 = Nicrom_CS_SL3_SpeedScale;
				float lerpResult309_g2 = lerp( SL3_SpeedScale_GV280_g2 , 1.0 , ApplicationIsPlaying285_g2);
				float2 SL3_UVs88_g2 = ( ( lerpResult302_g2 * ( SL3_Speed8_g2 * 0.1 * lerpResult309_g2 ) ) + UVs19_g2 );
				float SL3_Noise_Tex195_g2 = tex2D( _SL3Noise, SL3_UVs88_g2 ).r;
				float SL3_SharpMin188_g2 = _SL3SharpMin;
				float SL3_SharpMax189_g2 = _SL3SharpMax;
				float smoothstepResult205_g2 = smoothstep( SL3_SharpMin188_g2 , SL3_SharpMax189_g2 , SL3_Noise_Tex195_g2);
				#ifdef _SL3SHARPNESS_ON
				float staticSwitch242_g2 = smoothstepResult205_g2;
				#else
				float staticSwitch242_g2 = SL3_Noise_Tex195_g2;
				#endif
				float SL3_RemapMin260_g2 = _SL3RemapMin;
				float SL3_RemapMax262_g2 = _SL3RemapMax;
				float SL3_Opacity112_g2 = _SL3Opacity;
				float SL3_Noise50_g2 = (  (SL3_RemapMin260_g2 + ( staticSwitch242_g2 - 0.0 ) * ( SL3_RemapMax262_g2 - SL3_RemapMin260_g2 ) / ( 1.0 - 0.0 ) ) * SL3_Opacity112_g2 );
				float CS_3L244_g2 = ( ( SL1_Noise48_g2 + SL2_Noise49_g2 + SL3_Noise50_g2 ) / 3.0 );
				#if defined( _SHADOWLAYERS_TWO )
				float staticSwitch65_g2 = CS_2L243_g2;
				#elif defined( _SHADOWLAYERS_THREE )
				float staticSwitch65_g2 = CS_3L244_g2;
				#else
				float staticSwitch65_g2 = CS_3L244_g2;
				#endif
				float ShadowsCoverage59_g2 = _ShadowCoverage;
				float smoothstepResult75_g2 = smoothstep( ShadowSharpMin68_g2 , ShadowSharpMax67_g2 , saturate( ( staticSwitch65_g2 +  (-1.0 + ( ShadowsCoverage59_g2 - 0.0 ) * ( 1.0 - -1.0 ) / ( 1.0 - 0.0 ) ) ) ));
				float4 temp_cast_0 = (( 1.0 - ( ShadowStrength73_g2 * smoothstepResult75_g2 ) )).xxxx;
				
                finalColor = temp_cast_0;
				return finalColor;
            }
            ENDCG
		}
    }
	
	CustomEditor "Nicrom.CMI_CloudShadows"
	Fallback Off
}
/*ASEBEGIN
Version=19901
Node;AmplifyShaderEditor.FunctionNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;153;2304,-384;Inherit;False;Nicrom - Cloud Shadows;0;;2;c82a1e863c57a0c4ea68dd928d5d4144;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode, AmplifyShaderEditor, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null;29;2656,-384;Float;False;True;-1;2;Nicrom.CMI_CloudShadows;0;2;Nicrom/ASE/Cloud Shadows;32120270d1b3a8746af2aca8bc749736;True;Custom RT Update;0;0;Custom RT Update;1;False;True;0;1;False;;0;False;;0;1;False;;0;False;;True;0;False;;0;False;;False;False;False;False;False;False;False;False;False;True;0;False;;False;True;0;False;;False;True;True;True;True;True;0;False;;False;False;False;False;False;False;False;True;False;0;False;;255;False;;255;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;0;False;;False;True;1;False;;True;3;False;;True;True;0;False;;0;False;;True;0;True;2;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;3;False;0;;0;0;Standard;0;0;1;True;False;;False;0
WireConnection;29;0;153;0
ASEEND*/
//CHKSM=645D17440D7012FD36CA801311EB8E05C5E69747