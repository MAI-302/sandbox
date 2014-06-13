using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zadanie2
{
    class Program
    {
        public enum level { level0, level1, level2 };
        /// <summary>Показывает пункты меню, для 3 уровненей</summary>
        /// <param name="l">Перечислитель уровеней</param>
        public static void ShowLevel(level l) {
            switch (l) {
                case level.level0:
                    Console.WriteLine("************* Уровень 0 **************");
                    Console.WriteLine("Переход на уровень 1 --> 1");
                    Console.WriteLine("Выход                --> 0");
                    break;
                case level.level1:
                    Console.Clear();
                    Console.WriteLine("************* Уровень 1 **************");
                    Console.WriteLine("Переход на уровень 2 --> 1");
                    Console.WriteLine("Переход на уровень 0 --> 0");
                    break;
                case level.level2:
                    Console.Clear();
                    Console.WriteLine("************* Уровень 2 **************");
                    Console.WriteLine("Переход на уровень 1 --> 1");
                    Console.WriteLine("Вывести строку на экран --> 2");
                    break;
            }
        }

        static void Main(string[] args) {
            ConsoleKeyInfo cki;     // Информация о нажатой клавише
            bool f = true;
            do {
                ShowLevel(level.level0);        // Показываем нулевой уровень
                cki = Console.ReadKey();        // Считываем (нажатую клавишу) выбор пользователя
                do {
                    // Если клавиша 1
                    if (cki.Key == ConsoleKey.D1) {
                        ShowLevel(level.level1);    // Показываем первый уровень
                        cki = Console.ReadKey();    // Считываем (нажатую клавишу) выбор пользователя
                        // Если нажатая клавиша 1
                        if (cki.Key == ConsoleKey.D1) {
                            f = true;      // флаг выхода из уровня
                            do {
                                ShowLevel(level.level2);    // Показываем второй уровень
                                cki = Console.ReadKey();    // Считываем (нажатую клавишу) выбор пользователя
                                // Если нажатая клавиша 1
                                if (cki.Key == ConsoleKey.D1) {
                                    // Чистим консоль и переходим на уровень 1
                                    Console.Clear(); f = false;
                                }
                                // иначе если была нажата клавиша 2
                                else if (cki.Key == ConsoleKey.D2) {
                                    // Чистим консоль и остаемся на том же уровне
                                    Console.Clear();
                                    // Выводим строку
                                    Console.WriteLine("Эта строка находится на уровне 2");
                                    Console.WriteLine("Вернуться к Уровню 2 --> 1");
                                    cki = Console.ReadKey();
                                }
                                else {
                                    Console.Clear();
                                }
                            } while (f);    // Пока не пожелаем вернуться на уровень 1
                            f = true;
                        }
                        // иначе если была нажата клавиша 0, 
                        else if (cki.Key == ConsoleKey.D0) {
                            // чистим консоль и переходим на уровень 0
                            Console.Clear(); f = false; cki = new ConsoleKeyInfo();
                        }
                        else {
                            Console.Clear();
                        }
                    }
                    else {
                        Console.Clear();
                    }
                } while (f); 
            } while (cki.Key != ConsoleKey.D0);   // Выводим пункт до тех пор пока не нажали 0
        }
    }
}
