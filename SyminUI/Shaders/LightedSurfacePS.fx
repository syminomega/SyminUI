sampler2D inputTex : register(S0);
float2 mousePos : register(C0);
float2 uiSize : register(C1);
float2 lightSize : register(C2);
float intensity: register(C3);


float4 main(float2 uv : TEXCOORD) : COLOR
{
    //UI的透明通道
    float alpha = tex2D(inputTex, uv).a;
    //计算鼠标在UV空间位置
    float2 mousePercent = mousePos / uiSize;
    //


    return float4(1,1,1, alpha);
}