using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//вывод элементов матрицы в одну строку
namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа для вывода элементов");
            System.Console.WriteLine("матрицы    в    одной   строке");
            System.Console.WriteLine("------------------------------");
            byte i, j; //индексация 
            byte n, m;    //размер матрицы
              System.Console.WriteLine("Введите количество строк:");
              string str = System.Console.ReadLine();
              n = byte.Parse(str);

              System.Console.WriteLine("Введите количество столбцов:");
              string col = System.Console.ReadLine();
              m = byte.Parse(col);

              System.Console.WriteLine("----------------------------");
              System.Console.WriteLine();

              int[,] MTX = new int[n, m];
              Random rnd = new Random();
              System.Console.WriteLine("Исходная матрица:");
              System.Console.WriteLine();

              for (i = 0; i < n; i++)
              {
                  for (j = 0; j < m; j++)
                  {
                      MTX[i, j] = rnd.Next(0, 10);
                      System.Console.Write("\t" + MTX[i, j]);
                   }
                  System.Console.WriteLine();
                  System.Console.WriteLine();
                  System.Console.WriteLine();
              }
              System.Console.WriteLine();
              System.Console.WriteLine("Печать в строчку:");
              System.Console.WriteLine();
              for (i = 0; i < n; i++)
              {
                  for (j = 0; j < m; j++)
                  {
                      System.Console.Write(MTX[i, j]);
                      
                      
                  }
                  System.Console.Write("    ");
              }


                  System.Console.ReadKey();

        }
    }
}
