using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static string player1, player2;
        static char player1Mark = 'X';
        static char player2Mark = 'O';

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            Console.Write("Enter name for Player 1 (X): ");
            player1 = Console.ReadLine();

            Console.Write("Enter name for Player 2 (O): ");
            player2 = Console.ReadLine();

            int turns = 0;
            bool gameWon = false;

            while (turns < 9 && !gameWon)
            {
                Console.Clear();
                PrintBoard();
                string currentPlayer = (turns % 2 == 0) ? player1 : player2;
                char currentMark = (turns % 2 == 0) ? player1Mark : player2Mark;

                Console.Write($"{currentPlayer}'s turn ({currentMark}). Choose a position (1-9): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int pos) && pos >= 1 && pos <= 9 && board[pos - 1] != 'X' && board[pos - 1] != 'O')
                {
                    board[pos - 1] = currentMark;
                    turns++;

                    gameWon = CheckWin();

                    if (gameWon)
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"{currentPlayer} wins!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Press any key to try again.");
                    Console.ReadKey();
                }
            }

            if (!gameWon)
            {
                Console.Clear();
                PrintBoard();
                // No winner message for draw
            }

            Console.WriteLine("\nGame over. Press any key to exit.");
            Console.ReadKey();
        }

        static void PrintBoard()
        {
            Console.WriteLine();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine();
        }

        static bool CheckWin()
        {
            int[,] winPositions = {
                {0,1,2}, {3,4,5}, {6,7,8}, // rows
                {0,3,6}, {1,4,7}, {2,5,8}, // cols
                {0,4,8}, {2,4,6}           // diagonals
            };

            for (int i = 0; i < winPositions.GetLength(0); i++)
            {
                int a = winPositions[i, 0];
                int b = winPositions[i, 1];
                int c = winPositions[i, 2];

                if (board[a] == board[b] && board[b] == board[c])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
