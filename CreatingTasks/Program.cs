using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<List<int>> taskWithInLineAction = new Task<List<int>>(() =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < 1000; i++)
                    ints.Add(i);
                return ints;
            });

            Task<string> taskWithInActualMethodAndState =
                new Task<string>(new Func<object, string>(PrintTaskObjectState), "TaskState");

            Task<List<int>> taskWithFactoryAndState = Task.Factory.StartNew<List<int>>((stateobj) =>
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < (int)stateobj; i++)
                    ints.Add(i);
                return ints;
            }, 2000);

            taskWithInActualMethodAndState.Start();
            taskWithInLineAction.Start();

            Task.WaitAll(new Task[] {
                taskWithInLineAction, taskWithFactoryAndState, taskWithInActualMethodAndState
            });

            var taskWithInLineActionResult = taskWithInLineAction.Result;
            var taskWithFactoryAndStateResult = taskWithFactoryAndState.Result;
            var taskWithInActualMethodAndStateResult = taskWithInActualMethodAndState.Result;

            Console.WriteLine(taskWithFactoryAndStateResult.Count + "|" + taskWithInLineActionResult.Count + "|" +
                taskWithInActualMethodAndStateResult.Count());
            Console.ReadLine();
        }

        private static string PrintTaskObjectState(object arg)
        {
            return "***WOWSERS***";
        }
    }
}
