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
            a = Random.Next(min, max) + shift;
            b = Random.Next(min, max) + shift;
            c = Random.Next(min, max) + shift;
            d = Random.Next(min, max) + shift;
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
            int min = -100, max = 100, a = 0, b = 0, c = 0, d = 0, number, shift, intersection = 0;
            Console.WriteLine("введите колво повторений ");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("введите сдвиг ");
            shift = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                Generate(shift, min, max, ref a, ref b, ref c, ref d);
                Print("Полученные данные ", i, a, b, c, d);
                if (((c >= a) && (c <= b)) || ((d >= a) && (d <= b)) ||
((a >= c) && (a <= d)) || ((b >= c) && (b <= d)))
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
