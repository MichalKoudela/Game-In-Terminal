using System;

namespace Hra
{
    class Map
    {
        public static void DrawMap()
        {
            var Map = new Map();

            Player player = new();
            int PlayerLocationY = 1;
            int PlayerLocationX = 1;

            bool GameIsRunning = true;
            bool renderWolf = true;
            bool renderDragon = true;
            bool renderBandit = true;

            while (GameIsRunning)
            {
                Console.SetCursorPosition(0, 0);
                for (int x = 0; x <= 29; x++)
                {
                    for (int y = 0; y <= 80; y++)
                    {
                        if ((y >= 1 && y < 80) && x == 0 || x == 29)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("O");
                            Console.ResetColor();
                        }
                        else if (y >= 1 && y < 80)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(" ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("O");
                            Console.ResetColor();
                        }

                    }
                    if (x != 29)
                    {
                        Console.WriteLine(" ");
                    }

                }

                switch (renderWolf)
                {
                    case true:
                        Console.SetCursorPosition(6, 6);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("W");
                        Console.ResetColor();
                        break;
                    case false:
                        break;
                }
                switch (renderDragon)
                {
                    case true:
                        Console.SetCursorPosition(48, 15);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("W");
                        Console.ResetColor();
                        break;
                    case false:
                        break;
                }
                switch (renderBandit)
                {
                    case true:
                        Console.SetCursorPosition(25, 18);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("W");
                        Console.ResetColor();
                        break;
                    case false:
                        break;
                }

                Console.SetCursorPosition(PlayerLocationY, PlayerLocationX);
                Map.PlayerLocationForegroundColor(PlayerLocationX, PlayerLocationY);
                Map.PlayerLocationBackgroundColor(PlayerLocationX, PlayerLocationY);
                Console.Write("@");
                Console.ResetColor();
                Console.CursorVisible = false;

                ConsoleKeyInfo pressedButton = Console.ReadKey();
                PlayerLocationX = Map.PlayerLocationXChange(pressedButton, PlayerLocationX);
                PlayerLocationY = Map.PlayerLocationYChange(pressedButton, PlayerLocationY);
                if (pressedButton.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (pressedButton.Key == ConsoleKey.Enter || pressedButton.Key == ConsoleKey.Spacebar)
                {
                    if (PlayerLocationX == 6 && PlayerLocationY == 6 && renderWolf == true)
                    {
                        player.FinishedQuests += 1;
                        renderWolf = false;
                        Fights.FightWithWolf();
                    }
                    else if (PlayerLocationX == 18 && PlayerLocationY == 25 && renderBandit == true)
                    {
                        player.FinishedQuests += 1;
                        renderBandit = false;
                        Fights.FightWithBandit();
                    }
                    else if (PlayerLocationX == 15 && PlayerLocationY == 48 && renderDragon == true)
                    {
                        player.FinishedQuests += 1;
                        renderDragon = false;
                        Fights.FightWithDragon();
                    }
                    else
                    {
                        //nic se nestane
                    }
                }
                GameIsRunning = Map.GamesEnd(player.FinishedQuests);
            }
            Menu.ShowMenu();
        }
        private int PlayerLocationYChange(ConsoleKeyInfo pressedButton, int PlayerLocationY)
        {
            if (pressedButton.Key == ConsoleKey.LeftArrow)
            {
                if (PlayerLocationY == 1)
                {
                    return PlayerLocationY -= 0;
                }
                else
                {
                    return PlayerLocationY -= 1;
                }

            }
            else if (pressedButton.Key == ConsoleKey.RightArrow)
            {
                if (PlayerLocationY == 79)
                {
                    return PlayerLocationY += 0;
                }
                else
                {
                    return PlayerLocationY += 1;
                }

            }
            else
            {
                return PlayerLocationY += 0;
            }

        }
        private int PlayerLocationXChange(ConsoleKeyInfo pressedButton, int PlayerLocationX)
        {
            if (pressedButton.Key == ConsoleKey.DownArrow)
            {
                if (PlayerLocationX == 28)
                {
                    return PlayerLocationX + 0;
                }
                else
                {
                    return PlayerLocationX + 1;
                }

            }
            else if (pressedButton.Key == ConsoleKey.UpArrow)
            {
                if (PlayerLocationX == 1)
                {
                    return PlayerLocationX - 0;
                }
                else
                {
                    return PlayerLocationX - 1;
                }
            }
            else
            {
                return PlayerLocationX += 0;
            }
        }
        private ConsoleColor PlayerLocationForegroundColor(int x, int y)
        {
            if ((x == 6 && y == 6) || (x == 15 && y == 48) || (x == 18 && y == 25))
            {
                return Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                return Console.ForegroundColor = ConsoleColor.Blue;
            }
        }
        private ConsoleColor PlayerLocationBackgroundColor(int x, int y)
        {
            if ((x == 6 && y == 6) || (x == 15 && y == 48) || (x == 18 && y == 25))
            {
                return Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else
            {
                return Console.BackgroundColor = ConsoleColor.Blue;
            }
        }
        private bool GamesEnd(int NumberOfCompletedQuests)
        {
            if (NumberOfCompletedQuests == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Vyhrál si hru !");
                Console.ResetColor();
                System.Threading.Thread.Sleep(4000);
                return false;
            }
            else
            {
                return true;

            }
        }
    }

}
