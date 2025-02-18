using System;
using Program.Model;
using Program.View;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MainMenu menu = new MainMenu();
            menu.Initalise();
            menu.Display();

            
        }
    }
}