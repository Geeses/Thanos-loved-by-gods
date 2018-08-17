// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:34335,y:32724,varname:node_1873,prsc:2|emission-8268-OUT,alpha-9441-OUT,clip-8386-OUT;n:type:ShaderForge.SFN_TexCoord,id:8520,x:31968,y:33013,varname:node_8520,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2828,x:32149,y:33013,varname:node_2828,prsc:2,spu:0,spv:-0.7|UVIN-8520-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:142,x:32373,y:33717,ptovrint:False,ptlb:node_142,ptin:_node_142,varname:node_142,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2d80632687883b54da1c8994580d45bb,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1583,x:33078,y:33305,varname:node_1583,prsc:2|A-4110-OUT,B-9651-OUT;n:type:ShaderForge.SFN_OneMinus,id:8326,x:33234,y:33305,varname:node_8326,prsc:2|IN-1583-OUT;n:type:ShaderForge.SFN_RemapRange,id:3375,x:33421,y:33305,varname:node_3375,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8326-OUT;n:type:ShaderForge.SFN_Tex2d,id:7373,x:33373,y:33593,ptovrint:False,ptlb:FlameMask,ptin:_FlameMask,varname:node_7373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:81958387a3bf97041aeeaa3a89741b0d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8386,x:33802,y:33298,varname:node_8386,prsc:2|A-3375-OUT,B-837-OUT;n:type:ShaderForge.SFN_Tex2d,id:8419,x:32489,y:33013,ptovrint:False,ptlb:NoiseTex,ptin:_NoiseTex,varname:node_8419,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9121-UVOUT;n:type:ShaderForge.SFN_Panner,id:9121,x:32317,y:33013,varname:node_9121,prsc:2,spu:-0.3,spv:0|UVIN-2828-UVOUT;n:type:ShaderForge.SFN_Smoothstep,id:9651,x:32576,y:33540,varname:node_9651,prsc:2|A-120-OUT,B-6153-OUT,V-142-R;n:type:ShaderForge.SFN_Slider,id:120,x:32216,y:33506,ptovrint:False,ptlb:MinValueGradient,ptin:_MinValueGradient,varname:node_120,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:6153,x:32216,y:33603,ptovrint:False,ptlb:MaxValueGradient,ptin:_MaxValueGradient,varname:node_6153,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6255884,max:1;n:type:ShaderForge.SFN_Slider,id:7769,x:32399,y:32848,ptovrint:False,ptlb:NoiseAdd,ptin:_NoiseAdd,varname:node_7769,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.1004461,max:1;n:type:ShaderForge.SFN_Add,id:4110,x:32724,y:33013,varname:node_4110,prsc:2|A-7769-OUT,B-8419-R;n:type:ShaderForge.SFN_Color,id:913,x:33467,y:32505,ptovrint:False,ptlb:ColorOuter,ptin:_ColorOuter,varname:node_913,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:5618,x:33467,y:32685,ptovrint:False,ptlb:ColorInner,ptin:_ColorInner,varname:node_5618,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.834,c3:0,c4:1;n:type:ShaderForge.SFN_Set,id:6172,x:33544,y:33593,varname:FlameMask,prsc:2|IN-7373-RGB;n:type:ShaderForge.SFN_Get,id:837,x:33601,y:33347,varname:node_837,prsc:2|IN-6172-OUT;n:type:ShaderForge.SFN_Vector1,id:9441,x:34008,y:32981,varname:node_9441,prsc:2,v1:1;n:type:ShaderForge.SFN_Get,id:9168,x:33467,y:32410,varname:node_9168,prsc:2|IN-6172-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:129,x:33937,y:32597,varname:node_129,prsc:2,chbt:0|M-9168-OUT,R-913-RGB,G-5618-RGB,B-9638-OUT;n:type:ShaderForge.SFN_Lerp,id:9638,x:33733,y:32720,varname:node_9638,prsc:2|A-913-RGB,B-5618-RGB,T-2570-OUT;n:type:ShaderForge.SFN_Vector1,id:2570,x:33514,y:32899,varname:node_2570,prsc:2,v1:0.01;n:type:ShaderForge.SFN_RemapRange,id:8268,x:34121,y:32597,varname:node_8268,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-129-OUT;proporder:142-7373-8419-120-6153-7769-913-5618;pass:END;sub:END;*/

Shader "Shader Forge/Flame" {
    Properties {
        _node_142 ("node_142", 2D) = "white" {}
        _FlameMask ("FlameMask", 2D) = "white" {}
        _NoiseTex ("NoiseTex", 2D) = "white" {}
        _MinValueGradient ("MinValueGradient", Range(0, 1)) = 0
        _MaxValueGradient ("MaxValueGradient", Range(0, 1)) = 0.6255884
        _NoiseAdd ("NoiseAdd", Range(-1, 1)) = 0.1004461
        _ColorOuter ("ColorOuter", Color) = (1,0,0,1)
        _ColorInner ("ColorInner", Color) = (1,0.834,0,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_142; uniform float4 _node_142_ST;
            uniform sampler2D _FlameMask; uniform float4 _FlameMask_ST;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _MinValueGradient;
            uniform float _MaxValueGradient;
            uniform float _NoiseAdd;
            uniform float4 _ColorOuter;
            uniform float4 _ColorInner;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_6555 = _Time;
                float2 node_9121 = ((i.uv0+node_6555.g*float2(0,-0.7))+node_6555.g*float2(-0.3,0));
                float4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX(node_9121, _NoiseTex));
                float4 _node_142_var = tex2D(_node_142,TRANSFORM_TEX(i.uv0, _node_142));
                float4 _FlameMask_var = tex2D(_FlameMask,TRANSFORM_TEX(i.uv0, _FlameMask));
                float3 FlameMask = _FlameMask_var.rgb;
                clip((((1.0 - ((_NoiseAdd+_NoiseTex_var.r)*smoothstep( _MinValueGradient, _MaxValueGradient, _node_142_var.r )))*2.0+-1.0)*FlameMask) - 0.5);
////// Lighting:
////// Emissive:
                float3 node_9168 = FlameMask;
                float3 emissive = ((node_9168.r*_ColorOuter.rgb + node_9168.g*_ColorInner.rgb + node_9168.b*lerp(_ColorOuter.rgb,_ColorInner.rgb,0.01))*2.0+-1.0);
                float3 finalColor = emissive;
                return fixed4(finalColor,1.0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_142; uniform float4 _node_142_ST;
            uniform sampler2D _FlameMask; uniform float4 _FlameMask_ST;
            uniform sampler2D _NoiseTex; uniform float4 _NoiseTex_ST;
            uniform float _MinValueGradient;
            uniform float _MaxValueGradient;
            uniform float _NoiseAdd;
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
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_8525 = _Time;
                float2 node_9121 = ((i.uv0+node_8525.g*float2(0,-0.7))+node_8525.g*float2(-0.3,0));
                float4 _NoiseTex_var = tex2D(_NoiseTex,TRANSFORM_TEX(node_9121, _NoiseTex));
                float4 _node_142_var = tex2D(_node_142,TRANSFORM_TEX(i.uv0, _node_142));
                float4 _FlameMask_var = tex2D(_FlameMask,TRANSFORM_TEX(i.uv0, _FlameMask));
                float3 FlameMask = _FlameMask_var.rgb;
                clip((((1.0 - ((_NoiseAdd+_NoiseTex_var.r)*smoothstep( _MinValueGradient, _MaxValueGradient, _node_142_var.r )))*2.0+-1.0)*FlameMask) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
