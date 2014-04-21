using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0_2
{
    class Vector
    {
        public static void Generate(int shift, int min, int max, ref int a, ref int b, ref int c, ref int d)
        {
            var Random = new Random();
            a = Random.Next(min, max);
            b = Random.Next(min, max);
            c = Random.Next(min, max);
            d = Random.Next(min, max);
            if (a > b)
            {
                a = a + b;
                b = a - b;
                a = a - b;
            }
            if (c > d)
            {
                c = c + d;
                d = c - d;
                c = c - d;
            }
        }
        public static void Print(string title, int i, int a, int b, int c, int d)
        {
            Console.Write(title);
            Console.WriteLine(i + 1);
            Console.Write("Начало первого: ");
            Console.WriteLine(a);
            Console.Write("Конец первого: ");
            Console.WriteLine(b);
            Console.Write("Начало второго: ");
            Console.WriteLine(c);
            Console.Write("Конец второго: ");
            Console.WriteLine(d);
        }

        static void Main()
        {
            int a = 0, b = 0, c = 0, d = 0, number, intersection = 0;
            Console.WriteLine("Введите минимальный порог");
            int min = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите максимальный порог");
            int max = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите сдвиг");
            int shift = Convert.ToInt16(Console.ReadLine());
            min += shift;
            max += shift;

            Console.WriteLine("введите колво повторений ");
            number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Generate(shift, min, max, ref a, ref b, ref c, ref d);
                Print("Полученные данные ", i, a, b, c, d);
                if (((a <= c) && (c <= b)) || 
                    ((a <= d) && (d <= b)) ||
                    ((c <= a) && (a <= d)) || 
                    ((c <= b) && (b <= d)))
                {
                    intersection++;
                }
                Console.WriteLine();
            }
            Console.Write("Кол-во пересечений ");
            Console.WriteLine(intersection);
            Console.ReadLine();
        }
    }
}
