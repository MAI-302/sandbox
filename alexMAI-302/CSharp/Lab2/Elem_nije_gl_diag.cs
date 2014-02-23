using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//вывод элементов ниже главной диагонали
namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа для вывода элементов матрицы,");
            System.Console.WriteLine("стоящих    ниже    главной    диагонали");
            System.Console.WriteLine("----------------------------------------");
            byte i, j; //индексация 
            byte n;    //размер матрицы
              System.Console.WriteLine("Введите размер матрицы:");
              string str = System.Console.ReadLine();
              n = byte.Parse(str);
              System.Console.WriteLine("----------------------------");
              System.Console.WriteLine();

              int[,] MTX = new int[n, n];
              Random rnd = new Random();
              System.Console.WriteLine("Исходная матрица:");
              System.Console.WriteLine();

              for (i = 0; i < n; i++)
              {
                  for (j = 0; j < n; j++)
                  {
                      MTX[i, j] = rnd.Next(0, 10);
                      System.Console.Write("\t" + MTX[i, j]);
                   }
                  System.Console.WriteLine();
                  System.Console.WriteLine();
                  System.Console.WriteLine();
              }
              System.Console.WriteLine();
              System.Console.WriteLine("Измененная матрица:");
              System.Console.WriteLine();
              for (i = 0; i < n; i++)
              {
                  for (j = 0; j < n; j++)
                  {
                      if (i > j)
                      {
                          System.Console.Write( "\t" + MTX[i, j]);

                      }
                      
                  }
                  System.Console.WriteLine();
                  System.Console.WriteLine();
                  System.Console.WriteLine();
              }


                  System.Console.ReadKey();

        }
    }
}
