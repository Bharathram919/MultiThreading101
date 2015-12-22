using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPLCancellingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task<List<string>> taskWithFactoryAndState = Task.Factory.StartNew<List<string>>((stateObj) =>
            {
                System.Net.WebClient wc = new System.Net.WebClient();

                if(cancellationToken.IsCancellationRequested)
                {
                    wc.Dispose();
                    throw new OperationCanceledException(cancellationToken);
                }
                else
                {
                    string webContent = wc.DownloadString((string)stateObj);
                    return webContent.Split(new String[] { " ", "," }, Int16.MaxValue, StringSplitOptions.None).ToList();
                }
            }, "m.taptodeal.com", cancellationToken);
            Console.WriteLine("TaskCancelled? {0}", taskWithFactoryAndState.IsCanceled);
            cancellationTokenSource.Cancel();

            if(!taskWithFactoryAndState.IsCanceled && !taskWithFactoryAndState.IsFaulted)
            {
                try
                {
                    Console.WriteLine("{0}", taskWithFactoryAndState.Result.ToString());
                }
                catch (AggregateException ex)
                {
                    foreach(Exception e in ex.InnerExceptions)
                    {
                        Console.WriteLine("Exception Encountered : {0}", e.Message);
                    }
                }
                finally
                {
                    taskWithFactoryAndState.Dispose();
                }
            }
            else
            {
                Console.WriteLine("TaskCancelled> {0}", taskWithFactoryAndState.IsCanceled);
            }
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();
        }
    }
}
