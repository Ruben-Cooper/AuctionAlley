using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    class ProductData : User
    {
        private string productfileName = "auctionhouse.txt";
        
        public List<Listing> productlisting = new List<Listing>();
        public void ListItem(string email, string name, string description, string price)
        {
            using (StreamWriter filewrite = new StreamWriter(productfileName, true))
            {
                filewrite.WriteLine($"Listing:\n{email}\n{name}\n{description}\n{price}");
            }
        }


        /// <summary>
        /// Retrieves all the products from the file for the user
        /// </summary>
        public void RetrieveUserListings(string email)
        {
            List<string> prlisting = new List<string>();
            using (StreamReader fileread = new StreamReader(productfileName))
            {
                string line;
                while ((line = fileread.ReadLine()) != null)
                {
                    if (line.Contains(email))
                    {
                        prlisting.Clear();
                        prlisting.Add(fileread.ReadLine());
                        prlisting.Add(fileread.ReadLine());
                        prlisting.Add(fileread.ReadLine());
                        productlisting.Add(new Listing { Name = prlisting[0], Description = prlisting[1], Price = prlisting[2] });
                    }
                    
                }

            }




            /// Orders the list correctly
            List<Listing> sortedlisting = productlisting.OrderBy(x => x.Name).ThenBy(x => x.Description).ThenBy(x => x.Price).ToList();

            int counter = 0;
            foreach (Listing x in sortedlisting)
            {
                counter++;
                Console.WriteLine($"{counter}\t{x.Name}\t{x.Description}\t{x.Price}");
            }
            if (counter == 0)
            {
                Console.WriteLine("No listings found for this user");
            }

        }
        
    }



        
}
