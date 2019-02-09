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
			public struct EventRegistry
			{
				private List<EventListener> registeredListeners;

				public EventListener[] RegisteredListeners
				{
					get
					{
						return registeredListeners?.ToArray();
					}
				}

				public void Register(EventListener eventListener)
				{
					if (eventListener != null)
					{
						if (registeredListeners == null)
						{
							registeredListeners = new List<EventListener>();
						}

						if (!registeredListeners.Contains(eventListener))
						{
							registeredListeners.Add(eventListener);
						}
						else
						{
							ConsoleUtils.Warning($"{ToString()} tried to register a duplicate event listener: {eventListener.name}.");
						}
					}
					else
					{
						ConsoleUtils.Warning($"{ToString()} tried to register a null event listener.");
					}
				}

				public void Unregister(EventListener eventListener)
				{
					if (registeredListeners != null)
					{
						registeredListeners.Remove(eventListener);
					}
				}

				public void Raise()
				{
					if (registeredListeners != null)
					{
						foreach (EventListener eventListener in registeredListeners)
						{
							eventListener.Raise();
						}
					}
				}

				public void Clear()
				{
					registeredListeners?.Clear();
				}
			}
		}
	}
}