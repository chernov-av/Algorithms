using System;
using System.Collections.Generic;
using System.Text;
using CommonTypes;

namespace LibStructures
{
    struct StructDeque
    {
        double[] deque;
        int dequeSize;

        public void PushRight(double element)
        {
            this.dequeSize += 1;
            ResizeRight();
            this.deque[this.dequeSize - 1] = element;
        }

        public void PushLeft(double element)
        {
            this.dequeSize += 1;
            ResizeLeftPush();
            this.deque[0] = element;
        }

        public double PopRight()
        {
            if (DequeIsEmpty())
            {
                throw new System.ArgumentException("Deque is empty");
            }
            else
            {
                this.dequeSize -= 1;
                double res = this.deque[this.dequeSize];
                ResizeRight();
                return res;
            }
        }

        public double PopLeft()
        {
            if (DequeIsEmpty())
            {
                throw new System.ArgumentException("Deque is empty");
            }
            else
            {
                this.dequeSize -= 1;
                double res = this.deque[0];
                ResizeLeftPop();
                return res;
            }
        }

        public bool DequeIsEmpty()
        {
            if (this.dequeSize == 0) { return true; } else { return false; }
        }

        public int GetSize
        {
            get { return this.dequeSize; }
        }

        public double[] GetStruct
        {
            get { return this.deque; }
        }

        private void ResizeRight()
        {
            double[] tempStack = new double[this.dequeSize];
            if (this.deque != null)
            {
                for (int i = 0; i < Math.Min(tempStack.Length, deque.Length); i++)
                {
                    tempStack[i] = this.deque[i];
                }
            }
            this.deque = tempStack;
        }
        private void ResizeLeftPush()
        {
            double[] tempStack = new double[this.dequeSize];
            if (this.deque != null)
            {
                for (int i = 1; i <= Math.Min(tempStack.Length, deque.Length); i++)
                {
                    tempStack[i] = this.deque[i - 1];
                }
            }
            this.deque = tempStack;
        }

        private void ResizeLeftPop()
        {
            double[] tempStack = new double[this.dequeSize];
            if (this.deque != null)
            {
                for (int i = 0; i <= Math.Min(tempStack.Length, deque.Length) - 1; i++)
                {
                    tempStack[i] = this.deque[i + 1];
                }
            }
            this.deque = tempStack;
        }
    }
}
