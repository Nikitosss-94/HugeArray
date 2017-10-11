using System.Collections.Generic;

namespace HugeArray
{
    class HugeArray<T> where T : struct
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
            while (count - array.Count * MAXSIZE > MAXSIZE)
                array.Add(new T[MAXSIZE]);
            array.Add(new T[count - array.Count * MAXSIZE]);
            //for (var i = 0; i < n; i++)
            //{
            //    long j = 0;
            //    foreach (var item in array)
            //        j += item != null ? item.LongLength : 0;
            //    array[i] = count - j > MAXSIZE ? new T[MAXSIZE] : new T[count - j];
            //}
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
                return array[(int)(index / MAXSIZE)][index - (index / MAXSIZE * MAXSIZE)];//array[index];
            }
            set
            {
                array[(int)(index / MAXSIZE)][index - (index / MAXSIZE * MAXSIZE)] = value;
            }
        }
    }
}
