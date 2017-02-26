using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
namespace Sort
{
    class Program
    {
        public static int[] resizeArray(int[] array, int length, int[] main_array)
        {
            Array.Resize<int>(ref array, length);
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = main_array[i];
            }
            return array;
        }
        static void Main(string[] args)
        {
            const int SIZE_OF_ARRAY = 655360;
            Random rand_number = new Random();
            Stopwatch bucketSortTime = new Stopwatch();
            Stopwatch quickSortTime = new Stopwatch();
            Stopwatch mergeSortTime = new Stopwatch();
            Stopwatch insertionSortTime = new Stopwatch();
            int[] main_array = new int[SIZE_OF_ARRAY];
            int[] temp_array = new int[1];
            for (int i = 0; i < SIZE_OF_ARRAY; i++)
            {
                main_array[i] = rand_number.Next(1000);
            }
            BucketSort bucketSort = new BucketSort();
            QuickSort quickSort = new QuickSort();
            MergeSort mergeSort = new MergeSort();
            InsertionSort insertionSort = new InsertionSort();
            Console.WriteLine("N\tBucket Sort\tQuick Sort\tMerge Sort\tInsertion Sort\n");
            for (int i = 10; i <= SIZE_OF_ARRAY; i *= 2)
            {
                temp_array = resizeArray(temp_array, i, main_array);
                bucketSortTime.Start();
                bucketSort.bucketSort(temp_array);
                bucketSortTime.Stop();
                TimeSpan bucketSortElapsedTime = bucketSortTime.Elapsed;
                temp_array = resizeArray(temp_array, i, main_array);
                quickSortTime.Start();
                quickSort.quickSort(temp_array, 0, temp_array.Length - 1);
                quickSortTime.Stop();
                TimeSpan quickSortElapsedTime = quickSortTime.Elapsed;
                temp_array = resizeArray(temp_array, i, main_array);
                mergeSortTime.Start();
                mergeSort.mergeSort(temp_array, 0, temp_array.Length - 1);
                mergeSortTime.Stop();
                TimeSpan mergeSortElapsedTime = mergeSortTime.Elapsed;
                temp_array = resizeArray(temp_array, i, main_array);
                insertionSortTime.Start();
                insertionSort.insertionSort(temp_array);
                insertionSortTime.Stop();
                TimeSpan insertionSortElapsedTime = insertionSortTime.Elapsed;
                mergeSortTime.Reset();
                bucketSortTime.Reset();
                quickSortTime.Reset();
                insertionSortTime.Reset();
                Console.Write("{0}\t", i);
                Console.WriteLine("{0:00}:{1:00}:{2:00}.{3:00}\t{4:00}:{5:00}:{6:00}.{7:00}\t{8:00}:{9:00}:{10:00}.{11:00}\t{12:00}:{13:00}:{14:00}.{15:00}",
                bucketSortElapsedTime.Hours, bucketSortElapsedTime.Minutes, bucketSortElapsedTime.Seconds,
                bucketSortElapsedTime.Milliseconds / 10, quickSortElapsedTime.Hours, quickSortElapsedTime.Minutes, quickSortElapsedTime.Seconds,
                quickSortElapsedTime.Milliseconds / 10, mergeSortElapsedTime.Hours, mergeSortElapsedTime.Minutes, mergeSortElapsedTime.Seconds,
                mergeSortElapsedTime.Milliseconds / 10, insertionSortElapsedTime.Hours, insertionSortElapsedTime.Minutes, insertionSortElapsedTime.Seconds,
                insertionSortElapsedTime.Milliseconds / 10);
            }
        }
    }
}
