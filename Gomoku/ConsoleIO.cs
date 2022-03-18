using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    internal class ConsoleIO
    {
        public int GetInt(string prompt)
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        public int GetValidPlayerType(int highbound)
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
        public void PrintBoard(char[,] board)
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
        public string GetName(int playerNum)
        {
            string result = "";
            Console.Write($" Player {playerNum}, enter your name: ");
            result = Console.ReadLine();
            while (string.IsNullOrEmpty(result))
            {
                Console.Write("Name required, enter again: ");
                result = Console.ReadLine();
            }
            return result;
        }

        internal int GetRow()
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"Enter a row: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        internal int GetColumn()
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"Enter a column: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }

        private static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
