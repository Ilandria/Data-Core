using CCB.DataCore.Data.Reference;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			public class InputAxisReader : MonoBehaviour
			{
				[SerializeField]
				private StringVariableReference inputName;

				[SerializeField]
				private BoolVariableReference inputEnabled;

				[SerializeField]
				private EventRegistryVariableReference onEvent;

				[SerializeField]
				private EventRegistryVariableReference offEvent;

				[SerializeField]
				private EventRegistryVariableReference holdEvent;

				[SerializeField]
				private FloatVariableReference currentInputValue;

				public InputAxisReader()
				{
					inputName = new StringVariableReference(this);
					inputEnabled = new BoolVariableReference(this);
					onEvent = new EventRegistryVariableReference(this);
					offEvent = new EventRegistryVariableReference(this);
					holdEvent = new EventRegistryVariableReference(this);
					currentInputValue = new FloatVariableReference(this);
				}

				public void Update()
				{
					if (inputEnabled.Value)
					{
						float currentAxis = Input.GetAxis(inputName.Value);
						float previousAxis = currentInputValue.Value;
						currentInputValue.Value = currentAxis;

						// If it was not being activated...
						if (Mathf.Approximately(previousAxis, 0.0f))
						{
							// ...and now it is, raise the "on" event.
							if (!Mathf.Approximately(currentAxis, 0.0f))
							{
								onEvent.Value.Raise();
							}
						}
						// If it was being activated...
						else
						{
							// ...and now it isn't, raise the "off" event.
							if (Mathf.Approximately(currentAxis, 0.0f))
							{
								offEvent.Value.Raise();
							}
							// ...and it still is, raise the "hold" event.
							else
							{
								holdEvent.Value.Raise();
							}
						}
					}
				}
			}
		}
	}
}