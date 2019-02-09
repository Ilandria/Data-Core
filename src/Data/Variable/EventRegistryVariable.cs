using CCB.DataCore.Component;
using CCB.DataCore.Data.Variable;
using CCB.DataCore.Debugging;
using System.Collections.Generic;
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

					protected override void SetToDefault()
					{
						value.Clear();
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class EventRegistryVariableReference : VariableReference<EventRegistryVariable, EventRegistry>
				{
					public EventRegistryVariableReference(Object owner, VariableReferenceMode defaultMode = VariableReferenceMode.Value) : base(owner, defaultMode)
					{

					}
				}
			}
		}
	}
}