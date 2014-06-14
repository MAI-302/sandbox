using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zadanie2
{
    class Program
    {
        public enum level { level0, level1, level2, str, exit };

        /// <summary>Отображает меню с заданным уровнем</summary
        /// <param name="l">Уровень для отображения</param>
        private static void ShowMenu(level l) {
            Console.Clear(); 
            switch (l) {
                case level.level0:
                    Console.WriteLine("************* Уровень 0 **************");
                    Console.WriteLine("Переход на уровень 1 --> 1\nВыход                --> 0");
                    Levels(l, level.level1, level.exit);    break;
                case level.level1:
                    Console.Clear();
                    Console.WriteLine("************* Уровень 1 **************");
                    Console.WriteLine("Переход на уровень 2 --> 1\nПереход на уровень 0 --> 0");
                    Levels(l, level.level2, level.level0);    break;
                case level.level2:
                    Console.Clear();
                    Console.WriteLine("************* Уровень 2 **************");
                    Console.WriteLine("Переход на уровень 1 --> 1\nВывести строку на экран --> 0");
                    Levels(l, level.level1, level.str);    break;
                case level.str:
                    Console.WriteLine("Тестовая строка");
                    Console.WriteLine("Вернуться к Уровню 2 --> 1");
                    Levels(l, level.level2, level.level2);    break;
                case level.exit: break;
                default: Console.WriteLine("Уровень не существует"); break;
            }
        }
        /// <summary>Уровни</summary>
        /// <param name="l">Текущий уровень</param>
        /// <param name="l1">Следующий уровень</param>
        /// <param name="l2">Предыдущий уровень, или тот же или строка</param>
        private static void Levels(level l, level l1, level l2){
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey();    // Считываем нажатую клавишу
            if (cki.Key != ConsoleKey.D0 && cki.Key != ConsoleKey.D1) ShowMenu(l);
            if (cki.Key == ConsoleKey.D1) ShowMenu(l1);
            else if (cki.Key == ConsoleKey.D0) ShowMenu(l2);
        }

        static void Main(string[] args) {
            // Отображаем меню с нулевого уровня
            ShowMenu(level.level0);
        }
    }
}
