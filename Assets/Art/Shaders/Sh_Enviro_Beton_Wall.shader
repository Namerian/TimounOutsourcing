// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3902,x:32719,y:32712,varname:node_3902,prsc:2|diff-244-OUT,diffpow-244-OUT,spec-1306-A,normal-6659-RGB,voffset-5197-OUT;n:type:ShaderForge.SFN_Tex2d,id:1306,x:31316,y:32779,ptovrint:False,ptlb:// Diffuse,ptin:_Diffuse,varname:node_1306,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:582590ae50123e94a8060bfcdbcabe6d,ntxv:0,isnm:False|UVIN-6709-UVOUT,MIP-6654-OUT;n:type:ShaderForge.SFN_Tex2d,id:6659,x:32077,y:33053,ptovrint:False,ptlb:// Normal Map,ptin:_NormalMap,varname:node_6659,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b9b4e55fd6c9b8e4eb97e9b06ffce992,ntxv:3,isnm:True|UVIN-6709-UVOUT;n:type:ShaderForge.SFN_Slider,id:6654,x:30306,y:33067,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_6654,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7457599,max:1;n:type:ShaderForge.SFN_UVTile,id:6709,x:30775,y:33035,varname:node_6709,prsc:2|WDT-6654-OUT,HGT-6654-OUT,TILE-6654-OUT;n:type:ShaderForge.SFN_Lerp,id:7932,x:32146,y:32255,varname:node_7932,prsc:2|A-9444-OUT,B-2243-OUT,T-6258-OUT;n:type:ShaderForge.SFN_Vector3,id:403,x:32499,y:33416,varname:node_403,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Vector3,id:570,x:32499,y:33309,varname:node_570,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_VertexColor,id:1662,x:32670,y:33386,varname:node_1662,prsc:2;n:type:ShaderForge.SFN_Lerp,id:5197,x:32794,y:33250,varname:node_5197,prsc:2|A-403-OUT,B-570-OUT,T-1662-B;n:type:ShaderForge.SFN_Multiply,id:6258,x:31830,y:32169,varname:node_6258,prsc:2|A-9830-OUT,B-1450-OUT;n:type:ShaderForge.SFN_Tex2d,id:6011,x:30657,y:32455,ptovrint:False,ptlb:Mask_second_color,ptin:_Mask_second_color,varname:node_6011,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6709-UVOUT;n:type:ShaderForge.SFN_Vector1,id:9830,x:31654,y:32169,varname:node_9830,prsc:2,v1:1;n:type:ShaderForge.SFN_UVTile,id:8244,x:30387,y:32451,varname:node_8244,prsc:2|WDT-5833-OUT,HGT-5833-OUT,TILE-5833-OUT;n:type:ShaderForge.SFN_Vector1,id:5833,x:30250,y:32536,varname:node_5833,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:6237,x:30794,y:32659,varname:node_6237,prsc:2,v1:3;n:type:ShaderForge.SFN_Power,id:832,x:31089,y:32388,varname:node_832,prsc:2|VAL-4110-OUT,EXP-6237-OUT;n:type:ShaderForge.SFN_Multiply,id:9650,x:31239,y:32388,varname:node_9650,prsc:2|A-832-OUT,B-6237-OUT;n:type:ShaderForge.SFN_Clamp01,id:1450,x:31467,y:32248,varname:node_1450,prsc:2|IN-9650-OUT;n:type:ShaderForge.SFN_Multiply,id:5697,x:30738,y:32240,varname:node_5697,prsc:2|A-3275-B,B-6011-RGB;n:type:ShaderForge.SFN_VertexColor,id:3275,x:30519,y:32168,varname:node_3275,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4110,x:30933,y:32313,varname:node_4110,prsc:2|A-5697-OUT,B-6237-OUT;n:type:ShaderForge.SFN_Multiply,id:2243,x:31646,y:32640,varname:node_2243,prsc:2|A-3529-RGB,B-1306-RGB;n:type:ShaderForge.SFN_Color,id:5364,x:31385,y:32493,ptovrint:False,ptlb:wall_color_1,ptin:_wall_color_1,varname:node_5364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Color,id:3529,x:31371,y:32649,ptovrint:False,ptlb:wall_color_2,ptin:_wall_color_2,varname:node_3529,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9444,x:31631,y:32488,varname:node_9444,prsc:2|A-5364-RGB,B-1306-RGB;n:type:ShaderForge.SFN_VertexColor,id:5198,x:31074,y:31714,varname:node_5198,prsc:2;n:type:ShaderForge.SFN_Lerp,id:244,x:32695,y:32140,varname:node_244,prsc:2|A-7932-OUT,B-6791-OUT,T-2447-OUT;n:type:ShaderForge.SFN_Multiply,id:6791,x:32532,y:32247,varname:node_6791,prsc:2|A-1579-RGB,B-7932-OUT;n:type:ShaderForge.SFN_Color,id:1579,x:32055,y:32046,ptovrint:False,ptlb:edge_color,ptin:_edge_color,varname:node_1579,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2447,x:31585,y:31696,varname:node_2447,prsc:2|A-5198-R,B-8487-OUT;n:type:ShaderForge.SFN_Tex2d,id:249,x:31064,y:31941,ptovrint:False,ptlb:Mask_edges,ptin:_Mask_edges,varname:node_249,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-6709-UVOUT;n:type:ShaderForge.SFN_Multiply,id:1899,x:31440,y:31978,varname:node_1899,prsc:2|A-6510-OUT,B-249-RGB;n:type:ShaderForge.SFN_Power,id:7348,x:31613,y:31946,varname:node_7348,prsc:2|VAL-1899-OUT,EXP-8455-OUT;n:type:ShaderForge.SFN_Vector1,id:6510,x:31155,y:32128,varname:node_6510,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Clamp01,id:8487,x:31864,y:31924,varname:node_8487,prsc:2|IN-7348-OUT;n:type:ShaderForge.SFN_Vector1,id:8455,x:31386,y:32181,varname:node_8455,prsc:2,v1:3;proporder:6654-1306-6659-5364-3529-6011-249-1579;pass:END;sub:END;*/

