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

            System.Console.WriteLine("Введите 1 для транспонирования матрицы, 2 для вывода элементов ниже главной диагонали, 3 для вывода всех элементов в одной строке.");
            inputData = Convert.ToInt32(System.Console.ReadLine());

            if (inputData == 1)
            {

                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        support[i, j] = massiv[i, j];
                    }
                }
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

            if (inputData == 2)
            {
                System.Console.WriteLine("Будут выведены элементы массива, расположенные ниже главной диагонали.");
                for (i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        System.Console.WriteLine();
                    }
                    if (i != 0)
                    {
                        j = 0;
                        while (j < i)
                        {
                            System.Console.Write(massiv[i, j] + " ");
                            j++;
                        }
                    }
                    System.Console.WriteLine();
                }
                System.Console.ReadKey();
            }
            if (inputData == 3)
            {
                string Buf = "";
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        Buf += Convert.ToString(massiv[i, j]);
                        Buf += " ";
                    }
                }
                System.Console.WriteLine("Элементы массива в одной строке:");
                System.Console.WriteLine(Buf);
                System.Console.ReadKey();
            }
            
        }
    }
}
