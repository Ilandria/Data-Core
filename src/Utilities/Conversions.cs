using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Utilities
		{
			public static class Conversions
			{
				public static TypeOut ConvertType<TypeOut>(object value, Object owner = null, string ownerFieldName = "")
				{
					TypeOut result = default;

					try
					{
						result = (TypeOut)value;
					}
					catch (System.Exception)
					{
						Debugging.ConsoleUtils.InvalidConversionWarning(owner, ownerFieldName, typeof(TypeOut));
					}

					return result;
				}
			}
		}
	}
}