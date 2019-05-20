Shader "Sbin/vf2" {
	SubShader{
		Pass{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "sbin.cginc"
			

			

			void vert(in float2 objPos:POSITION,out float4 pos:POSITION,out float4 col:COLOR)
			{
				pos = float4(objPos,0,1);
				col = pos;
			}

			void frag(out float4 col:COLOR)
			{
				Func(col);
				//float arr[]={0.5,0.5};
				//col.x=Fun2(arr);
			}

			
			ENDCG
		}
	}
}
