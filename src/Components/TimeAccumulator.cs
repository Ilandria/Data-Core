using CCB.DataCore.Data.Reference;
using CCB.DataCore.Data.Variable;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			public class TimeAccumulator : MonoBehaviour
			{
				[SerializeField]
				private BoolVariableReference isRunning;

				[SerializeField]
				private FloatVariableReference output;

				public TimeAccumulator()
				{
					isRunning = new BoolVariableReference(this);
					output = new FloatVariableReference(this);
				}

				private void Update()
				{
					if (isRunning.Value)
					{
						output.Value += Time.deltaTime;
					}
				}
			}
		}
	}
}