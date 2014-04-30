using System;
using System.Threading;
using System.Timers;

namespace ReadTextFile_Console
{
    class Program
    {
        private  System.Timers.Timer aTimer;
        private  System.Timers.Timer bTimer;
        public Random rand = new Random();
        public int HeroHealth = 150, EnemyHealth = 90;
        public int HeroMana = 40, EnemyMana = 50;
        public Program() { }
        static Program p = new Program();
        static void Main(string[] args)
        {
            p.aTimer = new System.Timers.Timer(1900);
            p.bTimer = new System.Timers.Timer(1200);
            Console.WriteLine("Здоровье героя = 150, Мана героя = 40.");
            Console.WriteLine("Здоровье противника = 90, Мана противника = 50");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (; ; )
            {
                try
                {
                    p.aTimer.Elapsed += new ElapsedEventHandler(p.OnTimedEvent_1);
                    p.aTimer.Interval = 3000;
                    p.aTimer.Start();
                    p.bTimer.Elapsed += new ElapsedEventHandler(p.OnTimedEvent_2);
                    p.bTimer.Interval = 1100;
                    p.bTimer.Start();
                }
                catch (OutOfMemoryException)
                {
                    Console.WriteLine("Не хватает памяти, блин!");
                }
                break;
            }
            Console.ReadLine();
        }
        private  void OnTimedEvent_1(object source, ElapsedEventArgs e)
        {
            if (p.HeroHealth <= 0 || p.EnemyHealth <= 0)
                p.aTimer.Stop();
            else
            {
                if (p.HeroMana < 40)
                    p.HeroMana++;
                
                int EventRoll = p.rand.Next(1,3);
                if (EventRoll == 1)
                {
                    int CritRoll = p.rand.Next(1,21);
                    if (CritRoll == 20)
                    {
                        int roll = p.rand.Next(26, 56);
                        p.EnemyHealth = p.EnemyHealth - roll;
                        Console.WriteLine("КРИТИЧЕСКИЙ УДАР!!!");
                        Console.WriteLine("Герой нанес противнику " + roll + " единиц урона.");
                        Console.WriteLine("Здоровье противника = " + p.EnemyHealth);
                        Console.WriteLine();
                    }
                    else
                    {
                        int roll = p.rand.Next(13, 28);
                        p.EnemyHealth = p.EnemyHealth - roll;
                        Console.WriteLine("Герой нанес противнику " + roll + " единиц урона.");
                        Console.WriteLine("Здоровье противника = " + p.EnemyHealth);
                        Console.WriteLine();
                    }
                }
                if (EventRoll == 2)
                {
                    if (p.HeroMana >= 9) 
                    {
                        if (p.HeroHealth < 100)
                        {
                            p.HeroMana = p.HeroMana - 9;
                            p.HeroHealth = p.HeroHealth + 20;
                            Console.WriteLine("Герой применил заклинание ЛЕЧЕНИЯ! Восстановлено 20 единиц здоровья");
                            Console.WriteLine("Здоровье героя = " + p.HeroHealth + " Мана героя = " + p.HeroMana);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        private void OnTimedEvent_2(object source, ElapsedEventArgs e)
        {
            if (p.HeroHealth <= 0 || p.EnemyHealth <= 0)
                p.bTimer.Stop();
            else
            {
                if (p.EnemyMana < 40)
                    p.EnemyMana++;
                int EventRoll = p.rand.Next(1,3);
                if (EventRoll == 1)
                {
                    int roll = p.rand.Next(4, 9);
                    p.HeroHealth = p.HeroHealth - roll;
                    Console.WriteLine("Противник нанес герою " + roll + " единиц урона.");
                    Console.WriteLine("Здоровье героя = " + p.HeroHealth);
                    Console.WriteLine();
                }
                if (EventRoll == 2)
                {
                    if (p.EnemyMana >= 6)
                    {
                        p.EnemyMana = p.EnemyMana - 7;
                        p.HeroHealth = p.HeroHealth - 13;
                        Console.WriteLine("Противник использовал МОЛНИЮ! 15 единиц урона.");
                        Console.WriteLine("Здоровье героя = " + p.HeroHealth + " Мана противника = " + p.EnemyMana);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
