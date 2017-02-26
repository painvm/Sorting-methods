using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
namespace Sort
{
    class MergeSort
    {
        static private void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp_array = new int[numbers.Length];
            int i, left_end, merge_length, tmp_position;
            left_end = (mid - 1);
            tmp_position = left;
            merge_length = (right - left + 1);
            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid]) {
                    temp_array[tmp_position++] = numbers[left++];
                }
                else
                {
                    temp_array[tmp_position++] = numbers[mid++];
                }
            }
            while (left <= left_end)
            {
                temp_array[tmp_position++] = numbers[left++];
            }
            while (mid <= right)
            {
                temp_array[tmp_position++] = numbers[mid++];
            }
                for (i = 0; i < merge_length; i++)
                {
                    numbers[right] = temp_array[right];
                    right--;
                }
        }
        public void mergeSort(int[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                mergeSort(numbers, left, mid);
                mergeSort(numbers, (mid + 1), right);
                Merge(numbers, left, (mid + 1), right);
            }
        }
    }
}