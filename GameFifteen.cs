namespace GameFifteen
{
    using System;

    public class GameFifteen
    {
        private static Player player = new Player();

        private static int[,] BoardNumbers;

        private static int currentBoardRow, currentBoardCol;
        private static bool repeat = true;
        private static bool userExit = false;

        private static string[] playersHighScore = new string[5];
        private static int highScore = 0;

        public static Player Player
        {
            get
            {
                return player;
            }
        }

        public static bool UserExit
        {
            get
            {
                return userExit;
            }
            set
            {
                userExit = value;
            }
        }

        public static bool Repeat
        {
            get
            {
                return repeat;
            }
            set
            {
                repeat = value;
            }
        }

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

                    player.GetCommand();

                    if (UserExit)
                    {
                        break;
                    }

                    isSolved = IsGameSolved();
                }

                if (isSolved)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", player.Score);

                    Console.Write("Please enter your name for the top scoreboard: ");

                    string name = Console.ReadLine();

                    string result = player.Score + " moves by " + name;

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

        public static void PrintTable()
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
        public static GameFacade gameFacade;
        private static void CreateGameField()
        {
            gameFactory = new GameFactory();
            gameSingleton = gameFactory.initGame;
            gameSingleton.CreateGameField();
            BoardNumbers = gameSingleton.BoardNumbers;
            player.ResetScore();
            currentBoardCol = gameSingleton.CurrentBoardCol;
            currentBoardRow = gameSingleton.CurrentBoardRow;
            gameFacade = new GameFacade(gameSingleton);
        }

        private static void Move(int number)
        {
            gameFacade.Operation(number.ToString());
            
            PrintTable();
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

        public static void RestartGame()
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

        public static void PrintTopHighScore()
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
