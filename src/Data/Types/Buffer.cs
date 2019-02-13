using System.Collections.Generic;
using UnityEngine;

namespace CCB
{
	namespace DataCore
	{
		namespace Data
		{
			[System.Serializable]
			public class Buffer<T>
			{
				[SerializeField]
				private int maxBufferSize = 1;

				private Queue<T> buffer = new Queue<T>();

				public int MaxBufferSize
				{
					get
					{
						return maxBufferSize;
					}
				}

				public T[] BufferedValues
				{
					get
					{
						return buffer.ToArray();
					}
				}

				public Buffer(int maxBufferSize)
				{
					this.maxBufferSize = maxBufferSize;
					buffer = new Queue<T>();
				}

				/// <summary>
				/// Adds a value to the buffer and removes + returns the oldest one if the buffer was full.
				/// </summary>
				public T AddToBuffer(T value)
				{
					T oldestElement = default;

					buffer.Enqueue(value);

					if (buffer.Count > maxBufferSize)
					{
						oldestElement = buffer.Dequeue();
					}

					return oldestElement;
				}

				/// <summary>
				/// Pops the oldest element out of the buffer and returns it.
				/// </summary>
				public T GetOldest()
				{
					T oldestElement = default;

					if (buffer.Count > 1)
					{
						oldestElement = buffer.Dequeue();
					}

					return oldestElement;
				}

				public override string ToString()
				{
					return $"(Max: {maxBufferSize}, Current: {buffer.Count})";
				}
			}
		}
	}
}