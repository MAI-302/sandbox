using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGraphics
{
    public partial class HeroCreation : Form
    {
        Hero H = new Hero();
        public int Race = 0;
        public HeroCreation()
        {
            InitializeComponent();
        }

        public void ConfirmCreation_Click(object sender, EventArgs e)
        {
            H.Name = HeroNameText.Text;
            switch (Race)
            {
                case 1:
                    H.Race = "Человек";
                    H.Strength = 10;
                    H.Agility = 10;
                    H.Vitality = 10;
                    H.Intellect = 10;
                    break;
                case 2:
                    H.Race = "Эльф";
                    H.Strength = 10;
                    H.Agility = 12;
                    H.Vitality = 8;
                    H.Intellect = 10;
                    break;
                case 3:
                    H.Race = "Полуэльф";
                    H.Strength = 8;
                    H.Agility = 10;
                    H.Vitality = 10;
                    H.Intellect = 12;
                    break;
                case 4:
                    H.Race = "Дворф";
                    H.Strength = 12;
                    H.Agility = 8;
                    H.Vitality = 12;
                    H.Intellect = 8;
                    break;
                case 5:
                    H.Race = "Гном";
                    H.Strength = 8;
                    H.Agility = 12;
                    H.Vitality = 8;
                    H.Intellect = 12;
                    break;
            }
            Close();
        }

        public void RaceSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (RaceSelect.Text)
            {
                case "Человек":
                    RaceInf.Text = "Сила = 10" + Environment.NewLine + "Ловкость = 10"  + Environment.NewLine + "Конституция = 10" + Environment.NewLine + "Интеллект = 10";
                    Race = 1;
                    break;
                case "Эльф":
                    RaceInf.Text = "Сила = 10" + Environment.NewLine + "Ловкость = 12" + Environment.NewLine + "Конституция = 8" + Environment.NewLine + "Интеллект = 10";
                    Race = 2;
                    break;
                case "Полуэльф":
                    RaceInf.Text = "Сила = 8" + Environment.NewLine + "Ловкость = 10" + Environment.NewLine + "Конституция = 10" + Environment.NewLine + "Интеллект = 12";
                    Race = 3;
                    break;
                case "Дворф":
                    RaceInf.Text = "Сила = 12" + Environment.NewLine + "Ловкость = 8" + Environment.NewLine + "Конституция = 12" + Environment.NewLine + "Интеллект = 8";
                    Race = 4;
                    break;
                case "Гном":
                    RaceInf.Text = "Сила = 8" + Environment.NewLine + "Ловкость = 12" + Environment.NewLine + "Конституция = 8" + Environment.NewLine + "Интеллект = 12";
                    Race = 5;
                    break;
            
            }
        }

        public void ExitButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string Data
        {
            get
            {
                return this.HeroNameText.Text;
            }
        }
    }
}
