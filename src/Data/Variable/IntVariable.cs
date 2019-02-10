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

				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class IntVariableReference : VariableReference<IntVariable, int>
				{
					public IntVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Reference) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}