using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba0
{
    public class ExceedBoundsException : Exception
    {
        public ExceedBoundsException()
            : base()
        {
            Console.WriteLine("Ошибка разменности массива");
        }

    }
    class MatrixOperations
    {

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
            int[,] NewMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            if ((matrix2.GetLength(0) != matrix1.GetLength(0)) || (matrix1.GetLength(1) != matrix2.GetLength(1)))
                throw new ExceedBoundsException();
            else
            {

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        NewMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

                    }
                }
            }

            return NewMatrix;
        }
        public static int[,] Subtraction(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            if ((matrix2.GetLength(0) != matrix1.GetLength(0)) || (matrix1.GetLength(1) != matrix2.GetLength(1)))
                throw new ExceedBoundsException();
            else
            {

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        NewMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
            }
            return NewMatrix;
        }
        public static int[,] Multiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[matrix1.GetLength(0), matrix1.GetLength(1)];
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
                throw new ExceedBoundsException();
            else
            {

                for (int i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        for (int k = 0; k < matrix1.GetLength(1); k++)
                        {
                            NewMatrix[i,j] += matrix1[i,k] * matrix2[k,j];                           
                        }
                    }
                }
            }

            return NewMatrix;

        }

    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите длину массива");
            Console.WriteLine("Первого массива");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Второго массива");
            int n1 = int.Parse(Console.ReadLine());
            int m1 = int.Parse(Console.ReadLine());

            var array_1 = new int[n, m];
            var array_2 = new int[n1, m1];
            var array_3 = new int[n, m1];


            MatrixOperations.FillMatrix(ref array_1);
            MatrixOperations.PrintMatrix("Первый массив", array_1);
            MatrixOperations.FillMatrix(ref array_2);
            MatrixOperations.PrintMatrix("Второй массив", array_2);
            try
            {
                array_3 = MatrixOperations.Addition(array_1, array_2);
                MatrixOperations.PrintMatrix("Конечный массив(Сложение)", array_3);
            }
            catch (ExceedBoundsException)
            {
                Console.WriteLine("Не могу выполнить операцию 'Сложение'");
            }
            try
            {
                array_3 = MatrixOperations.Subtraction(array_1, array_2);
                MatrixOperations.PrintMatrix("Конечный массив(Вычитание)", array_3);
            }
            catch (ExceedBoundsException)
            {
                Console.WriteLine("Не могу выполнить операцию 'Вычитание'");
            }
            try
            {
                array_3 = MatrixOperations.Multiplication(array_1, array_2);
                MatrixOperations.PrintMatrix("Конечный массив(Умножение)", array_3);
            }
            catch (ExceedBoundsException)
            {
                Console.WriteLine("Не могу выполнить операцию 'Умножение'");
            }

            Console.ReadKey();
        }
    }
}
