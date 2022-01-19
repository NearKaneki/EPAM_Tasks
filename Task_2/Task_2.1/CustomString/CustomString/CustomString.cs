﻿namespace EpamString
{
    public class CustomString
    {
        private const int _defaultCapacity = 16;
        private char[] _charArray;
        private int _count;

        public int Count {get => _count; }
        
        public int Capacity { get => _charArray.Length; }

        public char[] CharArray { get => _charArray[0.._count]; }

        public char this[int index]
        {
            get
            {
                if (index <0)
                {
                    throw new ArgumentException("Index must be non negative");
                }
                if (index >= Count)
                {
                    throw new ArgumentException("Index is more than length string");
                }
                return _charArray[index];
            }

            set
            {
                if (index < 0)
                {
                    throw new ArgumentException("Index must be non negative");
                }
                if (index >= Count)
                {
                    throw new ArgumentException("Index is more than length string");
                }
                _charArray[index] = value;
            }
        }

        public CustomString(string startString,int startCapacity)
        {
            if (startCapacity < 0)
            {
                throw new ArgumentException("Capacity must be non negative");
            }
            if (startString.Length > startCapacity)
            {
                throw new ArgumentException("Capacity must be greater than or equal to string length");
            }
            if (startCapacity == 0)
            {
                startCapacity = _defaultCapacity;
            }
            _count = startString.Length;
            _charArray = new char[startCapacity];
            startString.ToArray().CopyTo(_charArray,0);
        }

        public CustomString():this(_defaultCapacity){}

        public CustomString(int startCapacity) : this(String.Empty, startCapacity) { }

        public CustomString(string startString) : this(startString, startString.Length) { }

        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < _count; i++)
            {
                temp += _charArray[i];
            }
            return temp;
        }

        public void Clear()
        {
            _count = 0;
            _charArray = new char[_defaultCapacity];
        }

        public void Append(char element)
        {
            isNeededCapacity(1);
            _charArray[_count] = element;
            ++_count;
        }
        public void Append(string input)
        {
            isNeededCapacity(input.Length);
            input.ToArray().CopyTo(_charArray, _count);
            _count+=input.Length;
        }

        public void Insert(char element,int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index must be non negative");
            }
            if (index == Count)
            {
                throw new ArgumentException("Use append");
            }
            if (index >= Count)
            {
                throw new ArgumentException("Index out of range");
            }
            isNeededCapacity(1);
            for (int i = _count; i > index ; i--)
            {
                _charArray[i] = _charArray[i - 1];
            }
            _charArray[index] = element;
            ++_count;
        }
        public void Insert(string input, int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index must be non negative");
            }
            if (index == Count)
            {
                throw new ArgumentException("Use append");
            }
            if (index > Count)
            {
                throw new ArgumentException("Index out of range");
            }
            isNeededCapacity(input.Length);
            //for (int i = _count+input.Length-1; i > index; i--)
            //{
            //    _charArray[i] = _charArray[i - input.Length];
            //}
            //input.ToArray().CopyTo(_charArray, index);
            char[] temp = new char[Capacity];
            _charArray[0..index].CopyTo(temp, 0);
            input.ToArray().CopyTo(temp, index);
            _charArray[index.._count].CopyTo(temp, index + input.Length);
            _charArray = temp;
            _count += input.Length;
        }

        public void Remove(int index,int length)
        {
            if (index < 0)
            {
                throw new ArgumentException("Index must be non negative");
            }
            if (index > Count)
            {
                throw new ArgumentException("Index out of range");
            }
            char[] temp = new char[Capacity];
            _charArray[0..index].CopyTo(temp, 0);
            int startPos = index + length;
            _charArray[startPos.._count].CopyTo(temp, index);
            _charArray = temp;
            _count -= length;
        }

        public int FindFirstString(string input)
        {
            char[] temp = input.ToArray();
            for (int i = 0; i <= _count - input.Length; i++)
            {
                int endSlice = i + input.Length;
                if (_charArray[i..endSlice].SequenceEqual(temp)) 
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindFirstChar(char input)
        {
            return(Array.FindIndex(_charArray,x=>x==input));
        }

        private int FindString(string input, ref int index)
        {
            char[] temp = input.ToArray();
            for (int i = index; i <= _count - input.Length; i++)
            {
                int endSlice = i + input.Length;
                if (_charArray[i..endSlice].SequenceEqual(temp))
                {
                    index = i;
                    return i;
                }
            }
            return -1;
        }

        public void Replace(string oldValue, string newValue)
        {
            if (oldValue == newValue)
            {
                throw new Exception("Arguments must not be equals");
            }
            int index = 0;
            while (FindString(oldValue,ref index)!=-1)
            {
                if (oldValue.Length < newValue.Length)
                {
                    isNeededCapacity(newValue.Length-oldValue.Length);
                }
                char[] temp = new char[Capacity];
                _charArray[0..index].CopyTo(temp, 0);
                newValue.ToArray().CopyTo(temp, index);
                int startPos = index + oldValue.Length;
                _charArray[startPos.._count].CopyTo(temp, index+newValue.Length);
                _charArray = temp;
                _count = _count - oldValue.Length + newValue.Length;
            }
        }

        private void isNeededCapacity(int length)
        {
            if (_count + length >Capacity)
            {
                Resize(_count+length-Capacity);
            }
        }
        
        private void Resize(int neededSpace)
        {
            int startCapacity = Capacity;
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
            Array.Resize(ref _charArray, Capacity + AddCapacity);
        }
        
        public bool Equal(CustomString obj)
        {
            return _charArray[0.._count].SequenceEqual(obj._charArray[0..obj._count]);
        }
    }
}