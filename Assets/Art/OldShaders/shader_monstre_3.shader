// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.3853806,fgcg:0.8010798,fgcb:0.9705882,fgca:1,fgde:0.02,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:687,x:33781,y:32688,varname:node_687,prsc:2|diff-1945-OUT,normal-9164-RGB,emission-7883-OUT,clip-2425-R;n:type:ShaderForge.SFN_Tex2d,id:6472,x:32500,y:32624,ptovrint:False,ptlb:diffuse,ptin:_diffuse,varname:node_6472,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:86b7001bc8c0a004d967e67f7c7203fd,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9164,x:32442,y:32877,ptovrint:False,ptlb:normal,ptin:_normal,varname:node_9164,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1c9726fbdf681294cb10bbdec7657503,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Fresnel,id:4975,x:32529,y:33056,varname:node_4975,prsc:2|EXP-5881-OUT;n:type:ShaderForge.SFN_Slider,id:8402,x:32002,y:33144,ptovrint:False,ptlb:fresnel_strength,ptin:_fresnel_strength,varname:node_8402,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2735043,max:1;n:type:ShaderForge.SFN_Reciprocal,id:5881,x:32356,y:33118,varname:node_5881,prsc:2|IN-8402-OUT;n:type:ShaderForge.SFN_LightVector,id:4163,x:31924,y:32404,varname:node_4163,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:3882,x:31885,y:32571,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:8170,x:32123,y:32464,varname:node_8170,prsc:2,dt:0|A-4163-OUT,B-3882-OUT;n:type:ShaderForge.SFN_Multiply,id:519,x:32782,y:32478,varname:node_519,prsc:2|A-7522-OUT,B-6472-RGB;n:type:ShaderForge.SFN_Clamp01,id:1279,x:33125,y:32505,varname:node_1279,prsc:2|IN-4625-OUT;n:type:ShaderForge.SFN_Multiply,id:5233,x:32688,y:32681,varname:node_5233,prsc:2|A-6472-RGB,B-1083-OUT;n:type:ShaderForge.SFN_Multiply,id:5680,x:32831,y:32713,varname:node_5680,prsc:2|A-5233-OUT,B-3906-RGB;n:type:ShaderForge.SFN_AmbientLight,id:3906,x:32664,y:32877,varname:node_3906,prsc:2;n:type:ShaderForge.SFN_Add,id:7883,x:33224,y:32894,varname:node_7883,prsc:2|A-5795-OUT,B-719-OUT;n:type:ShaderForge.SFN_LightColor,id:412,x:32812,y:33534,varname:node_412,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5795,x:33065,y:32770,varname:node_5795,prsc:2|A-5680-OUT,B-4712-RGB;n:type:ShaderForge.SFN_LightColor,id:4712,x:32831,y:32862,varname:node_4712,prsc:2;n:type:ShaderForge.SFN_Slider,id:1083,x:32226,y:32801,ptovrint:False,ptlb:ambient shadow intensity,ptin:_ambientshadowintensity,varname:node_1083,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_Tex2d,id:2425,x:32959,y:33385,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_2425,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b00f95e7057884d40956440a4d252b13,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4625,x:32970,y:32474,varname:node_4625,prsc:2|A-519-OUT,B-6141-OUT;n:type:ShaderForge.SFN_Multiply,id:6141,x:33003,y:32591,varname:node_6141,prsc:2|A-4712-RGB,B-7156-OUT;n:type:ShaderForge.SFN_Vector1,id:7156,x:32931,y:32713,varname:node_7156,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Posterize,id:3833,x:32657,y:32284,varname:node_3833,prsc:2|IN-5426-OUT,STPS-4101-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:7522,x:32639,y:32478,ptovrint:False,ptlb:cellshading,ptin:_cellshading,varname:node_7522,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-5426-OUT,B-3833-OUT;n:type:ShaderForge.SFN_Vector1,id:4101,x:32324,y:32311,varname:node_4101,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:1945,x:33324,y:32528,varname:node_1945,prsc:2|A-1279-OUT,B-6472-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:719,x:32864,y:33113,ptovrint:False,ptlb:fresnel is cellshaded,ptin:_fresneliscellshaded,varname:node_719,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4975-OUT,B-1654-OUT;n:type:ShaderForge.SFN_Posterize,id:1654,x:32690,y:33134,varname:node_1654,prsc:2|IN-4975-OUT,STPS-2689-OUT;n:type:ShaderForge.SFN_Vector1,id:2689,x:32509,y:33251,varname:node_2689,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:5426,x:32334,y:32464,varname:node_5426,prsc:2|A-8170-OUT,B-7632-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:7632,x:32173,y:32587,varname:node_7632,prsc:2;proporder:6472-9164-8402-1083-2425-7522-719;pass:END;sub:END;*/

Shader "Custom/shader_monstre_3" {
    Properties {
        _diffuse ("diffuse", 2D) = "white" {}
        _normal ("normal", 2D) = "bump" {}
        _fresnel_strength ("fresnel_strength", Range(0, 1)) = 0.2735043
        _ambientshadowintensity ("ambient shadow intensity", Range(0, 3)) = 0
        _mask ("mask", 2D) = "white" {}
        [MaterialToggle] _cellshading ("cellshading", Float ) = 0
        [MaterialToggle] _fresneliscellshaded ("fresnel is cellshaded", Float ) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float _fresnel_strength;
            uniform float _ambientshadowintensity;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform fixed _cellshading;
            uniform fixed _fresneliscellshaded;
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
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                clip(_mask_var.r - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_5426 = (dot(lightDirection,i.normalDir)*attenuation);
                float node_4101 = 2.0;
                float4 _diffuse_var = tex2D(_diffuse,TRANSFORM_TEX(i.uv0, _diffuse));
                float3 diffuseColor = (saturate(((lerp( node_5426, floor(node_5426 * node_4101) / (node_4101 - 1), _cellshading )*_diffuse_var.rgb)*(_LightColor0.rgb*1.5)))+_diffuse_var.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_4975 = pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0 / _fresnel_strength));
                float node_2689 = 2.0;
                float3 emissive = ((((_diffuse_var.rgb*_ambientshadowintensity)*UNITY_LIGHTMODEL_AMBIENT.rgb)*_LightColor0.rgb)+lerp( node_4975, floor(node_4975 * node_2689) / (node_2689 - 1), _fresneliscellshaded ));
/// Final Color:
                float3 finalColor = diffuse + emissive;
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _diffuse; uniform float4 _diffuse_ST;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float _fresnel_strength;
            uniform float _ambientshadowintensity;
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform fixed _cellshading;
            uniform fixed _fresneliscellshaded;
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
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                clip(_mask_var.r - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float node_5426 = (dot(lightDirection,i.normalDir)*attenuation);
                float node_4101 = 2.0;
                float4 _diffuse_var = tex2D(_diffuse,TRANSFORM_TEX(i.uv0, _diffuse));
                float3 diffuseColor = (saturate(((lerp( node_5426, floor(node_5426 * node_4101) / (node_4101 - 1), _cellshading )*_diffuse_var.rgb)*(_LightColor0.rgb*1.5)))+_diffuse_var.rgb);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _mask; uniform float4 _mask_ST;
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
                float4 _mask_var = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                clip(_mask_var.r - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
