using System;

namespace HugeArray
{
    class Program
    {
        static void Main(string[] args)
        {
            HugeArray<long> array = new HugeArray<long>(5000000050);
            array[10034500] = 25;
            Console.WriteLine(array[10034500]);
            Console.ReadLine();
        }
    }
}
