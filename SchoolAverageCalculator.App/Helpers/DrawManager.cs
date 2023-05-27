using SchoolAverageCalculator.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Helpers
{
    public static class DrawManager
    {
        /// <summary>
        /// Draw menu with message and options
        /// </summary>
        /// <param name="message">Message to be shown to user</param>
        /// <param name="options">List of avaibable choices</param>
        /// <param name="emptyLineSpace">Should print empty line before Input</param>
        /// <returns>Chosen option number (starting from 1...)</returns>
        public static int DrawMenu(string message, string[] options, bool emptyLineSpace = true)
        {
            Console.WriteLine(message);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            if (emptyLineSpace)
                Console.WriteLine();
            return InputManager.GetNumericInput(1, options.Length);
        }
        public static int DrawMenu(string message, List<string> options, bool emptyLineSpace = true)
        {
            Console.WriteLine(message);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            if (emptyLineSpace)
                Console.WriteLine();
            return InputManager.GetNumericInput(1, options.Count);
        }
        //public static int DrawMenu(string message, MenuService menuService, string menuTitle)
        //{
        //    return DrawMenu(message, menuService.GetOptionsByMenuTitle(menuTitle));
        //}
    }
}
