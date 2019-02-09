using CCB.DataCore.Data.Enum;
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
				[CreateAssetMenu(menuName = "CCB/Variable/Log Level")]
				public class LogLevelVariable : Variable<LogLevel>
				{

				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class LogLevelVariableReference : VariableReference<LogLevelVariable, LogLevel>
				{
					public LogLevelVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Value) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}