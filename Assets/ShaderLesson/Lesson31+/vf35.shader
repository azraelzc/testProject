// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'


Shader "Sbin/vf35" {
	Properties{
		_R("R",range(0,5)) = 1
		_OX("OX",range(-5,5)) = 0
	}

	SubShader{
	
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			float dis;
			float r;
			float _R;
			float _OX;
			struct v2f{
				float4 pos:POSITION;
				fixed4 color:COLOR;
			};

			
			v2f vert(appdata_base v)
			{
				float4 wpos = mul( unity_ObjectToWorld,v.vertex);
				float2 xy = wpos.xz;
				float d = _R - length(xy - float2(_OX,0));
				d = d < 0?0:d;
				float height = 1;
				float4 upPos = float4(v.vertex.x,d * height,v.vertex.z,v.vertex.w);
				v2f o;
				o.pos = UnityObjectToClipPos(upPos);
				o.color = fixed4(upPos.y,upPos.y,upPos.y,1);
				return o; 
			}

			fixed4 frag(v2f IN):COLOR
			{
				return IN.color;
			}
			ENDCG
		}
	}
}
