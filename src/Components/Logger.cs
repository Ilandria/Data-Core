using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
using CCB.DataCore.Debugging;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			[ExecuteAlways]
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
							ConsoleUtils.Msg(GetFormattedMessage());
							break;

						case LogLevel.Warning:
							ConsoleUtils.Wrn(GetFormattedMessage());
							break;

						case LogLevel.Error:
							ConsoleUtils.Err(GetFormattedMessage());
							break;

						case LogLevel.Debug:
							ConsoleUtils.Dbg(GetFormattedMessage());
							break;
					}
				}

				private string GetFormattedMessage()
				{
					return $"{name} | {logMessage.Value}";
				}
			}
		}
	}
}