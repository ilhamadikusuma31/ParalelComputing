using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IterationAndRecursiveParallelComputing
{

    public class ThreadedQuickSort<T> where T : IComparable<T>
    {
        public async Task QuickSort(T[] arr)
        {
            await QuickSort(arr, 0, arr.Length - 1);
        }

        private async Task QuickSort(T[] arr, int left, int right)
        {

            if (right <= left) return;
            int lt = left;
            int gt = right;
            var pivot = arr[left];
            int i = left + 1;
            while (i <= gt)
            {
                int cmp = arr[i].CompareTo(pivot);
                if (cmp < 0)
                    Swap(arr, lt++, i++);
                else if (cmp > 0)
                    Swap(arr, i, gt--);
                else
                    i++;
            }

            var t1 = Task.Run(() => QuickSort(arr, left, lt - 1));
            var t2 = Task.Run(() => QuickSort(arr, gt + 1, right));

            await Task.WhenAll(t1, t2).ConfigureAwait(false);

        }
        private void Swap(T[] a, int i, int j)
        {
            var swap = a[i];
            a[i] = a[j];
            a[j] = swap;
        }
    }

    internal class Program
    {
      
        static void Main(string[] args)
        {
            // ===ITERATION=== nyari angka prima dengan data 2jt
            // 2 million
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForeach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine("ITERATION");
            Console.WriteLine($"foreach loop non-paralel     | Jumlah Angka Prima : {primeNumbersFromForeach.Count} | Waktu : {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"foreach loop paralel         | Jumlah Angka Prima : {primeNumbersFromParallelForeach.Count} | Waktu : {watchForParallel.ElapsedMilliseconds} ms.");
            //===========================================================================================================

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");

            //===========================================================================================================
            //===RECURSION=== pengaplikasian quick sort menggunakan rekursif => biasa dan paralel
            Console.WriteLine("RECURSION");
            var approach1Array = GenRandomArray<string>(size: 2_000_000);
            //Console.WriteLine("Size " + approach1Array.Length);
            var approach2Array = new string[approach1Array.Length];
            Array.Copy(approach1Array, approach2Array, approach2Array.Length);

            Stopwatch approach1Stopwatch = new Stopwatch();
            approach1Stopwatch.Start();
            Array.Sort(approach1Array);
            approach1Stopwatch.Stop();
            Console.WriteLine($"Quick Sort non-paralel | udah di sort? {IsSorted(approach1Array)}| Waktu : {approach1Stopwatch.ElapsedMilliseconds} ms.");

            Stopwatch approach2Stopwatch = new Stopwatch();
            approach2Stopwatch.Start();
            approach2Array = approach2Array.AsParallel().OrderBy(t => t).ToArray();
            approach2Stopwatch.Stop();
            Console.WriteLine($"Quick Sort paralel     | udah di sort? {IsSorted(approach2Array)}| Waktu : {approach2Stopwatch.ElapsedMilliseconds} ms.");


            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }


        public static T[] GenRandomArray<T>(int size = 10000)
        {
            var a = new T[size];
            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                a[i] = (T)Convert.ChangeType(r.Next(Int32.MinValue, Int32.MaxValue), typeof(T));
                //Console.WriteLine(a[i]);
            }

            return a;

        }
        public static bool IsSorted<T>(T[] a) where T : IComparable<T>
        {
            if (!a.Any())
                return true;

            var prev = a.First();

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i].CompareTo(prev) < 0)
                    return false;

                prev = a[i];
            }

            return true;
        }

        //=======================================================================================================

        //ilist adalah list yang bisa diakses dan diubah seperti list pada python
        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

        private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();

            //ini sesuai thread laptop, laptop saya punya 8 thread
            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });
            return primeNumbers.ToList();
        }

        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
