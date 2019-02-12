using CCB.DataCore.Data.Reference;
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
				[CreateAssetMenu(menuName = "CCB/Variable/Float Buffer")]
				public class FloatBufferVariable : Variable<FloatBuffer>
				{
					[SerializeField]
					private FloatVariableReference linkedVariable;

					public FloatBufferVariable()
					{
						linkedVariable = new FloatVariableReference(this);
					}

					/// <summary>
					/// Copies the default max size into the current max size and clears the buffer.
					/// </summary>
					protected override void SetToDefault()
					{
						value = new FloatBuffer(defaultValue.MaxBufferSize);
					}

					/// <summary>
					/// Adds a copy of the linked "valueToAdd" to the buffer.
					/// </summary>
					public void AddLinkedVariableToBuffer()
					{
						if (!IsReadOnly)
						{
							Value.AddToBuffer(linkedVariable.Value);
						}
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class FloatBufferVariableReference : VariableReference<FloatBufferVariable, FloatBuffer>
				{
					public FloatBufferVariableReference(Object owner) : base(owner)
					{

					}
				}
			}
		}
	}
}