using System.Reflection;

namespace CCB
{
	namespace DataCore
	{
		namespace Debugging
		{
			namespace Reflection
			{
				public static class Utilities
				{
					/// <summary>
					/// If possible, retrieves the field name from the owner that the reference
					/// object is stored within.
					/// </summary>
					public static string GetFieldName(object referenceObject, object owner)
					{
						string fieldName = "";

						FieldInfo[] fields = owner.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);

						foreach (FieldInfo field in fields)
						{
							if (referenceObject.Equals(field.GetValue(owner)))
							{
								fieldName = field.Name;
							}
						}

						return fieldName;
					}
				}
			}
		}
	}
}