// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5052444,fgcg:0.6064499,fgcb:0.7720588,fgca:1,fgde:0.005,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1975,x:32719,y:32712,varname:node_1975,prsc:2|diff-3839-RGB,diffpow-3839-RGB,transm-3839-RGB,lwrap-3839-RGB,clip-3839-A,voffset-8797-OUT;n:type:ShaderForge.SFN_Tex2d,id:3839,x:32251,y:32619,ptovrint:False,ptlb:node_3839,ptin:_node_3839,varname:node_3839,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:53919ea7134037448b03a473082b5a55,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:3677,x:32069,y:32832,varname:node_3677,prsc:2;n:type:ShaderForge.SFN_Time,id:673,x:30972,y:32954,varname:node_673,prsc:2;n:type:ShaderForge.SFN_Cos,id:7266,x:31363,y:32988,varname:node_7266,prsc:2|IN-673-T;n:type:ShaderForge.SFN_Vector1,id:3843,x:32264,y:32877,varname:node_3843,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:8797,x:32396,y:32964,varname:node_8797,prsc:2|A-3843-OUT,B-5076-OUT,T-3677-B;n:type:ShaderForge.SFN_Multiply,id:5076,x:32050,y:33042,varname:node_5076,prsc:2|A-8822-OUT,B-5321-OUT;n:type:ShaderForge.SFN_Vector1,id:5321,x:31789,y:33295,varname:node_5321,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Tex2d,id:9964,x:31484,y:32616,ptovrint:False,ptlb:Distort,ptin:_Distort,varname:node_9964,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-7498-UVOUT;n:type:ShaderForge.SFN_Panner,id:7498,x:31305,y:32600,varname:node_7498,prsc:2,spu:0.1,spv:0.1|UVIN-3618-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3618,x:31071,y:32577,varname:node_3618,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:7449,x:31587,y:32893,varname:node_7449,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7266-OUT;n:type:ShaderForge.SFN_Add,id:8822,x:31892,y:32810,varname:node_8822,prsc:2|A-9964-RGB,B-7449-OUT;proporder:3839-9964;pass:END;sub:END;*/

Shader "Timoun/Foliage/Grass" {
    Properties {
        _node_3839 ("node_3839", 2D) = "white" {}
        _Distort ("Distort", 2D) = "white" {}
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3839; uniform float4 _node_3839_ST;
            uniform sampler2D _Distort; uniform float4 _Distort_ST;
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
                float node_3843 = 0.0;
                float4 node_4243 = _Time + _TimeEditor;
                float2 node_7498 = (o.uv0+node_4243.g*float2(0.1,0.1));
                float4 _Distort_var = tex2Dlod(_Distort,float4(TRANSFORM_TEX(node_7498, _Distort),0.0,0));
                float4 node_673 = _Time + _TimeEditor;
                v.vertex.xyz += lerp(float3(node_3843,node_3843,node_3843),((_Distort_var.rgb+(cos(node_673.g)*0.5+0.5))*0.02),o.vertexColor.b);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _node_3839_var = tex2D(_node_3839,TRANSFORM_TEX(i.uv0, _node_3839));
                clip(_node_3839_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = _node_3839_var.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = pow(max(float3(0.0,0.0,0.0), NdotLWrap + w ), _node_3839_var.rgb);
                float3 backLight = pow(max(float3(0.0,0.0,0.0), -NdotLWrap + w ), _node_3839_var.rgb) * _node_3839_var.rgb;
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _node_3839_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3839; uniform float4 _node_3839_ST;
            uniform sampler2D _Distort; uniform float4 _Distort_ST;
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
                float node_3843 = 0.0;
                float4 node_8460 = _Time + _TimeEditor;
                float2 node_7498 = (o.uv0+node_8460.g*float2(0.1,0.1));
                float4 _Distort_var = tex2Dlod(_Distort,float4(TRANSFORM_TEX(node_7498, _Distort),0.0,0));
                float4 node_673 = _Time + _TimeEditor;
                v.vertex.xyz += lerp(float3(node_3843,node_3843,node_3843),((_Distort_var.rgb+(cos(node_673.g)*0.5+0.5))*0.02),o.vertexColor.b);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _node_3839_var = tex2D(_node_3839,TRANSFORM_TEX(i.uv0, _node_3839));
                clip(_node_3839_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 w = _node_3839_var.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = pow(max(float3(0.0,0.0,0.0), NdotLWrap + w ), _node_3839_var.rgb);
                float3 backLight = pow(max(float3(0.0,0.0,0.0), -NdotLWrap + w ), _node_3839_var.rgb) * _node_3839_var.rgb;
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 diffuseColor = _node_3839_var.rgb;
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
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3839; uniform float4 _node_3839_ST;
            uniform sampler2D _Distort; uniform float4 _Distort_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float node_3843 = 0.0;
                float4 node_7148 = _Time + _TimeEditor;
                float2 node_7498 = (o.uv0+node_7148.g*float2(0.1,0.1));
                float4 _Distort_var = tex2Dlod(_Distort,float4(TRANSFORM_TEX(node_7498, _Distort),0.0,0));
                float4 node_673 = _Time + _TimeEditor;
                v.vertex.xyz += lerp(float3(node_3843,node_3843,node_3843),((_Distort_var.rgb+(cos(node_673.g)*0.5+0.5))*0.02),o.vertexColor.b);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_3839_var = tex2D(_node_3839,TRANSFORM_TEX(i.uv0, _node_3839));
                clip(_node_3839_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
