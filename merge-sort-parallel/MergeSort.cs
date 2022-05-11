//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Runtime.InteropServices;
//using System.Threading.Tasks;
//using System.Diagnostics;

//namespace ParalelComputing
//{
//    class MergeSort
//    {

//        public int[] arr;
//        public MergeSort(int[] ARR)
//        {
//            this.arr = ARR;
//        }
//        static public void MainMerge(int[] numbers, int left, int mid, int right)
//        {
//            int[] temp = new int[25];
//            int i, eol, num, pos;
//            eol = (mid - 1);
//            pos = left;
//            num = (right - left + 1);

//            while ((left <= eol) && (mid <= right))
//            {
//                if (numbers[left] <= numbers[mid])
//                    temp[pos++] = numbers[left++];
//                else
//                    temp[pos++] = numbers[mid++];
//            }
//            while (left <= eol)
//                temp[pos++] = numbers[left++];
//            while (mid <= right)
//                temp[pos++] = numbers[mid++];
//            for (i = 0; i < num; i++)
//            {
//                numbers[right] = temp[right];
//                right--;
//            }
//        }

//        static public void SortMerge(int[] numbers, int left, int right)
//        {
//            int mid;
//            if (right > left)
//            {
//                mid = (right + left) / 2;
//                SortMerge(numbers, left, mid);
//                SortMerge(numbers, (mid + 1), right);
//                MainMerge(numbers, left, (mid + 1), right);
//            }
//        }


//        static void MainMS(string[] args)
//        {


//            Console.Error.WriteLine("Executing sequential loop...");
//            Stopwatch stopwatch = new Stopwatch();
//            stopwatch.Start();


//            int[] numbers = { 76, 89, 23, 1, 55, 78, 2, 99, 12, 65 };
//            Console.WriteLine("MergeSort By Recursive Method");
//            SortMerge(numbers, 0, numbers.Length-1);
//            for (int i = 0; i < numbers.Length; i++)
//                Console.WriteLine(numbers[i]);
//            //Console.ReadLine();

//            stopwatch.Stop();
//            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
//                                    stopwatch.ElapsedMilliseconds);
//        }
//    }
//}