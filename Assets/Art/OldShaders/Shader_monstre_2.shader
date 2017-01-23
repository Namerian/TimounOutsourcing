// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:997,x:33512,y:32702,varname:node_997,prsc:2|diff-2471-RGB,spec-9967-OUT,normal-9751-RGB,emission-9916-OUT,amdfl-6126-OUT,clip-7969-B;n:type:ShaderForge.SFN_Tex2d,id:4264,x:31730,y:32834,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_4264,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6ab58722976928d4e973ca2699c3e6f8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9751,x:32450,y:32867,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_9751,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1c9726fbdf681294cb10bbdec7657503,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:2471,x:32157,y:32578,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_2471,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:86b7001bc8c0a004d967e67f7c7203fd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7969,x:32321,y:33135,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:node_7969,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b00f95e7057884d40956440a4d252b13,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9967,x:32093,y:32868,varname:node_9967,prsc:2|A-4264-RGB,B-1941-OUT;n:type:ShaderForge.SFN_Slider,id:1941,x:31713,y:32996,ptovrint:False,ptlb:Spec_intensity,ptin:_Spec_intensity,varname:node_1941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_LightVector,id:5058,x:31630,y:32383,varname:node_5058,prsc:2;n:type:ShaderForge.SFN_Dot,id:2066,x:31868,y:32400,varname:node_2066,prsc:2,dt:0|A-5058-OUT,B-4898-OUT;n:type:ShaderForge.SFN_NormalVector,id:4898,x:31647,y:32524,prsc:2,pt:False;n:type:ShaderForge.SFN_Clamp01,id:3410,x:32084,y:32370,varname:node_3410,prsc:2|IN-2066-OUT;n:type:ShaderForge.SFN_Multiply,id:2896,x:32412,y:32397,varname:node_2896,prsc:2|A-3410-OUT,B-2471-RGB;n:type:ShaderForge.SFN_Fresnel,id:9052,x:32322,y:33908,varname:node_9052,prsc:2|NRM-4427-OUT,EXP-345-OUT;n:type:ShaderForge.SFN_Reciprocal,id:345,x:32148,y:33979,varname:node_345,prsc:2|IN-4934-OUT;n:type:ShaderForge.SFN_Slider,id:4934,x:31801,y:34004,ptovrint:False,ptlb:fresnel_intensity,ptin:_fresnel_intensity,varname:node_4934,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.03294,max:10;n:type:ShaderForge.SFN_Dot,id:1721,x:31857,y:33487,varname:node_1721,prsc:2,dt:0|A-6512-OUT,B-9413-OUT;n:type:ShaderForge.SFN_LightVector,id:6512,x:31625,y:33534,varname:node_6512,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9413,x:31719,y:33722,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:4730,x:31941,y:33346,varname:node_4730,prsc:2|A-1721-OUT,B-9052-OUT;n:type:ShaderForge.SFN_Posterize,id:3125,x:32410,y:33300,varname:node_3125,prsc:2|IN-1382-OUT,STPS-647-OUT;n:type:ShaderForge.SFN_Vector1,id:647,x:32644,y:33827,varname:node_647,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:9775,x:32882,y:33321,varname:node_9775,prsc:2|A-2471-RGB,B-8889-RGB;n:type:ShaderForge.SFN_AmbientLight,id:8889,x:32706,y:33480,varname:node_8889,prsc:2;n:type:ShaderForge.SFN_Add,id:9916,x:33142,y:33210,varname:node_9916,prsc:2|A-4314-OUT,B-5307-OUT;n:type:ShaderForge.SFN_Clamp01,id:4314,x:32634,y:33271,varname:node_4314,prsc:2|IN-3125-OUT;n:type:ShaderForge.SFN_Color,id:4493,x:32882,y:33540,ptovrint:False,ptlb:ambient shadows,ptin:_ambientshadows,varname:node_4493,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3765571,c2:0.2728157,c3:0.6397059,c4:1;n:type:ShaderForge.SFN_Multiply,id:5307,x:33077,y:33431,varname:node_5307,prsc:2|A-9775-OUT,B-4493-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:5605,x:32099,y:33413,varname:node_5605,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1382,x:32223,y:33257,varname:node_1382,prsc:2|A-4730-OUT,B-5605-OUT;n:type:ShaderForge.SFN_Multiply,id:6126,x:32679,y:32443,varname:node_6126,prsc:2|A-2896-OUT,B-2954-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:2954,x:32404,y:32545,varname:node_2954,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:4427,x:32003,y:33734,prsc:2,pt:False;proporder:9751-2471-4264-1941-7969-4934-4493;pass:END;sub:END;*/

Shader "Custom/Shader_monstre_2" {
    Properties {
        _Normal ("Normal", 2D) = "bump" {}
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Specular ("Specular", 2D) = "white" {}
        _Spec_intensity ("Spec_intensity", Range(0, 1)) = 1
        _Mask ("Mask", 2D) = "white" {}
        _fresnel_intensity ("fresnel_intensity", Range(0, 10)) = 2.03294
        _ambientshadows ("ambient shadows", Color) = (0.3765571,0.2728157,0.6397059,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Spec_intensity;
            uniform float _fresnel_intensity;
            uniform float4 _ambientshadows;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                clip(_Mask_var.b - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float3 specularColor = (_Specular_var.rgb*_Spec_intensity);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                indirectDiffuse += ((saturate(dot(lightDirection,i.normalDir))*_Diffuse_var.rgb)*attenuation); // Diffuse Ambient Light
                float3 diffuseColor = _Diffuse_var.rgb;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_647 = 2.0;
                float3 emissive = (saturate(floor(((dot(lightDirection,i.normalDir)*pow(1.0-max(0,dot(i.normalDir, viewDirection)),(1.0 / _fresnel_intensity)))*attenuation) * node_647) / (node_647 - 1))+((_Diffuse_var.rgb*UNITY_LIGHTMODEL_AMBIENT.rgb)*_ambientshadows.rgb));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform float _Spec_intensity;
            uniform float _fresnel_intensity;
            uniform float4 _ambientshadows;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                clip(_Mask_var.b - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float3 specularColor = (_Specular_var.rgb*_Spec_intensity);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * (UNITY_PI / 4) );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(i.uv0, _Mask));
                clip(_Mask_var.b - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
