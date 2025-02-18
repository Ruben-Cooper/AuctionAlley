using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.View
{
    public class Menu : IDisplayable
    {
        // Fields
        protected int nextOpenIndex;
        protected int ListLength;
        protected int Selection;
        protected string outprompt;
        public bool success;

        // Properties
        public string Heading
        { get; set; }
        
        public string[] Options
        { get; set; }
        


        // Methods
        
        public void Add(string option) // Adds to current menu
        {
            if (nextOpenIndex == 0)
            {
                Options = new string[ListLength];
                Options[nextOpenIndex] = option;
                nextOpenIndex++;
            }
            else
            {
                Options[nextOpenIndex] = option;
                nextOpenIndex++;
            }
        }
        
        public virtual void Display() // Displays menu to User Interface
        {
            Console.WriteLine(Heading);
            Console.WriteLine("----------");
            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {Options[i]}");
            }
            success = UserInterface.Read(Options.Length, out Selection, outprompt);

        }
    }

        
    }

