Shader "SurfaceShader/SurfaceShader_001" {
    Properties
    {
        _MainColor("主颜色",Color) = (1,0,0,1)
        _MainTex("贴图",2D) = ""{}
    }

    SubShader
    {
        //表面着色器不需要Pass通道
        //使用的是CG语言进行编写
        CGPROGRAM
        #pragma surface surf Lambert alpha
        struct Input
        {
            float4 color:COLOR;
            float2 uv_MainTex;
        };

        fixed4 _MainColor;
        sampler2D _MainTex;

        void surf(Input IN , inout SurfaceOutput o)
        {
            o.Albedo = _MainColor.rgb;
            o.Alpha = _MainColor.a;
            o.Albedo = tex2D(_MainTex,IN.uv_MainTex).rgb;
        }
        ENDCG
    }
}