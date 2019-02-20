Shader "FexedFunction/ff2" {
	Properties {
		_Color("Main Color",color) = (1,1,1,1)
		_Ambient("Ambient",color) = (0.3,0.3,0.3,0.3)
		_Specular("Specular",color) = (1,1,1,1)
		_Shininess("Shininess",range(0,8)) = 4
		_Emission("Emission",color) = (1,1,1,1)
		_MainTex("MainTexture",2d) = ""{}
		_SecondTex("SecondTexture",2d) = ""{}
		_Constant("ConstantColor",color) = (1,1,1,0.3)
	}
	SubShader {
		Tags {"Queue" = "Transparent"}
		Pass{
			Blend SrcAlpha OneMinusSrcAlpha // Alpha blending
			//color(1,0,0,1)
			//color[_Color]
			material
			{
				diffuse[_Color]
				ambient[_Ambient]
				specular[_Specular]
				shininess[_Shininess]
				emission[_Emission]
			}
			lighting on
			separatespecular on

			settexture[_MainTex]
			{
				//double quad
				combine texture * primary double
			}

			settexture[_SecondTex]
			{
				constantColor[_Constant]
				//double quad
				combine texture * previous double, texture * constant
			}
		}
	}
}
