Shader "SurfaceShader/SurfaceShader_002" {
    Properties
    {
        _MainTex("纹理贴图",2D) = ""{} //主纹理
        _BumpMap("法线贴图",2D) = ""{} //与之对应的法线贴图
        _MainColor("颜色",Color) = (1,1,1,1)
    }

    SubShader
    {
        //表面着色器不需要Pass通道
        //使用的是CG语言进行编写
        CGPROGRAM
        #pragma surface surf Lambert
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_BumpMap;
        };
        sampler2D _MainTex;
        sampler2D _BumpMap;
        fixed4 _MainColor;
        void surf(Input IN , inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex,IN.uv_MainTex).rgb; //首先设置纹理
            o.Normal = UnpackNormal(tex2D(_BumpMap,IN.uv_BumpMap)); //设置法线
            o.Albedo += _MainColor.rgb; //颜色与纹理融合 （加法融合会亮）
        }
        ENDCG
    }
}