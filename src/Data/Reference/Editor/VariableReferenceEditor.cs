#if UNITY_EDITOR

using CCB.DataCore.Data.Reference;
using UnityEditor;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Editor
		{
			namespace Data
			{
				[CustomPropertyDrawer(typeof(VariableReferenceBase), true)]
				public class VariableReferenceEditor : PropertyDrawer
				{
					public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
					{
						VariableReferenceBase variableReference = (VariableReferenceBase)fieldInfo.GetValue(property.serializedObject.targetObject);

						float height = base.GetPropertyHeight(property, label);

						if (variableReference.Mode == VariableReferenceMode.Value)
						{
							height = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("value"));
						}

						return height;
					}

					public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
					{
						VariableReferenceBase variableReference = (VariableReferenceBase)fieldInfo.GetValue(property.serializedObject.targetObject);
						string mode = variableReference.Mode == VariableReferenceMode.Reference ? "reference" : "value";

						EditorGUI.BeginProperty(position, label, property);

						EditorGUI.LabelField(new Rect(position.x, position.y, 100, position.height), property.displayName);
						EditorGUI.PropertyField(new Rect(position.x + position.width - position.width * 0.55f - 30, position.y, 70, position.height), property.FindPropertyRelative("mode"), GUIContent.none);

						float start = position.x + position.width - position.width * 0.55f + 45;
						EditorGUI.PropertyField(new Rect(start, position.y, position.width - start + 14, position.height), property.FindPropertyRelative(mode), GUIContent.none);

						EditorGUI.EndProperty();
					}
				}
			}
		}
	}
}

#endif