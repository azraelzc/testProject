// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'


Shader "Sbin/Niuqu" {
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
				float angle = length(v.vertex) * _SinTime.w;
				//float4x4 m = {
					//float4(cos(angle),0,sin(angle),0),
					//float4(0,1,0,0),
					//float4(-sin(angle),0,cos(angle),0),
					//float4(0,0,0,1),
				//};

				//m = mul(UNITY_MATRIX_M,m);
				//m = mul(UNITY_MATRIX_VP,m);

				//v.vertex = mul(m,v.vertex);

				float x = cos(angle) * v.vertex.x + sin(angle) * v.vertex.z;
				float z = cos(angle) * v.vertex.z - sin(angle) * v.vertex.x;
				v.vertex.x = x;
				v.vertex.z = z;
				
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
