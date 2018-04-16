using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyThreadPool
{
    public delegate void WaitCallBack(object state);

    class ThreadPool
    {
        private int poolSize;

        public ThreadPool(int poolSize)
        {
            this.poolSize = poolSize;
        }

        private int PoolSize => this.poolSize;

        public bool QueueUserWorkItem(WaitCallBack waitCallBack, object param)
        {
            throw new NotImplementedException();
        }

        public void SetPoolSize(int size)
        {
            this.poolSize = size;
        }
    }
}
