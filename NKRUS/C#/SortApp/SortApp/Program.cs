using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortApp
{   //
    // 8 задание
    //
    class Program
    {
        static void Main(string[] args)
        {
            // ввод чисел
            double[] nums = new double[7];
            double[] numsnums = new double[7];
            Console.WriteLine("Введите семь чисел для массива nums");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("{0}-е число: ", i + 1);
                nums[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Введите семь чисел для массива numsnums");
            for (int i = 0; i < numsnums.Length; i++)
            {
                Console.Write("{0}-е число: ", i + 1);
                numsnums[i] = Convert.ToDouble(Console.ReadLine());
            }

            CreateSortedArray(nums);
            Sort(numsnums);

            // вывод
            Console.WriteLine("Вывод отсортированного массива nums");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.WriteLine("Вывод отсортированного массива numsnums");
            for (int i = 0; i < numsnums.Length; i++)
            {
                Console.WriteLine(numsnums[i]);
            }
            Console.ReadLine();
        }


        // Метод сортировки

        static double[] CreateSortedArray(double[] nums)
        {
            double temp;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            return nums;
        }
        // Метод сортировки без возврата
        static void Sort(double[] numsnums)
        {
            double temp;
            for (int i = 0; i < numsnums.Length; i++)
            {
                for (int j = i + 1; j < numsnums.Length; j++)
                {
                    if (numsnums[i] > numsnums[j])
                    {
                        temp = numsnums[i];
                        numsnums[i] = numsnums[j];
                        numsnums[j] = temp;
                    }
                }
            }
        }
    }
}