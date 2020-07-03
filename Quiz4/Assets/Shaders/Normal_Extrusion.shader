Shader "Custom/Normal_Extrusion" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Amount("Extrusion Amount",Range(-1,1)) = 0.5
	}
	SubShader{
	Tags{ "RenderType" = "Opaque" }

	CGPROGRAM
#pragma surface surf Lambert vertex:vert
	
		
	struct Input {
		float2 uv_MainTex;
	};
	float _Amount;
	void vert(inout appdata_full v) {
		v.vertex.xyz += v.normal * _Amount;
	}
	sampler2D _MainTex;
	void surf(Input IN, inout SurfaceOutput o) {
		o.Albedo = tex2D(_MainTex,IN.uv_MainTex).rgb;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
