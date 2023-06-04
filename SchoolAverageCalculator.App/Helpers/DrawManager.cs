using SchoolAverageCalculator.App.Common;
using SchoolAverageCalculator.App.Concrete;
using SchoolAverageCalculator.Domain.Common;
using SchoolAverageCalculator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Helpers
{
    /// <summary>
    /// Manager for drawing menus
    /// </summary>
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
            //Console.WriteLine(message);
            //for (int i = 0; i < options.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}. {options[i]}");
            //}
            //if (emptyLineSpace)
            //    Console.WriteLine();
            //return InputManager.GetNumericInput(1, options.Length);
            return DrawMenu(message, options.ToList(), emptyLineSpace);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="options"></param>
        /// <param name="skip"></param>
        /// <param name="emptyLineSpace"></param>
        /// <returns>Selected index or -1 if skipped</returns>
        public static int DrawMenuWithSkip(string message, List<string> options, string skip, bool emptyLineSpace = true)
        {
            options.Add(skip);
            int ret = DrawMenu(message, options, emptyLineSpace);
            if (ret == options.Count)
                return -1;
            return ret;
        }

        public static T? SelectEntityOrSkip<T>(string message, string skip, List<T> values) where T : BaseEntity
        {
            int input = DrawMenuWithSkip(message, values.Select(x => x.ToString()).ToList(), skip);
            if (input == -1)
                return null;
            return values.ElementAt(input - 1);
        }
        public static T? SelectEntity<T>(string message, List<T> values) where T : BaseEntity
        {
            int input = DrawMenu(message, values.Select(x => x.ToString()).ToList());
            if (input == -1)
                return null;
            return values.ElementAt(input - 1);
        }

        public static T? SelectEntityOrSkip<T>(string message, string skip, BaseService<T> service) where T : BaseEntity
        {
            if (service == null)
                return null;
            return SelectEntityOrSkip<T>(message, skip, service.Items);
        }
        public static T? SelectEntity<T>(string message, BaseService<T> service) where T : BaseEntity
        {
            if (service == null)
                return null;
            return SelectEntity<T>(message, service.Items);
        }
        //public static int DrawMenu(string message, MenuService menuService, string menuTitle)
        //{
        //    return DrawMenu(message, menuService.GetOptionsByMenuTitle(menuTitle));
        //}

        public static bool ConfirmationMenu(string message)
        {
            return DrawMenu(message, new string[] { "Confirm", "Abort" }) == 1;
        }
    }
}
