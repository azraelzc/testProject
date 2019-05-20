Shader "Sbin/vf1" {
	SubShader {
		Pass{
			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
         
            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 color : COLOR;
            };
            
            v2f vert (appdata_base v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				if (o.pos.x < 0 && o.pos.y <0) {
					o.color = float4(1,0,0,1);
				} else if (o.pos.x < 0) {
					o.color = float4(0,1,0,1);
				} else if (o.pos.y <0) {
					o.color = float4(0,1,1,1);
				} else {
					o.color = float4(0,0,1,1);
				}
                //o.color.xyz = v.normal * 0.5 + 0.5;
                //o.color.w = 1.0;
                return o;
            }

            fixed4 frag (v2f v) : SV_Target { 
				fixed4 f4;
				for(int i=0;i<10;i++) {
				
				} 
				if(i==11){
					f4 = float4(1,0,0,1); 
				} else {
					f4 = v.color;
				}
				return f4; 
			}
            ENDCG
		}
	}
}
