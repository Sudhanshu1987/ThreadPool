using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multithreading.BlockingQueue
{
    class BlockingQueueTest
    {
        private BlockingQueue BlockingQueue = new BlockingQueue(10);

        private void Producer(object j)
        {
            for (int i = 0; i < 10; i++)
            {
                this.BlockingQueue.Enqueue((int)i);
                Console.WriteLine("Enqueued from " + j + " Value:" + i);
                Thread.Sleep(3000);
            }
        }

        public void Consumer(object j)
        {
            for(int i= 0; i < 15; i++)
            {
                Console.WriteLine("Dequeued from " + j + " Value:" + this.BlockingQueue.Dequeue());
                Thread.Sleep(1000);
            } 
        }

        public void TestBlockingQueue()
        {
            var x = new BlockingQueueTest();
            //ParameterizedThreadStart threadStart = new ParameterizedThreadStart(x.Producer);
            Thread producer1 = new Thread(x.Producer);
            producer1.Start(1);

            //ParameterizedThreadStart threadStart1 = new ParameterizedThreadStart(x.Producer);
            //Thread producer2 = new Thread(threadStart1);
            //producer2.Start(2);

            Thread.Sleep(10000);
            //ParameterizedThreadStart threadStart2 = new ParameterizedThreadStart(x.Consumer);
            Thread consumer1 = new Thread(x.Consumer);
            consumer1.Start(3);
        }
    }
}
