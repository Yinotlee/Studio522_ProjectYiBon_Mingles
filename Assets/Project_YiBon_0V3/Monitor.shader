Shader "My/Monitor"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM

        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            //o.Albedo = c.rgb;
            //o.Albedo = (c.r + c.g + c.b)/3 + 1;
            o.Alpha = c.a;
            
            float ndotl = dot(c.r, 1) * 0.5 + 2;
            ndotl = ndotl * 5;
            ndotl = ceil(ndotl)/5;
            o.Albedo = ndotl;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
