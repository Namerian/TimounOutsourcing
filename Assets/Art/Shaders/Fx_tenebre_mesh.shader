// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4696691,fgcg:0.7911384,fgcb:0.875,fgca:1,fgde:0.022,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7895,x:32719,y:32712,varname:node_7895,prsc:2|emission-9463-OUT,alpha-4462-OUT;n:type:ShaderForge.SFN_Tex2d,id:3804,x:31529,y:32609,ptovrint:False,ptlb:// Noise_1,ptin:_Noise_1,varname:node_3804,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ca96f65ddb6b2294b93fe47e3292db2b,ntxv:0,isnm:False|UVIN-3260-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2253,x:31721,y:32724,varname:node_2253,prsc:2|A-3804-R,B-9339-OUT;n:type:ShaderForge.SFN_Panner,id:3260,x:31349,y:32557,varname:node_3260,prsc:2,spu:0.1,spv:0.1|UVIN-2879-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2879,x:31072,y:32571,varname:node_2879,prsc:2,uv:0;n:type:ShaderForge.SFN_Posterize,id:4462,x:32410,y:32957,varname:node_4462,prsc:2|IN-2516-OUT,STPS-7096-OUT;n:type:ShaderForge.SFN_Vector1,id:7096,x:31754,y:33204,varname:node_7096,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:9975,x:31865,y:32818,varname:node_9975,prsc:2|A-2253-OUT,B-4409-R;n:type:ShaderForge.SFN_Tex2d,id:4409,x:31388,y:33011,ptovrint:False,ptlb:// Noise_2,ptin:_Noise_2,varname:node_4409,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ca96f65ddb6b2294b93fe47e3292db2b,ntxv:0,isnm:False|UVIN-189-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:495,x:30237,y:32940,varname:node_495,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:189,x:31139,y:33034,varname:node_189,prsc:2,spu:-0.1,spv:-0.1|UVIN-495-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4390,x:32048,y:32870,varname:node_4390,prsc:2|A-9975-OUT,B-8370-OUT;n:type:ShaderForge.SFN_Vector1,id:8370,x:31754,y:33112,varname:node_8370,prsc:2,v1:5;n:type:ShaderForge.SFN_VertexColor,id:2754,x:31800,y:32156,varname:node_2754,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2516,x:32256,y:32829,varname:node_2516,prsc:2|A-4390-OUT,B-2754-A;n:type:ShaderForge.SFN_Append,id:2800,x:30784,y:33104,varname:node_2800,prsc:2|A-354-OUT,B-7699-OUT;n:type:ShaderForge.SFN_Multiply,id:354,x:30528,y:32818,varname:node_354,prsc:2|A-2754-R,B-495-U;n:type:ShaderForge.SFN_Multiply,id:7699,x:30566,y:33188,varname:node_7699,prsc:2|A-2754-G,B-495-V;n:type:ShaderForge.SFN_Fresnel,id:7070,x:31243,y:32806,varname:node_7070,prsc:2|EXP-2435-OUT;n:type:ShaderForge.SFN_Vector1,id:2435,x:31038,y:32840,varname:node_2435,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:9339,x:31496,y:32801,varname:node_9339,prsc:2|IN-7070-OUT;n:type:ShaderForge.SFN_Fresnel,id:5365,x:31709,y:32492,varname:node_5365,prsc:2|EXP-6947-OUT;n:type:ShaderForge.SFN_Vector1,id:6947,x:31438,y:32377,varname:node_6947,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:9463,x:32431,y:32643,varname:node_9463,prsc:2|A-2754-RGB,B-5930-OUT;n:type:ShaderForge.SFN_Multiply,id:5930,x:32097,y:32582,varname:node_5930,prsc:2|A-2754-RGB,B-5365-OUT;n:type:ShaderForge.SFN_Vector1,id:5363,x:31771,y:32639,varname:node_5363,prsc:2,v1:3;proporder:3804-4409;pass:END;sub:END;*/

Shader "Timoun/FX/tenebre_mesh" {
    Properties {
        _Noise_1 ("// Noise_1", 2D) = "white" {}
        _Noise_2 ("// Noise_2", 2D) = "white" {}
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Noise_1; uniform float4 _Noise_1_ST;
            uniform sampler2D _Noise_2; uniform float4 _Noise_2_ST;
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
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_5365 = pow(1.0-max(0,dot(normalDirection, viewDirection)),0.5);
                float3 emissive = (i.vertexColor.rgb+(i.vertexColor.rgb*node_5365));
                float3 finalColor = emissive;
                float4 node_2472 = _Time + _TimeEditor;
                float2 node_3260 = (i.uv0+node_2472.g*float2(0.1,0.1));
                float4 _Noise_1_var = tex2D(_Noise_1,TRANSFORM_TEX(node_3260, _Noise_1));
                float2 node_189 = (i.uv0+node_2472.g*float2(-0.1,-0.1));
                float4 _Noise_2_var = tex2D(_Noise_2,TRANSFORM_TEX(node_189, _Noise_2));
                float node_7096 = 2.0;
                fixed4 finalRGBA = fixed4(finalColor,floor(((((_Noise_1_var.r*(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0)))*_Noise_2_var.r)*5.0)*i.vertexColor.a) * node_7096) / (node_7096 - 1));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
