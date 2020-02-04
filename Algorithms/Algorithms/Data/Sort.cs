using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data
{
    class Sort : Algorithms
    {
        public bool CheckSortUp(double[] array)
        {
            bool res = array.SequenceEqual(array.OrderBy(e => e));
            return res;
        }

        public bool CheckSortDown(double[] array)
        {
            bool res = array.SequenceEqual(array.OrderByDescending(e => e));
            return res;
        }

        public double[] InsertionSortUp(double[] array_for_sorting)
        {
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

            return array_for_sorting;
        }

        public double[] InsertionSortDown(double[] array_for_sorting)
        {
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

            return array_for_sorting;
        }
    }
}
