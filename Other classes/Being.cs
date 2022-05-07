using System;

namespace Hra
{
    public abstract class Being
    {
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
    }
    #region EnemiesAndPlayer
    class Player : Being
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public int Armor { get; set; }
        public int FinishedQuests { get; set; }
        public Player()
        {
            this.FinishedQuests = 0;
            this.Health = 100;
            this.Damage = 30;
            this.Armor = 100;
        }
    }
    class Dragon : Being
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public Dragon()
        {
            this.Health = 200;
            this.Damage = 20;
        }
    }
    class Bandit : Being
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }
        public int Armor { get; set; }
        public Bandit()
        {
            this.Health = 60;
            this.Damage = 40;
            this.Armor = 60;
        }
    }
    class Wolf : Being
    {
        public override int Health { get; set; }
        public override int Damage { get; set; }

        public Wolf()
        {
            this.Health = 90;
            this.Damage = 30;
        }
    }
    #endregion
    public class Fights
    {
        public static void FightWithWolf()
        {
            int optionSelected = 1;
            Player player = new();
            Wolf wolf = new();
            Console.CursorVisible = true;
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.WriteLine("Chcete zaútočit ?");
                Console.WriteLine("Ano");
                Console.WriteLine("Ne");
                Console.SetCursorPosition(0, optionSelected);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (optionSelected == 2)
                    {
                        optionSelected -= 1;
                    }
                    else
                    {
                        optionSelected = 2;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (optionSelected == 1)
                    {
                        optionSelected += 1;
                    }
                    else
                    {
                        optionSelected = 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    if (optionSelected == 1)
                    {
                        wolf.Health -= player.Damage;
                        Console.WriteLine("Zaútočili jste na vlka jeho zdraví je " + wolf.Health);
                        if (player.Armor > 0 && player.Armor - wolf.Damage < 0)
                        {
                            player.Health -= wolf.Damage - player.Armor;
                            player.Armor = 0;
                        }
                        else if (player.Armor > 0)
                        {
                            player.Health -= (wolf.Damage / 5);
                            player.Armor -= (wolf.Damage);
                        }
                        else
                        {
                            player.Health -= wolf.Damage;
                        }
                        Console.WriteLine("Vlk zautočil tvoje zdraví je " + player.Health + " a tvoje zbroj je na " + player.Armor + " procentech");
                        Console.ReadKey();
                    }
                    else if (optionSelected == 2)
                    {
                        if (player.Armor > 0 && player.Armor - wolf.Damage < 0)
                        {
                            player.Health -= wolf.Damage - player.Armor;
                            player.Armor = 0;
                        }
                        if (player.Armor > 0)
                        {
                            player.Health -= (wolf.Damage / 5);
                            player.Armor -= (wolf.Damage);
                        }
                        else
                        {
                            player.Health -= wolf.Damage;
                        }
                        Console.WriteLine("Vlk zautočil tvoje zdraví je " + player.Health + " a tvoje zbroj je na " + player.Armor + " procentech");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("There has been error pleas try again");
                    Console.ReadKey();
                }
                if (wolf.Health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vyhrál si souboj !");
                    Console.ResetColor();
                    Console.WriteLine("Po boji sis opravil zbroj a vyléčil ses lektvarem");
                    Console.ReadKey();
                    break;
                }
                else if (player.Health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zemřel si !");
                    Console.ResetColor();
                    Console.ReadKey();
                    Menu.ShowMenu();
                }
            }
        }
        public static void FightWithDragon()
        {
            int optionSelected = 1;
            Player player = new();
            Dragon dragon = new();
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.WriteLine("Chcete zaútočit ?");
                Console.WriteLine("Ano");
                Console.WriteLine("Ne");
                Console.SetCursorPosition(0, optionSelected);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (optionSelected == 2)
                    {
                        optionSelected -= 1;
                    }
                    else
                    {
                        optionSelected = 2;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (optionSelected == 1)
                    {
                        optionSelected += 1;
                    }
                    else
                    {
                        optionSelected = 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    if (optionSelected == 1)
                    {
                        dragon.Health -= player.Damage;
                        Console.WriteLine("Zaútočili jste na malého draka jeho zdraví je " + dragon.Health);
                        if (player.Armor > 0 && player.Armor - dragon.Damage < 0)
                        {
                            player.Health -= dragon.Damage - player.Armor;
                            player.Armor = 0;
                        }
                        else if (player.Armor > 0)
                        {
                            player.Health -= (dragon.Damage / 5);
                            player.Armor -= (dragon.Damage);
                        }
                        else
                        {
                            player.Health -= dragon.Damage;
                        }
                        Console.WriteLine("Drak zautočil tvoje zdraví je " + player.Health + " a tvoje zbroj je na " + player.Armor + " procentech");
                        Console.ReadKey();
                    }
                    else if (optionSelected == 2)
                    {
                        if (player.Armor > 0 && player.Armor - dragon.Damage < 0)
                        {
                            player.Health -= dragon.Damage - player.Armor;
                            player.Armor = 0;
                        }
                        if (player.Armor > 0)
                        {
                            player.Health -= (dragon.Damage / 5);
                            player.Armor -= (dragon.Damage);
                        }
                        else
                        {
                            player.Health -= dragon.Damage;
                        }
                        Console.WriteLine("Drak zautočil tvoje zdraví je " + player.Health + " a tvoje zbroj je na " + player.Armor + " procentech");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Stala se chyba prosím zkuste to znovu");
                    Console.ReadKey();
                }
                if (dragon.Health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vyhrál si souboj !");
                    Console.ResetColor();
                    Console.WriteLine("Po boji sis opravil zbroj a vyléčil ses lektvarem");
                    Console.ReadKey();
                    break;
                }
                else if (player.Health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zemřel si !");
                    Console.ResetColor();
                    Console.ReadKey();
                    Menu.ShowMenu();
                }
            }
        }
        public static void FightWithBandit()
        {
            int optionSelected = 1;
            Player player = new();
            Bandit bandit = new();
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.WriteLine("Chcete zaútočit ?");
                Console.WriteLine("Ano");
                Console.WriteLine("Ne");
                Console.SetCursorPosition(0, optionSelected);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (optionSelected == 2)
                    {
                        optionSelected -= 1;
                    }
                    else
                    {
                        optionSelected = 2;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (optionSelected == 1)
                    {
                        optionSelected += 1;
                    }
                    else
                    {
                        optionSelected = 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    if (optionSelected == 1)
                    {
                        if (bandit.Armor > 0 && bandit.Armor - player.Damage < 0)
                        {
                            bandit.Health -= player.Damage - bandit.Armor;
                            bandit.Armor = 0;

                        }
                        else if (bandit.Armor > 0)
                        {
                            bandit.Armor -= player.Damage;
                            bandit.Health -= (player.Damage / 5);
                        }
                        else
                        {
                            bandit.Health -= player.Damage;
                        }
                        Console.WriteLine("Zaútočili jste na banditu jeho zdraví je " + bandit.Health + " a jeho štít je na " + bandit.Armor);

                        if (player.Armor > 0 && player.Armor - bandit.Damage < 0)
                        {
                            player.Health -= bandit.Damage - player.Armor;
                            player.Armor = 0;
                        }
                        else if (player.Armor > 0)
                        {
                            player.Health -= (bandit.Damage / 5);
                            player.Armor -= (bandit.Damage);
                        }
                        else
                        {
                            player.Health -= bandit.Damage;
                        }
                        Console.WriteLine("Bandita zautočil tvoje zdraví je " + player.Health + " a tvoje zbroj je na " + player.Armor + " procentech");
                        Console.ReadKey();
                    }
                    else if (optionSelected == 2)
                    {
                        if (player.Armor > 0 && player.Armor - bandit.Damage <= 0)
                        {
                            player.Health -= bandit.Damage - player.Armor;
                            player.Armor = 0;
                        }
                        else if (player.Armor > 0)
                        {
                            player.Health -= (bandit.Damage / 5);
                            player.Armor -= (bandit.Damage);
                        }
                        else
                        {
                            player.Health -= bandit.Damage;
                        }
                        Console.WriteLine("Bandita zautočil tvoje zdraví je " + player.Health + " a tvoje zbroj je na " + player.Armor + " procentech");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("There has been error pleas try again");
                    Console.ReadKey();
                }
                if (bandit.Health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vyhrál si souboj !");
                    Console.ResetColor();
                    Console.WriteLine("Po boji sis opravil zbroj a vyléčil ses lektvarem");
                    Console.ReadKey();
                    break;
                }
                else if (player.Health <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zemřel si !");
                    Console.ResetColor();
                    Console.ReadKey();
                    Menu.ShowMenu();
                }
            }
        }
    }
}
