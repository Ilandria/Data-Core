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
					/// <summary>
					/// Copies the default max size into the current max size and clears the buffer.
					/// </summary>
					protected override void SetToDefault()
					{
						value = new FloatBuffer(defaultValue.MaxBufferSize);
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class FloatBufferVariableReference : VariableReference<FloatBufferVariable, FloatBuffer>
				{
					public FloatBufferVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Reference) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}