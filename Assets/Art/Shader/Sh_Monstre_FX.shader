// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.8691534,fgcg:0.9264706,fgcb:0.5109212,fgca:1,fgde:0.01,fgrn:4.86,fgrf:301.33,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:8765,x:33373,y:32805,varname:node_8765,prsc:2|diff-1727-RGB,emission-6320-OUT;n:type:ShaderForge.SFN_Tex2d,id:1727,x:31835,y:32319,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_1727,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:93012918a4cd328418249ac0d89ef95a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_LightAttenuation,id:1850,x:31352,y:32710,varname:node_1850,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9411,x:30632,y:32781,prsc:2,pt:True;n:type:ShaderForge.SFN_LightVector,id:9252,x:31174,y:32439,varname:node_9252,prsc:2;n:type:ShaderForge.SFN_Dot,id:1437,x:31390,y:32415,varname:node_1437,prsc:2,dt:0|A-9252-OUT,B-9411-OUT;n:type:ShaderForge.SFN_Multiply,id:5789,x:31604,y:32473,varname:node_5789,prsc:2|A-1437-OUT,B-1850-OUT;n:type:ShaderForge.SFN_OneMinus,id:3615,x:31767,y:32538,varname:node_3615,prsc:2|IN-5789-OUT;n:type:ShaderForge.SFN_Multiply,id:1387,x:31962,y:32538,varname:node_1387,prsc:2|A-1727-RGB,B-3615-OUT;n:type:ShaderForge.SFN_Multiply,id:9926,x:32179,y:32617,varname:node_9926,prsc:2|A-1387-OUT,B-4718-RGB;n:type:ShaderForge.SFN_Color,id:4718,x:31951,y:32706,ptovrint:False,ptlb:Shadow,ptin:_Shadow,varname:node_4718,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2372628,c2:0.02660033,c3:0.6029412,c4:1;n:type:ShaderForge.SFN_Fresnel,id:1199,x:31388,y:32967,varname:node_1199,prsc:2|NRM-5657-OUT,EXP-5359-OUT;n:type:ShaderForge.SFN_NormalVector,id:5955,x:30531,y:32979,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:5954,x:30670,y:33243,ptovrint:False,ptlb:fresnelstrength,ptin:_fresnelstrength,varname:node_5954,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:4;n:type:ShaderForge.SFN_Reciprocal,id:5359,x:31135,y:33256,varname:node_5359,prsc:2|IN-5954-OUT;n:type:ShaderForge.SFN_Multiply,id:7604,x:31974,y:33013,varname:node_7604,prsc:2|A-1199-OUT,B-928-RGB;n:type:ShaderForge.SFN_Color,id:928,x:31788,y:33259,ptovrint:False,ptlb:fresnel color,ptin:_fresnelcolor,varname:node_928,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:8189,x:32309,y:32617,varname:node_8189,prsc:2|A-9926-OUT,B-7604-OUT;n:type:ShaderForge.SFN_Multiply,id:7786,x:32168,y:32889,varname:node_7786,prsc:2|A-1727-RGB,B-7604-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5657,x:31106,y:32932,ptovrint:False,ptlb:fresnel Normal influence,ptin:_fresnelNormalinfluence,varname:node_5657,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5955-OUT,B-9411-OUT;n:type:ShaderForge.SFN_Lerp,id:6320,x:32857,y:32804,varname:node_6320,prsc:2|A-8189-OUT,B-8060-OUT,T-9964-A;n:type:ShaderForge.SFN_Add,id:8060,x:32517,y:32770,varname:node_8060,prsc:2|A-8189-OUT,B-3244-OUT;n:type:ShaderForge.SFN_Vector1,id:3244,x:32371,y:32852,varname:node_3244,prsc:2,v1:1;n:type:ShaderForge.SFN_VertexColor,id:9964,x:32593,y:32915,varname:node_9964,prsc:2;proporder:1727-4718-5954-928-5657;pass:END;sub:END;*/

Shader "Custom/Sh_Monstre_FX" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Shadow ("Shadow", Color) = (0.2372628,0.02660033,0.6029412,1)
        _fresnelstrength ("fresnelstrength", Range(0, 4)) = 0
        _fresnelcolor ("fresnel color", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _fresnelNormalinfluence ("fresnel Normal influence", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Shadow;
            uniform float _fresnelstrength;
            uniform float4 _fresnelcolor;
            uniform fixed _fresnelNormalinfluence;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 node_7604 = (pow(1.0-max(0,dot(lerp( i.normalDir, normalDirection, _fresnelNormalinfluence ), viewDirection)),(1.0 / _fresnelstrength))*_fresnelcolor.rgb);
                float3 node_8189 = (((_Diffuse_var.rgb*(1.0 - (dot(lightDirection,normalDirection)*attenuation)))*_Shadow.rgb)+node_7604);
                float3 emissive = lerp(node_8189,(node_8189+1.0),i.vertexColor.a);
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _Shadow;
            uniform float _fresnelstrength;
            uniform float4 _fresnelcolor;
            uniform fixed _fresnelNormalinfluence;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
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
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
