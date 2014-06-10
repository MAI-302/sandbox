using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameGraphics
{
    public partial class Inventory : Form
    {
        List<Weapon> Weap = new List<Weapon>();
        List<Armor> Arm = new List<Armor>();
        List<Accessory> Accs = new List<Accessory>();
        Equipment[] Spots = new Equipment[17];
        DropItems Drop = new DropItems();
        /// <summary>
        /// Перечисление названий слотов для предметов.
        /// </summary>
        private enum ItemSpots { Шлем = 0, Амулет, Плащ, Наплечники, Наручи, Перчатки, Кольцо, Нагрудник, Рубаха, Пояс, Поножи, Сапоги, Аксессуар, Одноручное, Двуручное}

        /// <summary>
        /// Количество предметов
        /// </summary>
        int countItems;
        /// <summary>
        /// Координаты отрисовки предметов в сумке.
        /// </summary>
        int xCoord, yCoord;
        /// <summary>
        /// Изображение предмета.
        /// </summary>
        Image ImageForItem;
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public Inventory()
        {
            countItems = 0;
            xCoord = 0;
            yCoord = 0;
            InitializeComponent();
            SpotsCreation();
        }
        /// <summary>
        /// Выход из инвентаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Создание слотов для предметов, их типов
        /// </summary>
        public void SpotsCreation()
        {
            for (int i = 0; i < 17; i++)
            {
                Spots[i] = new Equipment();
                Spots[i].spotImage = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\spotImage.png");
                Spots[i].isEquipped = false;
            }

            Spots[0].spotName = "Шлем";
            Spots[0].spotX = 125;
            Spots[0].spotY = 5;

            Spots[1].spotName = "Амулет";
            Spots[1].spotX = 125;
            Spots[1].spotY = 70;

            Spots[2].spotName = "Плащ";
            Spots[2].spotX = 190;
            Spots[2].spotY = 70;

            Spots[3].spotName = "Наплечники";
            Spots[3].spotX = 60;
            Spots[3].spotY = 70;

            Spots[4].spotName = "Наручи";
            Spots[4].spotX = 60;
            Spots[4].spotY = 200;

            Spots[5].spotName = "Перчатки";
            Spots[5].spotX = 60;
            Spots[5].spotY = 135;

            Spots[6].spotName = "Кольцо 1";
            Spots[6].spotX = 190;
            Spots[6].spotY = 135;

            Spots[7].spotName = "Кольцо 2";
            Spots[7].spotX = 190;
            Spots[7].spotY = 200;

            Spots[8].spotName = "Нагрудник";
            Spots[8].spotX = 125;
            Spots[8].spotY = 135;

            Spots[9].spotName = "Рубаха";
            Spots[9].spotX = 125;
            Spots[9].spotY = 200;

            Spots[10].spotName = "Пояс";
            Spots[10].spotX = 125;
            Spots[10].spotY = 265;

            Spots[11].spotName = "Поножи";
            Spots[11].spotX = 125;
            Spots[11].spotY = 330;

            Spots[12].spotName = "Сапоги";
            Spots[12].spotX = 125;
            Spots[12].spotY = 395;

            Spots[13].spotName = "Аксессуар 1";
            Spots[13].spotX = 60;
            Spots[13].spotY = 330;

            Spots[14].spotName = "Аксессуар 2";
            Spots[14].spotX = 190;
            Spots[14].spotY = 330;

            Spots[15].spotName = "Правая рука";
            Spots[15].spotX = 60;
            Spots[15].spotY = 265;

            Spots[16].spotName = "Левая рука";
            Spots[16].spotX = 190;
            Spots[16].spotY = 265;
        }
        /// <summary>
        /// Отображение изображений в сумке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bag_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Weap.Count; i++)
                if (!Weap[i].isItemEquipped)
                    e.Graphics.DrawImage(Weap[i].itemImage, Weap[i].itemX, Weap[i].itemY);
            for (int i = 0; i < Arm.Count; i++)
                if (!Arm[i].isItemEquipped)
                    e.Graphics.DrawImage(Arm[i].itemImage, Arm[i].itemX, Arm[i].itemY);
            for (int i = 0; i < Accs.Count; i++)
                if (!Accs[i].isItemEquipped)
                    e.Graphics.DrawImage(Accs[i].itemImage, Accs[i].itemX, Accs[i].itemY);
        }
        /// <summary>
        /// Кнопка вызова функции генерации предмета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateItemButton_Click(object sender, EventArgs e)
        {
            Drop.Drop();
            textBox1.Text = Drop.ItemName1;
            textBox1.Text = textBox1.Text + Environment.NewLine;
            for (int i = 0; i < Drop.statsCount1; i++)
                textBox1.Text = textBox1.Text + Environment.NewLine + Drop.StatName[i] + "      " + " + " + Drop.StatsValues[i];

            switch (Drop.ItemSpot1)
            {
                case "Одноручное":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\OneHand.png");
                    Weap.Add(new Weapon(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Двуручное":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\TwoHand.png");
                    Weap.Add(new Weapon(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Шлем":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Helm.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Наплечники":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\naplechniki.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Нагрудник":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Chest.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Поножи":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Greaves.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Сапоги":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Boots.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Плащ":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Cloak.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Рубаха":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Shirt.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Наручи":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Bracers.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Перчатки":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Gloves.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Пояс":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Belt.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Щит":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Shield.png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Кольцо":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Ring.png");
                    Accs.Add(new Accessory(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Амулет":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Amulet.png");
                    Accs.Add(new Accessory(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case "Аксессуар":
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\Accessory.png");
                    Accs.Add(new Accessory(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
            }
            countItems++;
            xCoord = (countItems % 11) * 60;
            if (countItems % 11 == 0)
                yCoord += 60;
            this.Refresh();
        }
        /// <summary>
        /// Отображение предметов в инвентаре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpotsForItems_Paint(object sender, PaintEventArgs e)
        {
            foreach (Equipment eq in Spots)
                e.Graphics.DrawImage(eq.spotImage, eq.spotX, eq.spotY);
            if (Spots[15].isEquipped)
                for (int i = 0; i < Weap.Count; i++)
                    if(Weap[i].isItemEquipped)
                        e.Graphics.DrawImage(Weap[i].itemImage, Spots[15].spotX, Spots[15].spotY);
            if (Spots[0].isEquipped)
                for (int i = 0; i < Arm.Count; i++)
                    if (Arm[i].isItemEquipped && Arm[i].itemType == "Шлем")
                        e.Graphics.DrawImage(Arm[i].itemImage, Spots[0].spotX, Spots[0].spotY);
        }
        /// <summary>
        /// Обработчик события нажатия на предмет в инвантаре.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpotsForItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < Weap.Count; i++)
                    if ((e.X >= Spots[15].spotX && e.X <= Spots[15].spotX + 60) && (e.Y >= Spots[15].spotY && e.Y <= Spots[15].spotY + 60))
                    {
                        Spots[15].isEquipped = false;
                        Weap[i].isItemEquipped = false;
                        if (Weap[i].itemType == "Двуручное")
                            Spots[16].isEquipped = false;
                        label1.Text = Weap[i].itemType + " снято";
                        this.Refresh();
                        break;
                    }
                for (int i = 0; i < Arm.Count; i++)
                    if ((e.X >= Spots[15].spotX && e.X <= Spots[15].spotX + 60) && (e.Y >= Spots[15].spotY && e.Y <= Spots[15].spotY + 60))
                    {
                        if (Arm[i].itemType == "Шлем")
                            Spots[0].isEquipped = false;
                        Arm[i].isItemEquipped = false;
                        this.Refresh();
                        break;
                    }
                /*foreach (Armor arm in Arm)
                {
                    if ((e.X >= Spots[12].spotX && e.X <= Spots[12].spotX + 60) && (e.Y >= Spots[12].spotY && e.Y <= Spots[12].spotY + 60))
                    {
                        Spots[12].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[11].spotX && e.X <= Spots[11].spotX + 60) && (e.Y >= Spots[11].spotY && e.Y <= Spots[11].spotY + 60))
                    {
                        Spots[11].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[10].spotX && e.X <= Spots[10].spotX + 60) && (e.Y >= Spots[10].spotY && e.Y <= Spots[10].spotY + 60))
                    {
                        Spots[10].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[9].spotX && e.X <= Spots[9].spotX + 60) && (e.Y >= Spots[9].spotY && e.Y <= Spots[9].spotY + 60))
                    {
                        Spots[9].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[8].spotX && e.X <= Spots[8].spotX + 60) && (e.Y >= Spots[8].spotY && e.Y <= Spots[8].spotY + 60))
                    {
                        Spots[8].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[5].spotX && e.X <= Spots[5].spotX + 60) && (e.Y >= Spots[5].spotY && e.Y <= Spots[5].spotY + 60))
                    {
                        Spots[5].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[4].spotX && e.X <= Spots[4].spotX + 60) && (e.Y >= Spots[4].spotY && e.Y <= Spots[4].spotY + 60))
                    {
                        Spots[4].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[3].spotX && e.X <= Spots[3].spotX + 60) && (e.Y >= Spots[3].spotY && e.Y <= Spots[3].spotY + 60))
                    {
                        Spots[3].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[2].spotX && e.X <= Spots[2].spotX + 60) && (e.Y >= Spots[2].spotY && e.Y <= Spots[2].spotY + 60))
                    {
                        Spots[2].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[0].spotX && e.X <= Spots[0].spotX + 60) && (e.Y >= Spots[0].spotY && e.Y <= Spots[0].spotY + 60))
                    {
                        Spots[0].isEquipped = false;
                        this.Refresh();
                    }
                }*/
                foreach (Accessory accs in Accs)
                {
                    if ((e.X >= Spots[14].spotX && e.X <= Spots[14].spotX + 60) && (e.Y >= Spots[14].spotY && e.Y <= Spots[14].spotY + 60))
                    {
                        Spots[14].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[13].spotX && e.X <= Spots[13].spotX + 60) && (e.Y >= Spots[13].spotY && e.Y <= Spots[13].spotY + 60))
                    {
                        Spots[13].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[7].spotX && e.X <= Spots[7].spotX + 60) && (e.Y >= Spots[7].spotY && e.Y <= Spots[7].spotY + 60))
                    {
                        Spots[7].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[6].spotX && e.X <= Spots[6].spotX + 60) && (e.Y >= Spots[6].spotY && e.Y <= Spots[6].spotY + 60))
                    {
                        Spots[6].isEquipped = false;
                        this.Refresh();
                    }
                    else if ((e.X >= Spots[1].spotX && e.X <= Spots[1].spotX + 60) && (e.Y >= Spots[1].spotY && e.Y <= Spots[1].spotY + 60))
                    {
                        Spots[1].isEquipped = false;
                        this.Refresh();
                    }
                }
            }
        }
        /// <summary>
        /// Обработчик события нажатия на предмет в сумке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bag_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < Weap.Count; i++)
                    if ((e.X >= Weap[i].itemX && e.X <= Weap[i].itemX + 60) && (e.Y >= Weap[i].itemY && e.Y <= Weap[i].itemY + 60))
                    {
                        Weap[i].isItemEquipped = true;
                        Spots[15].isEquipped = true;
                        if (Weap[i].itemType == "Двуручное")
                            Spots[16].isEquipped = true;
                        label1.Text = Weap[i].itemType + " экипировано";
                        this.Refresh();
                        break;
                    }
                for (int i = 0; i < Arm.Count; i++)
                    if ((e.X >= Arm[i].itemX && e.X <= Arm[i].itemX + 60) && (e.Y >= Arm[i].itemY && e.Y <= Arm[i].itemY + 60))
                        if (Arm[i].itemType == "Шлем")
                        {
                            Spots[0].isEquipped = true;
                            Arm[i].isItemEquipped = true;
                            this.Refresh();
                            break;
                        }
            }
        }
    }
}
