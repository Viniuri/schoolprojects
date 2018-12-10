using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        /*Nell'esempio seguente viene dichiarato un delegato denominato 
        [Del] che può incapsulare un metodo che accetta una stringa come argomento e restituisce void*/
        public delegate void Del(string message);
        public delegate int Somma(int n, int n1);
        public delegate int sottrazione(int n, int n1);
        // Create a method for a delegate
        //Del
        public static void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }
        //Somma
        public static int DelegateSomma(int n, int n1)
        {
            return(n + n1);
        }
        public static  int DelegateSottr(int n,int n1)
        {
            return n - n1;
        }
        static void Main(string[] args)
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod;
            Somma sum = DelegateSomma;
            sottrazione Sottrazione = DelegateSottr;
            handler("Test");
            int ris = sum(1, 2);
            Message m = new Message();
            m.Print("Message sent");
            System.Console.ReadLine();
        }
        //Creo un metodo di tipo delegate;
        //Creo un metodo di qualsiasi tipo che corrisponde a quello sopra di tipo delegate;
        //Poi credo, come l'oggetto, un tipo delegate;
    }
}
