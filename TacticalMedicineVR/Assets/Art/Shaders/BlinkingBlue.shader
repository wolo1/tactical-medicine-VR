Shader "Custom/BlinkingBlue"
{
    Properties
    {
        _Color("Color", Color) = (0, 0, 1, 1)
        _Speed("Blink Speed", Float) = 2.0
        _ShadingStrength("Shading Strength", Range(0, 1)) = 0.5
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float3 normal : TEXCOORD1;
            };

            fixed4 _Color;
            float _Speed;
            float _ShadingStrength;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float blink = abs(sin(_Time.y * _Speed)); // Blink effect
                float shading = dot(i.normal, float3(0, 1, 0)) * _ShadingStrength + (1 - _ShadingStrength);
                return _Color * blink * shading;
            }
            ENDCG
        }
    }
}
