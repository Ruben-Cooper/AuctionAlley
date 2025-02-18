using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Model
{
    public class DataValidation
        
    {


        public static bool IsName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("     The supplied value is not a valid entry.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsEmail(string input)
        {
            var count = input.Count(x => x == '@');
            if (count == 1 && input.Contains("."))
            {
                string[] emailSplit = input.Split("@");
                int prefixLength = emailSplit[0].Length;
                if (emailSplit[0].Length > 0 && emailSplit[1].Length > 0)
                {
                    var match = emailSplit[0].IndexOfAny("!@#$%^&*()+\\=[]{}|;':\"<>/?".ToCharArray()) != -1;
                    var endmatch = emailSplit[0].Substring(prefixLength-1).IndexOfAny("_-.".ToCharArray()) != -1;
                    if (endmatch == false && match == false)
                    {
                        var match2 = emailSplit[1].IndexOfAny("!@#$%^&*()+\\=[]{_}|;':\"<>/?".ToCharArray()) != -1;
                        if (emailSplit[1].Contains(".") && match2 == false && emailSplit[1].EndsWith(".") == false && emailSplit[1].StartsWith(".") == false)
                        {
                            int index = emailSplit[1].LastIndexOf(".");
                            var lastdot = emailSplit[1].Substring(index+1).IndexOfAny("!@#$%^&*()+\\=[]{_}|;':\"<>/?1234567890.".ToCharArray()) != -1;
                            if (lastdot == false)
                            {
                                return true;
                            }
                        }
                    }
                }
 
            }
            Console.WriteLine("     The supplied value is not a valid email address.");
            return false;
        }

        public static bool IsPassword(string input)
        {
            if (input.Length >= 8 && input.Contains(" ") == false)
            {
                var nonalphamatch = input.IndexOfAny("!@#$%^&*()+\\=[]{}|;':\"<>/?".ToCharArray()) != -1;
                var nummatch = input.IndexOfAny("1234567890".ToCharArray()) != -1;
                if (nonalphamatch && nummatch && input.Any(char.IsUpper) && input.Any(char.IsLower))
                {
                    return true;
                }
            }
            Console.WriteLine("     The supplied value is not a valid password.");
            return false;
        }
        
        public static bool IsUint(string input)
        {
            // Checks if input is a non-negative number
            uint num = 0;
            if (uint.TryParse(input, out num))
            {
                return true;
            }
            Console.WriteLine("     Unit number must be a non-negative integer.");
            return false;
        }

        public static bool IsState(string input)
        {
            // Checks if input is a string in array
            string[] states = new string[] { "ACT", "NSW", "NT", "QLD", "SA", "TAS", "VIC", "WA", };
            string upperinput = input.ToUpper();
            if (states.Contains(upperinput))
            {
                return true;
            }
            Console.WriteLine("     The supplied value is not a valid state.");
            return false;
        }

        public static bool IsPostcode(string input)
        {
            // Checks if input is between 1000 and 9999
            int num;
            if (int.TryParse(input, out num))
            {
                if (num >= 1000 && num <= 9999)
                {
                    return true;
                }
            }
            Console.WriteLine("     The supplied value is not a valid postcode.");
            return false;
        }

        public static bool IsPrice(string input)
        {
            int index = input.Length - input.AsSpan().TrimStart().Length; // Finds index of first non-whitespace character
            if (input[index] == '$' && input.Contains(".")) // Checks if first non-whitespace character is a $
            {
                input = input.Remove(index, 1);
                Console.WriteLine(input);
                string[] priceSplit = input.Split(".");
                if (priceSplit.Length == 2) // Checks if there is only one decimal point
                {
                    if (priceSplit[0].Length >= 1 && priceSplit[1].Length == 2) // Checks if there are at least 1 digit before the decimal point and 2 digits after
                    {
                        int num;
                        int counter = 0;
                        if (int.TryParse(priceSplit[1], out num))
                        {
                            

                            if (input.Contains(","))
                            {
                                string[] commaSplit = priceSplit[0].Split(",");

                                for (int i = 0; i < commaSplit.Length; i++)
                                {
                                    if (int.TryParse(commaSplit[i], out num))
                                    {
                                        counter++;
                                    }
                                }

                                if (commaSplit.Length == counter)
                                {
                                    return true;
                                }
                            }
                            else if (int.TryParse(priceSplit[0], out num))
                                {
                                return true;
                            }
                        }
                        }
                          
                        }

                    }
            return false;

                }
                
                
                }

            }

            
            
