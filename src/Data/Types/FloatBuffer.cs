namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			[System.Serializable]
			public class FloatBuffer : Buffer<float>
			{
				public FloatBuffer(int maxBufferSize) : base(maxBufferSize)
				{

				}
			}
		}
	}
}