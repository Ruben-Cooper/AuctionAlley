using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    public class User
    {
        public string fileName = "userdata.txt";

        public string addressfileName = "useraddresses.txt";
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string signinemail;

        public void CreateUser(string Name, string Email, string Password)
        {
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                file.WriteLine($"Account:\n{Name}\n{Email}\n{Password}");
            }

            Console.WriteLine($"\nClient {Name}({Email}) has successfully registered at the Auction House.\n");
        }

        public bool ExistingEmail(string Email)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == Email)
                    {
                        return true;
                        
                    }

                }
            }
            return false;
        }

        public void SaveAddress(string email,string unit, string streetnum, string stretname, string streetsuffix, string city, string state, string postcode)
        {

           using (StreamWriter filewrite = new StreamWriter(addressfileName, true))
                    {
                        filewrite.WriteLine($"{email}\nUnit:\n{unit}\nStreetNum:\n{streetnum}\nStreetName:\n{stretname}\nStreetSuffix:\n{streetsuffix}\nCity:\n{city}\nState:\n{state}\nPostcode:\n{postcode}");
                    }
                }
                    


        public bool ExistingPassword(string Email, string Password)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                string line;
                bool compare = false;
                
                while ((line = file.ReadLine()) != null)
                {
                    if (compare) 
                    {
                        if (line == Password)
                        {
                            return true;
                        }
                    }
                    compare = line.Contains(Email);
                }
            }
            return false;
            }


        public bool existinghomeaddress(string email)
        {
            using (StreamReader file = new StreamReader(addressfileName))
            {
                string line;
                bool compare = false;

                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(email))
                    {
                            return false;
                    }
                }
            }
            return true;
        }


    }
}

