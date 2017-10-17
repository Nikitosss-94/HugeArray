using System;
using System.Collections.Generic;
using System.Threading;

namespace HugeArray
{
    public class HugeArray<T> where T : struct
    {
        List<T[]> array;
        long MAXSIZE = 10000000;

        /// <summary>
        /// Конструктор, создает массив заданного размера
        /// Не должен выбрасывать OutOfMemoryException если недостаточно оперативной памяти для массива
        /// </summary>
        /// <param name="count">Кол-во элементов</param>
        public HugeArray(long count)
        {
            var n = count / MAXSIZE;
            array = new List<T[]>();
            try
            {
                while (count - array.Count * MAXSIZE > MAXSIZE)
                {
                    array.Add(new T[MAXSIZE]);
                    //Thread.Sleep(100);
                }

                array.Add(new T[count - array.Count * MAXSIZE]);
            }
#pragma warning disable CS0168 // Переменная объявлена, но не используется
            catch (Exception ex)
#pragma warning restore CS0168 // Переменная объявлена, но не используется
            {
                Console.WriteLine("Создаваемый массив размерностью {0} слишком велик, был создан массив максимальной размерностью: {1} ", count, array.Count * MAXSIZE);
            }
        }

        /// <summary>
        /// Возвращает кол-во элементов
        /// </summary>
        public long Count
        {
            get
            {
                long j = 0;
                foreach (var item in array)
                    j += item != null ? item.LongLength : 0;
                return j;
            }
        }

        /// <summary>
        /// Возвращает или записываетэлемент по заданному индексу
        /// </summary>
        /// <param name="index">интекс в массиве</param>
        /// <returns></returns>
        public T this[long index] { get
            {
                T x;  
                lock (array[(int)(index / MAXSIZE)])
                { x = array[(int)(index / MAXSIZE)][index - (index / MAXSIZE * MAXSIZE)]; }
                return x;
            }
            set
            {
                lock (array[(int)(index / MAXSIZE)])
                {
                    array[(int)(index / MAXSIZE)][index - (index / MAXSIZE * MAXSIZE)] = value;
                }
            }
        }
    }
}
