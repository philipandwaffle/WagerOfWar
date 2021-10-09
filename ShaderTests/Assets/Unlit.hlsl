#ifndef MYRP_UNLIT_INCLUDED
#define MYRP_UNLIT_INCLUDED



//CBUFFER_START(UnityPerFrame)
	float4x4 Unity_MatrixVP;
//CBUFFER_END

cbuffer UnityPerDraw
{
	float4x4 Unity_ObjectToWorld;
}

struct VertexInput
{
	float4 pos : POSITIONT;
};

struct VertexOutput
{
	float4 clipPos : SV_POSITION;
};

VertexOutput UnlitPassVertex(VertexInput input)
{
	VertexOutput output;
	float4 worldPos = mul(Unity_ObjectToWorld, input.pos);
	output.clipPos = mul(Unity_MatrixVP, float4(worldPos.xyz, 1));	//as the 4th component is always 1 we can shave computation time
	return output;
}

float4 UnlitPassFragment(VertexOutput input) : SV_Target
{	
	return 1;
}

#endif // MYRP_UNLIT_INCLUDED