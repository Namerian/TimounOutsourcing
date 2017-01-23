// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.8691534,fgcg:0.9264706,fgcb:0.5109212,fgca:1,fgde:0.01,fgrn:4.86,fgrf:301.33,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:6423,x:33081,y:32731,varname:node_6423,prsc:2|diff-7112-RGB,spec-4418-OUT,emission-6068-OUT,alpha-9053-OUT;n:type:ShaderForge.SFN_Fresnel,id:9544,x:31836,y:32810,varname:node_9544,prsc:2;n:type:ShaderForge.SFN_Add,id:3276,x:32018,y:32795,varname:node_3276,prsc:2|A-9544-OUT,B-8320-OUT;n:type:ShaderForge.SFN_Vector1,id:8320,x:31836,y:32954,varname:node_8320,prsc:2,v1:-0.2;n:type:ShaderForge.SFN_Color,id:7112,x:32351,y:32559,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7112,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4376081,c2:0.6227253,c3:0.8382353,c4:1;n:type:ShaderForge.SFN_Vector1,id:4418,x:32381,y:32789,varname:node_4418,prsc:2,v1:10;n:type:ShaderForge.SFN_LightVector,id:5477,x:31176,y:32589,varname:node_5477,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:5326,x:31176,y:32712,varname:node_5326,prsc:2;n:type:ShaderForge.SFN_Dot,id:4642,x:31359,y:32589,varname:node_4642,prsc:2,dt:0|A-5477-OUT,B-5326-OUT;n:type:ShaderForge.SFN_Add,id:4538,x:32193,y:32755,varname:node_4538,prsc:2|A-5923-OUT,B-3276-OUT;n:type:ShaderForge.SFN_Power,id:1370,x:31733,y:32575,varname:node_1370,prsc:2|VAL-2452-OUT,EXP-515-OUT;n:type:ShaderForge.SFN_Vector1,id:515,x:31585,y:32709,varname:node_515,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:9399,x:31831,y:33181,varname:node_9399,prsc:2|A-7637-OUT,B-9816-OUT;n:type:ShaderForge.SFN_Fresnel,id:7637,x:31643,y:33181,varname:node_7637,prsc:2|EXP-6349-OUT;n:type:ShaderForge.SFN_Vector1,id:6349,x:31460,y:33203,varname:node_6349,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:6746,x:32381,y:33006,varname:node_6746,prsc:2|A-4538-OUT,B-9399-OUT;n:type:ShaderForge.SFN_Posterize,id:5923,x:31948,y:32575,varname:node_5923,prsc:2|IN-1370-OUT,STPS-3029-OUT;n:type:ShaderForge.SFN_Vector1,id:3029,x:31779,y:32731,varname:node_3029,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:2452,x:31534,y:32575,varname:node_2452,prsc:2|A-4241-OUT,B-4642-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:4241,x:31332,y:32455,varname:node_4241,prsc:2;n:type:ShaderForge.SFN_Vector1,id:9816,x:31666,y:33347,varname:node_9816,prsc:2,v1:5;n:type:ShaderForge.SFN_Add,id:9053,x:32828,y:33025,varname:node_9053,prsc:2|A-2836-OUT,B-5117-OUT;n:type:ShaderForge.SFN_Vector1,id:5117,x:32586,y:33181,varname:node_5117,prsc:2,v1:0;n:type:ShaderForge.SFN_Clamp01,id:2836,x:32586,y:33006,varname:node_2836,prsc:2|IN-6746-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:9111,x:32371,y:32388,varname:node_9111,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:7309,x:32644,y:32371,varname:node_7309,prsc:2,frmn:0,frmx:1,tomn:0.3,tomx:1|IN-9111-OUT;n:type:ShaderForge.SFN_Multiply,id:6068,x:32782,y:32535,varname:node_6068,prsc:2|A-7309-OUT,B-7112-RGB;proporder:7112;pass:END;sub:END;*/

Shader "Timoun/Character/Glass" {
    Properties {
        _Color ("Color", Color) = (0.4376081,0.6227253,0.8382353,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_4418 = 10.0;
                float3 specularColor = float3(node_4418,node_4418,node_4418);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = ((attenuation*0.7+0.3)*_Color.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_3029 = 2.0;
                fixed4 finalRGBA = fixed4(finalColor,(saturate(((floor(pow((attenuation*dot(lightDirection,viewReflectDirection)),5.0) * node_3029) / (node_3029 - 1)+((1.0-max(0,dot(normalDirection, viewDirection)))+(-0.2)))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),2.0)*5.0)))+0.0));
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_4418 = 10.0;
                float3 specularColor = float3(node_4418,node_4418,node_4418);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _Color.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_3029 = 2.0;
                fixed4 finalRGBA = fixed4(finalColor * (saturate(((floor(pow((attenuation*dot(lightDirection,viewReflectDirection)),5.0) * node_3029) / (node_3029 - 1)+((1.0-max(0,dot(normalDirection, viewDirection)))+(-0.2)))+(pow(1.0-max(0,dot(normalDirection, viewDirection)),2.0)*5.0)))+0.0),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
