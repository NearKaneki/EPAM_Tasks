using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayEPAM
{
    public class CycledCustomArray<T>:CustomArray<T>, IEnumerable, IEnumerable<T>
    {
        public CycledCustomArray():base()
        {
            _array = new T[8];
            Count = 0;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledEnumeratorArray<T>(_array[0..Count]);
        }

        //что это и почему не наследуется
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CycledEnumeratorArray<T>(_array[0..Count]);
        }
    }
}
