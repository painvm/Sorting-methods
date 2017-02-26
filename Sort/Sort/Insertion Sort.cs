using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sort
{
    class InsertionSort
    {
        public void insertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i - 1; j >= 0 && array[j] > array[j + 1]; j-- )
                {
                    array[j] += array[j + 1];
                    array[j + 1] = array[j] - array[j + 1];
                    array[j] -= array[j + 1];
                }
            }
        }
}
}