using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multithreading.Semaphore
{
    public class SemaphoreSlim1
    {
        private int initialValue;
        private int maximumValue;

        private object _lock;

        public SemaphoreSlim1(int inital, int max)
        {
            this.initialValue = inital;
            this.maximumValue = max;
            _lock = new object();
        }

        public int CurrentCount { get => initialValue; set => initialValue = value; }
        public int MaximumValue { get => maximumValue; set => maximumValue = value; }

        public void Wait()
        {
            lock (_lock)
            {
                while(initialValue == 0)
                {
                    Monitor.Wait(_lock);
                }
                this.initialValue--;

                Monitor.PulseAll(_lock);
            }
        }

        public void Release()
        {
            lock (_lock)
            {
                if(initialValue == this.maximumValue)
                {
                    throw new SemaphoreFullException();
                }
                else
                {
                    this.initialValue++;
                    Monitor.PulseAll(_lock);
                }
            }
        }
    }
}
