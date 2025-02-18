using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.View
{
    public static class UserInterface
    {
        const string Prompt = "> ";


        /// <summary>
        /// Reads and Displays prompt for int selection
        /// </summary>
        /// <param name="max">Maximum selectable/upper-bound limit of options</param>
        /// <param name="choice">Output of choice selection</param>
        /// <param name="outprompt">Prompt Parameter to Print in Console</param>
        /// <returns>If valid choice returns true otherwise returns false</returns>
        public static bool Read(int upperbound, out int choice, string outprompt)
        {
            Console.WriteLine(OptionPrompt(upperbound, outprompt));
            Console.Write(Prompt);
            bool success = false;
            choice = 0;
            string input = Console.ReadLine();
            success = int.TryParse(input, out choice);
            if (success)
            {
                if (choice < 1 || choice > upperbound)
                {
                    success = false;
                }
            }
            return success;
        }


        public static bool Read(out string input, string useraction)
        {
            Console.WriteLine(useraction);
            Console.Write(Prompt);
            input = Console.ReadLine();
            return true;
        }



        // Method
        public static string OptionPrompt(int upperBound, string inputType)
        {
            string prompt = "\nPlease enter " + inputType + " between 1 and "+ upperBound + ":";
            return prompt;
        }
    }
        
}
