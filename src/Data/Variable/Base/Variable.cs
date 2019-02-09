using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
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
				public abstract class Variable<T> : ScriptableObject
				{
					/// <summary>
					/// The current value of this variable.
					/// </summary>
					[SerializeField]
					protected T value;

					/// <summary>
					/// If this is a read-write value or read-only.
					/// </summary>
					[SerializeField]
					protected PermissionLevel accessMode = PermissionLevel.ReadWrite;

					/// <summary>
					/// The default value to reset to, if applicable.
					/// </summary>
					[SerializeField]
					protected T defaultValue;

					/// <summary>
					/// If the value should be reset to default at launch/recompile/etc. in editor.
					/// </summary>
					[SerializeField]
					protected bool autoResetInEditor = false;

					/// <summary>
					/// If the value should be reset to default at launch in builds.
					/// </summary>
					[SerializeField]
					protected bool autoResetInBuild = true;

					/// <summary>
					/// Optional event registry to raise whenever the value has changed.
					/// </summary>
					[SerializeField]
					protected EventVariableReference onValueChanged = null;

					/// <summary>
					/// If it is currently safe to write to this variable.
					/// </summary>
					public bool IsReadOnly
					{
						get
						{
							return accessMode == PermissionLevel.ReadOnly;
						}
					}

					/// <summary>
					/// Get or set the current value of this variable.
					/// </summary>
					public T Value
					{
						get
						{
							if (value == null)
							{
								ConsoleUtils.Warning($"Variable {name} value is currently null.");
							}

							return value;
						}

						set
						{
							if (accessMode == PermissionLevel.ReadWrite)
							{
								this.value = value;
								onValueChanged.Value?.Invoke();
							}
							else
							{
								ConsoleUtils.Warning($"Tried to set {name}'s value while it was in read-only mode.");
							}
						}
					}

					/// <summary>
					/// Call to reset the value to the default value. If the value is changed, the onChanged event is raised.
					/// </summary>
					public void Reset()
					{
						if (value != null)
						{
							if (!value.Equals(defaultValue))
							{
								onValueChanged.Value?.Invoke();
							}
						}

						SetToDefault();
					}

					/// <summary>
					/// Internally called by ResetIfChanged. Override to define custom reset behaviour to support
					/// things like deep copying data, or alter other properties.
					/// </summary>
					protected virtual void SetToDefault()
					{
						value = defaultValue;
					}

					protected void OnEnable()
					{
						AutoReset();
					}

					protected void OnDisable()
					{
						AutoReset();
					}

					private void AutoReset()
					{
#if UNITY_EDITOR
						if (autoResetInEditor)
						{
							SetToDefault();
						}
#else
						if (autoResetInBuild)
						{
							SetToDefault();
						}
#endif
					}
				}
			}
		}
	}
}