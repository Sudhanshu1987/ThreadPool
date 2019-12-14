using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multithreading.Semaphore
{
    public class TestDecrementSemaphore
    {
        SemaphoreSlim sem = new SemaphoreSlim(20, 20);
        int i = 20;
        public void Decrement() 
        {
            Console.WriteLine(i);
            sem.Wait();
            i--;
        }
    }
}
