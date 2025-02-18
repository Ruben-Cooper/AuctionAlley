using Program.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program.View
{
    public class Registration : IDisplayable
    {
        public string nameoutput;
        public string emailoutput;
        public string passwordoutput;
        public string signinemail;
        public string Heading = "Registration";
        public string name = "\nPlease enter your name";
        public string email = "\nPlease enter your email address";
        public string password = "\nPlease choose a password\n* At least 8 characters\n* No white space characters\n* At least one upper-case letter\n* At least one lower-case letter\n* At least one digit\n* At least one special character";

        // Fields used to register an address to a first time user
        public string unitoutput;
        public string streetnumoutput;
        public string streetnameoutput;
        public string streetsuffixoutput;
        public string cityoutput;
        public string stateoutput;
        public string postcodeoutput;
        string address = "\nPlease provide your home address";
        string unit = "\nUnit number (0 = none):";
        string streetnum = "\nStreet number:";
        string streetname = "\nStreet name:";
        string streetsuffix = "\nStreet suffix:";
        string city = "\nCity:";
        string state = "\nState (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):";
        string postcode = "\nPostcode (1000 .. 9999):";



        public void Display()
        {
            Console.WriteLine(Heading);
            Console.WriteLine("----------");
            namePrompt();
            emailPrompt();
            passwordPrompt();
            User user = new User();
            user.CreateUser(nameoutput, emailoutput, passwordoutput);
            MainMenu menu = new MainMenu();
            menu.Display();

        } 

        private void namePrompt()
        {
            UserInterface.Read(out nameoutput, name);
            if (DataValidation.IsName(nameoutput))
            {
                return;
            }
            else { namePrompt(); }
        }
        private void emailPrompt()
        {
            UserInterface.Read(out emailoutput, email);
            if (DataValidation.IsEmail(emailoutput))
            {
                User user = new User();
                if (user.ExistingEmail(emailoutput))
                {
                    Console.WriteLine("     The supplied address is already in use.");
                    emailPrompt();
                }
            }
            else { emailPrompt(); }
        }

        private void passwordPrompt()
        {
            
            UserInterface.Read(out passwordoutput, password);
            if (DataValidation.IsPassword(passwordoutput))
            {
                return;
            }
            else { passwordPrompt(); }
        }

        // Methods used to register an address to a first time user
        public void addressPrompt(string signinemail)
        {
            Console.WriteLine(address);
            Unit:
                UserInterface.Read(out unitoutput, unit);
                if (DataValidation.IsUint(unitoutput))
                {
                    goto StreetNumber;
                }
            else { goto Unit; }
            StreetNumber:
                UserInterface.Read(out streetnumoutput, streetnum);
                if (DataValidation.IsUint(streetnumoutput))
                {
                    goto StreetName;
                }
                else { goto StreetNumber; }
            StreetName:
                UserInterface.Read(out streetnameoutput, streetname);
                if (DataValidation.IsName(streetnameoutput))
                {
                    goto StreetSuffix;
                }
                else { goto StreetName; }
            StreetSuffix:
                UserInterface.Read(out streetsuffixoutput, streetsuffix);
                if (DataValidation.IsName(streetsuffixoutput))
                {
                    goto City;
                }
                else { goto StreetSuffix; }
            City:
                UserInterface.Read(out cityoutput, city);
                if (DataValidation.IsName(cityoutput))
                {
                    goto State;
                }
                else { goto City; }
            State:
                UserInterface.Read(out stateoutput, state);
                if (DataValidation.IsState(stateoutput))
                {
                goto PostCode;
                }
                else { goto State; }
            PostCode:
                UserInterface.Read(out postcodeoutput, postcode);
                if (DataValidation.IsPostcode(postcodeoutput))
                {
                    goto Save;
                }
                else { goto PostCode; }
            Save:
                User user = new User();
                user.SaveAddress(signinemail, unitoutput, streetnumoutput, streetnameoutput, streetsuffixoutput, cityoutput, stateoutput, postcodeoutput);
                if (unitoutput == "0")
                    {
                        Console.WriteLine($"\nAddress has been updated to {streetnumoutput} {streetnameoutput} {streetsuffixoutput}, {cityoutput} {stateoutput.ToUpper()} {postcodeoutput}");
                    }
                else { Console.WriteLine($"\nAddress has been updated to {unitoutput}/{streetnumoutput} {streetnameoutput} {streetsuffixoutput}, {cityoutput} {stateoutput.ToUpper()} {postcodeoutput}"); }
            



        }
        }

            
    }
