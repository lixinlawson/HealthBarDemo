Shader "Custom/HealthBar" {
  Properties
    {
	    _Color ("Main Color", Color) = (1,1,1,1)
	    _CurrentTex ("Current (RGB) Trans (A)", 2D) = "white" {}
	    _MaskTex ("Mask (A)", 2D) = "white" {}
	    _CurrentHealth ("Current Health", Range(0,1)) = 1.0
    }
 
    Category
    {
        Lighting Off
        ZWrite Off
        Cull back
        Fog { Mode Off }
        Tags {"Queue"="Transparent" "IgnoreProjector"="True"}
        Blend SrcAlpha OneMinusSrcAlpha
        SubShader
        {
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                sampler2D _MaskTex;
                sampler2D _CurrentTex;
                fixed4 _Color;
                float _CurrentHealth;
                
                struct appdata
                {
                    float4 vertex : POSITION;
                    float4 texcoord : TEXCOORD0;
                };
                struct v2f
                {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };
                v2f vert (appdata v)
                {
                    v2f o;
                    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                    o.uv = v.texcoord.xy;
                    return o;
                }
                half4 frag(v2f i) : COLOR
                {
                	fixed4 c =_Color * tex2D(_CurrentTex, i.uv);           	
                    fixed ca = tex2D(_MaskTex, i.uv).a;
                    c.a *= ca >= _CurrentHealth ? 0.0f : 1.0f;
                    return c;
                }
                ENDCG
            }
        }
 
        SubShader
        {          
             AlphaTest LEqual [_CurrentHealth] 
              Pass 
              {     
            	 SetTexture [_MaskTex] {combine texture}
               	 SetTexture [_CurrentTex] {combine texture, previous} 
              } 
        }
    }
    Fallback "Transparent/VertexLit"
}