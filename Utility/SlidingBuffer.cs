using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DebugAdapterProtocol.Utility
{
    public class SlidingBuffer<T>
    {
        public const int DefaultCapability = 4096;
        private T[] buffer;
        private int length = 0;

        public SlidingBuffer()
        {
            buffer = new T[DefaultCapability];
        }

        public SlidingBuffer(int capability)
        {
            buffer = new T[capability];
        }

        public int Length { get => length; }

        public void Append(T[] data, int count)
        {
            if (length + count > buffer.Length)
            {
                int newSize = Math.Max(length + count, (int)(buffer.Length * 1.5));
                T[] newBuffer = new T[newSize];
                Array.Copy(buffer, 0, newBuffer, 0, length);
                buffer = newBuffer;
            }
            for (int i = 0; i < count; i++)
            {
                buffer[length + i] = data[i];
            }
            length += count;
        }

        public T[] RemoveFirst(int count)
        {
            T[] removed = new T[count];
            Array.Copy(buffer, 0, removed, 0, count);
            Array.Copy(buffer, count, buffer, 0, length - count);
            length -= count;
            return removed;
        }

        public ReadOnlySpan<T> AsSpan()
        {
            return buffer.AsSpan(0, length);
        }

    }
}
