using System;
using System.Collections.Generic;
using System.Text;
using CommonTypes;

namespace LibStructures
{
    [ExecuteClass("Стек")]
    struct StructStack
    {
        double[] stack;
        int stackSize;

        public void Push(double element)
        {
            this.stackSize += 1;
            Resize();
            this.stack[this.stackSize - 1] = element;
        }

        public double Pop()
        {
            if (StackIsEmpty())
            {
                throw new System.ArgumentException("Stack is empty");
            }
            else
            {
                this.stackSize -= 1;
                double res = this.stack[this.stackSize];
                Resize();
                return res;
            }
        }

        public bool StackIsEmpty()
        {
            if (this.stackSize == 0) { return true; } else { return false; }
        }
        
        public int GetSize
        {
            get { return this.stackSize; }
        }

        public double[] GetStruct
        {
            get { return this.stack; }
        }

        private void Resize()
        {
            double[] tempStack = new double[this.stackSize];
            if (this.stack!=null)
            {
                for (int i = 0; i < Math.Min(tempStack.Length,stack.Length); i++)
                {
                    tempStack[i] = this.stack[i];
                }
            }
            this.stack = tempStack;
        }
    }
}
