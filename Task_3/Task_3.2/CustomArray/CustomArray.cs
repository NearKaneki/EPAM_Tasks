using System.Collections;

namespace CustomArrayEPAM
{
    public class CustomArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        protected T[] _array;
        public int Count { get; protected set; }

        public int Capacity
        {
            get => _array.Count();
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value must be positive");
                }
                Array.Resize(ref _array, value);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count || index <= -Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (index < 0)
                {
                    return _array[Count + index];
                }
                return _array[index];
            }
            set
            {
                if (index >= Count || index <= -Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (index < 0)
                {
                    _array[Count + index] = value;
                    return;
                }
                _array[index] = value;
            }
        }

        public CustomArray()
        {
            _array = new T[8];
            Count = 0;
        }

        public CustomArray(int capacity)
        {
            _array = new T[capacity];
            Count = 0;
        }

        public CustomArray(IEnumerable<T> initArray)
        {
            _array = new T[initArray.Count()];
            int count = 0;
            foreach (var item in initArray)
            {
                _array[count] = item;
                ++count;
            }
            Count = _array.Count();
        }

        public void Add(T item)
        {
            if (isNeededCapacity(1))
            {
                Resize(Count + 1 - _array.Count());
            };
            _array[Count] = item;
            ++Count;
        }

        public void AddRange(IEnumerable<T> addArray)
        {
            if (isNeededCapacity(addArray.Count()))
            {
                Resize(Count + addArray.Count() - _array.Count());
            };
            _array.Concat(addArray);
            Count += addArray.Count();
        }

        public void Insert(T item, int ind)
        {
            if (ind > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (ind < 0)
            {
                throw new ArgumentException("Index must be positiv");
            }
            if (isNeededCapacity(1))
            {
                Resize(Count + 1 - _array.Count());
            };
            _array[ind] = item;
            ++Count;
        }

        private bool isNeededCapacity(int length)
        {
            if (Count + length > _array.Count())
            {
                return true;
            }
            return false;
        }

        private void Resize(int neededSpace)
        {
            int startCapacity = _array.Count();
            int tempCapacity = startCapacity;
            int countProd = 0;
            while (tempCapacity < neededSpace)
            {
                neededSpace -= tempCapacity;
                tempCapacity *= 2;
                ++countProd;
            }
            int AddCapacity = startCapacity;
            for (int i = 1; i <= countProd; i++)
            {
                startCapacity *= 2;
                AddCapacity += startCapacity;
            }
            Array.Resize(ref _array, _array.Count() + AddCapacity);
        }

        public bool Remove(T item)
        {
            int ind = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    ind = i;
                    break;
                }
            }
            if (ind == -1)
            {
                return false;
            }
            for (int i = ind; i < Count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }
            --Count;
            return true;
        }

        public T[] ToArray()
        {
            return _array[0..Count];
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorArray<T>(_array[0..Count]);
        }

        IEnumerator  IEnumerable.GetEnumerator()
        {
            return new EnumeratorArray<T>(_array[0..Count]);
        }

        public object Clone()
        {
            return _array;
        }
    }
}