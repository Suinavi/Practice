Shader "z/Test"
{
    Properties
    {
        _MainTex ("Main texture", 2D) = "white" {}

    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MainTex;

        struct Input 
        {
            half2 uv_MainText;
        };
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainText);
        }
        ENDCG
    }
    Fallback "Diffuse"
}
