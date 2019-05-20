void Func(out float4 c)
{
	c=float4(1,0,0,1);
}

float Fun2(float arr[2])
{
	float sum=0;
	for(int i=0;i<arr.Length;i++)
	{
		sum+=arr[i];
	}
	return sum;
}