using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GameGraphics
{
    public class Creatures
    {
        public string Name;
        public string Race;
        public int Health;
        public int MaxHealth;
        public int Attack;
        public int Defence;
        public int ToHit;
        public int AC;
        public int Exp;
        public int Level;
        public bool Dead;
        public Image CreatureImage;
        public int X, Y;
        public bool f;
        public Creatures()
        { }
    }
    public class Hero
            :Creatures
    {
        public int Strength;
        public int Agility;
        public int Vitality;
        public int Intellect;
        public int AttackCurrent;
        public int ExpToLevel;
        public int X1, Y1;

        public Hero()
        {
            Name = "";
            Race = "";
            Strength = 10;
            Agility = 10;
            Vitality = 10;
            Intellect = 10;
            AttackCurrent = 0;
            Health = 10;
            MaxHealth = Health;
            Attack = 3;
            Defence = 1;
            ToHit = 1;
            AC = 1;
            Exp = 0;
            Level = 1;
            ExpToLevel = 300;
            X = 9;
            X1 = X;
            Y = 9;
            Y1 = Y;
            f = false;
            CreatureImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\hero.png");
        }
    }
    public class Goblin
            :Creatures
    {
        public Goblin()
        {
            Name = "Goblin";
            Race = "Goblin";
            Health = 7;
            MaxHealth = Health;
            Attack = 3;
            Defence = 1;
            ToHit = 1;
            AC = 1;
            Exp = 15;
            Level = 1;
            X = 0;
            Y = 0;
            f = false;
            CreatureImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\enemy1_t.png");
        }
    }

    public class MapObject
    {
        public bool IsPassable;
        public int X { get; set; }
        public int Y { get; set; }
        public Image ObjImage;
        public MapObject()
        { }
    }

    public class Tree
        : MapObject
    {
        public Tree()
        {
            IsPassable = false;
            X = 0;
            Y = 0;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\tree.png");
        }
    }
    public class Rock
        : MapObject
    {
        public Rock()
        {
            IsPassable = false;
            X = 0;
            Y = 0;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\stone.png");
        }
    }
    public class Grass
       : MapObject
    {
        public Grass(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_grass.png");
        }
    }
    public class RoadVercital
       : MapObject
    {
        public RoadVercital(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_vertical.png");
        }
    }
    public class RoadHorizontal
       : MapObject
    {
        public RoadHorizontal(int a, int b)
        {
            IsPassable = true;
            X = a;  
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_horizontal.png");
        }
    }
    public class RoadTUP
        : MapObject
    {
        public RoadTUP(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_T-up.png");
        }
    }
    public class RoadTUD
        : MapObject
    {
        public RoadTUD(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_T-down.png");
        }
    }
    public class RoadTUR
        : MapObject
    {
        public RoadTUR(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_T-right.png");
        }
    }
     public class RoadTUL
        : MapObject
    {
        public RoadTUL(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_T-left.png");
        }
    }
     public class RoadTurnLeftDown
     : MapObject
     {
         public RoadTurnLeftDown(int a, int b)
         {
             IsPassable = true;
             X = a;
             Y = b;
             ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_left-down.png");
         }
     }     
    public class RoadTurnRightDown
      : MapObject
     {
         public RoadTurnRightDown(int a, int b)
         {
             IsPassable = true;
             X = a;
             Y = b;
             ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_right-down.png");
         }
     }
    public class RoadTurnRightUp
      : MapObject
    {
        public RoadTurnRightUp(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_right-up.png");
        }
    }
    public class RoadTurnLeftUp
     : MapObject
    {
        public RoadTurnLeftUp(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_left-up.png");
        }
    }   
    public class RoadCross
     : MapObject
    {
        public RoadCross(int a, int b)
        {
            IsPassable = true;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_road_turn_cross.png");
        }
    }

    public class Water
        : MapObject
    {
        public Water(int a, int b)
        {
            IsPassable = false;
            X = a;
            Y = b;
            ObjImage = Image.FromFile(@"L:\Proga\GameGraphics\GameGraphics\obj\Debug\GamePictures\bg_water.png");
        }
    }
}
