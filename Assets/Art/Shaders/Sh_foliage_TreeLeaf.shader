// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4696691,fgcg:0.7911384,fgcb:0.875,fgca:1,fgde:0.022,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1975,x:32719,y:32712,varname:node_1975,prsc:2|diff-3839-RGB,diffpow-3839-RGB,spec-7097-OUT,transm-3839-RGB,lwrap-3839-RGB,clip-7853-B,voffset-2943-OUT;n:type:ShaderForge.SFN_Tex2d,id:3839,x:32030,y:32371,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3839,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40ffe1dd7aa09db45be193a6b669c1a1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:3677,x:30921,y:33026,varname:node_3677,prsc:2;n:type:ShaderForge.SFN_Time,id:673,x:30627,y:33312,varname:node_673,prsc:2;n:type:ShaderForge.SFN_Cos,id:7266,x:30858,y:33312,varname:node_7266,prsc:2|IN-673-T;n:type:ShaderForge.SFN_Vector1,id:3843,x:31074,y:32813,varname:node_3843,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:8797,x:31375,y:33160,varname:node_8797,prsc:2|A-3843-OUT,B-7449-OUT,T-3677-B;n:type:ShaderForge.SFN_RemapRange,id:7449,x:31062,y:33312,varname:node_7449,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:2|IN-7266-OUT;n:type:ShaderForge.SFN_Color,id:3333,x:32005,y:32564,ptovrint:False,ptlb:Specular Color,ptin:_SpecularColor,varname:node_3333,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8348885,c2:1,c3:0.4558824,c4:1;n:type:ShaderForge.SFN_Multiply,id:7097,x:32237,y:32593,varname:node_7097,prsc:2|A-3839-A,B-3333-RGB;n:type:ShaderForge.SFN_Tex2d,id:7853,x:32111,y:32716,ptovrint:False,ptlb:Opacity Mask (B&W),ptin:_OpacityMaskBW,varname:node_7853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:96a378161ef82e0499af17abe679ed88,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2885,x:32182,y:33065,varname:node_2885,prsc:2|A-2219-OUT,B-1641-OUT;n:type:ShaderForge.SFN_Vector1,id:1641,x:32030,y:33164,varname:node_1641,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:2219,x:31718,y:33147,varname:node_2219,prsc:2|A-8797-OUT,B-6384-RGB;n:type:ShaderForge.SFN_Tex2d,id:6384,x:31551,y:33254,ptovrint:False,ptlb:node_6384,ptin:_node_6384,varname:node_6384,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6066-UVOUT;n:type:ShaderForge.SFN_Panner,id:6066,x:31393,y:33326,varname:node_6066,prsc:2,spu:0.02,spv:0.02|UVIN-5985-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5985,x:31369,y:33469,varname:node_5985,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:2943,x:32449,y:33075,varname:node_2943,prsc:2|A-2885-OUT,B-4628-OUT;n:type:ShaderForge.SFN_NormalVector,id:4628,x:32312,y:33261,prsc:2,pt:False;proporder:3839-3333-7853-6384;pass:END;sub:END;*/
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5052444,fgcg:0.6064499,fgcb:0.7720588,fgca:1,fgde:0.005,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1975,x:32719,y:32712,varname:node_1975,prsc:2|diff-3839-RGB,diffpow-3839-RGB,spec-7097-OUT,transm-3839-RGB,lwrap-3839-RGB,clip-7853-B,voffset-2885-OUT;n:type:ShaderForge.SFN_Tex2d,id:3839,x:32030,y:32371,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3839,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ce82ba2960233d6469798b96ec28addb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:3677,x:31725,y:33102,varname:node_3677,prsc:2;n:type:ShaderForge.SFN_Time,id:673,x:31380,y:33405,varname:node_673,prsc:2;n:type:ShaderForge.SFN_Cos,id:7266,x:31615,y:33436,varname:node_7266,prsc:2|IN-673-T;n:type:ShaderForge.SFN_Vector1,id:3843,x:31868,y:33045,varname:node_3843,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:8797,x:32239,y:33197,varname:node_8797,prsc:2|A-3843-OUT,B-7449-OUT,T-3677-B;n:type:ShaderForge.SFN_RemapRange,id:7449,x:31830,y:33419,varname:node_7449,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7266-OUT;n:type:ShaderForge.SFN_Color,id:3333,x:32005,y:32564,ptovrint:False,ptlb:Specular Color,ptin:_SpecularColor,varname:node_3333,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7097,x:32237,y:32593,varname:node_7097,prsc:2|A-3839-A,B-3333-RGB;n:type:ShaderForge.SFN_Tex2d,id:7853,x:32101,y:32971,ptovrint:False,ptlb:Opacity Mask (B&W),ptin:_OpacityMaskBW,varname:node_7853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:75fe1b7056ad9524688d05deeeb12502,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2885,x:32489,y:33094,varname:node_2885,prsc:2|A-8797-OUT,B-1641-OUT;n:type:ShaderForge.SFN_Vector1,id:1641,x:32315,y:33493,varname:node_1641,prsc:2,v1:0.1;proporder:3839-3333-7853;pass:END;sub:END;*/
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5852076,fgcg:0.7062851,fgcb:0.9044118,fgca:1,fgde:0.025,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1975,x:32719,y:32712,varname:node_1975,prsc:2|diff-3839-RGB,diffpow-3839-RGB,spec-7097-OUT,transm-3839-RGB,lwrap-3839-RGB,clip-7853-B;n:type:ShaderForge.SFN_Tex2d,id:3839,x:32030,y:32371,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3839,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ce82ba2960233d6469798b96ec28addb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:3677,x:31725,y:33102,varname:node_3677,prsc:2;n:type:ShaderForge.SFN_Time,id:673,x:31380,y:33405,varname:node_673,prsc:2;n:type:ShaderForge.SFN_Cos,id:7266,x:31615,y:33436,varname:node_7266,prsc:2|IN-673-T;n:type:ShaderForge.SFN_Vector1,id:3843,x:31868,y:33045,varname:node_3843,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:8797,x:32239,y:33197,varname:node_8797,prsc:2|A-3843-OUT,B-7449-OUT,T-3677-B;n:type:ShaderForge.SFN_RemapRange,id:7449,x:31830,y:33419,varname:node_7449,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7266-OUT;n:type:ShaderForge.SFN_Color,id:3333,x:32005,y:32564,ptovrint:False,ptlb:Specular Color,ptin:_SpecularColor,varname:node_3333,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7097,x:32237,y:32593,varname:node_7097,prsc:2|A-3839-A,B-3333-RGB;n:type:ShaderForge.SFN_Tex2d,id:7853,x:32101,y:32971,ptovrint:False,ptlb:Opacity Mask (B&W),ptin:_OpacityMaskBW,varname:node_7853,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:75fe1b7056ad9524688d05deeeb12502,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2885,x:32489,y:33094,varname:node_2885,prsc:2|A-8797-OUT,B-1641-OUT;n:type:ShaderForge.SFN_Vector1,id:1641,x:32315,y:33493,varname:node_1641,prsc:2,v1:0.1;proporder:3839-3333-7853;pass:END;sub:END;*/

