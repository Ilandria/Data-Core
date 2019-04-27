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
					public void SetValue(TMPro.TMP_InputField input)
					{
						if (float.TryParse(input.text, out float result))
						{
							Value = result;
						}
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class FloatVariableReference : VariableReference<FloatVariable, float>
				{
					public FloatVariableReference(Object owner) : base(owner)
					{

					}
				}
			}
		}
	}
}