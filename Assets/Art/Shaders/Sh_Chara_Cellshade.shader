// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7107,x:32885,y:32632,varname:node_7107,prsc:2|normal-4007-RGB,emission-9616-OUT,custl-6744-OUT,clip-9413-A;n:type:ShaderForge.SFN_Tex2d,id:9413,x:30751,y:32127,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,cmnt:DIFFUSE,varname:node_9413,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f2d3ca9311ea9184494785c21f2b42f3,ntxv:1,isnm:False;n:type:ShaderForge.SFN_LightVector,id:7570,x:30309,y:32422,varname:node_7570,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:9251,x:30480,y:32893,varname:node_9251,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:4692,x:30362,y:32561,prsc:2,pt:True;n:type:ShaderForge.SFN_LightColor,id:5049,x:30564,y:33010,varname:node_5049,prsc:2;n:type:ShaderForge.SFN_AmbientLight,id:8577,x:31464,y:32251,varname:node_8577,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6999,x:31621,y:32216,varname:node_6999,prsc:2|A-9413-RGB,B-8577-RGB;n:type:ShaderForge.SFN_Multiply,id:575,x:30732,y:32893,varname:node_575,prsc:2|A-9251-OUT,B-5049-RGB;n:type:ShaderForge.SFN_Fresnel,id:3456,x:31312,y:31855,varname:node_3456,prsc:2|NRM-6060-OUT,EXP-2643-OUT;n:type:ShaderForge.SFN_Slider,id:430,x:30279,y:31848,ptovrint:False,ptlb:fresnel_strength,ptin:_fresnel_strength,varname:node_430,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Reciprocal,id:2643,x:30867,y:31840,varname:node_2643,prsc:2|IN-1381-OUT;n:type:ShaderForge.SFN_NormalVector,id:6060,x:31042,y:31695,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:1381,x:30671,y:31840,varname:node_1381,prsc:2|A-430-OUT,B-8921-OUT;n:type:ShaderForge.SFN_Vector1,id:8921,x:30425,y:31932,varname:node_8921,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:2898,x:32131,y:32046,varname:node_2898,prsc:2|A-697-RGB,B-3456-OUT;n:type:ShaderForge.SFN_Add,id:4035,x:32305,y:32185,varname:node_4035,prsc:2|A-2898-OUT,B-308-OUT;n:type:ShaderForge.SFN_Tex2d,id:4007,x:32612,y:32112,ptovrint:False,ptlb:normal,ptin:_normal,varname:node_4007,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:697,x:31969,y:31923,ptovrint:False,ptlb:fresnel color,ptin:_fresnelcolor,varname:node_697,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:308,x:31800,y:32216,varname:node_308,prsc:2|A-6999-OUT,B-2629-OUT;n:type:ShaderForge.SFN_Vector1,id:2629,x:31676,y:32346,varname:node_2629,prsc:2,v1:0.5;n:type:ShaderForge.SFN_LightAttenuation,id:321,x:31533,y:33225,varname:node_321,prsc:2;n:type:ShaderForge.SFN_Color,id:6000,x:31869,y:32967,ptovrint:False,ptlb:shadow color,ptin:_shadowcolor,varname:node_6000,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:6837,x:32293,y:32932,varname:node_6837,prsc:2|A-6045-OUT,B-2471-OUT;n:type:ShaderForge.SFN_Add,id:8038,x:32465,y:32373,varname:node_8038,prsc:2|A-4035-OUT,B-9059-OUT;n:type:ShaderForge.SFN_OneMinus,id:2471,x:32076,y:33173,varname:node_2471,prsc:2|IN-3779-OUT;n:type:ShaderForge.SFN_Multiply,id:9059,x:32402,y:32779,varname:node_9059,prsc:2|A-9413-RGB,B-6837-OUT;n:type:ShaderForge.SFN_Dot,id:2885,x:30516,y:32422,varname:node_2885,prsc:2,dt:0|A-7570-OUT,B-4692-OUT;n:type:ShaderForge.SFN_Multiply,id:1271,x:31044,y:32631,varname:node_1271,prsc:2|A-9036-OUT,B-575-OUT;n:type:ShaderForge.SFN_RemapRange,id:1043,x:30688,y:32573,varname:node_1043,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:1|IN-2885-OUT;n:type:ShaderForge.SFN_Multiply,id:396,x:31747,y:32731,varname:node_396,prsc:2|A-9413-RGB,B-1731-OUT;n:type:ShaderForge.SFN_Multiply,id:9036,x:30852,y:32573,varname:node_9036,prsc:2|A-1043-OUT,B-9325-OUT;n:type:ShaderForge.SFN_Vector1,id:9325,x:30688,y:32764,cmnt:Netteté Ombrage,varname:node_9325,prsc:2,v1:13;n:type:ShaderForge.SFN_Clamp01,id:4943,x:31214,y:32700,varname:node_4943,prsc:2|IN-1271-OUT;n:type:ShaderForge.SFN_RemapRange,id:1884,x:30688,y:32422,varname:node_1884,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.15|IN-2885-OUT;n:type:ShaderForge.SFN_Multiply,id:9037,x:31424,y:32527,varname:node_9037,prsc:2|A-9413-RGB,B-1884-OUT;n:type:ShaderForge.SFN_Add,id:4378,x:31986,y:32661,varname:node_4378,prsc:2|A-9037-OUT,B-396-OUT;n:type:ShaderForge.SFN_Multiply,id:6744,x:32168,y:32661,varname:node_6744,prsc:2|A-4378-OUT,B-321-OUT;n:type:ShaderForge.SFN_AmbientLight,id:4082,x:31896,y:32814,varname:node_4082,prsc:2;n:type:ShaderForge.SFN_Lerp,id:6045,x:32081,y:32858,varname:node_6045,prsc:2|A-4082-RGB,B-6000-RGB,T-9809-OUT;n:type:ShaderForge.SFN_Vector1,id:9809,x:32026,y:33026,varname:node_9809,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3779,x:31733,y:33111,varname:node_3779,prsc:2|A-1731-OUT,B-321-OUT;n:type:ShaderForge.SFN_Multiply,id:9616,x:32681,y:32452,varname:node_9616,prsc:2|A-8038-OUT,B-2429-OUT;n:type:ShaderForge.SFN_Vector1,id:2429,x:32465,y:32554,varname:node_2429,prsc:2,v1:0.9;n:type:ShaderForge.SFN_Add,id:1731,x:31408,y:32890,varname:node_1731,prsc:2|A-4943-OUT,B-2267-OUT;n:type:ShaderForge.SFN_Vector1,id:2267,x:31132,y:32878,varname:node_2267,prsc:2,v1:-0.15;n:type:ShaderForge.SFN_Vector1,id:4189,x:32609,y:32950,varname:node_4189,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Vector3,id:9383,x:32609,y:33084,varname:node_9383,prsc:2,v1:0.2426471,v2:0.1798443,v3:0.1391652;n:type:ShaderForge.SFN_Tex2d,id:1470,x:32449,y:33168,ptovrint:False,ptlb:node_1470,ptin:_node_1470,varname:node_1470,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:da605b5c99d0dd042b5b06537545bd75,ntxv:0,isnm:False;proporder:9413-4007-6000-697-430;pass:END;sub:END;*/

