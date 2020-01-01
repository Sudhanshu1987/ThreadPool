using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading.DefferedAction
{
    public class DefferedAct
    {

        public Task AddAction(Action a, int delay)
        {
            var taskCompletionSource = new TaskCompletionSource<Object>();
            var task = Task.Delay(delay);
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(a);
            Console.WriteLine("ThreadId: ok" + Thread.CurrentThread.ManagedThreadId);
            taskCompletionSource.SetResult(null);
            return taskCompletionSource.Task;
        }

        public Task AddAction1(Action a , int delay)
        {
            var taskCompletionSource = new TaskCompletionSource<Object>();
            var task = Task.Delay(delay);
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(a);
            Console.WriteLine("ThreadId: ok" + Thread.CurrentThread.ManagedThreadId);
            taskCompletionSource.SetResult(null);
            return taskCompletionSource.Task;
        }

        public void TestAddAction()
        {
            var tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                tasks[i] = Task.Run(() => AddAction1(() => Console.WriteLine("ThreadId:" + Thread.CurrentThread.ManagedThreadId), 3000).Wait());
            }

            Task.WaitAll(tasks);

            Console.ReadLine();

        }
    }
}
