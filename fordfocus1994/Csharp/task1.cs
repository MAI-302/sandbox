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
            System.Console.WriteLine("Введите размерность массива чисел.");
            n = Convert.ToInt32(System.Console.ReadLine());
            int[] massiv = new int[n];
            System.Console.WriteLine("Осуществить ввод элементов массива вручную (1) или заполнить случайными числами (2) ?");
            inputData = Convert.ToInt32(System.Console.ReadLine());

            if (inputData == 1)
            {
                for (i = 0; i < n; i++)
                {
                    System.Console.WriteLine("Введите " + i + " " + "элемент массива.");
                    massiv[i] = Convert.ToInt32(System.Console.ReadLine());
                }
                System.Console.WriteLine("Ваш массив:");
                for (i = 0; i < n; i++)
                {
                    System.Console.Write(massiv[i] + " ");
                }

            }
            if (inputData == 2)
            {
                Random rand = new Random();
                for (i = 0; i < n; i++)
                {
                    massiv[i] = rand.Next(1, 21);
                }
                System.Console.WriteLine("Ваш массив:");
                for (i = 0; i < n; i++)
                {
                    System.Console.Write(massiv[i] + " ");
                }
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Нажмите любую клавишу.");
            System.Console.ReadKey();
            for (j = 0; j < n; j++)
            {
                int min = j;
                bool support = false;
                for (i = 0; i < n - 1; i++)
                {
                    int temp;
                    if (massiv[i] > massiv[i + 1])
                    {
                        temp = massiv[i];
                        massiv[i] = massiv[i + 1];
                        massiv[i + 1] = temp;
                        support = true;
                    }
                    if (massiv[i] < massiv[min])
                    {
                        min = i;
                    }
                    
                }
                if (support == false)
                {
                    break;
                }
            }
            System.Console.WriteLine("Отсортированный массив:");
            for (i = 0; i < n; i++)
            {
                System.Console.Write(massiv[i] + " ");
            }
            System.Console.ReadKey();
        }
    }
}
