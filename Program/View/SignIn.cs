using Program.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program.View
{
    class SignIn : IDisplayable
    {
        // Fields
        protected string emailoutput;
        protected string passwordoutput;
        protected string prompt;
        protected string email = "\nPlease enter your email address";
        protected string password = "\nPlease enter your password";
        protected bool success;

        // Methods
        User user = new User();
        public void Display()
        {
            Console.WriteLine("Sign In");
            Console.WriteLine("----------");
            emailPrompt();
            passwordPrompt();
            firstLogin();
            ClientMenu clientmenu = new ClientMenu(emailoutput);
            clientmenu.Display();
        }

        private void emailPrompt()
        {
            UserInterface.Read(out emailoutput, email);
            if (user.ExistingEmail(emailoutput))
            {
                return;
            }
            else 
            {
                Console.WriteLine("     The supplied address isn't registered");
                emailPrompt();
            }
        }

        private void passwordPrompt()
        {
            UserInterface.Read(out passwordoutput, password);
            if (user.ExistingPassword(emailoutput, passwordoutput))
            {
                Console.WriteLine();
                return;
            }
            else
            {
                Console.WriteLine("     Incorrect password provided");
                passwordPrompt();
            }
        }

        public string usernamePrompt(string Email, string Print = "Personal Details for")
        {
            using (StreamReader file = new StreamReader(user.fileName))
            {
                string prev1 = "";
                string prev2;
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == Email)
                    {
                        return $"{Print} {prev1}({Email})";

                    }

                    prev2 = prev1;
                    prev1 = line;
                }
            }
            return "Error - No matching username";
        }


        public void firstLogin()
        {
            if (user.existinghomeaddress(emailoutput))
            {
                Registration registration = new Registration();
                Console.WriteLine(usernamePrompt(emailoutput));
                Console.WriteLine("----------------------------------------------------------");
                registration.addressPrompt(emailoutput);
            }
        }
        
    }
}
