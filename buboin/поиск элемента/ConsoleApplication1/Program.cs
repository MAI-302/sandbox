using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(" Программа для подсчета количества появлений заданного символа в строке");
            System.Console.WriteLine();
            System.Console.WriteLine();
            int i;     //индекс 
            int cnt = 0; //счетчик

            int L;     //длина строки

            System.Console.WriteLine("Введите строку символов:");
            System.Console.WriteLine();
            String str = System.Console.ReadLine(); // считывание строки
            L = str.Length;
            System.Console.WriteLine();
            System.Console.WriteLine("Какой символ искать?");
            char smb = char.Parse(System.Console.ReadLine());

            for (i = 0; i < L; i++)
            {
                if (str[i] == smb)
                    cnt++;
            }
            System.Console.WriteLine("В данной строке символ " + smb + " встречается " + cnt + " раз.");

            System.Console.ReadKey();

        }
    }
}