Shader "Timoun/Foliage/Tree Leaf" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _SpecularColor ("Specular Color", Color) = (0.8348885,1,0.4558824,1)
        _OpacityMaskBW ("Opacity Mask (B&W)", 2D) = "white" {}
        _node_6384 ("node_6384", 2D) = "white" {}
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _SpecularColor;
            uniform sampler2D _OpacityMaskBW; uniform float4 _OpacityMaskBW_ST;
            uniform sampler2D _node_6384; uniform float4 _node_6384_ST;
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
                float4 node_673 = _Time + _TimeEditor;
                float4 node_1801 = _Time + _TimeEditor;
                float2 node_6066 = (o.uv0+node_1801.g*float2(0.02,0.02));
                float4 _node_6384_var = tex2Dlod(_node_6384,float4(TRANSFORM_TEX(node_6066, _node_6384),0.0,0));
                v.vertex.xyz += (((lerp(0.0,(cos(node_673.g)*0.5+1.5),o.vertexColor.b)*_node_6384_var.rgb)*0.1)*v.normal);
                float4 node_673 = _Time + _TimeEditor;
                float node_2885 = (lerp(0.0,(cos(node_673.g)*0.5+0.5),o.vertexColor.b)*0.1);
                v.vertex.xyz += float3(node_2885,node_2885,node_2885);
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
                float4 _OpacityMaskBW_var = tex2D(_OpacityMaskBW,TRANSFORM_TEX(i.uv0, _OpacityMaskBW));
                clip(_OpacityMaskBW_var.b - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 specularColor = (_Diffuse_var.a*_SpecularColor.rgb);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = _Diffuse_var.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = pow(max(float3(0.0,0.0,0.0), NdotLWrap + w ), _Diffuse_var.rgb);
                float3 backLight = pow(max(float3(0.0,0.0,0.0), -NdotLWrap + w ), _Diffuse_var.rgb) * _Diffuse_var.rgb;
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _Diffuse_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _SpecularColor;
            uniform sampler2D _OpacityMaskBW; uniform float4 _OpacityMaskBW_ST;
            uniform sampler2D _node_6384; uniform float4 _node_6384_ST;
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
                float4 node_673 = _Time + _TimeEditor;
                float4 node_8829 = _Time + _TimeEditor;
                float2 node_6066 = (o.uv0+node_8829.g*float2(0.02,0.02));
                float4 _node_6384_var = tex2Dlod(_node_6384,float4(TRANSFORM_TEX(node_6066, _node_6384),0.0,0));
                v.vertex.xyz += (((lerp(0.0,(cos(node_673.g)*0.5+1.5),o.vertexColor.b)*_node_6384_var.rgb)*0.1)*v.normal);
                float4 node_673 = _Time + _TimeEditor;
                float node_2885 = (lerp(0.0,(cos(node_673.g)*0.5+0.5),o.vertexColor.b)*0.1);
                v.vertex.xyz += float3(node_2885,node_2885,node_2885);
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
                float4 _OpacityMaskBW_var = tex2D(_OpacityMaskBW,TRANSFORM_TEX(i.uv0, _OpacityMaskBW));
                clip(_OpacityMaskBW_var.b - 0.5);
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float3 specularColor = (_Diffuse_var.a*_SpecularColor.rgb);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 w = _Diffuse_var.rgb*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = pow(max(float3(0.0,0.0,0.0), NdotLWrap + w ), _Diffuse_var.rgb);
                float3 backLight = pow(max(float3(0.0,0.0,0.0), -NdotLWrap + w ), _Diffuse_var.rgb) * _Diffuse_var.rgb;
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = (forwardLight+backLight) * attenColor;
                float3 diffuseColor = _Diffuse_var.rgb;
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
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float4 _TimeEditor;
            uniform sampler2D _OpacityMaskBW; uniform float4 _OpacityMaskBW_ST;
            uniform sampler2D _node_6384; uniform float4 _node_6384_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float4 vertexColor : COLOR;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_673 = _Time + _TimeEditor;
                float4 node_2292 = _Time + _TimeEditor;
                float2 node_6066 = (o.uv0+node_2292.g*float2(0.02,0.02));
                float4 _node_6384_var = tex2Dlod(_node_6384,float4(TRANSFORM_TEX(node_6066, _node_6384),0.0,0));
                v.vertex.xyz += (((lerp(0.0,(cos(node_673.g)*0.5+1.5),o.vertexColor.b)*_node_6384_var.rgb)*0.1)*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.vertexColor = v.vertexColor;
                float4 node_673 = _Time + _TimeEditor;
                float node_2885 = (lerp(0.0,(cos(node_673.g)*0.5+0.5),o.vertexColor.b)*0.1);
                v.vertex.xyz += float3(node_2885,node_2885,node_2885);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _OpacityMaskBW_var = tex2D(_OpacityMaskBW,TRANSFORM_TEX(i.uv0, _OpacityMaskBW));
                clip(_OpacityMaskBW_var.b - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
