Shader "Hidden/Pixelization"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Pixelization("Pixelization", Range(0, 1)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			float _Pixelization;

			fixed4 frag(v2f i) : SV_Target
			{
				float2 uv = i.uv;

				float resolution = float2(_ScreenParams.x, _ScreenParams.y);
				resolution *= _Pixelization;

				// scaling uv by the wanted resolution
				uv *= resolution;
				uv = round(uv);

				// getting the pixel coords according to the wanted resolution
				uv /= resolution;

				fixed4 col = tex2D(_MainTex, uv);
				return col;
			}
			ENDCG
		}
	}
}
