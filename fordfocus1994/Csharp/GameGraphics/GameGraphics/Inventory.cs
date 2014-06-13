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
        Equipment[] Spots = new Equipment[3];
        DropItems Drop = new DropItems();
        /// <summary>
        /// Названия слотов для предметов
        /// </summary>
        enum SpotsNames
        { Шлем = 0, Одноручное = 1, Двуручное = 2, Амулет, Плащ, Наплечники, Наручи, Перчатки, Кольцо, Нагрудник, Рубаха, Пояс, Поножи, Сапоги, Аксессуар, Щит }
        /// <summary>
        /// Координаты слотов инвентаря
        /// </summary>
        enum SpotsCoordinates { SpotHelmX = 125, SpotHelmY = 5, SpotOneHandX = 60, SpotOneHandY = 265, SpotTwoHandX = 190, SpotTwoHandY = 265 }
        /// <summary>
        /// Количество слотов предметов в строке сумки - ширина сумки
        /// </summary>
        private int ItemRowCount;
        /// <summary>
        /// Размер слота предмета
        /// </summary>
        private int Size;
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
        public Inventory(int ItemSpotSize, int ItemRowCount)
        {
            SpotsCreation();
            this.ItemRowCount = ItemRowCount;
            this.Size = ItemSpotSize;
            countItems = 0;
            xCoord = 0;
            yCoord = 0;
            InitializeComponent();
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
            for (int i = 0; i < Spots.Length; i++)
            {
                Spots[i] = new Equipment();
                Spots[i].spotImage = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\spotImage.png");
                Spots[i].isEquipped = false;
            }

            Spots[0].spotName = Convert.ToString(SpotsNames.Шлем);
            Spots[0].spotX = (int)SpotsCoordinates.SpotHelmX;
            Spots[0].spotY = (int)SpotsCoordinates.SpotHelmY;

            Spots[1].spotName = Convert.ToString(SpotsNames.Одноручное);
            Spots[1].spotX = (int)SpotsCoordinates.SpotOneHandX;
            Spots[1].spotY = (int)SpotsCoordinates.SpotOneHandX;

            Spots[2].spotName = Convert.ToString(SpotsNames.Двуручное);
            Spots[2].spotX = (int)SpotsCoordinates.SpotTwoHandX;
            Spots[2].spotY = (int)SpotsCoordinates.SpotTwoHandX;
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

            switch ((SpotsNames)Enum.ToObject(typeof(SpotsNames), Drop.ItemSpotNumber))
            {
                case SpotsNames.Одноручное:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Weap.Add(new Weapon(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Двуручное:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Weap.Add(new Weapon(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Шлем:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Наплечники:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Нагрудник:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Поножи:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Сапоги:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Плащ:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Рубаха:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Наручи:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Перчатки:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Пояс:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Щит:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Arm.Add(new Armor(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Кольцо:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Accs.Add(new Accessory(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Амулет:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Accs.Add(new Accessory(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
                case SpotsNames.Аксессуар:
                    ImageForItem = Image.FromFile(Environment.CurrentDirectory + @"\GamePictures\" + Enum.GetName(typeof(SpotsNames), Drop.ItemSpotNumber) + ".png");
                    Accs.Add(new Accessory(Drop.ItemName1, Drop.ItemSpot1, Drop.ItemLevel1, xCoord, yCoord, ImageForItem));
                    break;
            }
            countItems++;
            xCoord = (countItems % ItemRowCount) * Size;
            if (countItems % ItemRowCount == 0)
                yCoord += Size;
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
            {
                e.Graphics.DrawImage(eq.spotImage, eq.spotX, eq.spotY);
            }
            if (Spots[1].isEquipped)
                for (int i = 0; i < Weap.Count; i++)
                    if(Weap[i].isItemEquipped)
                        e.Graphics.DrawImage(Weap[i].itemImage, Spots[1].spotX, Spots[1].spotY);
            if (Spots[0].isEquipped)
                for (int i = 0; i < Arm.Count; i++)
                    if (Arm[i].isItemEquipped && Arm[i].itemType == (Convert.ToString(SpotsNames.Шлем)))
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
                    if ((e.X >= Spots[1].spotX && e.X <= Spots[1].spotX + Size) && (e.Y >= Spots[1].spotY && e.Y <= Spots[1].spotY + Size))
                    {
                        Spots[1].isEquipped = false;
                        Weap[i].isItemEquipped = false;
                        if (Weap[i].itemType == Convert.ToString(SpotsNames.Двуручное))
                            Spots[2].isEquipped = false;
                        this.Refresh();
                        break;
                    }
                for (int i = 0; i < Arm.Count; i++)
                    if ((e.X >= Spots[0].spotX && e.X <= Spots[0].spotX + Size) && (e.Y >= Spots[0].spotY && e.Y <= Spots[0].spotY + Size))
                    {
                        //if (Arm[i].itemType == Convert.ToString(SpotsNames.Шлем))
                        Spots[0].isEquipped = false;
                        Arm[i].isItemEquipped = false;
                        this.Refresh();
                        break;
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
                    if ((e.X >= Weap[i].itemX && e.X <= Weap[i].itemX + Size) && (e.Y >= Weap[i].itemY && e.Y <= Weap[i].itemY + Size))
                    {
                        Weap[i].isItemEquipped = true;
                        Spots[1].isEquipped = true;
                        if (Weap[i].itemType == Convert.ToString(SpotsNames.Двуручное))
                            Spots[2].isEquipped = true;
                        this.Refresh();
                        break;
                    }
                for (int i = 0; i < Arm.Count; i++)
                    if ((e.X >= Arm[i].itemX && e.X <= Arm[i].itemX + Size) && (e.Y >= Arm[i].itemY && e.Y <= Arm[i].itemY + Size))
                        if (Arm[i].itemType == Convert.ToString(SpotsNames.Шлем))
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
