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
				[CreateAssetMenu(menuName = "CCB/Variable/Float")]
				public class FloatVariable : Variable<float>
				{

				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class FloatVariableReference : VariableReference<FloatVariable, float>
				{
					public FloatVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Reference) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}