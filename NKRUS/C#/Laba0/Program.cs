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
            Console.WriteLine("Введите семь чисел");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("{0}-е число: ", i + 1);
                nums[i] = Convert.ToDouble(Console.ReadLine());
            }

            CreateSortedArray(nums);
            Sort(nums);                
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
        // Метод Вывода
        static void Sort(double[] nums)
        {
            Console.WriteLine("Вывод отсортированного массива");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }
    } 
}