using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class TokenBucketFilter
    {
        private int N;
        private long InitialTimeStampinSeconds;
        private Object _object;

        public TokenBucketFilter(int N)
        {
            this.N = N;
            this.InitialTimeStampinSeconds = DateTimeOffset.Now.ToUnixTimeSeconds();
            this._object = new Object();
        }

        public void GetToken(int i)
        {
            lock (_object)
            {
                var currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();

                while(currentTime - InitialTimeStampinSeconds < 1)
                {
                    Task.Delay(1000);
                    currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();
                }

                if(currentTime - InitialTimeStampinSeconds > N)
                {
                    InitialTimeStampinSeconds = currentTime - N;
                }

                Console.WriteLine("Get Token : Thread : " + Thread.CurrentThread.ManagedThreadId + " : Seconds : " + DateTimeOffset.Now.ToUnixTimeSeconds());
                InitialTimeStampinSeconds++;
            }
        }
    }

    public class TokenBucketFilterTest
    {
        private TokenBucketFilter t = new TokenBucketFilter(10000);
        public void TestTokenBucketFilter(int i)
        {
            t.GetToken(i);
        }
        
        public void FetchTokenFiltersInThread()
        {
            var tasks = new Task[100];
            Action<int> a = TestTokenBucketFilter;

            Thread.Sleep(100000);

            for (int i = 0; i < 100; i++)
            {
                tasks[i] = Task.Run(() => {
                    a(i);
                    Task.Delay(100);
                    Task.Yield();
                    });           
            }

            Task.WaitAll(tasks);
        }
    }
}