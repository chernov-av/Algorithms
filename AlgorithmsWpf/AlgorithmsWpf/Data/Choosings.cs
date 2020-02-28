using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Algorithms.Data
{
    static class Choosings
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
    }
}
