using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsVsTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            int maxWaitHandleWaitAllAllowed = 64;
            ManualResetEventSlim[] mres = new ManualResetEventSlim[maxWaitHandleWaitAllAllowed];
            for (int i = 0; i < mres.Length; i++)
            {
                mres[i] = new ManualResetEventSlim();
            }
            long threadTime = 0;
            long taskTime = 0;

            watch.Start();
            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;
                Thread th = new Thread((state) =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine("Thread:{0}, Output:{1}", state.ToString(), j.ToString());
                    }
                    mres[idx].Set();
                });
                th.Start(i);
            }
            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            threadTime = watch.ElapsedMilliseconds;

            watch.Reset();
            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }

            watch.Start();
            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;
                Task task = Task.Factory.StartNew((state) =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine("Thread:{0}, Output:{1}", state.ToString(), j.ToString());
                    }
                    mres[idx].Set();
                }, i);
            }
            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            taskTime = watch.ElapsedMilliseconds;

            Console.WriteLine("Thread Time waited : {0}ms", threadTime);
            Console.WriteLine("Task Time waited : {0}ms", taskTime);

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }
            Console.WriteLine("All done, press Enter to Quit");
            Console.ReadLine();
        }
    }
}
