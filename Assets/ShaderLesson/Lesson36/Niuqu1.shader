// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'


Shader "Sbin/Niuqu1" {
	SubShader{
	
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			struct v2f{
				float4 pos:POSITION;
				fixed4 color:COLOR;
			};

			
			v2f vert(appdata_base v)
			{
				//float angle = length(v.vertex) * _SinTime.w;
				float angle = v.vertex.z + _Time.w;
				//float4x4 m = {
					//float4(sin(angle)/8+0.5,0,0,0),
					//float4(0,1,0,0),
					//float4(0,0,1,0),
					//float4(0,0,0,1),
				//};
				//v.vertex = mul(m,v.vertex);
				v.vertex.x = (sin(angle)/8+0.5) * v.vertex.x;
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = fixed4(0,1,1,1);
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
