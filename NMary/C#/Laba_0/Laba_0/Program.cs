using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0_3
{
    struct Point
    {
        public int x, y;

        public void PointXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void PointInfo()
        {
            Console.WriteLine("X: {0}, Y: {1}", x, y);
        }
    }

    class UserArray
    {
        public static Point[] ArrayGeneration(Point[] Array, int n)
        {
            var Random = new Random(DateTime.Now.Millisecond);
            int x, y;
            for (int i = 0; i < n; i++)
            {
                x = Random.Next(-100, 100);
                y = Random.Next(-100, 100);
                Array[i].x = x;
                Array[i].y = y;
            }
            return Array;
        }
    }
    class Program
    {
        const string filename = "1.txt";


        static void Main()
        {
        
            Console.WriteLine("!!!Результаты  будут находится в файле '1.txt' в папке с программой!!!");
            Console.Write("Введите размер массива: ");
            int n = int.Parse(Console.ReadLine());
            Point[] Array = new Point[n];
            UserArray.ArrayGeneration(Array, n);
            if (System.IO.File.Exists(filename))
            {
                StreamWriter NewFile = new StreamWriter(filename);
                Console.WriteLine("Данные записаны в {0}", filename);
                NewFile.WriteLine("Масив точек:");
                for (int i = 0; i < n; i++)
                {
                    NewFile.Write(Array[i].x + " ");
                    NewFile.WriteLine("; " + Array[i].y);
                }
                NewFile.Close();
            }
            else
            {
                Console.WriteLine("Файл '1.txt не создан!\r\nРезультаты работы программы на экране");
                for (int i = 0; i < n; i++)
                    Array[i].PointInfo();
            }
            Console.ReadKey();

        }
    }
}
