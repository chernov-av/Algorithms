using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms.Data
{
    static class Sort
    {
        public static bool CheckSortUp(double[] array)
        {
            bool res = array.SequenceEqual(array.OrderBy(e => e));
            return res;
        }

        public static bool CheckSortDown(double[] array)
        {
            bool res = array.SequenceEqual(array.OrderByDescending(e => e));
            return res;
        }

        public static Tuple<double[],string> InsertionSortUp(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int j = 2;
            int i = 0;
            double key;

            for (j = 1; j < array_for_sorting.Length; j++)
            {
                key = array_for_sorting[j];
                i = j - 1;

                while (i > -1 && array_for_sorting[i] > key)
                {
                    array_for_sorting[i + 1] = array_for_sorting[i];
                    i = i - 1;
                }

                array_for_sorting[i + 1] = key;
            }
            sw.Stop();
            return Tuple.Create(array_for_sorting,sw.Elapsed.ToString());
        }

        public static Tuple<double[],string> InsertionSortDown(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int j = 2;
            int i = 0;
            double key;

            for (j = 1; j < array_for_sorting.Length; j++)
            {
                key = array_for_sorting[j];
                i = j - 1;

                while (i > -1 && array_for_sorting[i] < key)
                {
                    array_for_sorting[i + 1] = array_for_sorting[i];
                    i = i - 1;
                }

                array_for_sorting[i + 1] = key;
            }

            sw.Stop();
            return Tuple.Create(array_for_sorting, sw.Elapsed.ToString());
        }

        public static Tuple<double[],string> MergeSortUpCaller(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[] output = MergeSortUp(array_for_sorting, 0, array_for_sorting.Length-1);
            sw.Stop();
            return Tuple.Create(output,sw.Elapsed.ToString());
        }

        public static Tuple<double[], string> MergeSortDownCaller(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[] output = MergeSortDown(array_for_sorting,0,array_for_sorting.Length-1);
            sw.Stop();
            return Tuple.Create(output, sw.Elapsed.ToString());
        }

        public static Tuple<double[],string> BubbleSortUp(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            double[] output = new double[array_for_sorting.Length];

            for (int i = 0; i < output.Length; i++)
            {
                for (int j = output.Length - 1; j >= i + 1; j--)
                {
                    if (array_for_sorting[j] < array_for_sorting[j - 1])
                    {
                        var temp = array_for_sorting[j];
                        array_for_sorting[j] = array_for_sorting[j - 1];
                        array_for_sorting[j - 1] = temp;
                    }
                }
            }
            output = array_for_sorting;
            sw.Stop();
            return Tuple.Create(output, sw.Elapsed.ToString());
        }

        public static Tuple<double[], string> BubbleSortDown(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double[] output = new double[array_for_sorting.Length];

            for (int i = output.Length-1; i > -1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array_for_sorting[j] < array_for_sorting[j + 1])
                    {
                        var temp = array_for_sorting[j];
                        array_for_sorting[j] = array_for_sorting[j + 1];
                        array_for_sorting[j + 1] = temp;
                    }
                }
            }
            output = array_for_sorting;
            sw.Stop();
            return Tuple.Create(output, sw.Elapsed.ToString());
        }

        public static Tuple<double[],string> HeapSortUp(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[] output = new double[array_for_sorting.Length];
            Heap heap = new Heap(array_for_sorting);
            heap.HeapMaxSort();
            output = heap.GetHeap();
            sw.Stop();
            return Tuple.Create(output, sw.Elapsed.ToString());
        }

        public static Tuple<double[], string> HeapSortDown(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[] output = new double[array_for_sorting.Length];
            Heap heap = new Heap(array_for_sorting);
            heap.HeapMinSort();
            output = heap.GetHeap();
            sw.Stop();
            return Tuple.Create(output, sw.Elapsed.ToString());
        }

        public static Tuple<double[], string> QuickSort(double[] array_for_sorting)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            double[] output = new double[array_for_sorting.Length];

            sw.Stop();
            return Tuple.Create(output, sw.Elapsed.ToString());
        }

        public static double[] MergeSortUp(double[] array, int p, int r)
        {
            if (p < r)
            {
                double val = (p + r) / 2;
                //int q = (int)Math.Round(val);
                int q = (p + r) / 2;
                array= MergeSortUp(array, p, q);
                array = MergeSortUp(array, q + 1, r);
                array = MergeUp(array, p, q, r);
            }
            return array;
        }
        public static double[] MergeUp(double[] array, int p, int q, int r)
        {
            int n1 = q - p + 1; //Length A[p..q]
            int n2 = r - q;//length A[q+1..r]

            double[] L = new double[n1 + 1];
            double[] R = new double[n2 + 1];
            int i;
            int j;

            for (i = 0; i < n1; i++)
            {
                L[i] = array[p + i];//copy A[p..q] to L[0..n1-1]
            }

            for (j = 0; j < n2; j++)
            {
                R[j] = array[q + j + 1];//copy A[q+1..r] to R[0..n2-1]
            }

            L[n1] = Double.PositiveInfinity;//limiter
            R[n2] = Double.PositiveInfinity;//limiter

            i = 0;
            j = 0;

            for (int k = p; k <= r; k++)
            {
                if (L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
            }

            return array;
        }
        public static double[] MergeSortDown(double[] array, int p, int r)
        {
            if (p < r)
            {
                double val = (p + r) / 2;
                //int q = (int)Math.Round(val);
                int q = p+(r -p) / 2;
                array = MergeSortDown(array, p, q);
                array = MergeSortDown(array, q + 1, r);
                array = MergeDown(array, p, q, r);
            }
            return array;
        }
        public static double[] MergeDown(double[] array, int p, int q, int r)
        {
            /*int n1 = q - p + 1; //Length A[p..q]
            int n2 = r - q;//length A[q+1..r]

            double[] L = new double[n1 + 1];
            double[] R = new double[n2 + 1];
            int i;
            int j;

            for (i = 0; i < n1; i++)
            {
                L[i] = array[p + i];//copy A[p..q] to L[0..n1-1]
            }

            for (j = 0; j < n2; j++)
            {
                R[j] = array[q + j + 1];//copy A[q+1..r] to R[0..n2-1]
            }

            L[n1] = Double.PositiveInfinity;//limiter
            R[n2] = Double.PositiveInfinity;//limiter

            i = 0;
            j = 0;

            for (int k = p; k <= r; k++)
            {
                if (L[i] >= R[j])
                {
                    array[k] = L[j];
                    j++;
                }
                else
                {
                    array[k] = R[i];
                    i++;
                }
            }
            */
            double[] aux = new double[array.Length];

            int i = p;
            int j = q + 1;
            

            for (int k=p; k <= r; k++)
            {
                aux[k] = array[k];
                if (i > q) { array[k] = aux[j]; j++; }
                else if (j > r) { array[k] = aux[i]; i++; }
                else if (aux[j] > aux[i]) { array[k] = aux[j]; j++; }
                else { array[k] = aux[i]; i++; }
            }


            return array;
        }
    }
}
