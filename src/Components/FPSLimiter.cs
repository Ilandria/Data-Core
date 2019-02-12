using CCB.DataCore.Data.Reference;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			public class FPSLimiter : MonoBehaviour
			{
				[SerializeField]
				private IntVariableReference targetFrameRate;

				public FPSLimiter()
				{
					targetFrameRate = new IntVariableReference(this);
				}

				private void Awake()
				{
					Application.targetFrameRate = targetFrameRate.Value;
				}
			}
		}
	}
}