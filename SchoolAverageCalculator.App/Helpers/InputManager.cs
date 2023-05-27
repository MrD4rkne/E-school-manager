using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Helpers
{
    public static class InputManager
    {
        public static int GetNumericInput(string message = "Input: ", bool clearUnsuccessful = true)
        {
            int ret;
            string? input;
            Console.Write(message);
            input = Console.ReadLine();
            while (!int.TryParse(input, out ret))
            {
                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return ret;
        }
        public static int GetNumericInput(int min, int max, string message = "Input: ", bool clearUnsuccessful = true)
        {
            int ret;
            string? input;
            Console.Write(message);
            input = Console.ReadLine();
            while (!int.TryParse(input, out ret) || ret < min || ret > max)
            {

                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return ret;
        }
        public static string? GetTextInput(string message, bool canBeEmpty, bool clearUnsuccessful = true)
        {
            Console.Write(message);
            string? input;

            input = Console.ReadLine();
            while (!canBeEmpty)
            {
                if (clearUnsuccessful && !string.IsNullOrEmpty(input) )
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return input;
        }

        public static decimal GetDecimalInput(decimal min, decimal max, string message = "Input: ", bool clearUnsuccessful = true)
        {
            decimal ret;
            string? input;
            Console.Write(message);
            input = Console.ReadLine();
            while (!decimal.TryParse(input, out ret) || ret < min || ret > max)
            {

                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return ret;
        }
        public static decimal GetDecimalInput(string message = "Input: ",  bool clearUnsuccessful = true)
        {
            decimal ret;
            string? input;
            Console.Write(message);
            input = Console.ReadLine();
            while (!decimal.TryParse(input, out ret))
            {

                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return ret;
        }

        public static void WaitForAnyKey(string message = "Press any key to return...")
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }
    }
}
