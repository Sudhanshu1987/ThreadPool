using Multithreading.BlockingQueue;
using Multithreading.Semaphore;
using System;
using System.Runtime.InteropServices;


namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //BlockingQueueTest test = new BlockingQueueTest();
            //test.TestBlockingQueue();
            /*TestDecrementSemaphore test = new TestDecrementSemaphore();
            for(int i = 0; i < 25; i++)
            {
                test.Decrement();
            } */

            TokenBucketFilterTest t = new TokenBucketFilterTest();
            t.FetchTokenFiltersInThread();
        }
    }
}
