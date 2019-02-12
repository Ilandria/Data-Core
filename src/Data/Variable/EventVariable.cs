using CCB.DataCore.Data.Variable;
using UnityEngine;
using UnityEngine.Events;

namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			namespace Variable
			{
				[System.Serializable]
				[CreateAssetMenu(menuName = "CCB/Variable/Event")]
				public class EventVariable : Variable<UnityEvent>
				{
					public void Raise()
					{
						Value?.Invoke();
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class EventVariableReference : VariableReference<EventVariable, UnityEvent>
				{
					public EventVariableReference(Object owner) : base(owner)
					{

					}

					public void Raise()
					{
						Value?.Invoke();
					}
				}
			}
		}
	}
}