using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сортировка_массива
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, buf;
            System.Console.WriteLine("Сортировка массива");
            System.Console.WriteLine("Введите длину массива");
            n = int.Parse(Console.ReadLine());
            int[] mass = new int[n];
            for (i = 0; i < n; i++)
            {
                System.Console.Write("A[{0}]=", i);
                mass[i] = int.Parse(System.Console.ReadLine());// ввод значений массива вручную
            }



            // цикл for для сортировки по возрастанию
            for (int k = n - 1; k > 0; k--)
                for ( i = 0; i < k; i++)
                    if (mass[i] > mass[i + 1])
                    {
                        buf = mass[i];
                        mass[i] = mass[i + 1];
                        mass[i + 1] = buf;
                    }
            for ( i = 0; i < n; i++)
                System.Console.Write("\t A[{0}] = {1}", i, mass[i]);


<<<<<<< HEAD
            // цикл do while
            
=======
            // цикл while

>>>>>>> 8047125798efea9f4eb6aabd7a6c7ea3c5b9cf02



            System.Console.ReadKey();
        }
    }
}
