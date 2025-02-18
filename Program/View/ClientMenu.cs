using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.View
{
    public class ClientMenu : Menu
    {
        public int ListSize = 6;
        public string Email { get; set; }

        public ClientMenu(string email)
        {
            Heading = "\nClient Menu";
            ListLength = ListSize;
            Add("Advertise Product");
            Add("View My Product List");
            Add("Search For Advertised Products");
            Add("View Bids On My Products");
            Add("View My Purchased Items");
            Add("Log off");
            outprompt = "an option";
            Email = email;
        }
        

        public override void Display()
        {
            base.Display();
            Console.WriteLine();
            Product product = new Product(Email);
            if (success)
            {
                switch (Selection)
                {
                    case 1:
                        product.Advertise();
                        break;
                    case 2:
                        product.UserProducts();
                        break;
                    case 6:
                        MainMenu menu = new MainMenu();
                        menu.Display();
                        break;
                }
            }


        }
    }
}


