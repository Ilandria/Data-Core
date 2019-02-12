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
				[CreateAssetMenu(menuName = "CCB/Variable/String")]
				public class StringVariable : Variable<string>
				{

				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class StringVariableReference : VariableReference<StringVariable, string>
				{
					public StringVariableReference(Object owner) : base(owner)
					{

					}
				}
			}
		}
	}
}