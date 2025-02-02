Shader "Custom/BubbleShader"
{
    Properties
    {
        _Color("Color", Color) = (0, 0, 1, 1)
        _Speed("Blink Speed", Float) = 2.0
    }
        SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
            };

            struct v2f {
                float4 pos : SV_POSITION;
            };

            fixed4 _Color;
            float _Speed;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float blink = abs(sin(_Time.y * _Speed)); // Creates a blinking effect
                return _Color * blink;
            }
            ENDCG
        }
    }
}
