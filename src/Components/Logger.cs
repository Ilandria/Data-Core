using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			public class Logger : MonoBehaviour
			{
				[SerializeField]
				private StringVariableReference logMessage;

				[SerializeField]
				private LogLevelVariableReference logLevel;

				public Logger()
				{
					logMessage = new StringVariableReference(this);
					logLevel = new LogLevelVariableReference(this);
				}

				public void Log()
				{
					switch (logLevel.Value)
					{
						case LogLevel.Message:
							Debug.Logger.Message(GetFormattedMessage());
							break;

						case LogLevel.Warning:
							Debug.Logger.Warning(GetFormattedMessage());
							break;

						case LogLevel.Error:
							Debug.Logger.Error(GetFormattedMessage());
							break;
					}
				}

				private string GetFormattedMessage()
				{
					return $"Object Name: {name} | {logMessage.Value}";
				}
			}
		}
	}
}