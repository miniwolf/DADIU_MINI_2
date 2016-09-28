Shader "Custom/CelShadingForwardRim" {
	Properties {
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Float) = 4
		_CelCut1("Cel Cut1", Range (-0.999, 0.999)) = 0.0
		_CelCut2("Cel Cut2", Range (-0.999, 0.999)) = 0.5
		_ViewOffsetX("Offset X", Float) = 0
		_ViewOffsetY("Offset Y", Float) = 0
		_ViewOffsetZ("Offset Z", Float) = 0
		_EmissionColor("Emission Color", Color) = (1, 1, 1, 1)

	}
	SubShader {
		Tags {
			"RenderType" = "Opaque"
		}
		LOD 200

		CGPROGRAM

		#pragma surface surf CelShadingForward

		#pragma target 3.0

		half4 _RimColor;
		half4 _EmissionColor;
		half _RimPower;
		half _CelCut1;
		half _CelCut2;
		half _ViewOffsetX;
		half _ViewOffsetY;
		half _ViewOffsetZ;

		half4 LightingCelShadingForward(SurfaceOutput s,  half3 lightDir, half3 viewDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			if (NdotL <= _CelCut1) NdotL = 0;
			else if (NdotL <= _CelCut2) NdotL = 0.5;
			else NdotL = 1;
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten * 2);
			c.a = s.Alpha;

			viewDir = normalize(viewDir + half3(_ViewOffsetX,_ViewOffsetY,_ViewOffsetZ));

			NdotL = 1 - clamp(dot(s.Normal, viewDir) * _RimPower, 0, 1);
			float4 white = float4(1,1,1, 0);

			if (NdotL <= 0.0) NdotL = 0;
			else NdotL = 1;

			c.rgb = lerp(c.rgb, c.rgb + _RimColor.rgb * NdotL, _RimColor.a);

			return c;
		}

		sampler2D _MainTex;
		fixed4 _Color;

		struct Input {
			float2 uv_MainTex;

		};

		void surf(Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
			o.Emission = _EmissionColor;;
		}
		ENDCG
	}
	FallBack "Diffuse"
}