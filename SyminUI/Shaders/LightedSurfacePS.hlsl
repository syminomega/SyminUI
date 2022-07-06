sampler2D inputTex : register(S0);
float2 mousePos : register(C0);
float2 uiSize : register(C1);
float lightSize : register(C2);
float intensity : register(C3);
float4 lightColor : register(C4);

static const float PI = 3.14159265f;

float4 main(float2 uv : TEXCOORD) : COLOR
{
	//UI的源颜色
	float4 sourceColor = tex2D(inputTex, uv);
	//计算当前UV值的实际尺寸坐标
	float xPos = uv.x * uiSize.x;
	float yPos = uv.y * uiSize.y;
	//计算当前片元和鼠标位置的实际距离
	float distanceMouseFrag = length(float2(xPos - mousePos.x, yPos - mousePos.y));
	//归一化距离(0~1)
	float uniformedDistance = min(distanceMouseFrag / lightSize,1);
	//距离转渐进强度(1~0)
	float intensityFrag = cos(uniformedDistance * PI) / 2.0f + 0.5f;
	//计算线性减淡
	float3 linearDodge = sourceColor.xyz + lightColor.xyz * intensityFrag * intensity * sourceColor.a;

	return float4(linearDodge, sourceColor.a);
	
}