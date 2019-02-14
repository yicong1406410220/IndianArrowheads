Shader "Sprites/FlowLight"
{
	Properties
	{
	[PerRendererData]
		_MainTex("Sprite Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1, 1, 1, 1)
	[MaterialToggle]
		PixelSnap("Pixel snap", float) = 0
		_FlowlightTex("Flowlight Texture", 2D) = "white" {}
		_Power("Power", float) = 1
		_SpeedX("SpeedX", float) = 1
		_SpeedY("SpeedY", float) = 0
			//以下代码块可以有效防止Editor报缺失参数的错误（笔者踩过的坑）
			_StencilComp("Stencil Comparison", Float) = 8
			_Stencil("Stencil ID", Float) = 0
			_StencilOp("Stencil Operation", Float) = 0
			_StencilWriteMask("Stencil Write Mask", Float) = 255
			_StencilReadMask("Stencil Read Mask", Float) = 255
			_ColorMask("Color Mask", Float) = 15
			//-----
	}

		SubShader
		{
		   Tags{
			   "Queue" = "Transparent"
			   "IgnoreProjector" = "True"
			   "RenderType" = "Transparent"
			   "PreviewType" = "Plane"
			   "CanUseSpriteAtlas" = "True"
		   }
			//以下代码块可以有效防止Editor报缺失参数的错误（笔者踩过的坑）
		  Stencil{
			  Ref[_Stencil]
			  Comp[_StencilComp]
			  Pass[_StencilOp]
			  ReadMask[_StencilReadMask]
			  WriteMask[_StencilWriteMask]
		  }
			//----
			Cull Off
				 Lighting Off
				 ZWrite Off
				 Blend One OneMinusSrcAlpha

			Pass
			{
				 CGPROGRAM
				 #pragma vertex vert
				 #pragma fragment frag
				 #pragma multi_compile _ PIXELSNAP_ON
			 #include "UnityCG.cginc"

				 struct appdata_t
				 {
					 float4 vertex : POSITION;
					 float4 color : COLOR;
					 float2 texcoord : TEXCOORD0;
				 };
				struct v2f
				{
					 float4 vertex : SV_POSITION;
					 fixed4 color : COLOR;
					 half2 texcoord : TEXCOORD0;
					 half2 texflow : TEXCOORD1;
				};
			fixed4 _Color;
			sampler2D _FlowlightTex;
				fixed4 _FlowlightTex_ST;
				fixed _SpeedX;
				fixed _SpeedY;

				 v2f vert(appdata_t IN)
				 {
					 v2f OUT;
					 OUT.vertex = UnityObjectToClipPos(IN.vertex);
					 OUT.texcoord = IN.texcoord;
					 OUT.texflow = TRANSFORM_TEX(IN.texcoord, _FlowlightTex);
					 OUT.texflow.x += _Time * _SpeedX;
					 OUT.texflow.y += _Time * _SpeedY;
					 OUT.color = IN.color * _Color;
				 #ifdef PIXELSNAP_ON
					 OUT.vertex = UnityPixelSnap(OUT.vertex);
				 #endif

					 return OUT;
				 }

				 sampler2D _MainTex;
				 float _Power;

				 fixed4 frag(v2f IN) : SV_Target
				 {
					 fixed4 c = tex2D(_MainTex, IN.texcoord);
					 fixed4 cadd = tex2D(_FlowlightTex, IN.texflow) * _Power;
					 cadd.rgb *= c.rgb;
					 c.rgb += cadd.rgb;
					 c.rgb *= c.a;
					 return c;
				 }
			ENDCG
		   }
		}
}