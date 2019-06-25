Shader "Sbin/vf" {
	SubShader {
		Pass{
			CGPROGRAM
			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it uses non-square matrices
			#pragma exclude_renderers gles
			// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members pos,uv)
			#pragma exclude_renderers d3d11
			#pragma vertex vert
			#pragma fragment frag
			#define MACROFL FL4(fl3.xy,0,1);

			typedef float4 FL4;
			struct v2f{
				float4 pos;
				float2 uv;
			};
			void vert(in float2 objPos:POSITION,out float4 pos:POSITION,out float4 col:COLOR)
			{
				pos = float4(objPos,0,1);
				col = pos;
			}

			void frag(inout float4 col:COLOR)
			{
				//float 32 half 16 fixed 11
				col = fixed4(1,1,0,1);
				bool bl = false;
				col = bl?col:fixed4(0,1,1,1);

				float2 fl2 = float2(1,0);
				float3 fl3 = float3(1,1,1);
				FL4 fl4 = MACROFL // xyzw/rgba
				col = fl4;

				float2x4 M2x4 = {1,0,1,1,1,1,0,0};
				col = M2x4[1];

				float arr[4] = {1,0.5,0.5,1};
				col = float4(arr[0],arr[1],arr[2],arr[3]);
				
				v2f o;
				o.pos = fl4;
				o.uv = fl2;
			}
			ENDCG
		}
	}
}
