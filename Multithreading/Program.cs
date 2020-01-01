using Multithreading.BlockingQueue;
using Multithreading.DefferedAction;
using Multithreading.Semaphore;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //BlockingQueueTest test = new BlockingQueueTest();
            //test.TestBlockingQueue();
            
            TestDecrementSemaphore test = new TestDecrementSemaphore();

            test.DecrementCounter();

            Thread.Sleep(3000);

            test.IncrementCounter();

            //TokenBucketFilterTest t = new TokenBucketFilterTest();
            //t.FetchTokenFiltersInThread();

            //DefferedAct d = new DefferedAct();
            //d.TestAddAction();
            /* int[] a = { 1, 2 };
             int[] b = { 3, 4 };
             Solution s = new Solution();
             s.FindMedianSortedArrays(a, b);*/
        }
    }
}
