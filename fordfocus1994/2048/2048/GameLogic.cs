using System;

namespace _2048
{
    class GameLogic
    {
        Random rand = new Random();
        public void MoveLeft(ref MainSquare mainSquare)
        {
            bool isSpotChanged = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (mainSquare.SquareMatrix[k, i] != 0)
                        {
                            if (mainSquare.SquareMatrix[k, i] == mainSquare.SquareMatrix[j, i])
                            {
                                mainSquare.SquareMatrix[k, i] = 0;
                                mainSquare.SquareMatrix[j, i] *= 2;
                                mainSquare.Score += mainSquare.SquareMatrix[j, i];
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                            }
                            break;
                        }
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    if (mainSquare.SquareMatrix[j, i] == 0)
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (mainSquare.SquareMatrix[k, i] != 0)
                            {
                                mainSquare.SquareMatrix[j, i] = mainSquare.SquareMatrix[k, i];
                                mainSquare.SquareMatrix[k, i] = 0;
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (isSpotChanged)
                CreateNewSquareNumber(ref mainSquare);
        }
        public void MoveRight(ref MainSquare mainSquare)
        {
            bool isSpotChanged = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 1; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (mainSquare.SquareMatrix[k, i] != 0)
                        {
                            if (mainSquare.SquareMatrix[k, i] == mainSquare.SquareMatrix[j, i])
                            {
                                mainSquare.SquareMatrix[k, i] = 0;
                                mainSquare.SquareMatrix[j, i] *= 2;
                                mainSquare.Score += mainSquare.SquareMatrix[j, i];
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                            }
                            break;
                        }
                    }
                }
                for (int j = 3; j >= 1; j--)
                {
                    if (mainSquare.SquareMatrix[j, i] == 0)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (mainSquare.SquareMatrix[k, i] != 0)
                            {
                                mainSquare.SquareMatrix[j, i] = mainSquare.SquareMatrix[k, i];
                                mainSquare.SquareMatrix[k, i] = 0;
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (isSpotChanged)
                CreateNewSquareNumber(ref mainSquare);
        }
        public void MoveUp(ref MainSquare mainSquare)
        {
            bool isSpotChanged = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = j+1; k < 4; k++)
                    {
                        if (mainSquare.SquareMatrix[i,k] != 0)
                        {
                            if (mainSquare.SquareMatrix[i, k] == mainSquare.SquareMatrix[i, j])
                            {
                                mainSquare.SquareMatrix[i, k] = 0;
                                mainSquare.SquareMatrix[i, j] *= 2;
                                mainSquare.Score += mainSquare.SquareMatrix[i, j];
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                            }
                            break;
                        }
                    }
                }
                for (int j = 0; j < 3; j++)
                {
                    if (mainSquare.SquareMatrix[i,j] == 0)
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (mainSquare.SquareMatrix[i,k] != 0)
                            {
                                mainSquare.SquareMatrix[i,j] = mainSquare.SquareMatrix[i,k];
                                mainSquare.SquareMatrix[i,k] = 0;
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (isSpotChanged)
                CreateNewSquareNumber(ref mainSquare);
        }
        public void MoveDown(ref MainSquare mainSquare)
        {
            bool isSpotChanged = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 1; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (mainSquare.SquareMatrix[i, k] != 0)
                        {
                            if (mainSquare.SquareMatrix[i, k] == mainSquare.SquareMatrix[i, j])
                            {
                                mainSquare.SquareMatrix[i, k] = 0;
                                mainSquare.SquareMatrix[i, j] *= 2;
                                mainSquare.Score += mainSquare.SquareMatrix[i, j];
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                            }
                            break;
                        }
                    }
                }
                for (int j = 3; j >= 1; j--)
                {
                    if (mainSquare.SquareMatrix[i, j] == 0)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (mainSquare.SquareMatrix[i, k] != 0)
                            {
                                mainSquare.SquareMatrix[i, j] = mainSquare.SquareMatrix[i, k];
                                mainSquare.SquareMatrix[i, k] = 0;
                                if (!isSpotChanged)
                                    isSpotChanged = true;
                                break;
                            }
                        }
                    }
                }
            }
            if (isSpotChanged)
                CreateNewSquareNumber(ref mainSquare);
        }
        public void Start(ref MainSquare mainSquare)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    mainSquare.SquareMatrix[i, j] = 0;

            CreateNewSquareNumber(ref mainSquare);
            CreateNewSquareNumber(ref mainSquare);
        }
        public void CreateNewSquareNumber(ref MainSquare mainSquare)
        {
            bool isValueCreated = false;
            int rollx = 0, rolly = 0;
            do
            {
                rollx = rand.Next(0,4);
                rolly = rand.Next(0,4);
                if(mainSquare.SquareMatrix[rollx,rolly] == 0)
                {
                    if (rand.Next(1, 11) <= 9)
                        mainSquare.SquareMatrix[rollx, rolly] = 2;
                    else
                        mainSquare.SquareMatrix[rollx, rolly] = 4;
                    isValueCreated = true;
                }
            } while (!isValueCreated);
        }
        public GameLogic()
        { }
    }
}
