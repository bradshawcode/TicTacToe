/*
Author: Michael Bradshaw
Date: December 2020.
Class/Program Name: Check_Vertical_Horizontal_Diagonal
Purpose: To check whether the computer or the player has successfully completed a row.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe__First_Game_in_C_Sharp_.Checks
{
    

    class Check_Vertical_Horizontal_Diagonal
    {
        public static bool CheckVertical(string playerChoice, string computerChoice)
        {
            int player = 0;
            int computer = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    string location = TicTacToe.grid[x, y]; //calls the grid from the program.
                    if (location == playerChoice)
                    {
                        player++;
                        if (player == 3)
                        {
                            Console.WriteLine(" "); //A blank.
                            Console.WriteLine("Player Wins!");
                            Console.WriteLine(" "); //A blank
                            TicTacToe.PrintGrid();
                            return false;
                        }
                    }
                    else if (location == computerChoice)
                    {
                        computer++;

                        if (computer == 3)
                        {
                            Console.WriteLine(" "); //A blank.
                            Console.WriteLine("Computer Wins!");
                            Console.WriteLine(" "); //A blank
                            TicTacToe.PrintGrid();
                            return false;
                        }
                        //
                    }
                }
                player = 0;
                computer = 0;
            }
            return true;
        }

        public static bool CheckHorizontal(string playerChoice, string computerChoice)
        {
            int player = 0;
            int computer = 0;

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    string location = TicTacToe.grid[x, y]; //calls the grid from the TicTacToe class.
                    if (location == playerChoice)
                    {
                        player++;
                        if (player == 3)
                        {
                            Console.WriteLine("Player Wins!");
                            TicTacToe.PrintGrid();
                            return false;
                        }
                    }
                    else if (location == computerChoice)
                    {
                        computer++;

                        if (computer == 3)
                        {
                            Console.WriteLine("Computer Wins!");
                            TicTacToe.PrintGrid();
                            return false;
                        }
                        //
                    }
                }
                player = 0;
                computer = 0;
            }
            return true;
        }

        public static bool CheckDiagonal(string playerChoice, string computerChoice)
        {
            int player;
            int computer;
            int y;
            for (int times = 0; times < 2; times++)
            {
                if (times == 0)
                {
                    y = 0;
                    player = 0;
                    computer = 0;
                }
                else
                {
                    y = 2;
                    player = 0;
                    computer = 0;
                }
                for (int x = 0; x < 3; x++)
                {
                    string location = TicTacToe.grid[x, y]; //calls the grid from the TicTacToe class.
                    if (location == playerChoice)
                    {
                        player++;
                        if (player == 3)
                        {
                            Console.WriteLine("Player Wins!");
                            TicTacToe.PrintGrid();
                            return false;
                        }
                    }
                    else if (location == computerChoice)
                    {
                        computer++;

                        if (computer == 3)
                        {
                            Console.WriteLine("Computer Wins!");
                            TicTacToe.PrintGrid();
                            return false;
                        }
                    }
                    if (times == 0)
                    {
                        y++;
                    }
                    else
                    {
                        y--;
                    }
                }
            }
            return true;
        }
    }
}