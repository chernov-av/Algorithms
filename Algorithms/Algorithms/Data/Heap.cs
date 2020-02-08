using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data
{
    class Heap
    {
        double[] A;
        int heapSize;

        public Heap(double[] A)
        {
            this.A = A;
        }
        
        public void MaxHeapify(int i)
        {
            int l = this.Left(i);
            int r = this.Right(i);
            int largest;

            if ((l<this.heapSize) && (this.A[l] > this.A[i]))
            {
                largest = l;
            }
            else
            {
                largest = i;
            }

            if ((r < this.heapSize) && (this.A[r] > this.A[largest]))
            {
                largest = r;
            }
            
            if (largest != i)
            {
                this.Swap(i, largest);                
                MaxHeapify(largest);
            }
        }

        public void BuildMaxHeap()
        {
            this.heapSize = this.A.Length;
            for (int i = (this.A.Length-1)/2; i >= 0; i--)
            {
                this.MaxHeapify(i);
            }
        }

        public void MinHeapify(int i)
        {
            int l = this.Left(i);
            int r = this.Right(i);
            int smallest;

            if ((l < this.heapSize) && (this.A[l] < this.A[i]))
            {
                smallest = l;
            }
            else
            {
                smallest = i;
            }

            if ((r < this.heapSize) && (this.A[r] < this.A[smallest]))
            {
                smallest = r;
            }

            if (smallest != i)
            {
                this.Swap(i, smallest);                
                this.MinHeapify(smallest);
            }
        }

        public void BuildMinHeap()
        {
            this.heapSize = this.A.Length;
            for (int i = (this.A.Length - 1) / 2; i >= 0; i--)
            {
                this.MinHeapify(i);
            }
        }

        public void HeapMaxSort()
        {
            this.BuildMaxHeap();
            for (int i = this.A.Length - 1; i >= 0; i--)
            {
                this.Swap(0, i);
                this.heapSize--;
                this.MaxHeapify(0);
            }
        }

        public void HeapMinSort()
        {
            this.BuildMinHeap();
            for (int i = this.A.Length - 1; i >= 0; i--)
            {
                this.Swap(0, i);
                this.heapSize--;
                this.MinHeapify(0);
            }
        }

        public void MaxHeapInsert()
        {

        }

        public void HeapExtractMax()
        {

        }

        public void HeapIncreaseKey()
        {

        }

        public void HeapMaximum()
        {

        }

        public double[] GetHeap()
        {
            return this.A;
        }

        //get parent node number
        public int Parent(int i)
        {
            return i / 2;
        }

        //get left child node number
        public int Left(int i)
        {
            return 2 * i + 1;
        }

        //get right child node number
        public int Right(int i)
        {
            return 2 * i + 2;
        }

        public void Swap(int i,int j)
        {
            var temp = this.A[i];
            this.A[i] = this.A[j];
            this.A[j] = temp;
        }
    }

    
}
