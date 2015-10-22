using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace EjemploWaitAll
{
    

    class WaitAllDemo
    {
        // Demonstrated features:
        // 		Task.Factory
        //		Task.Result
        //		Exception handling
        // Expected results:
        // 		10 tasks are started, each passed an index as a state object.
        //		The tasks that receive an argument between 2 and 5 throw exceptions.
        //		Task.WaitAll() wraps all exceptions in an AggregateException and propagates it to the main thread.
        // Documentation:
        //		http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskfactory_members(VS.100).aspx
        static void Main()
        {
            // Define a delegate that prints and returns the system tick count
            Func<object, int> action = (object obj) =>
            {
                int i = (int)obj;

                // Make each thread sleep a different time in order to return a different tick count
                Thread.Sleep(i * 100);

                // The tasks that receive an argument between 2 and 5 throw exceptions
                if (2 <= i && i <= 5)
                {
                    //throw new InvalidOperationException("SIMULATED EXCEPTION");
                }

                int tickCount = Environment.TickCount;
                Console.WriteLine("Task={0}, i={1}, TickCount={2}, Thread={3}", Task.CurrentId, i, tickCount, Thread.CurrentThread.ManagedThreadId);

                return tickCount;
            };

            const int n = 10;

            // Construct started tasks
            Task<int>[] tasks = new Task<int>[n];
            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task<int>.Factory.StartNew(action, i);
            }

            // Exceptions thrown by tasks will be propagated to the main thread
            // while it waits for the tasks. The actual exceptions will be wrapped in AggregateException.
            try
            {
                // Wait for all the tasks to finish.
                Task.WaitAll(tasks);

                // We should never get to this point
                Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }

            Console.ReadKey();
        }

    }
}
