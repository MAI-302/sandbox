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
            int count = 0, support = 0;
            System.Console.WriteLine("Введите строку для анализа.");
            string stringData = System.Console.ReadLine();
            System.Console.WriteLine("Введите символ, который будете искать в строке.");
            char Symbol = Convert.ToChar(System.Console.Read());
            int Length = stringData.Length;
            for (int i = 0; i < Length; i++)
            {
                if (stringData[i] == Symbol)
                {
                    if (count == 0)
                    {
                        support = i;
                    }
                    count++;
                }
            }
            System.Console.WriteLine("Заданный символ " + Symbol + "встречается в строке " + count + " раз.");
            System.Console.WriteLine("Первый раз он встречается в строке на " + support + " позиции.");
            System.Console.ReadKey();
        }
    }
}
