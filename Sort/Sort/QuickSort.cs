using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class QuickSort
    {
        public void quickSort(int[] data, int left, int right)
        {

            if (left < right)
            {
                int partition = Partition(data, left, right);
                quickSort(data, left, partition - 1);
                quickSort(data, partition + 1, right);
            }
        }

        private int Partition(int[] data, int left, int right)
        {
            int pivot = data[right];
            int temp;
            int i = left;

            for (int j = left; j < right; ++j)
            {
                if (data[j] <= pivot)
                {
                    temp = data[j];
                    data[j] = data[i];
                    data[i] = temp;
                    i++;
                }
            }

            data[right] = data[i];
            data[i] = pivot;

            return i;
        }

        }

      

    }

 

 

       