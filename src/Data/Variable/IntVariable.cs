using CCB.DataCore.Data.Variable;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			namespace Variable
			{
				[System.Serializable]
				[CreateAssetMenu(menuName = "CCB/Variable/Int")]
				public class IntVariable : Variable<int>
				{
					public void Increment()
					{
						Value++;
					}

					public void Decrement()
					{
						Value--;
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class IntVariableReference : VariableReference<IntVariable, int>
				{
					public IntVariableReference(Object owner) : base(owner)
					{

					}

					public void Increment()
					{
						Value = Value + 1;
					}

					public void Decrement()
					{
						Value = Value - 1;
					}
				}
			}
		}
	}
}