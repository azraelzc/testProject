﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'


Shader "Sbin/vf31" {
	SubShader{
	
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			uniform float4x4 mvp;
			struct v2f{
				float4 pos:POSITION;
			};

			
			v2f vert(appdata_base v)
			{
				v2f o;
				//o.pos = UnityObjectToClipPos(v.vertex);
				o.pos = mul(mvp,v.vertex);
				return o; 
			}

			fixed4 frag():COLOR
			{
				return fixed4(1,1,1,1);
			}
			ENDCG
		}
	}
}
