using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Number1
    {
      static void Main(string[] args)
        {
         Vector v1 = new Vector(15, 16);
         Vector v2 = new Vector(-7, 42);
         Vector Sum = v1 + v2;
         Vector Subtraction = v1 - v2;
         Vector Multiplication = v1 * 5;
         Vector Division = v2 / 3; 
         Console.WriteLine(" Value Vector 1:" + v1 +
                           "\n Value Vector 2: " + v2 +
                           "\n Sum of vectors: " + Sum +
                           "\n Subtraction of vectors: " + Subtraction +
                           "\n Multiplication vector 1 by scalar : " + Multiplication + 
                           "\n Division vector 2 by scalar: "+ Division);
         Console.ReadKey();
        }
    }
    class Vector
    {
        private double x;
        private double y;
    
        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }

        public double X
        {
        get
           {
            return x;
           }
        }

        public double Y
        {
        get
           {
            return y;
           }
        }

        
        public static Vector operator +(Vector V1, Vector V2)
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


        public override string ToString()
        {
         return "{" + X + ", " + Y + "}";
        }
    }
}