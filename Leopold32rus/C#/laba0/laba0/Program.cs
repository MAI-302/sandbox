using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0
{
    public class MyException : Exception
    {
        public MyException()
            : base()
        {
            Console.WriteLine("Ошибка разменности массива");
        }

    }
    class MatrixOperations
    {
        public const int m = 5;
        public const int n = 4;

        public static void FillMatrix(ref int[,] array)
        {
            var random = new Random();
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                    array[i, j] = random.Next(DateTime.Now.Second);
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


                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        NewMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

                    }
                }
            
            
            return NewMatrix;
        }
        public static int[,] Subtraction(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[m, n];

            
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        NewMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                 
            return NewMatrix;
        }
        public static int[,] Multiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[m, n];
               
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
                          
                return NewMatrix;
            return NewMatrix;
        }
    }
    class Program
    {       
         static void Main() 
         {
             var array_1 = new int[MatrixOperations.n, MatrixOperations.m];
             var array_2 = new int[MatrixOperations.n, MatrixOperations.m];
             var array_3 = new int[MatrixOperations.n, MatrixOperations.m];

             
                 MatrixOperations.FillMatrix(ref array_1);
                 MatrixOperations.PrintMatrix("Первый массив", array_1);
                 MatrixOperations.FillMatrix(ref array_2);
                 MatrixOperations.PrintMatrix("Второй массив", array_2);
                 try
                 {
                     throw new MyException();
                 array_3 = MatrixOperations.Addition(array_1, array_2);
                 MatrixOperations.PrintMatrix("Конечный массив(Сложение)", array_3);

                 array_3 = MatrixOperations.Subtraction(array_1, array_2);
                 MatrixOperations.PrintMatrix("Конечный массив(Вычитание)", array_3);

                 array_3 = MatrixOperations.Multiplication(array_1, array_2);
                 MatrixOperations.PrintMatrix("Конечный массив(Умножение)", array_3);
             }
             catch (MyException)
             {
                 MyException f = new MyException();
             }
             Console.ReadKey();
         }
    }       
}
