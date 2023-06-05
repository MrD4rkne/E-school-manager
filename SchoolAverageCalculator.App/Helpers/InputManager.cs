using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Helpers
{
    /// <summary>
    /// Manager for getting user's input 
    /// </summary>
    public static class InputManager
    {
        /// <summary>
        /// Get numeric (int) input, action will be repeated until valid data is entered.
        /// </summary>
        /// <param name="message">Custom message to be printed in Console</param>
        /// <param name="clearUnsuccessful">Should clear non-numeric inputs</param>
        /// <returns>Numeric input</returns>
        public static int GetNumericInput(string message = "Input: ", bool clearUnsuccessful = true)
        {
            int userIntegerInput;
            string? input;
            Console.Write(message);
            input = Console.ReadLine();
            while (!int.TryParse(input, out userIntegerInput))
            {
                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return userIntegerInput;
        }

        /// <summary>
        /// Get numeric (int) input withing <min,max> range, action will be repeated until valid data is entered.
        /// </summary>
        /// <param name="min">Minimum for demanded input</param>
        /// <param name="max">Maximum for demanded input</param>
        /// <param name="message">Custom message to be printed in Console</param>
        /// <param name="clearUnsuccessful">Should clear non-numeric inputs</param>
        /// <returns>Numeric input</returns>
        public static int GetNumericInput(int min, int max, string message = "Input: ", bool clearUnsuccessful = true)
        {
            int userIntegerInput;
            string? input;
            Console.Write(message);
            input = Console.ReadLine();
            while (!int.TryParse(input, out userIntegerInput) || userIntegerInput < min || userIntegerInput > max)
            {

                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return userIntegerInput;
        }

        /// <summary>
        /// Get one-line text (string) input
        /// </summary>
        /// <param name="message">Custom message to be printed in Console</param>
        /// <param name="canBeEmpty">Can input be a empty string</param>
        /// <returns>Text input</returns>
        public static string? GetTextInput(string message, bool canBeEmpty)
        {
            Console.Write(message);
            string? input;

            input = Console.ReadLine();
            while (!canBeEmpty && string.IsNullOrEmpty(input))
            {
                input = Console.ReadLine();
            }
            return input;
        }

        /// <summary>
        /// Get decimal (decimal) input withing <min,max> range, action will be repeated until valid data is entered.
        /// </summary>
        /// <param name="min">Minimum for demanded input</param>
        /// <param name="max">Maximum for demanded input</param>
        /// <param name="message">Custom message to be printed in Console</param>
        /// <param name="clearUnsuccessful">Should clear non-numeric inputs</param>
        /// <returns>Decimal input</returns>
        public static decimal GetDecimalInput(decimal min, decimal max, string message = "Input: ", bool clearUnsuccessful = true)
        {
            decimal userDecimalInput;
            string? input;

            Console.Write(message);
            input = Console.ReadLine();
            while (!decimal.TryParse(input, out userDecimalInput) || userDecimalInput < min || userDecimalInput > max)
            {

                if (clearUnsuccessful && !string.IsNullOrEmpty(input))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', input.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                input = Console.ReadLine();
            }
            return userDecimalInput;
        }

        /// <summary>
        /// Get decimal (decimal) input, action will be repeated until valid data is entered.
        /// </summary>
        /// <param name="message">Custom message to be printed in Console</param>
        /// <param name="clearUnsuccessful">Should clear non-numeric inputs</param>
        /// <returns>Decimal input</returns>
        public static decimal GetDecimalInput(string message = "Input: ",  bool clearUnsuccessful = true)
        {
            decimal userDecimalInput;
            string? userInput;

            Console.Write(message);
            userInput = Console.ReadLine();
            while (!decimal.TryParse(userInput, out userDecimalInput))
            {

                if (clearUnsuccessful && !string.IsNullOrEmpty(userInput))
                {

                    Console.SetCursorPosition(message.Length, Console.CursorTop - 1);
                    Console.Write(new string(' ', userInput.Length));
                    Console.SetCursorPosition(message.Length, Console.CursorTop);
                }
                userInput = Console.ReadLine();
            }
            return userDecimalInput;
        }

        /// <summary>
        /// Wait for any key press
        /// </summary>
        /// <param name="message">Message to be printed before waiting for key</param>
        public static void WaitForAnyKey(string message = "Press any key to return...")
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }
    }
}
