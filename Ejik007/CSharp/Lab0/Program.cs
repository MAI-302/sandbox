using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0_2
{
    class Vector
    {
        public static void Generate(int sdvig,int min, int max, ref int[] array)
        {
            var Random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < 4; i++)
                array[i] = Random.Next(min, max)+sdvig;
        }
        public static void Print(string title, int[] array)
        {
            Console.WriteLine(title);
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
            int min, max, kolvo,sdvig,perese4=0;
            Console.WriteLine("введите минимальный порог");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("введите максимальный порог ");
            max = int.Parse(Console.ReadLine());
            Console.WriteLine("введите колво повторений ");
            kolvo = int.Parse(Console.ReadLine());
            Console.WriteLine("введите сдвиг ");
            sdvig = int.Parse(Console.ReadLine());
            for (int i = 1; i < kolvo+1; i++)
            {
                Generate(sdvig,min, max, ref array);
                Print("Полученные данные "+i, array);
                for (int j = array[0]; j < array[1]; j++)
                {
                    if ((j == array[2]) || (j == array[3]))
                    {
                        perese4++;
                    }
                }
                for (int j = array[0]; j > array[1]; j--)
                {
                    if ((j == array[2]) || (j == array[3]))
                    {
                        perese4++;
                    }
                }
                Console.ReadLine();
            }
            Console.Write("Кол-во пересечений ");
            Console.WriteLine(perese4);
            Console.ReadLine();
        }
    }
}
