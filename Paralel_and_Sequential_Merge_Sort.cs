using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ParalelComputing
{
    class MSP
    {
        static public void merge(int[] arr, int p, int q, int r)
        {
            int i, j, k;
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (i = 0; i < n1; i++)
            {
                L[i] = arr[p + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[q + 1 + j];
            }
            i = 0;
            j = 0;
            k = p;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        static public void mergeSort(int[] arr, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                mergeSort(arr, p, q);
                mergeSort(arr, q + 1, r);
                merge(arr, p, q, r);
            }
        }

        static int[] InitializeMatrix(int rows)
        {
            int[] matrix = new int[rows];

            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    matrix[i] = r.Next(100);
                }
            }
            return matrix;
        }

        public static void MainMSP(int[] arr)
        {
            //int rowCount = 2000;
            //int n = 2000, i;
            //Console.WriteLine("Merge Sort");
            //Console.Write("Initial array is: ");
            //for (i = 0; i < n; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            int i;
            Console.Error.WriteLine("Executing paralel...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            mergeSort(arr, 0, arr.Length - 1);

            Console.Write("\nSorted Array is: ");
            for (i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            //Console.ReadLine();
            stopwatch.Stop();
            Console.WriteLine("Paralel time in milliseconds: {0}",
                                    stopwatch.ElapsedMilliseconds);
        }

    }


    class MS
    {

        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

        // A utility function to
        // print array of size n */
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code
        public static void MainMS(int[] arr)
        {
            //int[] arr = { 12, 11, 13, 5, 6, 7 };
            //Console.WriteLine("Given Array");
            //printArray(arr);
            int i;
            MS ob = new MS();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ob.sort(arr, 0, arr.Length - 1);
            Console.Write("\nSorted Array is: ");
            for (i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
                                    stopwatch.ElapsedMilliseconds);





        }
    }

    class Program
    {


        static void Main()
        {
            BuildArray arr = new BuildArray();
            int[] dummy = arr.InitializeMatrix(10000);

            //MSP msp = new MSP();
            //MS ms = new MS();


            MSP.MainMSP(dummy);
            MS.MainMS(dummy);
        }





    }


}




