using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    public class Area
    {
        public int x, y;//Размер пространства
        public int R;//число, определяющее минимальное расстояние до след фигуры
        public void CreateArea()//создаёт новую область
        {
            Random Rnd = new Random();

            x = Rnd.Next(0, 100);
            y = Rnd.Next(0, 100);
        }
    }

    public class Figures
        : Area
    {
        //координаты центра фигуры
        int CenterX, CenterY;
        public void DrawSmthg() { }
        public void FigureChoose(out int figure)
        {
            Random RndF = new Random();
            figure = RndF.Next(1, 4);
        }
    }

    public class WithoutAngle
        : Figures
    {
        //необходимы для построения окружности
        int Radius, A, B;

        new public void DrawSmthg()
        {
            //рисуем круг
        }
    }
    public class Circle
        : WithoutAngle
    {
        new public void DrawSmthg()
        {
            //рисуем круг
        }
    }

    public class Ellipse
        : WithoutAngle
    {
        new public void DrawSmthg()
        {
            //рисуем элипс
        }
    }

    public class WithAngle
        : Figures
    {
        //необходимы для построения угольника
        int A, B, C;
    }

    public class Triangle
        : WithAngle
    {
        new public void DrawSmthg()
        {
            //рисуем треугольник
        }

    }
    public class Quadrangle
            : WithAngle
    {
        int D;//доп точка для 4ого угла
        new public void DrawSmthg()
        {
            //рисуем прямоугольник
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Area field = new Area();
            //field.CreateArea();
        }
    }
}
