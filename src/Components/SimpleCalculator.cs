using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
using CCB.DataCore.Data.Variable;
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
				private IntVariableReference numberOfInputs;

				[SerializeField]
				private ArithmeticOperator[] operators;

				[SerializeField]
				private VariableBase[] inputs;

				[SerializeField]
				private FloatVariableReference result;

				public SimpleCalculator()
				{
					numberOfInputs = new IntVariableReference(this);
					operators = new ArithmeticOperator[numberOfInputs.Value];
					inputs = new VariableBase[numberOfInputs.Value];
					result = new FloatVariableReference(this);
				}

				private void Update()
				{
					float result = 0;

					for (int i = 0; i < numberOfInputs.Value; i++)
					{
						switch (operators[i])
						{
							case ArithmeticOperator.Add:
								result += GetValue(i);
								break;

							case ArithmeticOperator.Subtract:
								result -= GetValue(i);
								break;

							case ArithmeticOperator.Multiply:
								result *= GetValue(i);
								break;

							case ArithmeticOperator.Divide:
								result /= GetValue(i);
								break;
						}
					}

					this.result.Value = result;
				}

				private float GetValue(int elementIndex)
				{
					float result = 0;

					if (inputs[elementIndex] != null)
					{
						result = inputs[elementIndex].GetValueAs<float>();
					}

					return result;
				}
			}
		}
	}
}