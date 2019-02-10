#if UNITY_EDITOR

using CCB.DataCore.Component;
using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
using Supyrb;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
					SerializedProperty numElementsProperty;
					SerializedProperty operatorsProperty;
					SerializedProperty elementsProperty;

					public void OnEnable()
					{
						numElementsProperty = serializedObject.FindProperty("numElements");
						operatorsProperty = serializedObject.FindProperty("operators");
						elementsProperty = serializedObject.FindProperty("elements");
					}

					public override void OnInspectorGUI()
					{
						IntVariableReference numElementsReference = numElementsProperty.GetValue<IntVariableReference>();

						// Show the number of elements and see if it was changed.
						EditorGUI.BeginChangeCheck();
						EditorGUILayout.PropertyField(numElementsProperty);
						bool numElementsWasChanged = EditorGUI.EndChangeCheck();

						// Apply the changes.
						serializedObject.ApplyModifiedPropertiesWithoutUndo();

						// If the number of elements was changed, recreate the data arrays.
						int numElements = numElementsReference.Value;
						if (numElementsWasChanged)
						{
							RecreateArrays(numElements);
						}

						// Show each of the elements of the arrays for editing.
						for (int i = 0; i < numElements; i++)
						{
							if (i < operatorsProperty.arraySize && i < elementsProperty.arraySize)
							{
								EditorGUILayout.BeginHorizontal();

								EditorGUILayout.PropertyField(operatorsProperty.GetArrayElementAtIndex(i));
								EditorGUILayout.PropertyField(elementsProperty.GetArrayElementAtIndex(i));

								EditorGUILayout.EndHorizontal();
							}
						}

						// Apply the final changes with an undo available.
						serializedObject.ApplyModifiedProperties();
					}

					private void RecreateArrays(int numElements)
					{
						// Update the operators list.
						List<ArithmeticOperators> newOperators = new List<ArithmeticOperators>();
						ArithmeticOperators[] oldOperators = operatorsProperty.GetValue<ArithmeticOperators[]>();

						foreach (ArithmeticOperators op in oldOperators)
						{
							if (newOperators.Count < oldOperators.Length)
							{
								newOperators.Add(op);
							}
						}

						for (int i = newOperators.Count; i < numElements; i++)
						{
							newOperators.Add(ArithmeticOperators.Add);
						}

						operatorsProperty.SetValue(newOperators.ToArray());

						// Update the elements list.
						List<VariableReferenceBase> newElements = new List<VariableReferenceBase>();
						VariableReferenceBase[] oldElements = elementsProperty.GetValue<VariableReferenceBase[]>();

						foreach (VariableReferenceBase element in oldElements)
						{
							if (newElements.Count < oldElements.Length)
							{
								newElements.Add(element);
							}
						}

						for (int i = newElements.Count; i < numElements; i++)
						{
							newElements.Add(CreateInstance<FloatVariableReference>());
						}

						elementsProperty.SetValue(newElements.ToArray());

						// Apply the changes - no undo since we're partway through an update.
						serializedObject.ApplyModifiedPropertiesWithoutUndo();
					}
				}
			}
		}
	}
}

#endif