Shader "Sbin/MyDiffuse"
{
    SubShader{
		Pass{
		Tags{"LightModel" = "ForwardBase"}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "lighting.cginc"
			struct v2f{
				float4 pos:POSITION;
				fixed4 color:COLOR;
			};

			
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				float3 N = normalize(v.normal);
				float3 L = normalize(_WorldSpaceLightPos0);
				float ndotl = saturate(dot(N,L));
				o.color = _LightColor0 * ndotl;
				return o; 
			}

			fixed4 frag(v2f IN):COLOR
			{
				return IN.color * UNITY_LIGHTMODEL_AMBIENT;
			}
			ENDCG
		}
	}
}
