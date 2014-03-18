using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Для работы с приложением \r\nв этой же папке должен существовать текстовый документ '1.txt'");
            Console.WriteLine("Если его нет, то создайте сами, не маленькие уже. А сейчас нажмите крестик :)");
            Console.ReadKey(true);
            if (System.IO.File.Exists("1.txt"))
            {}
            else
            {
                Console.WriteLine("Ну или все таки маленькие =_= \r\nНе всегда же наш психологический возраст равен физическому.");
                Console.WriteLine("Да здравствует выход из программы!");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            string[] MyWrdd = new string[100500];
            string[] NewFile = File.ReadAllLines("1.txt");
            int Count = 0;
            int mw = 0;
            string mywrd = "";
            Console.WriteLine("Содержимое файла:");
            foreach (string str in NewFile)// создание массива строк 
            {
                Console.WriteLine(str);
                Count++;
            }
            Console.WriteLine("Найденные координаты:");
            for (int i = 0; i < Count; i++)
            {
                
                char[] mystr = NewFile[i].ToCharArray();// создание массива символов из строк 
                for (int j = 0; j < NewFile[i].Length; j++)
                {
                    char[] arar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ';', ' '};
                    int index = System.Array.IndexOf(arar, mystr[j]);
                    
                    
                    if (index < 0) 
                        {
                        Console.WriteLine("Вы ввели букву или какой то символ, который вводить нельзя.");// проверка входных данных
                        Console.WriteLine("Нехорошо так делать. Просмотрите входной файл на наличие ошибок.");
                        Console.WriteLine("А в качестве наказания осуществляетя выход из программы.");
                        Console.WriteLine("Впредь будьте внимательны :)");
                        Console.ReadKey(true);
                        Environment.Exit(0);
                        }
                    else
                    {
                        if (mystr[j] == ' ')// составление чисел
                        { 
                            MyWrdd[mw] = mywrd;
                            if (mywrd.Contains(";"))// проверка на ';' и вывод координат на экран
                            {
                                Console.WriteLine(mywrd);
                            }
                            mywrd = "";
                            mw++;
                           // Console.WriteLine(MyWrdd[mw]);
                        }
                        else
                        {
                            mywrd = mywrd + mystr[j];
                           // Console.WriteLine(mywrd);
                        }
                      }  
                        
                    }

                }
            /*for ( int k = 0; k < mw; k++)
                        {
                            if (MyWrdd[k].Contains(";"))// проверка на ';' и вывод координат на экран
                            {
                                Console.WriteLine(" ", MyWrdd[k], " ");
                            }
                        } */
            
            
            Console.ReadKey(true);}
        }
    }

