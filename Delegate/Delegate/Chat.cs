using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Message
    {
        public Message() { }
        public delegate void Stampa(string message);
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
