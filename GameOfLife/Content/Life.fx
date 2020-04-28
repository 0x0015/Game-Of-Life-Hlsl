//input image
sampler s0;

//xy is screen scroll, and zw if width and height
float4 screenPos;


float4 main(float2 coords: TEXCOORD0) : COLOR0
{
	float2 h1 = float2(1 / screenPos.z, 1 / screenPos.w);

	float4 color = tex2D(s0,coords);
	float4 n[8];
	n[0] = tex2D(s0, coords + float2(0, h1.y));
	n[1] = tex2D(s0, coords + float2(0, -h1.y));

	n[2] = tex2D(s0, coords + float2(h1.x, 0));
	n[3] = tex2D(s0, coords + float2(-h1.x, 0));

	n[4] = tex2D(s0, coords + float2(h1.x, h1.y));
	n[5] = tex2D(s0, coords + float2(-h1.x, h1.y));

	n[6] = tex2D(s0, coords + float2(h1.x, -h1.y));
	n[7] = tex2D(s0, coords + float2(-h1.x, -h1.y));

	int numaliven = 0;
	for (int i = 0; i < 8; i++) {
		if (n[i].x == 1) {
			numaliven++;
		}
	}
	int numdeadn = 8 - numaliven;

	if (numaliven < 2) {
		return(float4(0, 0, 0, 1));
	}

	if (color.x == 1) {
		if (numaliven == 2 || numaliven == 3) {
			return(float4(1, 1, 1, 1));
		}
	}
	else {
		if (numaliven == 3) {
			return(float4(1, 1, 1, 1));
		}
	}

	if (numaliven > 3) {
		return(float4(0, 0, 0, 0));
	}

	return(float4(0,0,0,0));
}



technique Technique1
{
	pass Pass1
	{
		//compile with ps 3 or higher (3 is highest supported)
		PixelShader = compile ps_3_0 main();
	}
}