// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.7289144,fgcg:0.7711505,fgcb:0.9264706,fgca:1,fgde:0.03,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:7223,x:33743,y:32624,varname:node_7223,prsc:2|emission-2154-OUT,alpha-6474-OUT;n:type:ShaderForge.SFN_Tex2d,id:3223,x:31661,y:32927,ptovrint:False,ptlb:node_3223,ptin:_node_3223,varname:node_3223,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:69c8810788daa3442bc872c134322427,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9036,x:31672,y:32290,ptovrint:False,ptlb:node_9036,ptin:_node_9036,varname:node_9036,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1725-UVOUT;n:type:ShaderForge.SFN_Multiply,id:4515,x:32017,y:32696,varname:node_4515,prsc:2|A-8003-OUT,B-3223-R;n:type:ShaderForge.SFN_Panner,id:1725,x:31502,y:32274,varname:node_1725,prsc:2,spu:0.03,spv:0.03|UVIN-9023-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9023,x:31283,y:32330,varname:node_9023,prsc:2,uv:0;n:type:ShaderForge.SFN_Color,id:3122,x:32262,y:32258,ptovrint:False,ptlb:node_3122,ptin:_node_3122,varname:node_3122,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:8683,x:31706,y:32662,ptovrint:False,ptlb:node_9036_copy,ptin:_node_9036_copy,varname:_node_9036_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1508-UVOUT;n:type:ShaderForge.SFN_Panner,id:6994,x:31355,y:32650,varname:node_6994,prsc:2,spu:-0.03,spv:-0.03|UVIN-9023-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8003,x:31898,y:32615,varname:node_8003,prsc:2|A-9036-R,B-8683-R;n:type:ShaderForge.SFN_Multiply,id:7248,x:32390,y:32826,varname:node_7248,prsc:2|A-7234-OUT,B-7939-OUT;n:type:ShaderForge.SFN_Vector1,id:7939,x:32220,y:32956,varname:node_7939,prsc:2,v1:5;n:type:ShaderForge.SFN_Power,id:5505,x:32509,y:32892,varname:node_5505,prsc:2|VAL-7248-OUT,EXP-8020-OUT;n:type:ShaderForge.SFN_Vector1,id:8020,x:32385,y:33073,varname:node_8020,prsc:2,v1:3;n:type:ShaderForge.SFN_Add,id:7234,x:32202,y:32770,varname:node_7234,prsc:2|A-4515-OUT,B-1473-OUT;n:type:ShaderForge.SFN_Multiply,id:1473,x:32045,y:32855,varname:node_1473,prsc:2|A-3223-R,B-7298-OUT;n:type:ShaderForge.SFN_Vector1,id:7298,x:31899,y:33053,varname:node_7298,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Rotator,id:1508,x:31624,y:32478,varname:node_1508,prsc:2|UVIN-9023-UVOUT,SPD-3365-OUT;n:type:ShaderForge.SFN_Vector1,id:3365,x:31430,y:32570,varname:node_3365,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Vector1,id:9073,x:33210,y:32663,varname:node_9073,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2d,id:4510,x:32236,y:32485,ptovrint:False,ptlb:node_4510,ptin:_node_4510,varname:node_4510,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7c95f055ba19bd347a22a82a1b03590f,ntxv:0,isnm:False|UVIN-7744-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2154,x:32552,y:32392,varname:node_2154,prsc:2|A-3122-RGB,B-4510-RGB;n:type:ShaderForge.SFN_Rotator,id:7744,x:32068,y:32405,varname:node_7744,prsc:2|UVIN-9023-UVOUT,SPD-4296-OUT;n:type:ShaderForge.SFN_Vector1,id:4296,x:31862,y:32499,varname:node_4296,prsc:2,v1:-0.4;n:type:ShaderForge.SFN_Tex2dAsset,id:7079,x:31585,y:32028,ptovrint:False,ptlb:node_7079,ptin:_node_7079,varname:node_7079,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:3332,x:33292,y:32924,varname:node_3332,prsc:2|A-8683-G,B-7832-OUT;n:type:ShaderForge.SFN_Vector1,id:7832,x:33076,y:33069,varname:node_7832,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:8299,x:33510,y:33012,varname:node_8299,prsc:2|A-3332-OUT,B-4142-OUT;n:type:ShaderForge.SFN_NormalVector,id:4142,x:33283,y:33181,prsc:2,pt:False;n:type:ShaderForge.SFN_Clamp01,id:442,x:32790,y:32775,varname:node_442,prsc:2|IN-5505-OUT;n:type:ShaderForge.SFN_RemapRange,id:6474,x:33073,y:32754,varname:node_6474,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.85|IN-442-OUT;proporder:3223-9036-3122-8683-4510;pass:END;sub:END;*/

Shader "Timoun/Sh_MoistureGround" {
    Properties {
        _node_3223 ("node_3223", 2D) = "white" {}
        _node_9036 ("node_9036", 2D) = "white" {}
        _node_3122 ("node_3122", Color) = (0,0,0,1)
        _node_9036_copy ("node_9036_copy", 2D) = "white" {}
        _node_4510 ("node_4510", 2D) = "white" {}
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
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3223; uniform float4 _node_3223_ST;
            uniform sampler2D _node_9036; uniform float4 _node_9036_ST;
            uniform float4 _node_3122;
            uniform sampler2D _node_9036_copy; uniform float4 _node_9036_copy_ST;
            uniform sampler2D _node_4510; uniform float4 _node_4510_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_8829 = _Time + _TimeEditor;
                float node_7744_ang = node_8829.g;
                float node_7744_spd = (-0.4);
                float node_7744_cos = cos(node_7744_spd*node_7744_ang);
                float node_7744_sin = sin(node_7744_spd*node_7744_ang);
                float2 node_7744_piv = float2(0.5,0.5);
                float2 node_7744 = (mul(i.uv0-node_7744_piv,float2x2( node_7744_cos, -node_7744_sin, node_7744_sin, node_7744_cos))+node_7744_piv);
                float4 _node_4510_var = tex2D(_node_4510,TRANSFORM_TEX(node_7744, _node_4510));
                float3 emissive = (_node_3122.rgb*_node_4510_var.rgb);
                float3 finalColor = emissive;
                float2 node_1725 = (i.uv0+node_8829.g*float2(0.03,0.03));
                float4 _node_9036_var = tex2D(_node_9036,TRANSFORM_TEX(node_1725, _node_9036));
                float node_1508_ang = node_8829.g;
                float node_1508_spd = 0.2;
                float node_1508_cos = cos(node_1508_spd*node_1508_ang);
                float node_1508_sin = sin(node_1508_spd*node_1508_ang);
                float2 node_1508_piv = float2(0.5,0.5);
                float2 node_1508 = (mul(i.uv0-node_1508_piv,float2x2( node_1508_cos, -node_1508_sin, node_1508_sin, node_1508_cos))+node_1508_piv);
                float4 _node_9036_copy_var = tex2D(_node_9036_copy,TRANSFORM_TEX(node_1508, _node_9036_copy));
                float4 _node_3223_var = tex2D(_node_3223,TRANSFORM_TEX(i.uv0, _node_3223));
                fixed4 finalRGBA = fixed4(finalColor,(saturate(pow(((((_node_9036_var.r*_node_9036_copy_var.r)*_node_3223_var.r)+(_node_3223_var.r*0.1))*5.0),3.0))*0.85+0.0));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
