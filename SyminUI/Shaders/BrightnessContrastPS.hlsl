sampler2D inputTex : register(S0);
//范围-1~1
float brightness : register(C0);
//范围-1~1
float contrast : register(C1);

static const float PI = 3.14159265f;

float4 main(float2 uv : TEXCOORD) : COLOR
{
    
    //UI的源颜色
    float4 sourceColor = tex2D(inputTex, uv);
    //计算对比度系数
    float k = tan((45 + 44 * contrast) / 180 * PI);
    //计算亮度对比度
    float4 outColor = (sourceColor - 0.5 * (1 - brightness)) * k + 0.5 * (1 + brightness);

    return outColor;
}
