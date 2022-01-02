/*
Author: Michael Bradshaw
Date: December 2020.
Class/Program Name: TicTacToe
Purpose: A game of tic tac toe, that uses classes and lists to create the game.
*/

using System;
using Tic_Tac_Toe__First_Game_in_C_Sharp_.Checks; // import all required classes.

namespace Tic_Tac_Toe__First_Game_in_C_Sharp_
{
    class TicTacToe
    {
        // The grid of the game.
        public static string[,] grid = new string[3, 3] {{ "0", "1", "2" }, { "0", "1", "2" }, { "0", "1", "2" }}; //Creates the list holding the tic tac toe grid.
        static bool check1 = false;
        static bool check2 = false;
        static bool check3 = false;
        // Varables;
        static string playerID = "";
        static string computerID = "";
        // Input method:
        static string Input()
        {
            // Gets the input:

            Console.Write("Please enter a value: ");
            string userinput = Console.ReadLine();

            // Returns the input.
            return userinput;
        }

        static int CheckInt()
        {
            int returnnum;
            string input = Input();
            if (int.TryParse(input, out returnnum))
            {
                if (returnnum > 2)
                {
                    Console.Write("Out of bowns, numbers between 0 and 2 are accepted.");
                    returnnum = CheckInt();
                }
            }
            else
            {
                if (input.ToUpper() == "Q")
                {
                    check1 = false;
                }
                else
                {
                    Console.Write("Enter a number!");
                    returnnum = CheckInt();
                }
            }
            return returnnum;
        }

        static void CheckInput(string computerChoice, string playerid)
        {
            // Calls the input function to get the users input.

            Console.WriteLine("Please enter the location of where you want you x or o to be.");
            Console.WriteLine("");
            Console.WriteLine("Enter the x postion between 0 and 2");
            int locationx = CheckInt();
            int locationy = 1;
            if (check1 != false)
            {
                Console.WriteLine("Enter the y postion between 0 and 2");
                locationy = CheckInt();
            }
            if (grid[locationx, locationy] == computerChoice)
            {
                Console.WriteLine("Enter a different location, since the computer has placed there.");
                CheckInput(computerChoice, playerid);
            }

            else
            {
                grid[locationx, locationy] = playerid;
            }
            
        }

        static void ComputerChoosing(string playerChoice, string computerChoice)
        {
            // Random for the computer choice.
            Random rnd = new Random();
            int locationx = rnd.Next(0, 2);
            int locationy = rnd.Next(0, 2);
            if (grid[locationx, locationy] == playerChoice)
            {
                ComputerChoosing(playerChoice, computerChoice);
            }

            else
            {
                grid[locationx, locationy] = computerChoice;
            }
        }
        
        static void XORO(out string playerid, out string computerChoice)//this function sends out muliple objects using the out method.
        {
            // Gets the users choice.
            Console.Write("Please enter X or O to choice your player: ");
            string choice = Console.ReadLine();
            choice = choice.ToUpper(); // changes the input to upercase

            playerid = "";
            computerChoice = "";
            if (choice == "X")
            {
                playerid = "X";
                computerChoice = "O";
            }
            else if (choice == "O")
            {
                Console.WriteLine("O!");
                playerid = "O";
                computerChoice = "X";
            }
            else if (choice == "Q")
            {
                check1 = false;
                Menu();
            }
            else
            {
                XORO(out playerid, out computerChoice);
            }
        }

        public static void PrintGrid() // Prints the grid to the screen.
        {
            int switc = 0;
            Console.WriteLine("______");
            foreach (string postion in grid)//goes thought the gird list.
            {
                Console.Write(postion);//prints the object at the postion.
                Console.Write("|");
                switc++;// the switch goes up by one.
                if (switc == 3)// if the switc varable reaches 3 it will set it back to 0 and print a space between the lines 1-3, so it looks like a grid.
                {
                    switc = 0;
                    Console.WriteLine("");

                }
            }
            Console.WriteLine("``````");
        }

        static void Menu()
        {
            string start;
            bool program = true;
            Console.WriteLine("Hello Welcome to Tic Tac Toe!");
            Console.WriteLine("(S)tart!");
            Console.WriteLine("(H)help!");
            Console.WriteLine("(Q)uit!");
            while (program)
            {
                start = Input();
                start = start.ToUpper();

                if (start == "S")
                {
                    program = false;
                    check1 = true;
                    check2 = true;
                    check3 = true;
                    XORO(out playerID, out computerID);//calls the fucntion for the playerid and computerChoice.
                }
                else if (start == "H")
                {
                    Console.WriteLine("Nothing to help with! :)");
                }
                else if (start == "Q")
                {
                    program = false;
                    check1 = false;
                    check2 = false;
                    check3 = false; 
                }

                else
                {
                    Console.WriteLine("Enter the right option!");
                }

            }
        }

        static void Main(string[] args)//the main function/method that gets called at the beginning of the program.
        {
            Menu();
            while (check1 && check2 && check3)//while all the checks are true, than contiue.
            {
                PrintGrid();
                CheckInput(computerID, playerID);// Calls the check input fucntion to get the userinput.
                if (check1 == false)
                {
                    Menu();
                    break;
                }
                ComputerChoosing(playerID, computerID);
                check1 = Check_Vertical_Horizontal_Diagonal.CheckVertical(playerID, computerID);
                check2 = Check_Vertical_Horizontal_Diagonal.CheckHorizontal(playerID, computerID);
                check3 = Check_Vertical_Horizontal_Diagonal.CheckDiagonal(playerID, computerID);
                if (check1 == false || check2 == false || check3 == false)
                {
                    Menu();
                    break;
                }
            }
        }
    }
}
