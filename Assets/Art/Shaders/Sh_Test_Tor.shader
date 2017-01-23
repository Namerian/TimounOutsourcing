// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5852076,fgcg:0.7062851,fgcb:0.9044118,fgca:1,fgde:0.025,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9810,x:33366,y:32780,varname:node_9810,prsc:2|diff-804-OUT,normal-4612-RGB;n:type:ShaderForge.SFN_FragmentPosition,id:9556,x:31764,y:33039,varname:node_9556,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:4138,x:32190,y:32799,ptovrint:False,ptlb:Tex_2_Down,ptin:_Tex_2_Down,varname:node_4138,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2e5b2f3593e252d41af49ae349931e5d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5318,x:32190,y:32602,ptovrint:False,ptlb:Tex_1_Up,ptin:_Tex_1_Up,varname:_node_4138_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0221b55c925a8e248a835fc667e287a2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:804,x:32428,y:32768,varname:node_804,prsc:2|A-4138-RGB,B-5318-RGB,T-6968-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:8927,x:31824,y:33230,varname:node_8927,prsc:2;n:type:ShaderForge.SFN_Subtract,id:7350,x:32078,y:33065,varname:node_7350,prsc:2|A-9556-Y,B-8927-Y;n:type:ShaderForge.SFN_Multiply,id:6286,x:32835,y:33209,varname:node_6286,prsc:2|A-1015-OUT,B-1848-RGB;n:type:ShaderForge.SFN_Tex2d,id:1848,x:32667,y:33462,ptovrint:False,ptlb:Mask_Lerp,ptin:_Mask_Lerp,varname:node_1848,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7c95f055ba19bd347a22a82a1b03590f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Power,id:1015,x:32606,y:33167,varname:node_1015,prsc:2|VAL-8389-OUT,EXP-9983-OUT;n:type:ShaderForge.SFN_Clamp01,id:6968,x:33008,y:33187,varname:node_6968,prsc:2|IN-6286-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9983,x:32440,y:33373,ptovrint:False,ptlb:Power_Val,ptin:_Power_Val,varname:node_9983,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_Add,id:8389,x:32318,y:33074,varname:node_8389,prsc:2|A-7350-OUT,B-3408-OUT;n:type:ShaderForge.SFN_Slider,id:3408,x:32008,y:33412,ptovrint:False,ptlb:Height_lerp,ptin:_Height_lerp,varname:node_3408,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:4612,x:33140,y:32901,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_4612,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;proporder:4138-5318-1848-9983-3408-4612;pass:END;sub:END;*/

Shader "Custom/Sh_Test_Tor" {
    Properties {
        _Tex_2_Down ("Tex_2_Down", 2D) = "white" {}
        _Tex_1_Up ("Tex_1_Up", 2D) = "white" {}
        _Mask_Lerp ("Mask_Lerp", 2D) = "white" {}
        _Power_Val ("Power_Val", Float ) = 8
        _Height_lerp ("Height_lerp", Range(0, 1)) = 0
        _Normal ("Normal", 2D) = "bump" {}
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
            uniform sampler2D _Tex_2_Down; uniform float4 _Tex_2_Down_ST;
            uniform sampler2D _Tex_1_Up; uniform float4 _Tex_1_Up_ST;
            uniform sampler2D _Mask_Lerp; uniform float4 _Mask_Lerp_ST;
            uniform float _Power_Val;
            uniform float _Height_lerp;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 _Tex_2_Down_var = tex2D(_Tex_2_Down,TRANSFORM_TEX(i.uv0, _Tex_2_Down));
                float4 _Tex_1_Up_var = tex2D(_Tex_1_Up,TRANSFORM_TEX(i.uv0, _Tex_1_Up));
                float node_7350 = (i.posWorld.g-objPos.g);
                float4 _Mask_Lerp_var = tex2D(_Mask_Lerp,TRANSFORM_TEX(i.uv0, _Mask_Lerp));
                float3 node_804 = lerp(_Tex_2_Down_var.rgb,_Tex_1_Up_var.rgb,saturate((pow((node_7350+_Height_lerp),_Power_Val)*_Mask_Lerp_var.rgb)));
                float3 diffuseColor = node_804;
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
            uniform float4 _LightColor0;
            uniform sampler2D _Tex_2_Down; uniform float4 _Tex_2_Down_ST;
            uniform sampler2D _Tex_1_Up; uniform float4 _Tex_1_Up_ST;
            uniform sampler2D _Mask_Lerp; uniform float4 _Mask_Lerp_ST;
            uniform float _Power_Val;
            uniform float _Height_lerp;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Tex_2_Down_var = tex2D(_Tex_2_Down,TRANSFORM_TEX(i.uv0, _Tex_2_Down));
                float4 _Tex_1_Up_var = tex2D(_Tex_1_Up,TRANSFORM_TEX(i.uv0, _Tex_1_Up));
                float node_7350 = (i.posWorld.g-objPos.g);
                float4 _Mask_Lerp_var = tex2D(_Mask_Lerp,TRANSFORM_TEX(i.uv0, _Mask_Lerp));
                float3 node_804 = lerp(_Tex_2_Down_var.rgb,_Tex_1_Up_var.rgb,saturate((pow((node_7350+_Height_lerp),_Power_Val)*_Mask_Lerp_var.rgb)));
                float3 diffuseColor = node_804;
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
