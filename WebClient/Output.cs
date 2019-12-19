using System;
using System.Text.RegularExpressions;

namespace WebClient
{
    class Outputs
    {
        public string Valid_InputNum0_100(string input)
        {
            Regex regex = new Regex(@"^([0-9]+)$");
            bool valid = false;
            valid = regex.IsMatch(input);
            if (valid == true)
            {
                return "YES";
            }
            else
            {
                Console.WriteLine("NOT A VALID INPUT");
                Console.ReadLine();
                return "NO";
            }
        }
        public bool Valid_NameInput(string input)
        {
            Regex regex = new Regex(@"^([A-Z-a-z]+)$");
            bool valid = false;
            valid = regex.IsMatch(input);
            if (valid == true)
            {
                return valid;
            }
            else
            {
                Console.WriteLine("NOT A VALID NAME");
                Console.ReadLine();

                return false;
            }
        }

        public string Valid_AgeInput(string input)
        {
            Regex regex = new Regex(@"^([0-9]+)$");
            bool valid = false;
            valid = regex.IsMatch(input);
            if (valid == true)
            {
                return "YES";
            }
            else
            {
                Console.WriteLine("NOT A VALID INPUT");
                Console.ReadLine();
                return "NO";
            }
        }
        public string Valid_InputNum0_3(string input)
        {
            Regex regex = new Regex(@"^([0-3]+)$");
            bool valid = false;
            valid = regex.IsMatch(input);
            if (valid == true)
            {
                return "YES";
            }
            else
            {
                Console.WriteLine("NOT A VALID INPUT");
                Console.ReadLine();
                return "NO";
            }
        }
        public string Valid_InputNum0_2(string input)
        {

            Regex regex = new Regex(@"^([0-2]+)$");
            bool valid = false;
            valid = regex.IsMatch(input);
            if (valid == true)
            {
                return "YES";
            }
            else
            {
                Console.WriteLine("NOT A VALID INPUT");
                Console.ReadLine();
                return "NO";
            }
        }
        public string Valid_Input_YesNo(string input)
        {
            if (input == "YES" || input == "NO")
            {

                return "YES";
            }
            else
            {
                Console.WriteLine("Please use a valid input");
                Console.ReadLine();
                return "NO";
            }
        }
        public void HelpName()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\nHelp");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": Please input a name that is only letters!\n      No spaces, special characters or numbers");
        }
        public void HelpAge()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\nHelp");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":Numbers only!\n     Over 16 only!");
        }
        public void HelpYesOrNo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Help");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":Inputting '");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("YES");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' will move on '");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("NO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("' will reset this section\n     Any Invalid inputs will be rejected!");
        }
        public void OutputNameDialouge1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Type in your name:");
        }

        public void OutputNameDialouge2()
        {
            Console.Write("Name:");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void OutputAgeDialouge1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Please Type in your age:");
        }
        public void OutPutAgeDialouge2()
        {
            Console.Write("Age:");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public string OutputCheck(string check)
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (check != "YES" && check != "NO")
            {
                Console.WriteLine("Invalid entry, seting as 'NO'");
                Console.ReadLine();
                return "NO";

            }
            else if (check == "NO")
            {
                Console.WriteLine("seting as 'NO'");
                Console.ReadLine();
                return "NO";

            }
            else if (check == "YES")
            {
                Console.Clear();
                return "YES";
            }
            return "NO";

        }
        public void OutputFilmDialouge1()
        {
            Console.WriteLine("Please select one of the following movies\n\nPlease Type>\n1 = Batman\n2 = The Avengers\n3 = Skyfall\n");
        }
               
        public void OutputBorder1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("||=============================================================================================||\n\n");//Window dividers
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void OutputBorder2()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n||=============================================================================================||\n");//Window dividers
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void OutputInput1()
        {

            Console.Write("Input:");
            Console.ForegroundColor = ConsoleColor.Green;

        }

        public void OutputYesOrNo()
        {
            Console.Write(" -<Yes> or <No>-");
            Console.ForegroundColor = ConsoleColor.Green;
        }

    }
}

