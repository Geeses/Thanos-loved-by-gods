// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)
Shader "Andre/SpriteNormalMap v. 3"
{
	Properties
	{
	    _Color("Tint", Color) = (0,0,0,0)
	    _NormalMap("Normal Map", 2D) = "white" {}
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_MetallMap("Metallic Map", 2D) = "white" {}
		_Smoothness("Smoothness", Range(0,1)) = 0
		[HideInInspector] _RendererColor("RendererColor", Color) = (0,0,0,0)
		[HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
		[PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
		[PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		CGPROGRAM
		#pragma surface surf Standard vertex:vert keepalpha
		#pragma multi_compile _ PIXELSNAP_ON
		#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
		#pragma target 3.0
		#include "UnitySprites.cginc"

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_NormalMap;
			float2 uv_MetallicMap;
			fixed4 color;
		};
		
		sampler2D _NormalMap;
		sampler2D _MetallMap;
		float _Smoothness;

		void vert(inout appdata_full v, out Input o)
		{
			v.vertex.xy *= _Flip.xy;

			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.color = v.color * _Color * _RendererColor;
		}

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = SampleSpriteTexture(IN.uv_MainTex) * IN.color;
			fixed4 metal = tex2D(_MetallMap, IN.uv_MainTex);
			o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
			o.Metallic = metal.r;
			o.Smoothness = metal.a * _Smoothness;
			o.Albedo = c.rgb * c.a;
			o.Alpha = c.a;
		}
		ENDCG
	}

	Fallback "Transparent/VertexLit"
}
