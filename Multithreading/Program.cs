using Multithreading.BlockingQueue;
using System;
using System.Runtime.InteropServices;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingQueueTest test = new BlockingQueueTest();
            test.TestBlockingQueue();
        }
    }
}
