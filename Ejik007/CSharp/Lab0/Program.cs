using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0_2
{
    class Vector
    {
        public static void Generate(int shift,int min, int max, ref int[] array)
        {
            var Random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < 4; i++)
                array[i] = Random.Next(min, max)+shift;
            if (array[0] > array[1])
            {
                array[0] = array[0] + array[1];
                array[1] = array[0] - array[1];
                array[0] = array[0] - array[1];
            }
            if (array[2] > array[3])
            {
                array[2] = array[2] + array[3];
                array[3] = array[2] - array[3];
                array[2] = array[2] - array[3];
            }
        }
        public static void Print(string title,int i, int[] array)
        {
            Console.Write(title);
            Console.WriteLine(i+1);
            Console.Write("Начало первого: ");
            Console.WriteLine(array[0] );
            Console.Write("Конец первого: ");
            Console.WriteLine(array[1]);
            Console.Write("Начало второго: ");
            Console.WriteLine(array[2]);
            Console.Write("Конец второго: ");
            Console.WriteLine(array[3]);
        }
        
        static void Main() 
        {
            var array = new int[4];
            int min, max, number, shift, intersection = 0;
            Console.WriteLine("введите минимальный порог");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("введите максимальный порог ");
            max = int.Parse(Console.ReadLine());
            Console.WriteLine("введите колво повторений ");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("введите сдвиг ");
            shift = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Generate(shift,min, max, ref array);
                Print("Полученные данные ",i, array);
                if (((array[2] >= array[0]) && (array[2] <= array[1])) || ((array[3] >= array[0]) && (array[3] <= array[1])) ||
((array[0] >= array[2]) && (array[0] <= array[3])) || ((array[1] >= array[2]) && (array[1] <= array[3])))
                {
                    intersection++;                   
                }
                Console.Write("Кол-во пересечений ");
                Console.WriteLine(intersection);
                Console.ReadLine();
            }          
            Console.ReadLine();
        }
    }
}
