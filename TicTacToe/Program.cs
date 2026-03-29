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

        static int player1Score = 0;
        static int player2Score = 0;

        static char player1Symbol = 'X';
        static char player2Symbol = 'O';
        static bool useCustomSymbols = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Игра Крестики-Нолики v2.0");
            Console.WriteLine("=========================");

            Console.Write("\nХотите изменить символы игроков? (да/нет): ");
            string customizeChoice = Console.ReadLine().ToLower();

            if (customizeChoice == "да" || customizeChoice == "yes" || customizeChoice == "д")
            {
                useCustomSymbols = true;
                CustomizeSymbols();
            }

            bool playAgain = true;

            while (playAgain)
            {
                ResetBoard();
                currentPlayer = 1;
                flag = 0;

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
                    int winner = (currentPlayer == 1) ? 2 : 1;
                    if (winner == 1)
                    {
                        player1Score++;
                        Console.WriteLine($"\nПобедил Игрок 1 ({player1Symbol})!");
                    }
                    else
                    {
                        player2Score++;
                        Console.WriteLine($"\nПобедил Игрок 2 ({player2Symbol})!");
                    }
                }
                else
                {
                    Console.WriteLine("\nНичья!");
                }

                ShowScore();

                Console.Write("\nХотите сыграть еще раз? (да/нет): ");
                string again = Console.ReadLine().ToLower();

                if (again != "да" && again != "yes" && again != "д")
                {
                    playAgain = false;
                }
                else
                {
                    Console.Write("Хотите изменить символы перед следующей игрой? (да/нет): ");
                    string changeSymbols = Console.ReadLine().ToLower();
                    if (changeSymbols == "да" || changeSymbols == "yes" || changeSymbols == "д")
                    {
                        CustomizeSymbols();
                    }
                }
            }

            Console.WriteLine("\nСпасибо за игру! Финальный счет:");
            ShowScore();
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void CustomizeSymbols()
        {
            Console.Clear();
            Console.WriteLine("=== Кастомизация символов ===");

            Console.Write("Введите символ для Игрока 1 (было " + player1Symbol + "): ");
            string input1 = Console.ReadLine();
            if (input1.Length > 0)
            {
                player1Symbol = input1[0];
            }

            Console.Write("Введите символ для Игрока 2 (было " + player2Symbol + "): ");
            string input2 = Console.ReadLine();
            if (input2.Length > 0)
            {
                player2Symbol = input2[0];
            }

            Console.WriteLine($"\nСимволы установлены: Игрок 1 - {player1Symbol}, Игрок 2 - {player2Symbol}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        static void ShowScore()
        {
            Console.WriteLine("\n=== СЧЕТ ===");
            Console.WriteLine($"Игрок 1 ({player1Symbol}): {player1Score}");
            Console.WriteLine($"Игрок 2 ({player2Symbol}): {player2Score}");
            Console.WriteLine("===========");
        }

        static void ResetBoard()
        {
            board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine($"Счет: {player1Score} : {player2Score}");
            Console.WriteLine();
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
            char symbol = (currentPlayer == 1) ? player1Symbol : player2Symbol;

            Console.WriteLine($"\nХод Игрока {currentPlayer} ({symbol})");
            Console.Write("Выберите позицию (1-9): ");

            try
            {
                bool success = int.TryParse(Console.ReadLine(), out choice);

                if (success && choice >= 1 && choice <= 9 &&
                    board[choice - 1] != player1Symbol &&
                    board[choice - 1] != player2Symbol)
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
                if (board[i] != player1Symbol && board[i] != player2Symbol)
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
