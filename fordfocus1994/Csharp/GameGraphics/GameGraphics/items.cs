using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace GameGraphics
{
    abstract class Items
    {
        public bool isItemEquipped;
        public string itemName;
        public string itemType;
        public string itemLevel;
        public int itemCost;
        public int itemCount;
        public int itemX, itemY;
        public int itemStatsCount;
        public int itemStatAdded;
        public Image itemImage;
    }
    class Weapon
        : Items 
    {
        public int weaponAttackMin;
        public int weaponAttackMax;
        public double weaponAttackSpeed;
        public Weapon(string name, string type, string level, int x, int y, Image Img)
        { 
            itemName = name;
            isItemEquipped = false;
            itemType = type;
            itemLevel = level;
            itemX = x;
            itemY = y;
            weaponAttackMin = 0;
            weaponAttackMax = 0;
            weaponAttackSpeed = 0;
            itemImage = Img;
        }
    }
    class Armor
        : Items 
    {
        public int armorDefence;
        public string armorType;
        public Armor(string name, string type, string level, int x, int y, Image Img)
        {
            itemName = name;
            isItemEquipped = false;
            itemType = type;
            itemLevel = level;
            itemX = x;
            itemY = y;
            armorDefence = 1;
            itemImage = Img;
        }
    }

    class Accessory
        : Items
    {
        public Accessory(string name, string type, string level, int x, int y, Image Img)
        {
            itemName = name;
            isItemEquipped = false;
            itemType = type;
            itemLevel = level;
            itemX = x;
            itemY = y;
            itemImage = Img;
        }
    }

    class QuestItem
        : Items
    {
        public QuestItem(string name, string level, int x, int y, Image Img)
        {
            itemName = name;
            itemType = "Quest item";
            itemLevel = level;
            itemX = x;
            itemY = y;
            itemImage = Img;
        }
    }

    class TrashItem
        : Items 
    {
        public TrashItem(string name, int x, int y, Image Img)
        {
            itemName = name;
            itemType = "Trash item";
            itemX = x;
            itemY = y;
            itemImage = Img;
        }
    }

    class Equipment
    {
        public bool isEquipped;
        public string spotName;
        public string itemEquipped;
        public int spotX;
        public int spotY;
        public Image spotImage;
        public Equipment()
        { 
        }
    }
}
