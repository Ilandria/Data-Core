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
				[CreateAssetMenu(menuName = "CCB/Variable/Bool")]
				public class BoolVariable : Variable<bool>
				{

				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class BoolVariableReference : VariableReference<BoolVariable, bool>
				{
					public BoolVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Reference) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}