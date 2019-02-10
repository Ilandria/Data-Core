using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			[System.Serializable]
			public class SimpleCalculator : MonoBehaviour
			{
				[SerializeField]
				private IntVariableReference numElements;

				[SerializeField]
				private ArithmeticOperators[] operators;

				[SerializeField]
				private VariableReferenceBase[] elements;

				public SimpleCalculator()
				{
					numElements = new IntVariableReference(this, VariableReferenceMode.Value);
				}
			}
		}
	}
}