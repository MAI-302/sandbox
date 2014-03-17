using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0
{
    class MatrixOperations
    {
        const int m = 5;
        const int n = 5;
        const int min = 5;
        const int max = 20;

        public static void FillMatrix(ref int[,] array)
        {
            var random = new Random();
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                  array[i, j] = random.Next(min, max);
            }
        }
        public static void PrintMatrix(string title, int[,] array)
        {
            Console.WriteLine(title);
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + "   ");
                Console.WriteLine(Environment.NewLine);
            }
        }
        public static int[,] Addition(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[m, n];
            try
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        NewMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Не удается выполнить операцию.Возможно заданы разноразмерные матрицы");
            }
            return NewMatrix;
        }
        public static int[,] Subtraction(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[m, n];
            try
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        NewMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Не удается выполнить операцию.Возможно заданы разноразмерные матрицы");
            }
            return NewMatrix;
        }
        public static int[,] Multiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[m, n];
            try
            {
                for (int i = 0; i < m; i++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            NewMatrix[i, k] += matrix1[j, k] * matrix2[i, j];
                        }
                    }
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Не удается выполнить операцию.Возможно заданы разноразмерные матрицы");
            }
            return NewMatrix;
        }
    }
    class Program
    {
        const int w = 5;
        const int h = 5;


        static byte Case(byte n)
        {
            var array_1 = new int[h, w];
            var array_2 = new int[h, w];
            var array_3 = new int[h, w];

            

            switch (n)
            {
                case 1:
                    {
                        MatrixOperations.FillMatrix(ref array_1);
                        MatrixOperations.PrintMatrix("Первый массив", array_1);
                        MatrixOperations.FillMatrix(ref array_2);
                        MatrixOperations.PrintMatrix("Второй массив", array_2);
                        array_3 = MatrixOperations.Addition(array_1, array_2);
                        MatrixOperations.PrintMatrix("конечный массив", array_3);
                    } break;
                case 2:
                    {
                        MatrixOperations.FillMatrix(ref array_1);
                        MatrixOperations.PrintMatrix("Первый массив", array_1);
                        MatrixOperations.FillMatrix(ref array_2);
                        MatrixOperations.PrintMatrix("Второй массив", array_2);
                        array_3 = MatrixOperations.Subtraction(array_1, array_2);
                        MatrixOperations.PrintMatrix("конечный массив", array_3);
                    } break;
                case 3:
                    {
                        MatrixOperations.FillMatrix(ref array_1);
                        MatrixOperations.PrintMatrix("Первый массив", array_1);
                        MatrixOperations.FillMatrix(ref array_2);
                        MatrixOperations.PrintMatrix("Второй массив", array_2);
                        array_3 = MatrixOperations.Multiplication(array_1, array_2);
                        MatrixOperations.PrintMatrix("конечный массив", array_3);
                    } break;
                case 0: Exit(); break;
            }
            return n;
        }
        static void Exit()
        {                  
                Console.WriteLine("Всего доброго!");        
        }
        static void MainMenu()
        {
            Console.Write("Выберете необходимую операцию и нажимете нужную клавишу:");
            Console.WriteLine(Environment.NewLine);
            Console.Write("0 - завершение работы программы");
            Console.WriteLine(Environment.NewLine);
            Console.Write("1 - сложение матриц");
            Console.WriteLine(Environment.NewLine);
            Console.Write("2 - вычитание матриц");
            Console.WriteLine(Environment.NewLine);
            Console.Write("3 - умнодение матриц");
            Console.WriteLine(Environment.NewLine);
        }
         static void Main() 
         {  
             MainMenu();            
             byte n = byte.Parse(Console.ReadLine());
             Case(n);
             Console.ReadKey();
         }
    }       
}
