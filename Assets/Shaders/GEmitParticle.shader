Shader "Spark/Ani/GEmitParticle"
{
    Properties
    {
		[NoScaleOffset]
		_MainTex("Sprite Texture", 2D) = "white" {}
		[HideInInspector] _TimeOffset("Time Offset",float) = 0

		[Header(Base)]
		_CellScale("Cell Scale", Range(0.01,10)) = 1
		_CellScaleRand("Cell Scale Random", Range(0,1)) = 0
		_EmittingTime("Emitting Time", Range(0,60)) = 0
		_FlyingTime("Flying Time", Range(0,10)) = 0
		_FlyingTimeRand("Flying Time Random", Range(0,10)) = 0
		_SilentTime("Silent Time", Range(0,40)) = 0
		_EjectorWidth("Ejector Width", Range(0,20)) = 0
		_EjectorHeight("Ejector Height", Range(0,20)) = 0

		[Header(Moving and force)]
		_Speed("Speed", Range(0,20)) = 0
		_SpeedRand("Speed Random", Range(0,10)) = 0
		_EmitDirection("Emit Direction", Range(-3.1416,3.1416)) = 0.7854
		_EmitDirectionRand("Emit Direction Random", Range(0,8)) = 0
		_Resistance("Resistance", Range(0,4)) = 0.2
		_Gravity("Gravity", Range(-10,10)) = 0
		_Tightly("Tightly", Range(0,2)) = 0
		_RotateSpeed("Rotate Speed", Range(-5,5)) = 2
		_RotateSpeedRand("Rotate Speed Rand", Range(0,1)) = 0

		[Header(Fade)]
		_FadeIn("FadeIn", Range(0.1,0.9)) = 0.2
		_FadeOut("FadeOut", Range(0.1,0.9)) = 0.8
		_FadeInScale("Fade In Scale", Range(0.01,4)) = 0.2
		_FadeOutScale("Fade Out Scale", Range(0.01,4)) = 1.2
		_Color("Fade In Color", Color) = (1,1,1,1)
		_FadeOutColor("Fade Out Color", Color) = (1,1,1,1)
		_VerticalFade("Vertical Fade", Range(0,2)) = 0
		_HorizontalFade("Horizontal Fade", Range(0,2)) = 0
		_Transparent("Transparent", Range(0.1,1)) = 1
    }

	CGINCLUDE
		#include "UnityCG.cginc"

		fixed4 _Color;
		fixed4 _FadeOutColor;
		half _EmittingTime;
		half _FlyingTime;
		half _FlyingTimeRand;
		half _SilentTime;
		half _TimeOffset;

		half _EjectorWidth;
		half _EjectorHeight;

		half _CellScale;
		half _CellScaleRand;
		half _Speed;
		half _SpeedRand;
		half _EmitDirection;
		half _EmitDirectionRand;
		half _Gravity;
		half _Resistance;
		half _RotateSpeed;
		half _FadeIn;
		half _FadeOut;
		half _Transparent;
		half _VerticalFade;
		half _HorizontalFade;
		half _FadeInScale;
		half _FadeOutScale;
		half _Tightly;
		
        struct appdata_t
        {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f
        {
            float4 vertex : SV_POSITION;
			float4 color : COLOR;
            float3 uv : TEXCOORD0;
        };

        sampler2D _MainTex;
        float4 _MainTex_ST;

	ENDCG

    SubShader
    {
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}
		Cull Off
		Lighting Off
		ZWrite Off
		Blend SrcAlpha One

        Pass
        {
			Tags{ "LightMode" = "ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma target 2.0

			v2f vert(appdata_t v)
			{
				v2f o;

				float2 pd = float2(abs(v.vertex.x), abs(v.vertex.y));
				float4 rand = float4(dot(pd, float2(1.2, 1.1)), dot(pd, float2(0.7, 1.3)), 
					                 dot(pd, float2(1.05, 0.9)), dot(pd, float2(0.7, 0.9)));
				rand = fmod(rand, 0.02) * 50-0.5;
				
				float4 vtxpos = float4(_EjectorWidth*rand.z, _EjectorHeight*rand.w,0,1);
				
				float sinv, cosv;
				float emitDirection = _EmitDirection + _EmitDirectionRand*rand.x;
				sincos(emitDirection, sinv, cosv);

				float speed = _Speed + _SpeedRand*rand.y;
				float speedX = speed*cosv;
				float speedY = speed*sinv;
				float spdRtRand = 1 - _RotateSpeed*rand.x;

				half4 speeddata = half4(speedX, speedY, _Gravity,_RotateSpeed);
				half4 fadedata = half4(_FadeIn, _FadeOut, _HorizontalFade, _VerticalFade);
				half4 scaledata = half4(_CellScale, _CellScaleRand, _FadeInScale, _FadeOutScale);
				
				float emittime = _EmittingTime + 0.001;
				float tm = _Time.y + _TimeOffset + rand.y*emittime;

				float flyingtime = _FlyingTime + abs(rand.w)*_FlyingTimeRand;
				float cycletime = flyingtime +_SilentTime;

				float tf = fmod(tm, cycletime);
				float fadeV =clamp(tf/flyingtime,0,1);

				float maxDampingTime = 1 / (_Resistance + 0.01);
				float speedTime = min(tf, maxDampingTime);
				float speedDamping= (speedTime - _Resistance*speedTime*speedTime*0.5);
				float tightlyFactor = max(0, 1 - _Tightly*fadeV*fadeV);
				
				float2 movingDist =float2(speeddata.x*speedDamping,speeddata.y*speedDamping - speeddata.z*tf*tf*0.5);

				float visible = step(tf, flyingtime);

				float fadeInAlpha = min(fadeV, fadedata.x) / fadedata.x;
				float fadeOutAlpha = 1 - (max(fadeV, fadedata.y) - fadedata.y) / (1 - fadedata.y);
				fadeOutAlpha = max(0, fadeOutAlpha - fadeV*fadedata.w);

				vtxpos.xy += movingDist;

				float hzv = clamp(abs(vtxpos.x), 0, 1) * 2;
				float fadeHzAlpha = max(0, 1 - hzv* fadedata.z);

				vtxpos.x *= tightlyFactor;
								
				float rt = speeddata.w * tm * rand.x;

				float csrd = rand.y*scaledata.y+1- scaledata.y;
				float2 xyOffset = (v.uv - 0.5)*scaledata.x*csrd*lerp(scaledata.z, scaledata.w, fadeV);
				sincos(rt, sinv, cosv);
				vtxpos.x += xyOffset.x*cosv - xyOffset.y*sinv;
				vtxpos.y += xyOffset.x*sinv + xyOffset.y*cosv;

				o.vertex = UnityObjectToClipPos(vtxpos);

				o.color = lerp(_Color, _FadeOutColor, fadeV);
				o.color.a *= visible;

				o.uv = float3(v.uv, clamp(fadeInAlpha*fadeOutAlpha*fadeHzAlpha, 0, 1)*_Transparent);
				return o;
			}

            fixed4 frag (v2f i) : SV_Target
            {
				float4 tex=tex2D(_MainTex, i.uv.xy);
				float4 tc = i.color;
				tc.a *= i.uv.z*tex.r*tex.a;

				return tc;
            }
            ENDCG
        }
    }
}
