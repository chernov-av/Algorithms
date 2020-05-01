using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using LibSort;
using CommonTypes;

namespace LibSelect
{
    static class Select
    {
        [Execute("Минимум")]
        public static Tuple<double, string> Minimum(double[] array)
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
        [Execute("Максимум")]
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
        [Execute("Медиана O(nlogn)")]
        public static Tuple<double, string> Median_nlogn(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double median;
            Sort srt = new Sort();
            array = srt.QuickSortUp(array).Item1;
            if (array.Length % 2 == 1) { median = array[array.Length / 2]; }
            else { median = (array[array.Length / 2 - 1] + array[array.Length / 2]) / 2; }

            sw.Stop();
            return Tuple.Create(median, sw.Elapsed.ToString());
        }
        [Execute("Медиана O(n)")]
        public static Tuple<double, string> Median_n(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double median = -1;            

            if (array.Length % 2 == 1)
            { median = quickSelect(array, array.Length / 2); }
            else
            { median = (quickSelect(array, array.Length / 2 - 1) + quickSelect(array, array.Length / 2)) / 2; }

            sw.Stop();
            return Tuple.Create(median, sw.Elapsed.ToString());
        }
        private static double quickSelect(double[] array, int index)
        {
            double res;
            
            if (array.Length == 1) { index = 0; return res = array[0]; }

            List<double> lows = new List<double>();
            List<double> highs = new List<double>();
            List<double> pivots = new List<double>();

            Random rnd = new Random();
            int pivot = rnd.Next(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[pivot])
                {
                    lows.Add(array[i]);
                }
                else if (array[i] > array[pivot])
                {
                    highs.Add(array[i]);
                }
                else if (array[i]==array[pivot]) { pivots.Add(array[i]); }
            }

            if (index < lows.ToArray().Length) { return res = quickSelect(lows.ToArray(), index); }
            else if (index < lows.ToArray().Length + pivots.ToArray().Length) { return pivots[0]; }
            else { return res = quickSelect(highs.ToArray(), index - lows.ToArray().Length - pivots.ToArray().Length); }
        }
        [Execute("Сл. выбор макс.")]
        public static Tuple<double, string> SelectRandomizedMax(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double element = SelectRandMax(array, 0, array.Length - 1, array.Length);

            sw.Stop();
            return Tuple.Create(element, sw.Elapsed.ToString());
        }
        [Execute("Сл. выбор мин.")]
        public static Tuple<double, string> SelectRandomizedMin(double[] array)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            double element = SelectRandMin(array, 0, array.Length - 1, array.Length);

            sw.Stop();
            return Tuple.Create(element, sw.Elapsed.ToString());
        }

        private static double SelectRandMax(double[] array, int p, int r, int i)
        {
            if (p == r) { return array[p]; }
            Sort srt = new Sort();
            int q = srt.PartitionRandomizedUp(array, p, r);
            int k = q - p + 1;
            if (i == k) { return array[q]; }
            else if (i < k) { return SelectRandMax(array, p, q - 1, i); }
            else return SelectRandMax(array, q + 1, r, i - k);
        }
        private static double SelectRandMin(double[] array, int p, int r, int i)
        {
            if (p == r) { return array[p]; }
            Sort srt = new Sort();
            int q = srt.PartitionRandomizedDown(array, p, r);
            int k = q - p + 1;
            if (i == k) { return array[q]; }
            else if (i < k) { return SelectRandMin(array, p, q - 1, i); }
            else return SelectRandMin(array, q + 1, r, i - k);
        }
    }
}
