using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multithreading.Semaphore
{
    public class TestDecrementSemaphore
    {
        //SemaphoreSlim sem = new SemaphoreSlim(3, 3);
        SemaphoreSlim1 sem = new SemaphoreSlim1(3, 3);
        int i = 20;
        public void Decrement() 
        {
            sem.Wait();
            Console.WriteLine("Decrement" + sem.CurrentCount);
            i--;
        }

        public void Increment()
        {
            sem.Release();
            Console.WriteLine("Increment" + sem.CurrentCount);
            i++;
        }

        public void IncrementCounter()
        {
            var threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Increment);
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i].Start();
            }
        }

        public void DecrementCounter()
        {
            var threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(Decrement);
            }

            for(int i = 0; i < 5; i++)
            {
                threads[i].Start();
            }
        }
    }
}
