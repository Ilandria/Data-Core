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
						Value.Raise();
					}

					protected override void SetToDefault()
					{
						Value.Clear();
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class EventRegistryVariableReference : VariableReference<EventRegistryVariable, EventRegistry>
				{
					public EventRegistryVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Reference) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}