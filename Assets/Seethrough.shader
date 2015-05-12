Shader "Custom/Seethrough"
{
    Properties
    {
        _Color("Main Color", Color) = (1,1,1,1)
        _ThruColor("Thru Color", Color) = (1,0,0,1)
    }

    CGINCLUDE

    #include "UnityCG.cginc"

    struct v2f
    {
        float4 position : SV_POSITION;
    };

    half4 _Color;
    half4 _ThruColor;

    v2f vert(appdata_base v)
    {
        v2f o;
        o.position = mul(UNITY_MATRIX_MVP, v.vertex);
        return o;
    }

    half4 frag1(v2f i) : COLOR
    {
        return _Color;
    }

    half4 frag2(v2f i) : COLOR
    {
        return _ThruColor;
    }

    ENDCG

    SubShader
    {
        Pass
        {
            ZTest less
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag1
            ENDCG
        }
        Pass
        {
            ZTest greater
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag2
            ENDCG
        }
    } 
}
