#if UNITY_EDITOR

using CCB.DataCore.Component;
using UnityEditor;

namespace CCB
{
	namespace DataCore
	{
		namespace Editor
		{
			namespace Component
			{
				[CustomEditor(typeof(SimpleCalculator))]
				public class SimpleCalculatorEditor : UnityEditor.Editor
				{
					public override void OnInspectorGUI()
					{
						SimpleCalculator simpleCalculator = (SimpleCalculator)target;
					}
				}
			}
		}
	}
}

#endif