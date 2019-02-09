using UnityEngine;
using System.Runtime.CompilerServices;
using System.IO;

namespace CCB
{
	namespace DataCore
	{
		namespace Debugging
		{
			public static class ConsoleUtils
			{
				public static void Message(string info, [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
				{
					UnityEngine.Debug.Log(GetFormattedMessage(memberName, lineNumber, filePath, info, "Info"));
				}

				public static void Warning(string info, [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
				{
					UnityEngine.Debug.LogWarning(GetFormattedMessage(memberName, lineNumber, filePath, info, "Warning"));
				}

				public static void Error(string info, [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
				{
					UnityEngine.Debug.LogError(GetFormattedMessage(memberName, lineNumber, filePath, info, "Error"));
				}

				private static string GetFormattedMessage(string memberName, int lineNumber, string filePath, string info, string label)
				{
					return $"{Application.productName} ({Path.GetFileNameWithoutExtension(filePath)}::{memberName} - {lineNumber}) [{label}] {info}";
				}
			}
		}
	}
}