﻿namespace GameFifteen
{
    using System;

    public class GameFifteen
    {
        private static int[,] BoardNumbers;

        private static int currentBoardRow, currentBoardCol;
        private static bool repeat = true;
        private static int counter;

        private static string[] playersHighScore = new string[5];
        private static int highScore = 0;

        public static void Main(string[] args)
        {
            while (repeat)
            {
                CreateGameField();
                Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n");
                PrintTable();

                bool isSolved = IsGameSolved();
                while (!isSolved)
                {
                    currentBoardRow = gameSingleton.CurrentBoardRow;
                    currentBoardCol = gameSingleton.CurrentBoardCol;
                    Console.Write("Enter a number to move: ");
                    string numberForMove = Console.ReadLine();
                    int number;
                    bool isIntNumber = int.TryParse(numberForMove, out number);
                    if (isIntNumber)
                    {
                        if (number >= 1 && number <= 15)
                        {
                            Move(number);
                        }
                        else
                        {
                            Console.WriteLine("Illegal move!");
                        }
                    }
                    else
                    {
                        if (numberForMove == "exit")
                        {
                            Console.WriteLine("Good bye!");
                            repeat = false;
                            break;
                        }
                        else
                        {
                            if (numberForMove == "restart")
                            {
                                RestartGame();
                            }
                            else
                            {
                                if (numberForMove == "top")
                                {
                                    PrintTopHighScore();
                                }
                                else
                                {
                                    Console.WriteLine("Illegal command!");
                                }
                            }
                        }
                    }

                    isSolved = IsGameSolved();
                }

                if (isSolved)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", counter);

                    Console.Write("Please enter your name for the top scoreboard: ");

                    string name = Console.ReadLine();

                    string result = counter + " moves by " + name;

                    if (highScore < 5)
                    {
                        playersHighScore[highScore] = result;

                        highScore++;

                        Array.Sort(playersHighScore);
                    }
                    else
                    {
                        for (int i = 4; i >= 0; i++)
                        {
                            if (playersHighScore[i].CompareTo(result) <= 0)
                            {
                                AddAndSort(i, result);
                            }
                        }
                    }

                    PrintTopHighScore();
                }
            }
        }

        private static void PrintTable()
        {
            Console.WriteLine(" -------------");
            for (int row = 0; row < 4; row++)
            {
                Console.Write("| ");
                for (int col = 0; col < 4; col++)
                {
                    if (BoardNumbers[row, col] >= 10)
                    {
                        Console.Write("{0} ", BoardNumbers[row, col]);
                    }
                    else
                    {
                        if (BoardNumbers[row, col] == 0)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0} ", BoardNumbers[row, col]);
                        }
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(" -------------");
        }



        public static GameFactory gameFactory;
        public static GameSingleton gameSingleton;

        private static void CreateGameField()
        {
            gameFactory = new GameFactory();
            gameSingleton = gameFactory.initGame;
            gameSingleton.CreateGameField();
            BoardNumbers = gameSingleton.BoardNumbers;
            counter = gameSingleton.Counter;
            currentBoardCol = gameSingleton.CurrentBoardCol;
            currentBoardRow = gameSingleton.CurrentBoardRow;
        }

        private static bool IsEmptyNeighbourCell(int row, int col)
        {
            if ((row == currentBoardRow - 1 || row == currentBoardRow + 1) && col == currentBoardCol)
            {
                return true;
            }

            if ((row == currentBoardRow) && (col == currentBoardCol - 1 || col == currentBoardCol + 1))
            {
                return true;
            }

            return false;
        }

        private static void Move(int number)
        {
            int row = currentBoardRow, col = currentBoardCol;
            bool isFoundNumber = false;
            for (int i = 0; i < 4; i++)
            {
                if (!isFoundNumber)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (gameSingleton.BoardNumbers[i, j] == number)
                        {
                            row = i;
                            col = j;
                            isFoundNumber = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            bool isFoundEmptyCell = IsEmptyNeighbourCell(row, col);
            if (!isFoundEmptyCell)
            {
                Console.WriteLine("Illegal move!");
            }
            else
            {
                int numberForSwap = gameSingleton.BoardNumbers[row, col];
                gameSingleton[row, col] = BoardNumbers[currentBoardRow, currentBoardCol];
                gameSingleton[currentBoardRow, currentBoardCol] = numberForSwap;
                gameSingleton.CurrentBoardRow = row;
                gameSingleton.CurrentBoardCol = col;
                counter++;
                PrintTable();
            }
        }

        private static bool IsGameSolved()
        {
            if (BoardNumbers[3, 3] == 0)
            {
                int numberInCurrentCell = 1;
                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (numberInCurrentCell <= 15)
                        {
                            if (BoardNumbers[row, col] == numberInCurrentCell)
                            {
                                numberInCurrentCell++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static void RestartGame()
        {
            CreateGameField();
            PrintTable();
        }

        private static void AddAndSort(int playerNumber, string result)
        {
            if (playerNumber == 0)
            {
                playersHighScore[playerNumber] = result;
            }

            for (int i = 0; i < playerNumber; i++)
            {
                playersHighScore[i] = playersHighScore[i + 1];
            }

            playersHighScore[playerNumber] = result;
        }

        private static void PrintTopHighScore()
        {
            Console.WriteLine("\nScoreboard:");
            if (highScore != 0)
            {
                for (int i = 5 - highScore; i < 5; i++)
                {
                    Console.WriteLine("{0}", playersHighScore[i]);
                }
            }
            else
            {
                Console.WriteLine("-");
            }

            Console.WriteLine();
        }
    }
}
