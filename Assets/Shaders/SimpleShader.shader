// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/SimpleShader"
{
    Properties
    {
     _Color("Screen Color", Color) = (1,1,1,1)
     _MainTex("Texture", 2D) = "white"{}
     _TransitionTex("Transition Texture", 2D) = "white" {}
     _Cutoff("Cutoff", Range(0,1)) = 0
    _Fade("Fade", Range(0,1)) = 0
    [MaterialToggle] _Distort("Distort", Float) = 0
    }
        SubShader
     {
         Pass
         {
             CGPROGRAM
             #pragma vertex vert
             #pragma fragment frag


             // vertex shader inputs
             struct appdata
             {
                 float4 vertex : POSITION; // vertex position
                 float2 uv : TEXCOORD0; // texture coordinate
             };

             // vertex shader outputs ("vertex to fragment")
             struct v2f
             {
                 float2 uv : TEXCOORD0; // texture coordinate
                 float4 vertex : SV_POSITION; // clip space position
             };

             // vertex shader
             v2f vert(appdata v)
             {
                 v2f o;
                 // transform position to clip space
                 // (multiply with model*view*projection matrix)
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 // just pass the texture coordinate
                 o.uv = v.uv;
                 return o;
             }

             // texture we will sample
             sampler2D _MainTex;
             sampler2D _TransitionTex;
             float _Cutoff;
             float _Fade;
             float _Distort;
             fixed4 _Color;

             // pixel shader; returns low precision ("fixed4" type)
             // color ("SV_Target" semantic)
             fixed4 frag(v2f i) : SV_Target
             {
                 fixed4 transit = tex2D(_TransitionTex, i.uv);

             fixed2 direction = float2(0, 0);

             if (_Distort)
                 direction = normalize(float2((transit.r - 0.5) * 2, (transit.g - 0.5) * 2));
                

             fixed col = tex2D(_MainTex, i.uv + _Cutoff + direction);
                 if (transit.b < _Cutoff)
                    return  col = lerp(col, _Color, _Fade);
               //  col.a = 0;

                 return tex2D(_MainTex, i.uv);
             }
             ENDCG
        }
     }

}
