namespace CustomArrayEPAM
{
    public class CycledEnumeratorArray<T> : EnumeratorArray<T>, IEnumerator<T>
    {
        public CycledEnumeratorArray(T[] array) : base(array) { }

        public override bool MoveNext()
        {
            if (_pos != _array.Length - 1)
            {
                ++_pos;
                return true;
            }
            _pos = 0;
            return true;
        }
    }
}
