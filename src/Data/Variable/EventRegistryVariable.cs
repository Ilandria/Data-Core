using CCB.DataCore.Data.Variable;
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
				[CreateAssetMenu(menuName = "CCB/Variable/Event Registry")]
				public class EventRegistryVariable : Variable<EventRegistry>
				{
					public void Raise()
					{
						Value?.Raise();
					}

					public override void Reset()
					{
						Value?.Clear();
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class EventRegistryVariableReference : VariableReference<EventRegistryVariable, EventRegistry>
				{
					public EventRegistryVariableReference(Object owner) : base(owner)
					{

					}
				}
			}
		}
	}
}