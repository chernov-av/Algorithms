using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Algorithms.Data
{
    static class Select
    {
        public static Tuple<double,string> Minimum(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double min = array[0];
            foreach (double a in array)
            {
                if (a < min) { min = a; }
            }

            sw.Stop();
            return Tuple.Create(min, sw.Elapsed.ToString());
        }

        public static Tuple<double, string> Maximum(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double max = array[0];
            foreach (double a in array)
            {
                if (a > max) { max = a; }
            }

            sw.Stop();
            return Tuple.Create(max, sw.Elapsed.ToString());
        }

        public static Tuple<double, string> SelectRandomizedMax(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double element = SelectRandMax(array, 0, array.Length - 1, array.Length);

            sw.Stop();
            return Tuple.Create(element, sw.Elapsed.ToString());
        }

        public static Tuple<double, string> SelectRandomizedMin(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double element = SelectRandMin(array, 0, array.Length - 1, array.Length);

            sw.Stop();
            return Tuple.Create(element, sw.Elapsed.ToString());
        }

        internal static double SelectRandMax(double[] array, int p, int r, int i)
        {
            if (p == r) { return array[p]; }
            int q = PartitionRandomizedUp(array, p, r);
            int k = q - p + 1;
            if (i == k) { return array[q]; }
            else if (i < k) { return SelectRandMax(array, p, q - 1, i); }
            else return SelectRandMax(array, q + 1, r, i - k);
        }
        internal static double SelectRandMin(double[] array, int p, int r, int i)
        {
            if (p == r) { return array[p]; }
            int q = PartitionRandomizedDown(array, p, r);
            int k = q - p + 1;
            if (i == k) { return array[q]; }
            else if (i < k) { return SelectRandMin(array, p, q - 1, i); }
            else return SelectRandMin(array, q + 1, r, i - k);
        }

        internal static int PartitionUp(double[] array, int p, int r)
        {
            var x = array[r];
            int i = p;
            for (int j = p; j < r; j++)
            {
                if (array[j] <= x)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }
            var temp2 = array[i];
            array[i] = array[r];
            array[r] = temp2;
            return i;
        }
        internal static int PartitionDown(double[] array, int p, int r)
        {
            var x = array[r];
            int i = p;
            for (int j = p; j < r; j++)
            {
                if (array[j] >= x)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                }
            }
            var temp2 = array[i];
            array[i] = array[r];
            array[r] = temp2;
            return i;
        }

        internal static int PartitionRandomizedUp(double[] array, int p, int r)
        {
            Random rand = new Random();
            int i = rand.Next(p, r);
            var temp = array[r];
            array[r] = array[i];
            array[i] = temp;
            return PartitionUp(array, p, r);
        }
        internal static int PartitionRandomizedDown(double[] array, int p, int r)
        {
            Random rand = new Random();
            int i = rand.Next(p, r);
            var temp = array[r];
            array[r] = array[i];
            array[i] = temp;
            return PartitionDown(array, p, r);
        }
    }
}
