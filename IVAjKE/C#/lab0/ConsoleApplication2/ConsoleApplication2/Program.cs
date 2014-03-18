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
         Vector SummaVectors = v1 + v2;
         Vector RaznostVectors = v1 - v2;
         Vector Umojenie = v1 * 5;
         Vector Delenie = v2 / 3; 
         Console.WriteLine("Vector 1 " + v1 +
                      "\n Vector 2: " + v2 +
                      "\n Vector 3: " + SummaVectors +
                      "\n Raznost Vectorov: " + RaznostVectors +
                      "\n Umnojenie vector 1 na Skalyar: " + Umojenie + 
                      "\n Delenie vectora 2 na skalyar: "+ Delenie);
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