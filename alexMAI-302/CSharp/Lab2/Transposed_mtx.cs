using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, n, m;
            System.Console.WriteLine("Введите количество строк матрицы:");
            string str = System.Console.ReadLine();
            System.Console.WriteLine("Введите количество столбцов матрицы:");
            string col = System.Console.ReadLine();
            n = int.Parse(str);
            m = int.Parse(col);

            int [,] inp = new int[n, m];
            Random rnd = new Random();
            int [,] otp = new int[m, n];

            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine("Исходная матрица:");
            System.Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    inp[i, j] = rnd.Next(0, 10);
                    System.Console.Write("\t" + inp[i, j]);
                }
                System.Console.WriteLine();

            }

            System.Console.WriteLine("Транспонированная матрица:");
            System.Console.WriteLine();

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    otp[i, j] = inp[j, i];
                    System.Console.Write("\t" + otp[i, j]);
                }
                System.Console.WriteLine();
            }

                System.Console.ReadKey();


        }
    }
}
