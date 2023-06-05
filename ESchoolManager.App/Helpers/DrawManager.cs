using ESchoolManager.App.Common;
using ESchoolManager.App.Concrete;
using ESchoolManager.Domain.Common;
using ESchoolManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.App.Helpers
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
            return DrawMenu(message, options.ToList(), emptyLineSpace);
        }

        /// <summary>
        /// Draw menu with message and options
        /// </summary>
        /// <param name="message">Message to be shown to user</param>
        /// <param name="options">List of available choices</param>
        /// <param name="emptyLineSpace">Should print empty line before Input</param>
        /// <returns>Chosen option number (starting from 1...)</returns>
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
        /// Draw menu but with skip option
        /// </summary>
        /// <param name="message">Message to be shown to the user</param>
        /// <param name="options">List of available options</param>
        /// <param name="skip">Skip option</param>
        /// <param name="emptyLineSpace">Should print empty line before Input</param>
        /// <returns>Selected index (starting from 1) or -1 if skipped</returns>
        public static int DrawMenuWithSkip(string message, List<string> options, string skip, bool emptyLineSpace = true)
        {
            options.Add(skip);
            int ret = DrawMenu(message, options, emptyLineSpace);
            if (ret == options.Count)
                return -1;
            return ret;
        }

        /// <summary>
        /// Present user list of entities to choose or skip
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="message">Message to be shown to the user</param>
        /// <param name="skip">Skip option</param>
        /// <param name="values">List of entities</param>
        /// <returns>Selected entity or null if skipped</returns>
        public static T? SelectEntityOrSkip<T>(string message, string skip, List<T> values) where T : BaseEntity
        {
            int input = DrawMenuWithSkip(message, values.Select(x => x.ToString()).ToList(), skip);
            if (input == -1)
                return null;
            return values.ElementAt(input - 1);
        }

        /// <summary>
        /// Present user list of entities to choose
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="message">Message to be shown to the user</param>
        /// <param name="values">List of entities</param>
        /// <returns>Selected entity</returns>
        public static T? SelectEntity<T>(string message, List<T> values) where T : BaseEntity
        {
            int input = DrawMenu(message, values.Select(x => x.ToString()).ToList());
            if (input == -1)
                return null;
            return values.ElementAt(input - 1);
        }

        /// <summary>
        /// Present user list of entities to choose or skip
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="message">Message to be shown to the user</param>
        /// <param name="skip">Skip option</param>
        /// <param name="service">Service which items should be presented as options</param>
        /// <returns>Selected entity or null if skipped</returns>
        public static T? SelectEntityOrSkip<T>(string message, string skip, BaseService<T> service) where T : BaseEntity
        {
            if (service == null)
                return null;
            return SelectEntityOrSkip<T>(message, skip, service.Items);
        }

        /// <summary>
        /// Present user list of entities to choose
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="message">Message to be shown to the user</param>
        /// <param name="service">Service which items should be presented as options</param>
        /// <returns>Selected entity</returns>
        public static T? SelectEntity<T>(string message, BaseService<T> service) where T : BaseEntity
        {
            if (service == null)
                return null;
            return SelectEntity<T>(message, service.Items);
        }

        /// <summary>
        /// Show confirmation menu: Confirm, Abort
        /// </summary>
        /// <param name="message">Message to be shown to the user</param>
        /// <returns>True if confirmed should be selected, or False otherwise</returns>
        public static bool ConfirmationMenu(string message = "Are you sure you want to proceed?")
        {
            return DrawMenu(message, new string[] { "Confirm", "Abort" }) == 1;
        }
    }
}
