using System;

namespace Hra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n Hra se ovládá šipkami více informací v ovládání a informace.");
            System.Threading.Thread.Sleep(5000);
            Menu.ShowMenu();
        }
    }
}
