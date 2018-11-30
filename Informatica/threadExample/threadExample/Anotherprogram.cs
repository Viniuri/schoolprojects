using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace threadExample
{
    class Anotherprogram
    {
        public static void Main()
        {
            var threads = new Thread[] {
    new Thread(() =>
    {
        for (int x = 0; x < 10000; x++)
        {
            Console.WriteLine("First :" + x);
        }
    }),
    new Thread(() =>
    {
        for (int x = 0; x < 10000; x++)
        {
            Console.WriteLine("Second :" + x);
        }
    })
};

            // start the threads
            foreach (var t in threads)
                t.Start();

            // block the initial thread until the new threads are finished
            foreach (var t in threads)
                t.Join();

            // Now the following line won't execute until both threads are done
            Console.ReadKey();
        }
    }
}
