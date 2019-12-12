using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Multithreading.BlockingQueue
{
    class BlockingQueue
    {
        private int[] Queue;
        private int MaxSize;
        private int Head;
        private int Tail;
        private int CurrentSize;
        private Object _lock;

        public BlockingQueue(int capacity)
        {
            this.MaxSize = capacity;
            this.Queue = new int[capacity];
            this.Head = -1;
            this.Tail = -1;
            this.CurrentSize = 0;
            this._lock = new Object();
        }

        public void Enqueue(int item)
        {
            lock (this._lock)
            {
                while (this.CurrentSize == this.MaxSize)
                {
                    Monitor.Wait(_lock);
                }

                if (this.Head == -1 && this.Tail == -1)
                {
                    this.Head = 0;
                    this.Tail = 0;
                }
                else if (this.Tail == this.MaxSize - 1)
                {
                    this.Tail = 0;
                }
                else
                {
                    this.Tail++;
                }

                this.CurrentSize++;

                this.Queue[this.Tail] = item;

                Monitor.PulseAll(this._lock);
            }
        }
        public int Dequeue()
        {
            int itemDequeued;
            lock (this._lock)
            {
                while (this.CurrentSize == 0)
                {
                    Monitor.Wait(this._lock);
                }

                itemDequeued = this.Queue[this.Head];

                if (this.Head == this.MaxSize - 1)
                {
                    this.Head = 0;
                }
                else
                {
                    this.Head++;
                }

                this.CurrentSize--;

                Monitor.PulseAll(this._lock);
            }

            return itemDequeued;
        }
    }
}