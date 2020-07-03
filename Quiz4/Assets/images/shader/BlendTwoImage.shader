Shader "Custom/BlendTwoImage" {
	Properties {
	
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Texture2("Base (RGB)", 2D) = "white" {}
		_MainColor("Color",Color) = (1,1,1,1)
		_Proportion("Proportion",Range(0,1)) = 0.5
		
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _Texture2;
		float4 _MainColor;
		float _Proportion;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
		
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half4 c2 = tex2D (_Texture2, IN.uv_MainTex);
			
			half3 c3 = c.rgb*_Proportion+c2.rgb*(1-_Proportion);
			
			o.Albedo = c3*_MainColor;
			
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
