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
				private EventVariableReference response;

				[SerializeField]
				private EventRegistryVariable[] autoRegister = null;

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
							eventRegistry.Register(this);
						}
					}
				}

				private void OnDestroy()
				{
					if (autoRegister != null)
					{
						foreach (EventRegistryVariable eventRegistry in autoRegister)
						{
							eventRegistry.Unregister(this);
						}
					}
				}
			}
		}
	}
}