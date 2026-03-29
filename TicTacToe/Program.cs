// Автор: Курбанова Елизавета Валиержоновна
// Группа: ИСП(9)-23-1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1;
        static int choice;
        static int flag = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Игра Крестики-Нолики");
            Console.WriteLine("Игрок 1: X");
            Console.WriteLine("Игрок 2: O");
            Console.WriteLine();

            do
            {
                DrawBoard();
                PlayerTurn();
                CheckWin();
                CheckDraw();
                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            } while (flag == 0);

            DrawBoard();

            if (flag == 1)
            {
                Console.WriteLine($"\nПобедил Игрок {(currentPlayer == 1 ? 2 : 1)}!");
            }
            else
            {
                Console.WriteLine("\nНичья!");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[0], board[1], board[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[3], board[4], board[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[6], board[7], board[8]);
            Console.WriteLine("     |     |     ");
        }

        static void PlayerTurn()
        {
            char symbol = (currentPlayer == 1) ? 'X' : 'O';

            Console.WriteLine($"\nХод Игрока {currentPlayer} ({symbol})");
            Console.Write("Выберите позицию (1-9): ");

            try
            {
                choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O')
                {
                    board[choice - 1] = symbol;
                }
                else
                {
                    Console.WriteLine("Неверный ход! Нажмите любую клавишу...");
                    Console.ReadKey();
                    PlayerTurn();
                }
            }
            catch
            {
                Console.WriteLine("Неверный ввод! Нажмите любую клавишу...");
                Console.ReadKey();
                PlayerTurn();
            }
        }

        static void CheckWin()
        {
            if (board[0] == board[1] && board[1] == board[2]) flag = 1;
            else if (board[3] == board[4] && board[4] == board[5]) flag = 1;
            else if (board[6] == board[7] && board[7] == board[8]) flag = 1;
            else if (board[0] == board[3] && board[3] == board[6]) flag = 1;
            else if (board[1] == board[4] && board[4] == board[7]) flag = 1;
            else if (board[2] == board[5] && board[5] == board[8]) flag = 1;
            else if (board[0] == board[4] && board[4] == board[8]) flag = 1;
            else if (board[2] == board[4] && board[4] == board[6]) flag = 1;
        }

        static void CheckDraw()
        {
            bool draw = true;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 'X' && board[i] != 'O')
                {
                    draw = false;
                    break;
                }
            }

            if (draw && flag == 0)
            {
                flag = 2;
            }
        }
    }
}
