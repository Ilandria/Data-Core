using CCB.DataCore.Data.Reference;
using System;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Component
		{
			public class FloatToTimeString : MonoBehaviour
			{
				[SerializeField]
				private FloatVariableReference input;

				[SerializeField]
				private StringVariableReference output;

				public FloatToTimeString()
				{
					input = new FloatVariableReference(this);
					output = new StringVariableReference(this);
				}

				private void Update()
				{
					TimeSpan timeSpan = TimeSpan.FromSeconds(Mathf.Round(input.Value));

					if (timeSpan.Hours > 0)
					{
						output.Value = $"{timeSpan.Hours}h {timeSpan.Minutes}m {timeSpan.Seconds}s";
					}
					else if (timeSpan.Minutes > 0)
					{
						output.Value = $"{timeSpan.Minutes}m {timeSpan.Seconds}s";
					}
					else
					{
						output.Value = $"{timeSpan.Seconds}s";
					}
				}
			}
		}
	}
}