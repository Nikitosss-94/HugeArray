using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace HugeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t = true;
            //new Thread(() =>
            //{
            //    while (t)
            //    {
            //        Console.WriteLine("Используется процессом: " + Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024 + " Mb");
            //        Console.WriteLine("Свободно памяти: " + new PerformanceCounter("Memory", "Available MBytes").NextValue() + " Мб");
            //        Thread.Sleep(500);
            //        Console.Clear();
            //    }
            //}).Start();
            //HugeArray<long> array = new HugeArray<long>(1650000005);
            //t = false;
            //array[10034500] = 25;
            //Console.WriteLine(array[10034500]);
            //Console.WriteLine("Используется процессом: " + Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024 + " Mb");
            //Console.WriteLine("Свободно памяти: " + new PerformanceCounter("Memory", "Available MBytes").NextValue() + " Мб");
            //Thread.Sleep(1000);
            //Console.ReadLine();

            HugeArray<long> hg = new HugeArray<long>(40);
            Thread[] t = new Thread[40];

            for (var i = 0; i < 4; i++)
            {
                (t[i] = new Thread(() =>
                {
                    int n = int.Parse(Thread.CurrentThread.Name);
                    for (int j = n * 10; j < n * 10 + 10; j++)
                    {
                        hg[j] = j;
                        Console.WriteLine(hg[j]);
                    }
                })).Name = (i).ToString();
                t[i].Start();
            }
            Console.ReadLine();            
        }        
    }
}
