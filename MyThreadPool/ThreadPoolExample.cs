using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThreadPool
{
    class ThreadPoolExample
    {
        private void RunThreadPoolExample()
        {
            ThreadPool thPool = new ThreadPool(5);

            for(int i = 0; i < 100; i++)
            {                
                thPool.QueueUserWorkItem(new WaitCallBack(ThreadProc), i);
            }
        }

        public void ThreadProc(object i)
        {
            Console.WriteLine("The value printed is:" + i);
            Thread.Sleep(1000);
        }
    }
}
