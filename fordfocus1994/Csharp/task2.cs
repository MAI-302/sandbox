using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputData;
            int i, j, n;
            System.Console.WriteLine("Введите размерность матрицы (1 число)");
            n = Convert.ToInt32(System.Console.ReadLine());
            int[,] massiv = new int [n,n];
            int[,] support = new int [n,n];
            System.Console.WriteLine("Работаем с матрицей размерности " + n + ".");
            System.Console.WriteLine("Осуществить ввод элементов матрицы вручную (1) или заполнить случайными числами (2) ?");
            inputData = Convert.ToInt32(System.Console.ReadLine());
            if (inputData == 1)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        System.Console.WriteLine("Введите " + i + " " + j + " " + "элемент матрицы.");
                        massiv[i, j] = Convert.ToInt32(System.Console.ReadLine());
                    }
                }
                System.Console.WriteLine("Ваш массив:");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        System.Console.Write(massiv[i, j] + " ");
                    }
                    System.Console.WriteLine();
                }
                
            }
            if (inputData == 2)
            {
                Random rand = new Random();
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        massiv[i, j] = rand.Next(1, 20);
                    }
                }
                System.Console.WriteLine("Ваш массив:");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        System.Console.Write(massiv[i, j] + " ");
                    }
                    System.Console.WriteLine();
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    support[i, j] = massiv[i, j];
                }
            }
            System.Console.WriteLine("Ваш массив будет транспонирован. Нажмите любую клавишу для продолжения работы программы.");
            System.Console.ReadKey();
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    massiv[i, j] = support[j, i];
                }
            }
            System.Console.WriteLine("Транспонированный массив:");
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    System.Console.Write(massiv[i, j] + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.ReadKey();
        }
    }
}
