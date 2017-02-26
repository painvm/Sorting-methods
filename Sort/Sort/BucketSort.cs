using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class BucketSort
    { 
        
       public int[] bucketSort(int[] array)
        {
            List<int>[] Bucket = new List<int>[array.Length];
            int min = array[0], max = array[array.Length - 1];
            for(int i=1; i<array.Length; i++) { 
                min = array[i] < min ? array[i] : min; 
            }
            for (int i = 0; i < array.Length; i++)
            {
                max = array[i] > max ? array[i] : max;
            }   
            int bucket = array.Length;
             double divider = Math.Ceiling((((double)max + 1) / bucket));
            for (int i = 0; i < array.Length; i++)
            {
                Bucket[i] = new List<int>();
            }

           for (int k = 0; k < array.Length; k++)
            {
                int j = (int)Math.Floor(((double)array[k] / divider));
                Bucket[j].Add(array[k]);
            }
           InsertionSort insertionSort = new InsertionSort(); 

           for (int i = 0; i < array.Length; i++)
           {
               if (Bucket[i].Count > 1)
               {
                   int[] current_array = Bucket[i].ToArray();
                  insertionSort.insertionSort(current_array);
                   Bucket[i] = current_array.ToList<int>();
               }
           }
           int step = 0;
           for (int i = 0; i < array.Length; i++)
           {
               if (Bucket[i].Count > 0)
               {
                   for (int k = 0; k < Bucket[i].Count; k++)
                   {
                       array[step] = Bucket[i][k];
                       step++;
                   }
               }
               
           }
           return array;
           
        }
    }
}
