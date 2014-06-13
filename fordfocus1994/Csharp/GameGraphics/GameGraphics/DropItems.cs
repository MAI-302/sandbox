using System;
using System.IO;
using System.Text;

namespace GameGraphics
{
    public class DropItems
    {
        /// <summary>
        /// Переменные, отвечающие за случайно сгенерированные числа.
        /// </summary>
        private int roll, rollSupport, rollSupportAdditional;
        /// <summary>
        /// Переменная для уровневой группы героя.
        /// </summary>
        private int HeroLevelGroup;
        /// <summary>
        /// Прочие вспомогательные переменные - временное значение уровня героя для тестов, золото, количество характеристик на предмете и коэффициент усиления значений характеристик, зависящий от уровня предмета.
        /// </summary>
        public int HeroLevel = 39, gold, statsCount1, LevelRating, ItemSpotNumber;
        /// <summary>
        /// Прочие вспомогательные переменные, необходимые для генерации предметов.
        /// </summary>
        public string ItemSpot1, ItemLevel1, StatName1, ItemName1, ItemType, ItemSuffix = "", ItemPrefix = "";
        /// <summary>
        /// Массив, отвечающий за значения характеристик предметов.
        /// </summary>
        public int[] StatsValues;
        /// <summary>
        /// Название характеристики.
        /// </summary>
        public string[] StatName;
        /// <summary>
        /// Вспомогательные флаги для проверки генерируемых префиксов.
        /// </summary>
        public bool Prefix6Check, Prefix6Check1;
        /// <summary>
        /// Генератор случайных чисел.
        /// </summary>
        private Random rand = new Random();
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public DropItems()
        {}
        /// <summary>
        /// Чтение названий слотов для предметов из текстового файла.
        /// </summary>
        /// <returns>Массив массивов строк</returns>
        string[][] ReadItemNamesFile()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\SpotsNames.txt").Length;
            string[][] SpotsPossibleNames = new string[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\SpotsNames.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        string[] Buf = new string[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = SplitLine[j];
                        }
                        SpotsPossibleNames[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return SpotsPossibleNames;
        }
        /// <summary>
        /// Чтение названий преффиксов из текстового файла.
        /// </summary>
        /// <returns>Массив массивов строк</returns>
        string[][] ReadPrefixesArray()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\PrefixesArray.txt").Length;
            string[][] PrefixesArray = new string[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\PrefixesArray.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        string[] Buf = new string[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = SplitLine[j];
                        }
                        PrefixesArray[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return PrefixesArray;
        }
        /// <summary>
        /// Чтение названий суффиксов из текстового файла.
        /// </summary>
        /// <returns>Массив массивов строк</returns>
        string[][] ReadSuffixesArray()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\SuffixesArray.txt").Length;
            string[][] SuffixesArray = new string[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\SuffixesArray.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ',', '.', ':', '\t' });
                        string[] Buf = new string[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = SplitLine[j];
                        }
                        SuffixesArray[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return SuffixesArray;
        }
        /// <summary>
        /// Чтение значений характеристик для преффиксов из текстового файла.
        /// </summary>
        /// <returns>Массив массивов чисел.</returns>
        int[][] ReadPrefixesStatsValuesArray()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\PrefixesStatsValuesArray.txt").Length;
            int[][] PrefixesStatsValuesArray = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\PrefixesStatsValuesArray.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        }
                        PrefixesStatsValuesArray[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return PrefixesStatsValuesArray;
        }
        /// <summary>
        /// Чтение значений характеристик для суффиксов из текстового файла.
        /// </summary>
        /// <returns></returns>
        int[][] ReadSuffixesStatsValuesArray()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\SuffixesStatsValuesArray.txt").Length;
            int[][] SuffixesStatsArray = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\SuffixesStatsValuesArray.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        }
                        SuffixesStatsArray[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return SuffixesStatsArray;
        }
        /// <summary>
        /// Чтение названий характеристик преффиксов из текстового файла.
        /// </summary>
        /// <returns>Массив строк</returns>
        string[] ReadPrefixesStatsArray()
        {
            int i;
            int LinesCount = System.IO.File.ReadAllLines("L:\\PrefixesStatsArray.txt").Length;
            string[] PrefixesStatsArray = new string[LinesCount];
            using (StreamReader Reader = new StreamReader("L:\\PrefixesStatsArray.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        PrefixesStatsArray[i] = Reader.ReadLine();
                    }
                }
                Reader.Close();
            }
            return PrefixesStatsArray;
        }
        /// <summary>
        /// Чтение названий характеристик суффиксов из текстового файла.
        /// </summary>
        /// <returns>Массив строк</returns>
        string[] ReadSuffixesStatsArray()
        {
            int i;
            int LinesCount = System.IO.File.ReadAllLines("L:\\SuffixesStatsArray.txt").Length;
            string[] SuffixesStatsArray = new string[LinesCount];
            using (StreamReader Reader = new StreamReader("L:\\SuffixesStatsArray.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                    for (i = 0; i < LinesCount; i++)
                        SuffixesStatsArray[i] = Reader.ReadLine();
                Reader.Close();
            }
            return SuffixesStatsArray;
        }
        /// <summary>
        /// Чтение границ для броска случайного числа для определения уровня предмета.
        /// </summary>
        /// <returns>Массив массивов чисел</returns>
        int[][] ReadBorderValuesForItemLevelsGeneration()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\BorderValuesForItemLevelGeneration.txt").Length;
            int[][] BorderValuesItemsLevels = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\BorderValuesForItemLevelGeneration.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        BorderValuesItemsLevels[i] = Buf;
                    }
                Reader.Close();
            }
            return BorderValuesItemsLevels;
        }
        /// <summary>
        /// Чтение границ для броска случайного числа для определения градации характеристики предмета.
        /// </summary>
        /// <returns>Массив массивов чисел</returns>
        int[][] ReadBorderValues6Levels()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\BorderValues6Levels.txt").Length;            
            int[][] BorderValues6Levels = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\BorderValues6Levels.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        BorderValues6Levels[i] = Buf;
                    }
                Reader.Close();
            }
            return BorderValues6Levels;
        }
        /// <summary>
        /// Чтение границ для броска случайного числа для определения градации характеристики предмета.
        /// </summary>
        /// <returns>Массив массивов чисел</returns>
        int[][] ReadBorderValues5Levels()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\BorderValues5Levels.txt").Length;
            int[][] BorderValues5Levels = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\BorderValues5Levels.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        }
                        BorderValues5Levels[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return BorderValues5Levels;
        }
        /// <summary>
        /// Чтение границ для броска случайного числа для определения градации характеристики предмета.
        /// </summary>
        /// <returns>Массив массивов чисел</returns>
        int[][] ReadBorderValues2Levels()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\BorderValues2Levels.txt").Length;
            int[][] BorderValues2Levels = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\BorderValues2Levels.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                        {
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        }
                        BorderValues2Levels[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return BorderValues2Levels;
        }
        /// <summary>
        /// Чтение числовых аналогов названий слотов предметов
        /// </summary>
        /// <returns></returns>
        int[][] ReadSpotsNumbers()
        {
            int i, j;
            int LinesCount = System.IO.File.ReadAllLines("L:\\SpotsNumbers.txt").Length;
            int[][] SpotsNumbers = new int[LinesCount][];
            using (StreamReader Reader = new StreamReader("L:\\SpotsNumbers.txt", Encoding.Default))
            {
                while (!Reader.EndOfStream)
                {
                    for (i = 0; i < LinesCount; i++)
                    {
                        string MassiveLine = Reader.ReadLine();
                        string[] SplitLine = MassiveLine.Split(new Char[] { ' ', ',', '.', ':', '\t' });
                        int[] Buf = new int[SplitLine.Length];
                        for (j = 0; j < SplitLine.Length; j++)
                            Buf[j] = Int32.Parse(SplitLine[j]);
                        SpotsNumbers[i] = Buf;
                    }
                }
                Reader.Close();
            }
            return SpotsNumbers;
        }
        /// <summary>
        /// Генерация типа предмета.
        /// </summary>
        /// <returns>Тип предмета</returns>
        string CreateItemSpot()
        {
            string ItemSpot = "";
            string[][] ItemSpots = ReadItemNamesFile();
            int[][] ItemValues = ReadSpotsNumbers();
            roll = rand.Next(1, 11);
            if (roll < 3)
            {
                rollSupport = rand.Next(1,5);
                if (rollSupport < 4)
                {
                    ItemSpot = ItemSpots[0][0];
                    ItemSpotNumber = ItemValues[0][0];
                }
                if (rollSupport >= 4)
                {
                    ItemSpot = ItemSpots[0][1];
                    ItemSpotNumber = ItemValues[0][1];
                }
                ItemType = "Оружие";
            }
            else if (roll > 2 && roll < 10)
            {
                rollSupport = rand.Next(1, 6);
                if (rollSupport == 1 || rollSupport == 2)
                {
                    rollSupportAdditional = rand.Next(1, 6);
                    ItemSpot = ItemSpots[1][rollSupportAdditional - 1];
                    ItemSpotNumber = ItemValues[1][rollSupportAdditional - 1];
                    ItemType = "Тяжелый доспех";
                }
                if (rollSupport == 3 || rollSupport == 4)
                {
                    rollSupportAdditional = rand.Next(1, 6);
                    ItemSpot = ItemSpots[2][rollSupportAdditional - 1];
                    ItemSpotNumber = ItemValues[2][rollSupportAdditional - 1];    
                    ItemType = "Легкий доспех";
                }
                if (rollSupport == 5)
                {
                    ItemSpot = ItemSpots[3][0];
                    ItemSpotNumber = ItemValues[3][0];
                    ItemType = "Щит";
                }
            }
            else if (roll == 10)
            {
                rollSupport = rand.Next(1, 4);
                ItemSpot = ItemSpots[4][rollSupport - 1];
                ItemSpotNumber = ItemValues[4][rollSupport - 1];
                ItemType = "Аксессуар";
            }
            return ItemSpot;
        }
        /// <summary>
        /// Генерация уровня предмета.
        /// </summary>
        /// <param name="HeroLevelGroupLocal">Уровневая группа героя, которая влияет на генерируемый уровень предмета.</param>
        /// <returns>Уровень предмета</returns>
        string CreateItemLevel(int HeroLevelGroupLocal)
        {
            int[][] BorderValues = ReadBorderValuesForItemLevelsGeneration();
            string ItemLevelLocal = "";
            roll = rand.Next(1, 501);
            if (roll >= BorderValues[HeroLevelGroupLocal - 1][2])
                ItemLevelLocal = "Редкий";
            else if (roll >= BorderValues[HeroLevelGroupLocal - 1][1])
                ItemLevelLocal = "Необычный";
            else if (roll >= BorderValues[HeroLevelGroupLocal - 1][0])
                ItemLevelLocal = "Обычный";
            return ItemLevelLocal;
        }
        /// <summary>
        /// Определения коэффициента увеличения характеристик.
        /// </summary>
        /// <param name="ItemLevel">Уровень предмета, влияющий на коэффициент увеличения характеристик</param>
        /// <returns>Коэффициент увеличения характеристик</returns>
        int GetLevelRating(string ItemLevel)
        {
            if (ItemLevel == "Редкий")
                return 4;
            if (ItemLevel == "Необычный")
                return 2;
            else 
                return 1;
        }
        /// <summary>
        /// Определение количества характеристик у предмета.
        /// </summary>
        /// <returns>Число характеристик</returns>
        int StatsCount()
        {
            string[][] Prefixes = ReadPrefixesArray();
            int statsCount = 0;
            if (ItemPrefix != "")
            {
                for (int i = 0; i < Prefixes[6].Length; i++)
                    if (ItemPrefix == Prefixes[6][i])
                        statsCount++;
                statsCount++;
            }
            if (ItemSuffix != "")
                statsCount++;
            return statsCount;
        }
        /// <summary>
        /// Определение уровневой группы героя.
        /// </summary>
        /// <param name="HeroLevelLocal">Уровень героя.</param>
        /// <returns></returns>
        int HeroLevelGroupGeneration(int HeroLevelLocal)
        {
            return (HeroLevelLocal/7) + 1;
        }
        /// <summary>
        /// Определениие названия характеристики.
        /// </summary>
        /// <param name="StatNameReceived">Название характеристики предмета</param>
        /// <returns>Уровневая группа</returns>
        string StatsNameGeneration(string StatNameReceived)
        {
            string[][] Suffixes = ReadSuffixesArray();
            string[][] Prefixes = ReadPrefixesArray();
            string[] SuffixesNames = ReadSuffixesStatsArray();
            string[] PrefixesNames = ReadPrefixesStatsArray();
            string StatNameLocal = "";
            for (int i = 0; i < Suffixes.Length; i++)
                for (int j = 0; j < Suffixes[i].Length; j++)
                    if (StatNameReceived == Suffixes[i][j])
                        return SuffixesNames[i];
            for (int i = 0; i < Prefixes[6].Length; i++)
                if (StatNameReceived == Prefixes[6][i])
                {
                    Prefix6Check = !Prefix6Check;
                    return PrefixesNames[Prefix6Check ? 4 : 5];
                }
            for (int i = 0; i < Prefixes.Length; i++)
                for (int j = 0; j < Prefixes[i].Length; j++)
                    if (StatNameReceived == Prefixes[i][j])
                        return PrefixesNames[i];
            return StatNameLocal;
        }
        /// <summary>
        /// Определение значения характеристики.
        /// </summary>
        /// <param name="StatNameReceived">Название характеристики предмета</param>
        /// <param name="LevelRatingLocal">Коэффициент увеличения значения характеристики</param>
        /// <returns>Значение характеристики</returns>
        int StatsValueGeneration(string StatNameReceived, int LevelRatingLocal)
        {
            string[][] Suffixes = ReadSuffixesArray();
            string[][] Prefixes = ReadPrefixesArray();
            int[][] PrefixesStatsValues = ReadPrefixesStatsValuesArray();
            int[][] SuffixesStatsValues = ReadSuffixesStatsValuesArray();
            int StatValueAdded = 0;
            int i, j;
            for (i = 0; i < Suffixes.Length; i++)
                for (j = 0; j < Suffixes[i].Length; j++)
                    if (StatNameReceived == Suffixes[i][j])
                    {
                        if (j == 0)
                            return rand.Next(1, SuffixesStatsValues[i][j]) * LevelRatingLocal;
                        else if (j > 0)
                            return rand.Next(SuffixesStatsValues[i][j - 1], SuffixesStatsValues[i][j]) * LevelRatingLocal;
                    }
            for (i = 0; i < Prefixes.Length; i++)
            {
                for (j = 0; j < Prefixes[i].Length; j++)
                {
                    if (StatNameReceived == Prefixes[6][j])
                    {
                        if (Prefix6Check1 == false)
                        {
                            Prefix6Check1 = true;
                            if (j == 0)
                                return rand.Next(1, PrefixesStatsValues[4][j]) * LevelRatingLocal;
                            else
                                return rand.Next(PrefixesStatsValues[4][j - 1], PrefixesStatsValues[4][j]) * LevelRatingLocal;
                        }
                        else if (Prefix6Check1 == true)
                        {
                            Prefix6Check1 = false;
                            if (j == 0)
                                return rand.Next(1, PrefixesStatsValues[5][j]) * LevelRatingLocal;
                            else
                                return rand.Next(PrefixesStatsValues[5][j - 1], PrefixesStatsValues[5][j]) * LevelRatingLocal;
                        }
                    }
                    else if (StatNameReceived != Prefixes[6][j] && StatNameReceived == Prefixes[i][j])
                    {
                        if (j == 0)
                            return rand.Next(1, PrefixesStatsValues[i][j]) * LevelRatingLocal;
                        else
                            return rand.Next(PrefixesStatsValues[i][j - 1], PrefixesStatsValues[i][j]) * LevelRatingLocal;
                    }
                }
            }
            return StatValueAdded;
        }
        /// <summary>
        /// Определение рода слова.
        /// </summary>
        /// <param name="ItemSpot"></param>
        /// <returns>Род слова</returns>
        string GetGender(string ItemSpot)
        {
            string Support = " ";
            char Sup = ItemSpot[ItemSpot.Length-1];
            if (Sup == 'о' || Sup == 'е')
            {
                Support = "Средний";
            }
            if (Sup == 'а' || Sup == 'ь')
            {
                Support = "Женский";
            }
            if (Sup == 'и' || Sup == 'ы')
            {
                Support = "Много";
            }
            else if (Sup != 'о' && Sup != 'е' && Sup != 'а' && Sup != 'ь' && Sup != 'и' && Sup != 'ы')
            {
                Support = "Мужской";
            }
            return Support;
        }
        /// <summary>
        /// Получение итогового названия уровня предмета.
        /// </summary>
        /// <param name="ItemLevel">Уровень предмета</param>
        /// <param name="Gender">Род уровня предмета</param>
        /// <returns>Название уровня предмета</returns>
        string GetItemLevelName(string ItemLevel, string Gender)
        {
            string Support = " ";
            if (ItemLevel == "Редкий")
                Support = "Редк";
            if (ItemLevel == "Необычный")
                Support = "Необычн";
            if (ItemLevel == "Обычный")
                Support = "Обычн";

            if (Gender == "Средний")
                Support += "ое";
            if (Gender == "Женский")
                Support += "ая";
            if (Gender == "Много")
            {
                if (Support == "Редк")
                    Support += "ие";
                else
                    Support += "ые";
            }
            if (Gender == "Мужской")
            {
                if (Support == "Редк")
                    Support += "ий";
                else 
                    Support += "ый";
            }
            return Support;
        }
        /// <summary>
        /// Получение итогового названия префикса предмета
        /// </summary>
        /// <param name="ItemPrefixLocal">Корень префикса</param>
        /// <param name="Gender">Род префикса</param>
        /// <returns>Итоговое имя префикса</returns>
        string GetItemPrefixName(string ItemPrefixLocal, string Gender)
        {
            string Support = " ";
            if (Gender == "Средний")
            {
                if (ItemPrefixLocal == "Охотнич")
                    Support = ItemPrefixLocal + "ье";
                else
                    Support = ItemPrefixLocal + "ое";
            }
            if (Gender == "Женский")
            {
                if (ItemPrefixLocal == "Охотнич")
                {
                    Support = ItemPrefixLocal + "ья";
                }
                else
                {
                    Support = ItemPrefixLocal + "ая";
                }
            }
            if (Gender == "Много")
            {
                if (ItemPrefixLocal == "Космическ" || ItemPrefixLocal == "Воинск" || ItemPrefixLocal == "Солдатск" || ItemPrefixLocal == "Рыцарск" || ItemPrefixLocal == "Чемпионск" || ItemPrefixLocal == "Королевск" || ItemPrefixLocal == "Жесток" || ItemPrefixLocal == "Крепк" || ItemPrefixLocal == "Велик")
                {
                    Support = ItemPrefixLocal + "ие";
                }
                else if (ItemPrefixLocal == "Охотнич")
                {
                    Support = ItemPrefixLocal + "ьи";
                }
                else
                {
                    Support = ItemPrefixLocal + "ые";
                }
            }
            if (Gender == "Мужской")
            {
                if (ItemPrefixLocal == "Охотнич" || ItemPrefixLocal == "Космическ" || ItemPrefixLocal == "Воинск" || ItemPrefixLocal == "Солдатск" || ItemPrefixLocal == "Рыцарск" || ItemPrefixLocal == "Чемпионск" || ItemPrefixLocal == "Королевск" || ItemPrefixLocal == "Жесток" || ItemPrefixLocal == "Крепк" || ItemPrefixLocal == "Велик")
                {
                    Support = ItemPrefixLocal + "ий";
                }
                else if (ItemPrefixLocal == "Стальн" || ItemPrefixLocal == "Свят")
                {
                    Support = ItemPrefixLocal + "ой";
                }
                else
                {
                    Support = ItemPrefixLocal + "ый";
                }
            }
            return Support;
        }
        /// <summary>
        /// Генерация имени предмета.
        /// </summary>
        /// <param name="ItemSpot">Тип предмета</param>
        /// <param name="ItemLevel">Уровень предмета</param>
        /// <param name="HeroLevelGroupLocal">Уровневая группа героя</param>
        /// <returns>Название предмета</returns>
        string ItemNameGeneration(string ItemSpot, string ItemLevel, int HeroLevelGroupLocal)
        {
            string[][] ItemSpots = ReadItemNamesFile();
            string ItemNameConfirmed = "";
            string Support = "";
            string ItemPrefixName = "";
            string Gender, ItemLevelName;
            if (ItemSpot == ItemSpots[0][0])
            {
                roll = rand.Next(1,5);
                switch (roll)
                {
                    case 1:
                        Support = "Короткий меч";
                        break;
                    case 2:
                        Support = "Длинный меч";
                        break;
                    case 3:
                        Support = "Топор";
                        break;
                    case 4:
                        Support = "Молот";
                        break;
                }
                Gender = GetGender(Support);
                ItemLevelName = GetItemLevelName(ItemLevel, Gender);
                ItemPrefix = ChoosePrefix(HeroLevelGroupLocal);
                ItemSuffix = ChooseSuffix(HeroLevelGroupLocal);
                ItemPrefixName = GetItemPrefixName(ItemPrefix, Gender);
                ItemNameConfirmed = ItemLevelName + " " + ItemPrefixName + " " + Support + " " + ItemSuffix;
            }
            else if (ItemSpot == ItemSpots[0][1])
            {
                roll = rand.Next(1, 4);
                switch (roll)
                {
                    case 1:
                        Support = "Большой меч";
                        break;
                    case 2:
                        Support = "Алебарда";
                        break;
                    case 3:
                        Support = "Копье";
                        break;
                }
                Gender = GetGender(Support);
                ItemLevelName = GetItemLevelName(ItemLevel, Gender);
                ItemPrefix = ChoosePrefix(HeroLevelGroupLocal);
                ItemSuffix = ChooseSuffix(HeroLevelGroupLocal);
                ItemPrefixName = GetItemPrefixName(ItemPrefix, Gender);
                ItemNameConfirmed = ItemLevelName + " " + ItemPrefixName + " " + Support + " " + ItemSuffix;
            }
            else
            {
                Gender = GetGender(ItemSpot);
                ItemLevelName = GetItemLevelName(ItemLevel, Gender);
                ItemPrefix = ChoosePrefix(HeroLevelGroupLocal);
                ItemSuffix = ChooseSuffix(HeroLevelGroupLocal);
                ItemPrefixName = GetItemPrefixName(ItemPrefix, Gender);
                ItemNameConfirmed = ItemLevelName + " " + ItemPrefixName + " " + ItemSpot + " " + ItemSuffix;
            }
            return ItemNameConfirmed;
        }
        /// <summary>
        /// Генерация всех параметров предмета.
        /// </summary>
        void CreateItem()
        {
            HeroLevelGroup = HeroLevelGroupGeneration(HeroLevel);
            ItemLevel1 = CreateItemLevel(HeroLevelGroup);
            ItemSpot1 = CreateItemSpot();
            LevelRating = GetLevelRating(ItemLevel1);

            ItemName1 = ItemNameGeneration(ItemSpot1, ItemLevel1, HeroLevelGroup);
            statsCount1 = StatsCount();
            StatName = new string[statsCount1];
            StatsValues = new int[statsCount1];
            if (ItemPrefix != "")
            {
                for (int i = 0; i < statsCount1 - 1; i++)
                {
                    StatName[i] = StatsNameGeneration(ItemPrefix);
                    StatsValues[i] = StatsValueGeneration(ItemPrefix, LevelRating);
                }
            }
            if (ItemSuffix != "")
            {
                StatName[statsCount1 - 1] = StatsNameGeneration(ItemSuffix);
                StatsValues[statsCount1 - 1] = StatsValueGeneration(ItemSuffix, LevelRating);
            }
        }
        /// <summary>
        /// Выбор суффикса предмета.
        /// </summary>
        /// <param name="HeroLevelGroupLocal">Уровневая группа героя.</param>
        /// <returns>Суффикс предмета</returns>
        string ChooseSuffix(int HeroLevelGroupLocal)
        {
            int j;
            string Suffix = "";
            bool IsSuffixGenerated = false;
            string[][] Suffixes = ReadSuffixesArray();
            int[][] BorderValues2 = ReadBorderValues2Levels();
            int[][] BorderValues5 = ReadBorderValues5Levels();
            int[][] BorderValues6 = ReadBorderValues6Levels();
            if (IsSuffixGenerated == false)
            {
                rollSupport = rand.Next(1, 501);
                for (j = 0; j < BorderValues5[HeroLevelGroupLocal - 1].Length; j++)
                {
                    if (rollSupport >= BorderValues5[HeroLevelGroupLocal - 1][BorderValues5[HeroLevelGroupLocal - 1].Length - 1 - j])
                    {
                        roll = rand.Next(1, 201);
                        if (roll >= 167)//Сила
                        {
                            Suffix = Suffixes[0][Suffixes[0].Length - 1 - j];
                            IsSuffixGenerated = true;
                        }
                        else if (roll >= 134)//Ловкость
                        {
                            Suffix = Suffixes[1][Suffixes[1].Length - 1 - j];
                            IsSuffixGenerated = true;
                        }
                        else if (roll >= 100)//Живучесть
                        {
                            Suffix = Suffixes[2][Suffixes[2].Length - 1 - j];
                            IsSuffixGenerated = true;
                        }
                        else if (roll >= 67)//Интеллект
                        {
                            Suffix = Suffixes[3][Suffixes[3].Length - 1 - j];
                            IsSuffixGenerated = true;
                        }
                        else if (roll >= 34)//Здоровье
                        {
                            Suffix = Suffixes[4][Suffixes[4].Length - 1 - j];
                            IsSuffixGenerated = true;
                        }
                        else if (roll >= 1)//Мана
                        {
                            Suffix = Suffixes[5][Suffixes[5].Length - 1 - j];
                            IsSuffixGenerated = true;
                        }
                        break;
                    }
                }
                if (ItemType == "Оружие")
                {
                    roll = rand.Next(1, 101);
                    if (roll >= 45)
                    {
                        rollSupport = rand.Next(1, 101);
                        rollSupportAdditional = rand.Next(1, 501);
                        for (j = 0; j < BorderValues5[HeroLevelGroupLocal - 1].Length; j++)
                        {
                            if (rollSupportAdditional >= BorderValues5[HeroLevelGroupLocal - 1][BorderValues5[HeroLevelGroupLocal - 1].Length - 1 - j])
                            {
                                if (rollSupport >= 60)//Скорость
                                {
                                    IsSuffixGenerated = true;
                                    return Suffixes[11][Suffixes[11].Length - 1 - j];
                                }
                                else//Урон
                                {
                                    IsSuffixGenerated = true;
                                    return Suffixes[10][Suffixes[10].Length - 1 - j];
                                }
                            }
                        }
                    }
                    else if (roll >= 15)
                    {
                        rollSupport = rand.Next(1, 101);
                        rollSupportAdditional = rand.Next(1, 501);
                        for (j = 0; j < BorderValues2[HeroLevelGroupLocal - 1].Length; j++)
                        {
                            if (rollSupportAdditional >= BorderValues2[HeroLevelGroupLocal - 1][BorderValues2[HeroLevelGroupLocal - 1].Length - 1 - j])
                            {
                                if (rollSupport >= 50)//Лайфстил
                                {
                                    IsSuffixGenerated = true;
                                    return Suffixes[8][Suffixes[8].Length - 1 - j];
                                }
                                else//Манастил
                                {
                                    IsSuffixGenerated = true;
                                    return Suffixes[9][Suffixes[9].Length - 1 - j];
                                }
                            }
                        }
                    }
                }
                if (ItemType == "Легкий доспех" || ItemType == "Тяжелый доспех")
                {
                    roll = rand.Next(1, 101);
                    if (roll >= 60)//Уменьшение урона при ударе
                    {
                        rollSupportAdditional = rand.Next(1, 501);
                        for (j = 0; j < BorderValues5[HeroLevelGroupLocal - 1].Length; j++)
                        {
                            if (rollSupportAdditional >= BorderValues5[HeroLevelGroupLocal - 1][BorderValues5[HeroLevelGroupLocal - 1].Length - 1 - j])
                            {
                                IsSuffixGenerated = true;
                                return Suffixes[6][Suffixes[6].Length - 1 - j];
                            }
                        }
                    }
                }
                if (ItemType == "Щит")
                {
                    roll = rand.Next(1, 101);
                    if (roll >= 40)//Блокирование
                    {
                        IsSuffixGenerated = true;
                        return Suffixes[7][Suffixes[7].Length - 1];
                    }
                }
            }
            
            return Suffix;
        }
        /// <summary>
        /// Выбор префикса предмета.
        /// </summary>
        /// <param name="HeroLevelGroupLocal">Уровневая группа героя.</param>
        /// <returns>Префикс предмета</returns>
        string ChoosePrefix(int HeroLevelGroupLocal)
        {
            int j;
            string[][] Prefixes = ReadPrefixesArray();
            int[][] BorderValues2 = ReadBorderValues2Levels();
            int[][] BorderValues5 = ReadBorderValues5Levels();
            int[][] BorderValues6 = ReadBorderValues6Levels();
            roll = rand.Next(1, 101);
            rollSupport = rand.Next(1, 501);
            if (ItemType == "Оружие")
            {
                roll = rand.Next(1, 101);
                if (roll >= 10)
                {
                    for (j = 0; j < BorderValues6[HeroLevelGroupLocal - 1].Length; j++)
                    {
                        rollSupport = rand.Next(1, 101);
                        rollSupportAdditional = rand.Next(1, 501);
                        if (rollSupportAdditional >= BorderValues6[HeroLevelGroupLocal - 1][BorderValues6[HeroLevelGroupLocal - 1].Length - 1 - j])
                        {
                            if (rollSupport >= 65)//Меткость
                            {
                                return Prefixes[4][Prefixes[4].Length - 1 - j];
                            }
                            else if (rollSupport >= 35)//Урон
                            {
                                return Prefixes[5][Prefixes[5].Length - 1 - j];
                            }
                            else//Меткость + Урон
                            {
                                return Prefixes[6][Prefixes[6].Length - 1 - j];
                            }
                        }
                    }
                }
            }
            else if (ItemType == "Легкий доспех" || ItemType == "Тяжелый доспех")
            {
                roll = rand.Next(1, 101);
                if (roll >= 20)//Броня
                {
                    for (j = 0; j < BorderValues6[HeroLevelGroupLocal - 1].Length; j++)
                    {
                        rollSupportAdditional = rand.Next(1, 501);
                        if (rollSupportAdditional >= BorderValues6[HeroLevelGroupLocal - 1][BorderValues6[HeroLevelGroupLocal - 1].Length - 1 - j])
                        {
                            return Prefixes[3][Prefixes[3].Length - 1 - j];
                        }
                    }
                }
            }
            if (roll >= 67)//Все характеристики
            {
                for (j = 0; j < BorderValues5[HeroLevelGroupLocal - 1].Length; j++)
                {
                    if (rollSupport >= BorderValues5[HeroLevelGroupLocal - 1][BorderValues5[HeroLevelGroupLocal - 1].Length - 1 - j])
                    {
                        return Prefixes[0][Prefixes[0].Length - 1 - j];
                    }
                }
            }
            else if (roll >= 34)//Защита от магии
            {
                for (j = 0; j < BorderValues5[HeroLevelGroupLocal - 1].Length; j++)
                {
                    if (rollSupport >= BorderValues5[HeroLevelGroupLocal - 1][BorderValues5[HeroLevelGroupLocal - 1].Length - 1 - j])
                    {
                        return Prefixes[1][Prefixes[1].Length - 1 - j];
                    }
                }
            }
            else if (roll >= 1)//Крит
            {
                for (j = 0; j < BorderValues2[HeroLevelGroupLocal - 1].Length; j++)
                {
                    if (rollSupport >= BorderValues2[HeroLevelGroupLocal - 1][BorderValues2[HeroLevelGroupLocal - 1].Length - 1 - j])
                    {
                        return Prefixes[2][Prefixes[2].Length - 1 - j];
                    }
                }
            }
            return "";
        }
        /// <summary>
        /// Функция появления предмета.
        /// </summary>
        public void Drop()
        {
            /*roll = rand.Next(1, 1000);
            if (roll >= 888)
            {
                CreateItem();
            }
            roll = rand.Next(1, 15);
            gold = roll;*/
            CreateItem();
        }
    }
}