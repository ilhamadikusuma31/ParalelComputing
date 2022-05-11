//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using System.Runtime.InteropServices;



//namespace ParalelComputing
//{
//    internal class MergerSortParalel
//    {


//        public int[] arr;
//        public MergerSortParalel(int[] ARR)
//        {
//            this.arr = ARR;
//        }
//        static public void merge(int[] arr, int p, int q, int r)
//        {
//            int i, j, k;
//            int n1 = q - p + 1;
//            int n2 = r - q;
//            int[] L = new int[n1];
//            int[] R = new int[n2];
//            for (i = 0; i < n1; i++)
//            {
//                L[i] = arr[p + i];
//            }
//            for (j = 0; j < n2; j++)
//            {
//                R[j] = arr[q + 1 + j];
//            }
//            i = 0;
//            j = 0;
//            k = p;
//            while (i < n1 && j < n2)
//            {
//                if (L[i] <= R[j])
//                {
//                    arr[k] = L[i];
//                    i++;
//                }
//                else
//                {
//                    arr[k] = R[j];
//                    j++;
//                }
//                k++;
//            }
//            while (i < n1)
//            {
//                arr[k] = L[i];
//                i++;
//                k++;
//            }
//            while (j < n2)
//            {
//                arr[k] = R[j];
//                j++;
//                k++;
//            }
//        }
//        static public void mergeSort(int[] arr, int p, int r)
//        {
//            if (p < r)
//            {
//                int q = (p + r) / 2;
//                mergeSort(arr, p, q);
//                mergeSort(arr, q + 1, r);
//                merge(arr, p, q, r);
//            }
//        }

//        static int[] InitializeMatrix(int rows)
//        {
//            int[] matrix = new int[rows];

//            Random r = new Random();
//            for (int i = 0; i < rows; i++)
//            {
//                for (int j = 0; j < rows; j++)
//                {
//                    matrix[i] = r.Next(100);
//                }
//            }
//            return matrix;
//        }


//        public int[] 
//        public static void MainMSP()
//        {
//            //int[] arr = { 76, 89, 23, 1, 55, 78, 99, 12, 65, 100, 2, 231,123,132,1, 3,4,2,4,6,7,7,7,456,456,34,2 };

//            int rowCount = 2000;
//            //int[] arr = InitializeMatrix(rowCount);

          

//            int n = 2000, i;
//            Console.WriteLine("Merge Sort");
//            Console.Write("Initial array is: ");
//            for (i = 0; i < n; i++)
//            {
//                Console.Write(arr[i] + " ");
//            }
//            Console.Error.WriteLine("Executing paralel...");
//            Stopwatch stopwatch = new Stopwatch();
//            stopwatch.Start();
//            mergeSort(arr, 0, n - 1);
//            Console.Write("\nSorted Array is: ");
//            for (i = 0; i < n; i++)
//            {
//                Console.Write(arr[i] + " ");
//            }
//            //Console.ReadLine();
//            stopwatch.Stop();
//            Console.WriteLine("Paralel time in milliseconds: {0}",
//                                    stopwatch.ElapsedMilliseconds);
//        }
//    }
//}


