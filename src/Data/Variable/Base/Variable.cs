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
								ConsoleUtils.Msg($"Got {value.ToString()} from {name}.");
							}

							if (value == null)
							{
								ConsoleUtils.Dbg($"Variable {name} value is currently null.");
							}

							return value;
						}

						set
						{
							if (accessMode == PermissionLevel.ReadWrite)
							{
								if (logOnWrite)
								{
									ConsoleUtils.Msg($"Set {name} to {value.ToString()}, was {this.value.ToString()}");
								}

								this.value = value;

								onValueChanged.Invoke();
							}
							else
							{
								ConsoleUtils.Dbg($"Tried to set {name}'s value while it was in read-only mode.");
							}
						}
					}

					public override T GetValueAs<T>()
					{
						return Utilities.Conversions.ConvertType<T>(Value, this, "value");
					}

					/// <summary>
					/// Call to reset the value to the default value. If the value is changed, the onChanged event is raised.
					/// </summary>
					public override void Reset()
					{
						if (Value != null)
						{
							if (!Value.Equals(defaultValue))
							{
								onValueChanged.Invoke();
							}
						}

						SetToDefault();
					}

					/// <summary>
					/// Internally called by ResetIfChanged. Override to define custom reset behaviour to support
					/// things like deep copying data, or alter other properties.
					/// </summary>
					protected override void SetToDefault()
					{
						Value = defaultValue;
					}
				}
			}
		}
	}
}