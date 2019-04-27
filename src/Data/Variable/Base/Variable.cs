using CCB.DataCore.Data.Enum;
using CCB.DataCore.Debugging;
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
				public abstract class Variable<ValueType> : VariableBase
				{
					/// <summary>
					/// The current value of this variable.
					/// </summary>
					[SerializeField]
					protected ValueType value;

					/// <summary>
					/// The default value to reset to, if applicable.
					/// </summary>
					[SerializeField]
					protected ValueType defaultValue;

					/// <summary>
					/// Get or set the current value of this variable.
					/// </summary>
					public ValueType Value
					{
						get
						{
							if (logOnRead)
							{
								ConsoleUtils.Dbg($"Got {value.ToString()} from {name}.");
							}

							if (value == null)
							{
								ConsoleUtils.Wrn($"Variable {name} value is currently null.");
							}

							return value;
						}

						set
						{
							if (accessMode == PermissionLevel.ReadWrite)
							{
								if (!this.value.Equals(value))
								{
									if (logOnWrite)
									{
										ConsoleUtils.Dbg($"Set {name} to {value.ToString()}, was {this.value.ToString()}");
									}

									this.value = value;
									onValueChanged?.Invoke();
								}
							}
							else
							{
								ConsoleUtils.Wrn($"Tried to set {name}'s value while it was in read-only mode.");
							}
						}
					}

					public override T GetValueAs<T>()
					{
						return Utilities.Conversions.ConvertType<T>(Value, this, "value");
					}

					/// <summary>
					/// Call to reset the value to the default value.
					/// </summary>
					public override void Reset()
					{
						Value = defaultValue;
					}

					public override string ToString()
					{
						return Value?.ToString();
					}
				}
			}
		}
	}
}