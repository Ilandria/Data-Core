using CCB.DataCore.Data.Variable;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			namespace Reference
			{
				[System.Serializable]
				public abstract class VariableReference<VariableType, ValueType> : VariableReferenceBase where VariableType : Variable<ValueType>
				{
					/// <summary>
					/// The Variable object that this is pointing to.
					/// </summary>
					[SerializeField]
					protected VariableType reference;

					/// <summary>
					/// Locally stored data.
					/// </summary>
					[SerializeField]
					protected ValueType value;

					public VariableReference(Object owner, VariableReferenceMode defaultMode) : base(owner, defaultMode)
					{
						value = default;
					}

					/// <summary>
					/// Sets the internal pointer. Does not allow retrieval in order to limit caching potential.
					/// </summary>
					public VariableType Reference
					{
						set
						{
							reference = value;
						}
					}

					/// <summary>
					/// The value currently stored in the referenced variable object or local data depending on current operation mode.
					/// </summary>
					public ValueType Value
					{
						get
						{
							ValueType result = default;

							if (mode == VariableReferenceMode.Reference)
							{
								if (reference != null)
								{
									result = reference.Value;
								}
								else
								{
									LogNullReference();
								}
							}
							else
							{
								result = value;
							}

							return result;
						}

						set
						{
							if (mode == VariableReferenceMode.Reference)
							{
								if (reference != null)
								{
									reference.Value = value;
								}
								else
								{
									LogNullReference();
								}
							}
							else
							{
								this.value = value;
							}
						}
					}
				}
			}
		}
	}
}