using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Программа для вывода элементов матрицыв строку");
            byte i, j;     //индексация элементов (байт- целое число)  
            byte n, m;     //размер матрицы
            System.Console.WriteLine("Введите количество строк:");
            string str = System.Console.ReadLine(); // считвание  строки , стр и кол локальные переменные
            n = byte.Parse(str); // преобразование  строки в целое число

            System.Console.WriteLine("Введите количество столбцов:");
            string col = System.Console.ReadLine();// считывание  столбца
            m = byte.Parse(col);

            System.Console.WriteLine();// оставляет строку пустой

            int[,] mtx = new int[n, m]; // инт- объявление переменной, мтх - матрица
            Random rnd = new Random(); // создание случайных элементов
            System.Console.WriteLine("Исходная матрица:");
            System.Console.WriteLine();
            System.Console.WriteLine();

            for (i = 0; i < n; i++)// цикл от 0 до н по 1 по строкам
            {
                for (j = 0; j < m; j++)// цикл по столбцам, здесь считывается матрица
                {
                    mtx[i, j] = rnd.Next(0, 10);// возврат случайного целого числа от 0 до 9
                    System.Console.Write("\t" + mtx[i, j]); // вывод матрицы
                }
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
            System.Console.WriteLine("Печать в строку:");
            System.Console.WriteLine();
            for (i = 0; i < n; i++) // печатается матрица в строку
            {
                for (j = 0; j < m; j++)
                {
                    System.Console.Write(mtx[i, j]);


                }
                System.Console.Write("     ");// пробел между числами, печатающимися в строку
            }


            System.Console.ReadKey();// считывание введенных пользователем чисел

        }
    }
}
