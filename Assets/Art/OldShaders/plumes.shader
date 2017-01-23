// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3382,x:32719,y:32712,varname:node_3382,prsc:2|diff-4422-RGB,diffpow-4422-RGB,emission-5777-OUT,clip-8427-B;n:type:ShaderForge.SFN_Tex2d,id:4422,x:31920,y:32629,ptovrint:False,ptlb:node_4422,ptin:_node_4422,varname:node_4422,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3d9f4c9c6a0715d47a50da242ec3a0ac,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3541,x:32144,y:33079,ptovrint:False,ptlb:node_3541,ptin:_node_3541,varname:node_3541,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3a5a96df060a5cf4a9cc0c59e13486b7,ntxv:0,isnm:False|UVIN-3951-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5307,x:31677,y:33145,varname:node_5307,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:3951,x:31852,y:33312,varname:node_3951,prsc:2,spu:0.1,spv:0.1|UVIN-5307-UVOUT;n:type:ShaderForge.SFN_Slider,id:3304,x:32089,y:33447,ptovrint:False,ptlb:node_3304,ptin:_node_3304,varname:node_3304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.2394477,max:1;n:type:ShaderForge.SFN_ConstantClamp,id:474,x:32473,y:33152,varname:node_474,prsc:2,min:0.05,max:0.1|IN-6420-OUT;n:type:ShaderForge.SFN_Multiply,id:6420,x:32316,y:33179,varname:node_6420,prsc:2|A-3541-R,B-3304-OUT;n:type:ShaderForge.SFN_Tex2d,id:8427,x:32416,y:32905,ptovrint:False,ptlb:node_8427,ptin:_node_8427,varname:node_8427,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1be887e15465f3a41b8c137edd754dff,ntxv:0,isnm:False;n:type:ShaderForge.SFN_LightColor,id:7651,x:31949,y:32830,varname:node_7651,prsc:2;n:type:ShaderForge.SFN_LightVector,id:1267,x:31760,y:32290,varname:node_1267,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:5541,x:31708,y:32422,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:8111,x:31940,y:32309,varname:node_8111,prsc:2,dt:0|A-1267-OUT,B-5541-OUT;n:type:ShaderForge.SFN_Multiply,id:2644,x:32337,y:32430,varname:node_2644,prsc:2|A-8947-OUT,B-4422-RGB;n:type:ShaderForge.SFN_Clamp01,id:8947,x:32099,y:32304,varname:node_8947,prsc:2|IN-8111-OUT;n:type:ShaderForge.SFN_Multiply,id:1128,x:32072,y:32690,varname:node_1128,prsc:2|A-4422-RGB,B-7651-RGB;n:type:ShaderForge.SFN_Add,id:5777,x:32399,y:32676,varname:node_5777,prsc:2|A-4195-OUT,B-2644-OUT;n:type:ShaderForge.SFN_Multiply,id:4195,x:32242,y:32734,varname:node_4195,prsc:2|A-1128-OUT,B-4069-RGB;n:type:ShaderForge.SFN_Color,id:4069,x:32124,y:32913,ptovrint:False,ptlb:node_4069,ptin:_node_4069,varname:node_4069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1917582,c2:0.1641436,c3:0.3382353,c4:1;proporder:4422-3541-3304-8427-4069;pass:END;sub:END;*/

Shader "Custom/plumes" {
    Properties {
        _node_4422 ("node_4422", 2D) = "white" {}
        _node_3541 ("node_3541", 2D) = "white" {}
        _node_3304 ("node_3304", Range(-1, 1)) = 0.2394477
        _node_8427 ("node_8427", 2D) = "white" {}
        _node_4069 ("node_4069", Color) = (0.1917582,0.1641436,0.3382353,1)
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _node_4422; uniform float4 _node_4422_ST;
            uniform sampler2D _node_8427; uniform float4 _node_8427_ST;
            uniform float4 _node_4069;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float4 _node_8427_var = tex2D(_node_8427,TRANSFORM_TEX(i.uv0, _node_8427));
                clip(_node_8427_var.b - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
////// Emissive:
                float4 _node_4422_var = tex2D(_node_4422,TRANSFORM_TEX(i.uv0, _node_4422));
                float3 emissive = (((_node_4422_var.rgb*_LightColor0.rgb)*_node_4069.rgb)+(saturate(dot(lightDirection,i.normalDir))*_node_4422_var.rgb));
                float3 finalColor = emissive;
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _node_4422; uniform float4 _node_4422_ST;
            uniform sampler2D _node_8427; uniform float4 _node_8427_ST;
            uniform float4 _node_4069;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
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
                float4 _node_8427_var = tex2D(_node_8427,TRANSFORM_TEX(i.uv0, _node_8427));
                clip(_node_8427_var.b - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float3 finalColor = 0;
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
            uniform sampler2D _node_8427; uniform float4 _node_8427_ST;
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
                float4 _node_8427_var = tex2D(_node_8427,TRANSFORM_TEX(i.uv0, _node_8427));
                clip(_node_8427_var.b - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
