#if UNITY_EDITOR

using CCB.DataCore.Component;
using CCB.DataCore.Data.Enum;
using CCB.DataCore.Data.Reference;
using CCB.DataCore.Data.Variable;
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
					SerializedProperty numInputsProperty;
					SerializedProperty operatorsProperty;
					SerializedProperty inputsProperty;
					SerializedProperty resultProperty;

					public void OnEnable()
					{
						numInputsProperty = serializedObject.FindProperty("numberOfInputs");
						operatorsProperty = serializedObject.FindProperty("operators");
						inputsProperty = serializedObject.FindProperty("inputs");
						resultProperty = serializedObject.FindProperty("result");
					}

					public override void OnInspectorGUI()
					{
						IntVariableReference numElementsReference = numInputsProperty.GetValue<IntVariableReference>();

						// Show the number of elements and see if it was changed.
						EditorGUI.BeginChangeCheck();
						EditorGUILayout.PropertyField(numInputsProperty);
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
							if (i < operatorsProperty.arraySize && i < inputsProperty.arraySize)
							{
								EditorGUILayout.BeginHorizontal();

								EditorGUILayout.PropertyField(operatorsProperty.GetArrayElementAtIndex(i));
								EditorGUILayout.PropertyField(inputsProperty.GetArrayElementAtIndex(i), GUIContent.none);

								EditorGUILayout.EndHorizontal();
							}
						}

						// Show the result output field.
						EditorGUILayout.PropertyField(resultProperty);

						// Apply the final changes with an undo available.
						serializedObject.ApplyModifiedProperties();
					}

					private void RecreateArrays(int numElements)
					{
						// Update the operators list.
						List<ArithmeticOperator> newOperators = new List<ArithmeticOperator>();
						ArithmeticOperator[] oldOperators = operatorsProperty.GetValue<ArithmeticOperator[]>();

						foreach (ArithmeticOperator op in oldOperators)
						{
							if (newOperators.Count < oldOperators.Length)
							{
								newOperators.Add(op);
							}
						}

						for (int i = newOperators.Count; i < numElements; i++)
						{
							newOperators.Add(ArithmeticOperator.Add);
						}

						operatorsProperty.SetValue(newOperators.ToArray());

						// Update the elements list.
						List<VariableBase> newElements = new List<VariableBase>();
						VariableBase[] oldElements = inputsProperty.GetValue<VariableBase[]>();

						foreach (VariableBase element in oldElements)
						{
							if (newElements.Count < oldElements.Length)
							{
								newElements.Add(element);
							}
						}

						for (int i = newElements.Count; i < numElements; i++)
						{
							newElements.Add(null);
						}

						inputsProperty.SetValue(newElements.ToArray());

						// Apply the changes - no undo since we're partway through an update.
						serializedObject.ApplyModifiedPropertiesWithoutUndo();
					}
				}
			}
		}
	}
}

#endif