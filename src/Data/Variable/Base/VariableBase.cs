using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
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
				public abstract class VariableBase : ScriptableObject
				{
					/// <summary>
					/// If this is a read-write value or read-only.
					/// </summary>
					[SerializeField]
					protected PermissionLevel accessMode = PermissionLevel.ReadWrite;

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
					protected UnityEngine.Events.UnityEvent onValueChanged = null;

					/// <summary>
					/// If reading this value should output a log message.
					/// </summary>
					[SerializeField]
					protected bool logOnRead = false;

					/// <summary>
					/// If reading this value should output a log message.
					/// </summary>
					[SerializeField]
					protected bool logOnWrite = false;

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
					/// Call to reset the value to the default value. If the value is changed, the onChanged event is raised.
					/// </summary>
					public abstract void Reset();

					/// <summary>
					/// Get the currently stored value as the given type.
					/// </summary>
					public abstract T GetValueAs<T>();

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
							Reset();
						}
#else
						if (autoResetInBuild)
						{
							Reset();
						}
#endif
					}
				}
			}
		}
	}
}