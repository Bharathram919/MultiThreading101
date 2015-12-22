using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            StartCounting();
            Console.WriteLine("Press Any Key To Exit");
            Console.ReadKey();
            Console.WriteLine("Exiting...");
        }

        private static void StartCounting()
        {
            Thread th = new Thread(() =>
            {
                for(int i = 0; i<20;i++)
                {
                    Console.WriteLine("{0}...", i);
                    Thread.Sleep(400);
                }
            });

            //Use this to mark thread as background thread
            //The .NET framework would end the application as soon as main thread ends by stopping all background threads
            //th.IsBackground = true;
            th.Start();
        }
    }
}
