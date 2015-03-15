using System;
using System.Linq;

namespace Generic
{
    public class GenericList<T>
    {
        private T[] arr;
        public int Size
        {
            get;
            private set;
        }
        public int Capacity
        {
            get
            {
                return this.arr.Length;
            }
        }

        public GenericList(int capacity)
        {
            this.arr = new T[capacity];
            this.Size = 0;
        }

        public void Add(T element)
        {
            this.Insert(this.Size, element);
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.arr[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.arr[index] = value;
            }
        }

        public void Remove(int index)
        {
            this.ValidateIndex(index);
            for (int i = index; i < this.Size - 1; i++)
            {
                this.arr[i] = this.arr[i + 1];
            }
            this.Size--;
        }

        public void Insert(int index, T element)
        {
            if (this.Size == this.Capacity)
            {
                this.Resize();
            }
            this.Size++;
            this.ValidateIndex(index);
            for (int i = this.Size - 1; i > index; i--)
            {
                this.arr[i] = this.arr[i - 1];
            }
            this.arr[index] = element;
        }

        public void Clear()
        {
            this.Size = 0;
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.arr, element);
        }

        public override string ToString()
        {
            return String.Join(" ", this.arr.Select(x => x.ToString()).ToArray(), 0, this.Size);
        }

        public T Min<V>() where V : IComparable<T>
        {
            return this.arr.Take(this.Size).Min();
        }
        public T Max<V>() where V : IComparable<T>
        {
            return this.arr.Take(this.Size).Max();
        }

        private void Resize()
        {
            Array.Resize(ref this.arr, this.Capacity * 2);
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new ArgumentException("Invalid index.");
            }
        }
    }
}

