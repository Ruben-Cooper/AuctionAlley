using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Program.View
{
    public class MainMenu : Menu
    {

        public int ListSize = 3;

        public MainMenu()
        {
            Heading = "Main Menu";
            ListLength = ListSize;
            Add("Register");
            Add("Login");
            Add("Exit");
            outprompt = "an option";
        }

        public override void Display() // Prints Menu and waits for user input
        {
            base.Display();
            Console.WriteLine();
            if (success)
            {
                switch (Selection)
                {
                    case 1:
                        Registration registration = new Registration();
                        registration.Display(); // Calls registration menu
                        break;
                    case 2:
                        SignIn login = new SignIn();
                        login.Display(); // Calls login menu
                        break;
                    case 3:
                        Exit();
                        Environment.Exit(0);
                        break;
                }
            }

            else
            {
                Display();
            }
        }

        public void Initalise() // Initialises Auction House
        {
            Console.WriteLine("+------------------------------+");
            Console.WriteLine("| Welcome to the Auction House |");
            Console.WriteLine("+------------------------------+\n");

            string[] files = { "userdata.txt", "useraddresses.txt", "auctionhouse.txt" }; // List of files to create
            for (int i = 0; i < 3; i++)
            {
                if (!File.Exists(files[i])) // Creates files if files dont exist
                {
                    StreamWriter initialise = new StreamWriter(files[i]);
                    initialise.Close();
                }
            }
        }

            public void Exit() // Exists Peacefully
            {
                Console.WriteLine("+--------------------------------------------------+\n| Good bye, thank you for using the Auction House! |\n+--------------------------------------------------+");
            }
        }
    }

