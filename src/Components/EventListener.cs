using CCB.DataCore.Data.Reference;
using CCB.DataCore.Data.Variable;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			public class EventListener : MonoBehaviour
			{
				[SerializeField]
				private EventRegistryVariable[] autoRegister = null;

				[SerializeField]
				private EventVariableReference response;

				public EventListener()
				{
					response = new EventVariableReference(this);
				}

				public void Raise()
				{
					response.Value.Invoke();
				}

				private void Awake()
				{
					if (autoRegister != null)
					{
						foreach (EventRegistryVariable eventRegistry in autoRegister)
						{
							eventRegistry.Value.Register(this);
						}
					}
				}

				private void OnDestroy()
				{
					if (autoRegister != null)
					{
						foreach (EventRegistryVariable eventRegistry in autoRegister)
						{
							eventRegistry.Value.Unregister(this);
						}
					}
				}
			}
		}
	}
}