Shader "Timoun/Character/Chara-Cellshading" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "gray" {}
        _normal ("normal", 2D) = "bump" {}
        _shadowcolor ("shadow color", Color) = (0.5,0.5,0.5,1)
        _fresnelcolor ("fresnel color", Color) = (0.5,0.5,0.5,1)
        _fresnel_strength ("fresnel_strength", Range(0, 1)) = 0
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
            
            
            Stencil {
                Ref 128
            }
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _fresnel_strength;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float4 _fresnelcolor;
            uniform float4 _shadowcolor;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse)); // DIFFUSE
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float node_2885 = dot(lightDirection,normalDirection);
                float3 node_1731 = (saturate((((node_2885*1.5+-0.5)*13.0)*(attenuation*_LightColor0.rgb)))+(-0.15));
                float3 emissive = ((((_fresnelcolor.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),(1.0 / (_fresnel_strength*3.0))))+((_Diffuse_var.rgb*UNITY_LIGHTMODEL_AMBIENT.rgb)*0.5))+(_Diffuse_var.rgb*(lerp(UNITY_LIGHTMODEL_AMBIENT.rgb,_shadowcolor.rgb,0.5)*(1.0 - (node_1731*attenuation)))))*0.9);
                float3 finalColor = emissive + (((_Diffuse_var.rgb*(node_2885*0.15+0.0))+(_Diffuse_var.rgb*node_1731))*attenuation);
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _fresnel_strength;
            uniform sampler2D _normal; uniform float4 _normal_ST;
            uniform float4 _fresnelcolor;
            uniform float4 _shadowcolor;
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
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _normal_var = UnpackNormal(tex2D(_normal,TRANSFORM_TEX(i.uv0, _normal)));
                float3 normalLocal = _normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse)); // DIFFUSE
                clip(_Diffuse_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_2885 = dot(lightDirection,normalDirection);
                float3 node_1731 = (saturate((((node_2885*1.5+-0.5)*13.0)*(attenuation*_LightColor0.rgb)))+(-0.15));
                float3 finalColor = (((_Diffuse_var.rgb*(node_2885*0.15+0.0))+(_Diffuse_var.rgb*node_1731))*attenuation);
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
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
            float4 frag(VertexOutput i) : COLOR {
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse)); // DIFFUSE
                clip(_Diffuse_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
