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
					Debug.Log(GetFormattedMessage(memberName, lineNumber, filePath, info, "Info"));
				}

				public static void Warning(string info, [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
				{
					Debug.LogWarning(GetFormattedMessage(memberName, lineNumber, filePath, info, "Warning"));
				}

				public static void Error(string info, [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "")
				{
					Debug.LogError(GetFormattedMessage(memberName, lineNumber, filePath, info, "Error"));
				}

				public static void UnassignedReferenceWarning(Object owner, string ownerFieldName)
				{
					string ownerTypeName = "UnknownOwnerType";
					string ownerName = "Unknown Owner";

					if (owner != null)
					{
						ownerName = owner.name;
						ownerTypeName = owner.GetType().ToString().Substring(ownerTypeName.LastIndexOf('.') + 1);
					}

					Warning($"{ownerName}'s {ownerTypeName}.{ownerFieldName} is set to reference mode and reference is null!");
				}

				public static void InvalidConversionWarning(Object owner, string ownerFieldName, System.Type targetType)
				{
					string ownerTypeName = "UnknownOwnerType";
					string ownerName = "Unknown Owner";

					if (owner != null)
					{
						ownerName = owner.name;
						ownerTypeName = owner.GetType().ToString();
						ownerTypeName = ownerTypeName.Substring(ownerTypeName.LastIndexOf('.') + 1);
					}

					string targetTypeName = targetType.ToString();
					targetTypeName = targetTypeName.Substring(targetTypeName.LastIndexOf('.') + 1);

					Warning($"{ownerName}'s {ownerTypeName}.{ownerFieldName} can not be converted to {targetTypeName}");
				}

				private static string GetFormattedMessage(string memberName, int lineNumber, string filePath, string info, string label)
				{
					return $"{Application.productName} ({Path.GetFileNameWithoutExtension(filePath)}::{memberName} - {lineNumber}) [{label}] {info}";
				}
			}
		}
	}
}