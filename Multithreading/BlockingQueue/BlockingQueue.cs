using System;
using System.Collections.Generic;
using System.Text;

namespace Multithreading.BlockingQueue
{
    class BlockingQueue
    {
        private int[] Queue;
        private int MaxSize;
        private int Head;
        private int Tail;

        public BlockingQueue(int capacity)
        {
            this.MaxSize = capacity;
            this.Queue = new int[capacity];
            this.Head = -1;
            this.Tail = -1;
        }

        public bool Enqueue(int item)
        {
            if(++this.Head == this.Tail)
            {

            }
        }

        public int Dequeue()
        {
            return -1;
        }
    }
}
