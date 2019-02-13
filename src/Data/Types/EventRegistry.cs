using CCB.DataCore.Component;
using CCB.DataCore.Debugging;
using System.Collections.Generic;

namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			[System.Serializable]
			public class EventRegistry
			{
				private List<EventListener> registeredListeners;

				public EventRegistry()
				{
					registeredListeners = new List<EventListener>();
				}

				public EventListener[] RegisteredListeners
				{
					get
					{
						return registeredListeners.ToArray();
					}
				}

				public void Register(EventListener eventListener)
				{
					if (eventListener != null)
					{
						if (!registeredListeners.Contains(eventListener))
						{
							registeredListeners.Add(eventListener);
						}
						else
						{
							ConsoleUtils.Wrn($"{ToString()} tried to register a duplicate event listener: {eventListener.name}.");
						}
					}
					else
					{
						ConsoleUtils.Wrn($"{ToString()} tried to register a null event listener.");
					}
				}

				public void Unregister(EventListener eventListener)
				{
					registeredListeners.Remove(eventListener);
				}

				public void Raise()
				{
					foreach (EventListener eventListener in registeredListeners)
					{
						eventListener.Raise();
					}
				}

				public void Clear()
				{
					registeredListeners.Clear();
				}
			}
		}
	}
}