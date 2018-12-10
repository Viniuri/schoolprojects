using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Class1
    {
        private delegate int sommaDueNumeri(int n1, int n2);
        private int Somma(int n1, int n2)
        {
            int n;
            n = n1 + n2;
            return n;
        }
    }
}
