using System;

namespace Hra
{
    class Menu
    {
        public static void ShowMenu()
        {
            Console.Clear();
            Console.CursorVisible = true;

            var optionSelected = 1;
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(" Začít hrát" + "\n Ovládání a Informace" + "\n Konec");
            }
            while (true)
            {
                Console.SetCursorPosition(0, optionSelected);
                ConsoleKeyInfo pressedButton = Console.ReadKey();
                if (pressedButton.Key == ConsoleKey.DownArrow || pressedButton.Key == ConsoleKey.RightArrow)
                {
                    if (optionSelected == 3)
                    {
                        optionSelected = 1;
                    }
                    else
                    {
                        optionSelected += 1;
                    }
                }
                else if (pressedButton.Key == ConsoleKey.UpArrow || pressedButton.Key == ConsoleKey.LeftArrow)
                {
                    if (optionSelected == 1)
                    {
                        optionSelected = 3;
                    }
                    else if (optionSelected == 2)
                    {
                        optionSelected = 1;
                    }
                    else
                    {
                        optionSelected = 2;
                    }
                }
                else if (pressedButton.Key == ConsoleKey.Enter || pressedButton.Key == ConsoleKey.Spacebar)
                {
                    if (optionSelected == 1)
                    {
                        Console.Clear();
                        Map.DrawMap();
                    }
                    else if (optionSelected == 2)
                    {
                        ShowOptions();
                    }
                    else if (optionSelected == 3)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Neplatná klávesa prosím zkuste to znovu");
                    System.Threading.Thread.Sleep(2000);
                    ShowMenu();
                }
            }
        }
        private static void ShowOptions()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nOVLÁDÁNÍ\n");
            Console.ResetColor();
            Console.WriteLine("Pohyb: Šipky\nAkce a potvrzení: Enter nebo Mezerník\nOdejít ze hry: Escpace\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nINFORMACE O HŘE\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("@");
            Console.ResetColor();
            Console.Write(" : hráč\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("@");
            Console.ResetColor();
            Console.Write(" : hráč poblíž úkolu\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("W");
            Console.ResetColor();
            Console.Write(" : nepřítel\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("W");
            Console.ResetColor();
            Console.Write(" : pohyblivá plocha\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("I");
            Console.ResetColor();
            Console.Write(" : překážka\n");
            Console.Write("\nCíl hry : Zabij tři nepřátele");
            Console.ReadKey();
            ShowMenu();

        }
    }
}
