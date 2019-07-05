// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'


Shader "Sbin/wave" {
	Properties{
		_Amplipude("Amplipude",range(0,1)) = 0.5
		_Cycle("Cycle",range(0,5)) = 1
		_Speed("Speed",range(0,5)) = 1
	}

	SubShader{
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			float _Amplipude,_Cycle,_Speed;
			struct v2f{
				float4 pos:POSITION;
				fixed4 color:COLOR;
			};

			
			v2f vert(appdata_base v)
			{
				//叠加波
				//v.vertex.y += _Amplipude * sin((v.vertex.x+v.vertex.z) * _Cycle + _Time.w *_Speed);
				v.vertex.y += _Amplipude * sin((v.vertex.x-v.vertex.z) * _Cycle + _Time.w *_Speed);
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = fixed4(v.vertex.y,v.vertex.y,v.vertex.y,1);
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
