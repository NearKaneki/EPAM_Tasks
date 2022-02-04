using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrayEPAM
{
    public class CycledCustomArray<T>:CustomArray<T>
    {
        public CycledCustomArray():base()
        {
            _array = new T[8];
            Count = 0;
        }
    }
}
