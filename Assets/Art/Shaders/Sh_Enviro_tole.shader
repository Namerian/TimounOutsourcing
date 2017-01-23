// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.7076095,fgcg:0.7867647,fgcb:0.4280926,fgca:1,fgde:0.01,fgrn:4.86,fgrf:301.33,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3945,x:32719,y:32712,varname:node_3945,prsc:2|diff-5058-OUT,diffpow-5058-OUT,spec-9292-OUT,normal-3196-RGB,clip-4860-OUT;n:type:ShaderForge.SFN_Tex2d,id:3397,x:31626,y:32495,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_3397,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:eefa4e148c6d8894aae615332e7aa6a4,ntxv:0,isnm:False|UVIN-206-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3196,x:32087,y:32980,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_3196,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5f155a0003bfe1b429d1682b2fcc1358,ntxv:3,isnm:True|UVIN-206-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9292,x:32399,y:32731,varname:node_9292,prsc:2|A-3397-A,B-2386-RGB;n:type:ShaderForge.SFN_Color,id:2386,x:32009,y:32787,ptovrint:False,ptlb:Spec_color,ptin:_Spec_color,varname:node_2386,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_TexCoord,id:206,x:31348,y:32558,varname:node_206,prsc:2,uv:1;n:type:ShaderForge.SFN_Multiply,id:5058,x:32339,y:32427,varname:node_5058,prsc:2|A-9243-OUT,B-3397-RGB;n:type:ShaderForge.SFN_Lerp,id:9243,x:32058,y:32243,varname:node_9243,prsc:2|A-8026-OUT,B-4831-OUT,T-1014-OUT;n:type:ShaderForge.SFN_VertexColor,id:7046,x:31063,y:32162,varname:node_7046,prsc:2;n:type:ShaderForge.SFN_Vector1,id:4831,x:31615,y:32168,varname:node_4831,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Vector1,id:8026,x:31591,y:31982,varname:node_8026,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1014,x:31502,y:32248,varname:node_1014,prsc:2|A-7046-B,B-1760-OUT;n:type:ShaderForge.SFN_Vector1,id:2636,x:30935,y:32461,varname:node_2636,prsc:2,v1:7;n:type:ShaderForge.SFN_Vector1,id:2963,x:30813,y:32429,varname:node_2963,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:2960,x:30761,y:32254,ptovrint:False,ptlb:mask borders,ptin:_maskborders,varname:node_2960,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9008-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:7576,x:30296,y:32225,varname:node_7576,prsc:2,uv:0;n:type:ShaderForge.SFN_UVTile,id:9008,x:30573,y:32254,varname:node_9008,prsc:2|UVIN-7576-UVOUT,WDT-6468-OUT,HGT-6468-OUT,TILE-6468-OUT;n:type:ShaderForge.SFN_Vector1,id:6468,x:30296,y:32405,varname:node_6468,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:5243,x:30995,y:32293,varname:node_5243,prsc:2|A-2960-RGB,B-2963-OUT;n:type:ShaderForge.SFN_Power,id:6641,x:31156,y:32293,varname:node_6641,prsc:2|VAL-5243-OUT,EXP-2636-OUT;n:type:ShaderForge.SFN_Clamp01,id:1760,x:31310,y:32317,varname:node_1760,prsc:2|IN-6641-OUT;n:type:ShaderForge.SFN_Tex2d,id:7168,x:31230,y:32778,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_7168,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c06312fd738ad9f4babeb1e3975f4da2,ntxv:0,isnm:False|UVIN-2529-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:2529,x:30895,y:32794,varname:node_2529,prsc:2,uv:0;n:type:ShaderForge.SFN_Step,id:4860,x:31562,y:32852,varname:node_4860,prsc:2|A-2928-OUT,B-7168-A;n:type:ShaderForge.SFN_Vector1,id:2928,x:31355,y:32953,varname:node_2928,prsc:2,v1:0.5;proporder:3397-3196-2386-2960-7168;pass:END;sub:END;*/

Shader "Timoun/Enviro/Tole" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _Spec_color ("Spec_color", Color) = (0.5,0.5,0.5,1)
        _maskborders ("mask borders", 2D) = "white" {}
        _Opacity ("Opacity", 2D) = "white" {}
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
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _Spec_color;
            uniform sampler2D _maskborders; uniform float4 _maskborders_ST;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
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
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv1, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                clip(step(0.5,_Opacity_var.a) - 0.5);
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv1, _Diffuse));
                float3 specularColor = (_Diffuse_var.a*_Spec_color.rgb);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float node_8026 = 1.0;
                float node_4831 = 1.5;
                float node_6468 = 0.4;
                float2 node_9008_tc_rcp = float2(1.0,1.0)/float2( node_6468, node_6468 );
                float node_9008_ty = floor(node_6468 * node_9008_tc_rcp.x);
                float node_9008_tx = node_6468 - node_6468 * node_9008_ty;
                float2 node_9008 = (i.uv0 + float2(node_9008_tx, node_9008_ty)) * node_9008_tc_rcp;
                float4 _maskborders_var = tex2D(_maskborders,TRANSFORM_TEX(node_9008, _maskborders));
                float3 node_5058 = (lerp(float3(node_8026,node_8026,node_8026),float3(node_4831,node_4831,node_4831),(i.vertexColor.b*saturate(pow((_maskborders_var.rgb*2.0),7.0))))*_Diffuse_var.rgb);
                float3 directDiffuse = pow(max( 0.0, NdotL), node_5058) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = node_5058;
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
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _Spec_color;
            uniform sampler2D _maskborders; uniform float4 _maskborders_ST;
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
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
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv1, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                clip(step(0.5,_Opacity_var.a) - 0.5);
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
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv1, _Diffuse));
                float3 specularColor = (_Diffuse_var.a*_Spec_color.rgb);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float node_8026 = 1.0;
                float node_4831 = 1.5;
                float node_6468 = 0.4;
                float2 node_9008_tc_rcp = float2(1.0,1.0)/float2( node_6468, node_6468 );
                float node_9008_ty = floor(node_6468 * node_9008_tc_rcp.x);
                float node_9008_tx = node_6468 - node_6468 * node_9008_ty;
                float2 node_9008 = (i.uv0 + float2(node_9008_tx, node_9008_ty)) * node_9008_tc_rcp;
                float4 _maskborders_var = tex2D(_maskborders,TRANSFORM_TEX(node_9008, _maskborders));
                float3 node_5058 = (lerp(float3(node_8026,node_8026,node_8026),float3(node_4831,node_4831,node_4831),(i.vertexColor.b*saturate(pow((_maskborders_var.rgb*2.0),7.0))))*_Diffuse_var.rgb);
                float3 directDiffuse = pow(max( 0.0, NdotL), node_5058) * attenColor;
                float3 diffuseColor = node_5058;
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
            uniform sampler2D _Opacity; uniform float4 _Opacity_ST;
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
                float4 _Opacity_var = tex2D(_Opacity,TRANSFORM_TEX(i.uv0, _Opacity));
                clip(step(0.5,_Opacity_var.a) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
