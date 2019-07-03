﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'



Shader "Sbin/vf33" {
	SubShader{
	
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			float4x4 mvp;
			float4x4 sm;
			struct v2f{
				float4 pos:POSITION;
				fixed4 color:COLOR;
			};

			
			v2f vert(appdata_base v)
			{
				v2f o;
				float4x4 m = mul(mvp,sm);
				o.pos = mul(m,v.vertex);
				if(v.vertex.x == 0.5 && v.vertex.y == 0.5 && v.vertex.z == 0.5)
					o.color = fixed4(_SinTime.w/2+0.5,_CosTime.w/2+0.5,_SinTime.y/2+0.5,1);
				else
					o.color = fixed4(0,0,1,1);
				//float4 wpos = mul(unity_ObjectToWorld,v.vertex);
				//if(wpos.x >0)
					//o.color = fixed4(1,0,0,1);
				//else
					//o.color = fixed4(0,0,1,1);
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
