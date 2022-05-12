
sampler2D inputTex : register(S0);
float2 center : register(C0);
float4 color1 : register(C1);
float4 color2: register(C2);
float2 range : register(C3);

static const float PI = 3.14159265f;

float4 main(float2 uv : TEXCOORD) : COLOR
{
    //UI的透明通道
    float alpha = tex2D(inputTex, uv).a;
    //求得夹角弧度
    float angle = atan2(uv.y - center.y, uv.x - center.x) + PI;
    //转化为 0~1 范围
    angle = (angle / (2 * PI));
    //求取范围长度
    float rangeWidth = range.y - range.x;
    //根据范围截断
    angle = max(range.x, angle);
    angle = min(range.y, angle);

    float rangeRatio = (angle - range.x) / rangeWidth;

    float4 color = lerp(color1, color2, rangeRatio) * alpha;

    

    return float4(color.xyz, alpha);
}