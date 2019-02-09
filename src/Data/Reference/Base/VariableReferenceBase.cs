using CCB.DataCore.Debugging;
using System;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			namespace Reference
			{
				[Serializable]
				public class VariableReferenceBase
				{
					/// <summary>
					/// If this VariableReference is currently referring to a Variable object or storing local data.
					/// </summary>
					[SerializeField]
					protected VariableReferenceMode mode = VariableReferenceMode.Reference;

					/// <summary>
					/// The UnityEngine.Object that owns this reference.
					/// </summary>
					protected UnityEngine.Object owner = null;

					/// <summary>
					/// Get which mode this VariableReference is currently operating in (pointer or data).
					/// </summary>
					public VariableReferenceMode Mode
					{
						get
						{
							return mode;
						}
					}

					/// <summary>
					/// Get the field name that this object is stored within in its owner.
					/// </summary>
					protected string OwnerFieldName
					{
						get
						{
							string fieldName = Debugging.Reflection.Utilities.GetFieldName(this, owner);

							if (string.IsNullOrWhiteSpace(fieldName))
							{
								ConsoleUtils.Warning($"The field for {GetType()} could not be found in \"{owner.name}\" ({owner.GetType()}). This is could make debugging a pain!");
							}

							return fieldName;
						}
					}

					private VariableReferenceBase()
					{

					}

					public VariableReferenceBase(UnityEngine.Object owner, VariableReferenceMode defaultMode)
					{
						if (owner == null)
						{
							ConsoleUtils.Error($"{GetType()} was not assigned an owner. This is could make debugging a pain!");
						}
						else
						{
							this.owner = owner;
						}

						mode = defaultMode;
					}

					/// <summary>
					/// Prints a reference is null message to the console log containing the object's
					/// identity for traceability.
					/// </summary>
					protected void LogNullReference()
					{
						string ownerType = owner.GetType().ToString();
						int lastDelimIndex = ownerType.LastIndexOf('.');

						ConsoleUtils.Warning($"{owner.name}'s {ownerType.Substring(lastDelimIndex + 1)}.{OwnerFieldName} is set to reference mode and reference is null!");
					}
				}
			}
		}
	}
}