using System;
using System.Collections.Generic;
using System.Text;
using CommonTypes;

namespace LibStructures
{
    [ExecuteClass("Очередь")]
    struct StructQueue
    {
        double[] queue;
        int queueSize;
        int head;
        int tail;

        public StructQueue(int size)
        {
            this.queue = new double[size];
            this.queueSize = size;
            this.head = 0;
            this.tail = 0;
        }

        public void Enqueue(double element)
        {
            if ((this.head == this.tail + 1) || (this.head == 0 && this.tail == this.queue.Length))
            {
                //this.tail = 0;
                throw new ArgumentException("Queue is full");
            }
            else
            {
                this.queue[tail] = element;
                if (this.tail == this.queueSize)
                {
                    this.tail = 0;
                }
                else
                {
                    this.tail += 1;
                }
            }
        }

        public double Dequeue()
        {
            if (this.head == this.tail)
            {
                this.head = 0;
                this.tail = 0;
                throw new ArgumentException("Queue is empty");
            }
            else
            {
                double res = this.queue[head];
                if (this.head == this.queueSize)
                {
                    this.head = 0;
                }
                else
                {
                    this.head += 1;
                }
                return res;
            } 
        }
        
        public int GetSize
        {
            get { return this.tail; }
        }

        public double[] GetStruct
        {
            get 
            {
                double[] q = new double[tail - head];
                int j = 0;
                for (int i = head; i < tail; i++)
                {
                    q[j] = this.queue[i];
                    j++;
                }
                return q; 
            }
        }                
    }
}
