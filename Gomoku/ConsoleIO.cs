using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public static class ConsoleIO
    {
        public static int GetInt(string prompt)
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("~ ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            Console.ResetColor();
            return result;
        }
        public static bool GetYesOrNo(string message)
        {
            while (true)
            {
                Display(message);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("~ ");
                string sender = Console.ReadLine();
                if (sender.ToUpper() == "Y")
                {
                    Console.ResetColor();
                    return true;
                }
                else if (sender.ToUpper() == "N")
                {
                    Console.ResetColor();
                    return false;
                }
            }
        }
        public static int GetValidPlayerType(int highbound)
        {
            bool isGettingInt = true;
            int gotIt = -1;
            while (isGettingInt)
            {
                Console.ForegroundColor= ConsoleColor.Green;

                Console.WriteLine($"Please Enter a guess 1-{highbound}: ");
                Console.Write("~ ");
                int.TryParse(Console.ReadLine(), out gotIt);
                if (gotIt > 1 && gotIt < highbound)
                    isGettingInt = false;
            }
            Console.ResetColor();
            return gotIt;
        }
        public static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0)+1; i++)
            {
                for (int j = 0; j < board.GetLength(1)+1; j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write($"   ");
                    else if (j == 16 || i == 16)
                        break;
                    else if (j == 0)
                    {
                        Console.WriteLine();
                        Console.Write($"{i:00}");
                    }
                    else if (i == 0)
                        Console.Write($"{j:00} ");
                    else
                    {
                        Console.Write($" {board[i,j]} ");
                    }

                }
            }
            //for (int i = 0; i < board.GetLength(0)+1; i++)
            //{
            //    for (int j = 0; j < board.GetLength(1)+1; j++)
            //    {
            //        if (i == 0 && j == 0)
            //            Console.Write($"   ");
            //        else if (j == 0)
            //        {
            //            Console.WriteLine();
            //            Console.Write($"{i:00}");
            //        }
            //        else if (i == 0)
            //            Console.Write($"{j:00} ");
            //        else
            //        {
            //            Console.Write(" _ ");
            //        }

            //    }
            //}
        }
        public static string GetName(int playerNum)
        {
            string result = "";
            
            Console.Write($"\nPlayer {playerNum}, enter your name: ");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.Write("~ ");
            result = Console.ReadLine();
            
            while (string.IsNullOrEmpty(result))
            {
                Console.Write("Name required, enter again: ");
                result = Console.ReadLine();
            }
            Console.ResetColor();
            return result;
        }

        internal static int GetRow()
        {
            
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"Enter a row: ");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("~ ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else if (result > 15 | result < 1)
                {
                    Error("Stay within the bounds of the board, 1-15: ");
                }
                else
                {
                    valid = true;
                }
            }
            Console.ResetColor();
            return result;
        }
        internal static int GetColumn()
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"Enter a column: ");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("~ ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else if (result > 15 | result < 1)
                {
                    Error("Stay within the bounds of the board, 1-15: ");
                }
                else
                {
                    valid = true;
                }
            }
            Console.ResetColor();
            return result;
        }

        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
