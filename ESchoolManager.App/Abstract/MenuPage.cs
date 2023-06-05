using ESchoolManager.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.App.Abstract
{
    public abstract class MenuPage : BasePage
    {
        public abstract string[] Options { get; }

        /// <summary>
        /// BasePage.Draw() then PresentChoice()
        /// </summary>
        public override void Draw()
        {
            base.Draw();
            PresentChoice();
        }
        /// <summary>
        /// Print message and draw menu with options to select
        /// </summary>
        /// <param name="message"></param>
        protected void PresentChoice(string message = "Choose what to do:")
        {
            HandleChoice(DrawManager.DrawMenu(message, Options));
        }
        /// <summary>
        /// Method for handling user's choice
        /// Option 1 stands for Options[0] ...
        /// </summary>
        /// <param name="option"></param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void HandleChoice(int option)
        {
            switch (option)
            {
                default: throw new NotImplementedException($"Error occured, option does't exist: {Environment.NewLine}Option: {option}{Environment.NewLine}Options: {string.Join(" | ", Options)}");
            }
        }
    }
}
