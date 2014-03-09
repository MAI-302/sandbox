using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //одномерный
            int[] mass = new int[5];
            mass[0] = 1;
            mass[1] = 2;
            mass[2] = 3;
            mass[3] = 4;
            mass[4] = 5;
            int a = 0;
            while (a < 5) {
                a++;
                System.Console.WriteLine("mass["+a+"]="+mass[a-1]);
            }
            System.Console.ReadLine();

            //двумерный
            int m = 3; int n = 2;//границы массивов
            int[,] dmass = new int[m,n];
            int i1; int i2 = 0;
         
            for (i1=0; i1 < m; i1++) {
            for (i2=0; i2 < n; i2++)
            {
                System.Console.WriteLine("write dmass[" + (i1+1) + "," + (i2+1) + "]");
                dmass[i1, i2] = int.Parse(Console.ReadLine());
            }
            }
            System.Console.ReadLine();
            //новый двумерный массив
            int[,] tdmass = new int[n, m];
            for (i1 = 0; i1 < n; i1++)
            {
                for (i2 = 0; i2 < m; i2++)
                {
                    tdmass[i1, i2] = dmass[i2, i1];
                    System.Console.WriteLine("tdmass[" + (i1 + 1) + "," + (i2 + 1) + "]="+tdmass[i1,i2]);
                }
            }

            System.Console.ReadLine();
        }
    }
}
