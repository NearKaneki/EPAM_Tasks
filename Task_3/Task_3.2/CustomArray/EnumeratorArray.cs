using System.Collections;

namespace CustomArrayEPAM
{
    public class EnumeratorArray<T> : IEnumerator<T>
    {
        protected T[] _array;
        protected int _pos = -1;

        public T Current => _array[_pos];

        object IEnumerator.Current => _array[_pos];

        public EnumeratorArray(T[] array)
        {
            _array = array;
        }

        public void Dispose()
        {
            _pos = -1;
        }

        public virtual bool MoveNext()
        {
            if (_pos != _array.Length-1)
            {
                ++_pos;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _pos = 0;
        }
    }
}
