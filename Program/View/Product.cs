using Program.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program.View
{
    class Product : Registration
    {
        public string productname = "\nProduct name";
        public string productdescription = "\nProduct description";
        public string productprice = "\nProduct price ($d.cc)";
        public string productnameoutput;
        public string productdescriptionoutput;
        public string productpriceoutput;
        public string productlistheader = "Item #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amt";

        public string Email { get; set; }

        public Product(string email)
        {
          Email = email;
        }

        public void Advertise() 
        {
            SignIn userinfo = new SignIn();
            Console.WriteLine(userinfo.usernamePrompt(Email, "Product Advertisement for"));
            Console.WriteLine("------------------------------------------------");
            productname:
                UserInterface.Read(out productnameoutput, productname);
                if (DataValidation.IsName(productnameoutput))
                {
                    goto productdescription;
                }
                else
                {
                    goto productname;
                }
            productdescription:
                UserInterface.Read(out productdescriptionoutput, productdescription);
                if (DataValidation.IsName(productdescriptionoutput) && productdescriptionoutput != productnameoutput)
                {
                goto productprice;
                }
                else
                {
                    Console.WriteLine("     Product description cannot be the same as the product name");
                    goto productdescription;
                }
             productprice:
                UserInterface.Read(out productpriceoutput, productprice);
                if (DataValidation.IsPrice(productpriceoutput))
                {
                    goto save;
                }
                else
                {
                    Console.WriteLine("     A currency value is required, e.g. $54.95 $9.99, $2314.15");
                    goto productprice;
                }
             save:
                Console.WriteLine($"\nSuccessfully added product {productnameoutput}, {productdescriptionoutput}, {productpriceoutput}.");
                ProductData product = new ProductData();
                product.ListItem(Email, productnameoutput, productdescriptionoutput, productpriceoutput);
                ClientMenu clientmenu = new ClientMenu(Email);
                clientmenu.Display();
        }

            public void UserProducts()
            {
            SignIn userinfo = new SignIn();
            Console.WriteLine(userinfo.usernamePrompt(Email, "Product List for"));
            Console.WriteLine("---------------------------------------------------------\n");
            Console.WriteLine(productlistheader);
            ProductData product = new ProductData();
            product.RetrieveUserListings(Email);
            ClientMenu clientmenu = new ClientMenu(Email);
            clientmenu.Display();
            }



    }



    }





      


