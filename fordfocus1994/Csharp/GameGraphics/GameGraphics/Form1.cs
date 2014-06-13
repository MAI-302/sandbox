using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGraphics
{
    public partial class Form1 : Form
    {
        public bool CreatedHero;
        public int MapWidth, MapHeight;
        public int[,] MassOfMapObjects;
        List<Hero> H = new List<Hero>();
        List<Goblin> G = new List<Goblin>();
        List<Tree> Tr = new List<Tree>();
        List<Rock> Ro = new List<Rock>();
        List<Grass> Gr = new List<Grass>();
        List<Water> Wa = new List<Water>();
        List<RoadHorizontal> RoHo = new List<RoadHorizontal>();
        List<RoadVercital> RoVe = new List<RoadVercital>();
        List<RoadTUP> RoTUP = new List<RoadTUP>();
        List<RoadTurnRightUp> RoTRU = new List<RoadTurnRightUp>();
        List<RoadTurnLeftUp> RoTLU = new List<RoadTurnLeftUp>();
        public Form1()
        {
            CreatedHero = false;
            DoubleBuffered = true;
            InitializeComponent();
        }

        HeroCreation Cr = new HeroCreation();
        Inventory Inv = new Inventory(60, 11);

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Creation_Click(object sender, EventArgs e)
        {
            if (CreatedHero == true)
            {
                foreach (Hero n in H)
                {
                    NameTextBox.Text = "Герой уже создан.";
                }
            }
            if (CreatedHero == false && NameTextBox.Text == Cr.Data)
            {
                H.Add(new Hero());
                CreatedHero = true;
                this.Refresh();
            }
        }

        private void HeroPicture_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(HeroPicture, Cr.Data);
        }

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            MapWidth = pictureBox1.Width / 50;
            MapHeight = pictureBox1.Height / 50;
            foreach (Grass gr in Gr)
            {
                e.Graphics.DrawImage(gr.ObjImage, gr.X, gr.Y);
            }
            foreach (Water wa in Wa)
            {
                e.Graphics.DrawImage(wa.ObjImage, wa.X, wa.Y);
            }
            foreach (RoadHorizontal rh in RoHo)
            {
                e.Graphics.DrawImage(rh.ObjImage, rh.X, rh.Y);
            }
            foreach (RoadVercital rv in RoVe)
            {
                e.Graphics.DrawImage(rv.ObjImage, rv.X, rv.Y);
            }
            foreach (RoadTUP rotup in RoTUP)
            {
                e.Graphics.DrawImage(rotup.ObjImage, rotup.X, rotup.Y);
            }
            foreach (RoadTurnRightUp rotru in RoTRU)
            {
                e.Graphics.DrawImage(rotru.ObjImage, rotru.X, rotru.Y);
            }
            foreach (RoadTurnLeftUp rotlu in RoTLU)
            {
                e.Graphics.DrawImage(rotlu.ObjImage, rotlu.X, rotlu.Y);
            }
            //////////////////////////////////////////////////
            foreach (Hero n in H)
            {
                e.Graphics.DrawImage(n.CreatureImage, n.X, n.Y);
            }
            foreach (Goblin g in G)
            {
                e.Graphics.DrawImage(g.CreatureImage, g.X, g.Y); 
            }
            foreach (Tree tr in Tr)
            {
                e.Graphics.DrawImage(tr.ObjImage, tr.X, tr.Y);
            }
            foreach (Rock ro in Ro)
            {
                e.Graphics.DrawImage(ro.ObjImage, ro.X, ro.Y);
            }
        }

        public void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Hero n in H)
                {
                    if ((e.X >= n.X && e.X <= n.X + 32) && (e.Y >= n.Y && e.Y <= n.Y + 32))
                    {
                        n.f = true;
                        n.X = e.X;
                        n.Y = e.Y;
                    }
                }
            }
        }

        public void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Hero n in H)
            {
                if (n.f == true)
                {
                    n.X = e.X - 16;
                    n.Y = e.Y - 16;
                    this.Refresh();
                }
            }
        }

        public void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int celx, cely;
            if (e.Button == MouseButtons.Left)
            {
                foreach (Hero n in H)
                {
                    celx = n.X / 25;
                    cely = n.Y / 25;
                    if (n.f == true)
                    {
                        /*n.f = false;
                        if (celx % 2 == 0 && cely % 2 == 0)
                        {
                            n.X = 9 + 25 * celx;
                            n.Y = 9 + 25 * cely;
                            this.Refresh();
                        }
                        if (celx % 2 == 1 && cely % 2 == 1)
                        {
                            n.X = 9 + 25 * (celx - 1);
                            n.Y = 9 + 25 * (cely - 1);
                            this.Refresh();
                        }
                        if (celx % 2 == 1 && cely % 2 == 0)
                        {
                            n.X = 9 + 25 * (celx - 1);
                            n.Y = 9 + 25 * cely;
                            this.Refresh();
                        }
                        if (celx % 2 == 0 && cely % 2 == 1)
                        {
                            n.X = 9 + 25 * celx;
                            n.Y = 9 + 25 * (cely - 1);
                            this.Refresh();
                        }*/
                         n.f = false;
                         if (n.X - n.X1 > 50)
                         {
                             n.X = n.X1 + 50; 
                             if (n.Y - n.Y1 > 50)
                             {
                                 n.Y= n.Y1 + 50;
                             }
                             if ((n.Y - n.Y1 < 50 && n.Y - n.Y1 >= 0) || (n.Y - n.Y1 < 50 && n.Y - n.Y1 >= 0))
                             {
                                 n.Y = n.Y1;
                             }
                             if (n.Y1 - n.Y > 50)
                             {
                                 n.Y = n.Y1 - 50;
                             }
                             this.Refresh();
                         }
                         if ((n.X - n.X1 < 50 && n.X - n.X1 >= 0) || (n.X - n.X1 < 50 && n.X - n.X1 >= 0))
                         {
                             n.X = n.X1;
                             if (n.Y - n.Y1 > 50)
                             {
                                 n.Y = n.Y1 + 50;
                             }
                             if ((n.Y - n.Y1 < 50 && n.Y - n.Y1 >= 0) || (n.Y - n.Y1 < 50 && n.Y - n.Y1 >= 0))
                             {
                                 n.Y = n.Y1;
                             }
                             if (n.Y1 - n.Y > 50)
                             {
                                 n.Y = n.Y1 - 50;
                             }
                             this.Refresh();
                         }
                         if (n.X1 - n.X > 50)
                         {
                             n.X = n.X1 - 50;
                             if (n.Y - n.Y1 > 50)
                             {
                                 n.Y = n.Y1 + 50;
                             }
                             if ((n.Y - n.Y1 < 50 && n.Y - n.Y1 >= 0) || (n.Y - n.Y1 < 50 && n.Y - n.Y1 >= 0))
                             {
                                 n.Y = n.Y1;
                             }
                             if (n.Y1 - n.Y > 50)
                             {
                                 n.Y = n.Y1 - 50;
                             }
                             this.Refresh();
                         }
                         n.X1 = n.X;
                         n.Y1 = n.Y;
                    }
                }
            }
        }

        private void InputStats_Click(object sender, EventArgs e)
        {
            Cr.ShowDialog();
        }

        private void ImageCreation_Click(object sender, EventArgs e)
        {
            using (openFileDialog1)
            {
                openFileDialog1.Filter = "Image Files|*.bmp";
                openFileDialog1.Title = "Выберите картинку для портрета героя.";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    HeroPicture.Image = new Bitmap(openFileDialog1.FileName);
                    this.Controls.Add(HeroPicture);
                }
                openFileDialog1.Dispose();
            }
        }

        private void CreationMap_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int rollx = 0, rolly = 0;
            int i;
            if (G.Count < 10)
            {
                for (i = 0; i < 10; i++)
                {
                    G.Add(new Goblin());
                }
                foreach (Goblin g in G) 
                {
                    rollx = rand.Next(1, MapWidth);
                    rolly = rand.Next(1, MapHeight);
                    g.X = 9 + 50 * rollx;
                    g.Y = 9 + 50 * rolly;
                    rollx = 0;
                    rolly = 0;
                }
            }
            if (Tr.Count < 30)
            {
                for (i = 0; i < 30; i++)
                {
                    Tr.Add(new Tree());
                }
                foreach (Tree tr in Tr)
                {
                    rollx = rand.Next(1, MapWidth);
                    rolly = rand.Next(1, MapHeight);
                    tr.X = 9 + 50 * rollx;
                    tr.Y = 9 + 50 * rolly;
                    rollx = 0;
                    rolly = 0;
                }
            }
            if (Ro.Count < 30)
            {
                for (i = 0; i < 30; i++)
                {
                    Ro.Add(new Rock());
                }
                foreach (Rock ro in Ro)
                {
                    rollx = rand.Next(1, MapWidth);
                    rolly = rand.Next(1, MapHeight);
                    ro.X = 9 + 50 * rollx;
                    ro.Y = 9 + 50 * rolly;
                    rollx = 0;
                    rolly = 0;
                }
            }
            this.Refresh();
        }

        public void Messages()
        {
            foreach (Hero n in H)
            {
                foreach (Goblin g in G)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (((n.X - g.X > 50 && n.X - g.X < 75) && ((n.Y - g.Y > 50 && n.Y - g.Y < 75) || (g.Y - n.Y > 50 && g.Y - n.Y < 75))) || ((g.X - n.X > 50 && g.X - n.X < 75) && ((n.Y - g.Y > 50 && n.Y - g.Y < 75) || (g.Y - n.Y > 50 && g.Y - n.Y < 75))))
                        {
                            MainTextBox.Text = "Вы рядом с гоблином.";
                        }
                    }
                }
            }
        }

        public void Fight()
        {
 
        }

        private void LoadMap_Click(object sender, EventArgs e)
        {
            MassOfMapObjects = new int[MapWidth, MapHeight];
            int i, j, t, Buf = 0;
            using (StreamReader Reader = new StreamReader("L:\\mapCoord_2.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < MapHeight; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] {' ', ',', '.', ':', '\t'});
                        for (j = 0; j < MapWidth; j++)
                        {
                            Buf = Int32.Parse(SplitLine[j]);
                            MassOfMapObjects[j, i] = Buf;
                        }
                    }
                }
            }
            for (j = 0; j < MapHeight; j++)
            {
                for (i = 0; i < MapWidth; i++)
                {
                    t = MassOfMapObjects[i, j];
                    switch (t)
                    {
                        case 1:
                            Gr.Add(new Grass(i * 50, j * 50));
                            break;
                        case 2:
                            Wa.Add(new Water(i * 50, j * 50));
                            break;
                        case 3:
                            RoHo.Add(new RoadHorizontal(i * 50, j * 50));
                            break;
                        case 4:
                            RoVe.Add(new RoadVercital(i * 50, j * 50));
                            break;
                        case 5:
                            RoTUP.Add(new RoadTUP(i * 50, j * 50));
                            break;
                        case 6:
                            RoTRU.Add(new RoadTurnRightUp(i * 50, j * 50));
                            break;
                        case 7:
                            RoTLU.Add(new RoadTurnLeftUp(i * 50, j * 50));
                            break;
                    }
                }
            }
            this.Refresh();
        }

        private void inventory_Click(object sender, EventArgs e)
        {
            Inv.ShowDialog();
        }
    }
}