Shader "Timoun/Enviro/Wall Beton" {
    Properties {
        _Tiling ("Tiling", Range(0, 1)) = 0.7457599
        _Diffuse ("// Diffuse", 2D) = "white" {}
        _NormalMap ("// Normal Map", 2D) = "bump" {}
        _wall_color_1 ("wall_color_1", Color) = (0.5,0.5,0.5,1)
        _wall_color_2 ("wall_color_2", Color) = (0.5,0.5,0.5,1)
        _Mask_second_color ("Mask_second_color", 2D) = "white" {}
        _Mask_edges ("Mask_edges", 2D) = "white" {}
        _edge_color ("edge_color", Color) = (0.5,0.5,0.5,1)
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Tiling;
            uniform sampler2D _Mask_second_color; uniform float4 _Mask_second_color_ST;
            uniform float4 _wall_color_1;
            uniform float4 _wall_color_2;
            uniform float4 _edge_color;
            uniform sampler2D _Mask_edges; uniform float4 _Mask_edges_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                v.vertex.xyz += lerp(float3(0,0,0),float3(0,0,0),o.vertexColor.b);
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
                float2 node_6709_tc_rcp = float2(1.0,1.0)/float2( _Tiling, _Tiling );
                float node_6709_ty = floor(_Tiling * node_6709_tc_rcp.x);
                float node_6709_tx = _Tiling - _Tiling * node_6709_ty;
                float2 node_6709 = (i.uv0 + float2(node_6709_tx, node_6709_ty)) * node_6709_tc_rcp;
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_6709, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 _Diffuse_var = tex2Dlod(_Diffuse,float4(TRANSFORM_TEX(node_6709, _Diffuse),0.0,_Tiling));
                float3 specularColor = float3(_Diffuse_var.a,_Diffuse_var.a,_Diffuse_var.a);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float4 _Mask_second_color_var = tex2D(_Mask_second_color,TRANSFORM_TEX(node_6709, _Mask_second_color));
                float node_6237 = 3.0;
                float3 node_6258 = (1.0*saturate((pow(((i.vertexColor.b*_Mask_second_color_var.rgb)*node_6237),node_6237)*node_6237)));
                float3 node_7932 = lerp((_wall_color_1.rgb*_Diffuse_var.rgb),(_wall_color_2.rgb*_Diffuse_var.rgb),node_6258);
                float4 _Mask_edges_var = tex2D(_Mask_edges,TRANSFORM_TEX(node_6709, _Mask_edges));
                float3 node_244 = lerp(node_7932,(_edge_color.rgb*node_7932),(i.vertexColor.r*saturate(pow((1.5*_Mask_edges_var.rgb),3.0))));
                float3 directDiffuse = pow(max( 0.0, NdotL), node_244) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = node_244;
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
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _Tiling;
            uniform sampler2D _Mask_second_color; uniform float4 _Mask_second_color_ST;
            uniform float4 _wall_color_1;
            uniform float4 _wall_color_2;
            uniform float4 _edge_color;
            uniform sampler2D _Mask_edges; uniform float4 _Mask_edges_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                v.vertex.xyz += lerp(float3(0,0,0),float3(0,0,0),o.vertexColor.b);
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
                float2 node_6709_tc_rcp = float2(1.0,1.0)/float2( _Tiling, _Tiling );
                float node_6709_ty = floor(_Tiling * node_6709_tc_rcp.x);
                float node_6709_tx = _Tiling - _Tiling * node_6709_ty;
                float2 node_6709 = (i.uv0 + float2(node_6709_tx, node_6709_ty)) * node_6709_tc_rcp;
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_6709, _NormalMap)));
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 _Diffuse_var = tex2Dlod(_Diffuse,float4(TRANSFORM_TEX(node_6709, _Diffuse),0.0,_Tiling));
                float3 specularColor = float3(_Diffuse_var.a,_Diffuse_var.a,_Diffuse_var.a);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float4 _Mask_second_color_var = tex2D(_Mask_second_color,TRANSFORM_TEX(node_6709, _Mask_second_color));
                float node_6237 = 3.0;
                float3 node_6258 = (1.0*saturate((pow(((i.vertexColor.b*_Mask_second_color_var.rgb)*node_6237),node_6237)*node_6237)));
                float3 node_7932 = lerp((_wall_color_1.rgb*_Diffuse_var.rgb),(_wall_color_2.rgb*_Diffuse_var.rgb),node_6258);
                float4 _Mask_edges_var = tex2D(_Mask_edges,TRANSFORM_TEX(node_6709, _Mask_edges));
                float3 node_244 = lerp(node_7932,(_edge_color.rgb*node_7932),(i.vertexColor.r*saturate(pow((1.5*_Mask_edges_var.rgb),3.0))));
                float3 directDiffuse = pow(max( 0.0, NdotL), node_244) * attenColor;
                float3 diffuseColor = node_244;
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
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                v.vertex.xyz += lerp(float3(0,0,0),float3(0,0,0),o.vertexColor.b);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
