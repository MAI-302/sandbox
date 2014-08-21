using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// задание 18



namespace ConsoleApplication1
{
    class Number1
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(9, 65); // задание 2-х векторов вручную
            Vector v2 = new Vector(6, 8);
            Vector Sum = v1 + v2; // сложение
            Vector Subtraction = v1 - v2;// вычитание и т.д
            Vector Multiplication = v1 * 5;
            Vector Division = v2 / 3;
            System.Console.WriteLine("Value Vector 1:" + v1 +
                              "\n Value Vector 2: " + v2 +
                              "\n Sum of vectors: " + Sum +
                              "\n Subtraction of vectors: " + Subtraction +
                              "\n Multiplication vector 1 by scalar : " + Multiplication +
                              "\n Division vector 2 by scalar: " + Division);
            System.Console.ReadKey();
        }
    }
    class Vector
    {
        private double x;// приват обозначает закрытый доступ
        private double y;

        public Vector(double X, double Y)// дабл объявляет число с плавающей запятой, паблик противоположность привату
        {
            x = X;
            y = Y;
        }

        public double X
        {
            get // определяет метод доступа
            {
                return x; // прерывает выполнение метода
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
        }


        public static Vector operator +(Vector V1, Vector V2)// статик используется для объявления статического члена, принадлежащего собственно типу
        //Ключевое слово оператор используется для перегрузки встроенного оператора или выполнения пользовательского преобразования в классе или объявлении структуры
        {
            return new Vector(V1.X + V2.X, V1.Y + V2.Y);
        }


        public static Vector operator *(Vector V1, Vector V2)
        {
            return new Vector(V1.X * V2.X, V1.Y * V2.Y);
        }


        public static Vector operator -(Vector V1, Vector V2)
        {
            return new Vector(V1.X - V2.X, V1.Y - V2.Y);
        }


        public static Vector operator *(Vector V1, double scalar)
        {
            return new Vector(V1.X * scalar, V1.Y * scalar);
        }


        public static Vector operator /(Vector V2, double scalar)
        {
            return new Vector(V2.X / scalar, V2.Y / scalar);
        }


        public override string ToString() // оверрайд требуется для расширения или изменения абстрактной или виртуальной реализации
        {
            return "{" + X + ", " + Y + "}";
        }
    }
}