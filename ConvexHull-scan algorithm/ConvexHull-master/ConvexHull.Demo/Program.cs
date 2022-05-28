using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using ConvexHull;

namespace ConvexHull
{

    public class Demo
    {

        static List<Point> listPoints = null;

        static void GrahamScanDemo()
        {
            GrahamScan gs = new GrahamScan();

            Console.WriteLine("==========================================================================");
            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            gs.convexHull(listPoints,"Sequential");
            stopwatch2.Stop();
            float elapsed_time2 = stopwatch2.ElapsedMilliseconds;
            Console.WriteLine("Sequential: {0} milliseconds", elapsed_time2);
            Console.WriteLine("==========================================================================");


            var stopwatch = new Stopwatch();
            stopwatch.Start();
            gs.convexHull(listPoints, "Parallel");
            stopwatch.Stop();
            float elapsed_time = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Parallel: {0} milliseconds", elapsed_time);
            Console.ReadLine();
        }


        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber()
        {
            lock (syncLock)
            { 
                return random.Next();
            }
        }
        public static void Main()
        {
            listPoints = new List<Point>();

            int ukuranData = 60000;
            for(int i=0; i<=ukuranData; i++)
            {
                int x = RandomNumber();
                int y = RandomNumber();
                listPoints.Add(new Point(x, y));
            }
       

            GrahamScanDemo();
        }

    }

}
