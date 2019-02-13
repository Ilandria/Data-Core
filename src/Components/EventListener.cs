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
				private EventRegistryVariable[] autoRegister;

				[SerializeField]
				private EventVariableReference response;

				public EventListener()
				{
					autoRegister = new EventRegistryVariable[0];
					response = new EventVariableReference(this);
				}

				public void Raise()
				{
					response.Value.Invoke();
				}

				private void OnEnable()
				{
					foreach (EventRegistryVariable eventRegistry in autoRegister)
					{
						eventRegistry.Value.Register(this);
					}
				}

				private void OnDisable()
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