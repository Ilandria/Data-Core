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
				public class EventRegistryVariable : Variable<List<EventListener>>
				{
					public void Register(EventListener eventListener)
					{
						if (eventListener != null)
						{
							if (!value.Contains(eventListener))
							{
								value.Add(eventListener);
							}
							else
							{
								ConsoleUtils.Warning($"{name} tried to register a duplicate event listener: {eventListener.name}.");
							}
						}
						else
						{
							ConsoleUtils.Warning($"{name} tried to register a null event listener.");
						}
					}

					public void Unregister(EventListener eventListener)
					{
						value.Remove(eventListener);
					}

					public void Raise()
					{
						foreach (EventListener eventListener in value)
						{
							eventListener.Raise();
						}
					}

					protected override void SetToDefault()
					{
						value.Clear();

						foreach (EventListener eventListener in defaultValue)
						{
							value.Add(eventListener);
						}
					}
				}
			}

			namespace Reference
			{
				[System.Serializable]
				public class EventRegistryVariableReference : VariableReference<EventRegistryVariable, List<EventListener>>
				{
					public EventRegistryVariableReference(Object owner) : base(owner)
					{

					}
				}
			}
		}
	}
}