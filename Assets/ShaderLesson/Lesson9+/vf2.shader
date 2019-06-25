Shader "Sbin/vf2" {
	Properties{
			_MainColor("Main Color",Color) = (1,1,1,1)
	}
	SubShader{
	
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "sbin.cginc"
			struct v2f{
				float4 pos:POSITION;
				float2 opos:TEXCOORD0;
				fixed4 col:COLOR;
			};
			float4 _MainColor;
			uniform float4 _SecondColor;
			//typedef struct{
			//} v1f;

			
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = float4(v.pos,0,1);
				o.opos = float2(1,0);
				o.col = v.color;
				return o;
			}

			fixed4 frag(v2f IN):COLOR
			{
				//Func(col);
				//fixed4 col = o.pos;
				//return _MainColor * 0.5 +  _SecondColor * 0.5;
				return lerp(_MainColor,_SecondColor,0.1);
			}

			
			ENDCG
		}
	}
}
