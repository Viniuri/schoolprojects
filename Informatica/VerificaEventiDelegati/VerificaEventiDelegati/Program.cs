using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaEventiDelegati
{
    class Program
    {
        //Eventi
        public void EventName(object sender, EventArgs e)
        {

        }
        //
        private delegate int Somma(int n1, int n2);
        private static int DelegateSomma(int n1, int n2)
        {
            return n1 + n2;
        }
        static void Main(string[] args)
        {
            int ris, n1, n2;
            Somma somma = DelegateSomma;
            ///ripristina
            Console.WriteLine("Digiti il primo numero");
            n1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digiti il secondo numero");
            n2 = int.Parse(Console.ReadLine());
            ris = somma(n1, n2);
            Console.WriteLine(ris);
            Console.ReadLine();
        }
    }
}
