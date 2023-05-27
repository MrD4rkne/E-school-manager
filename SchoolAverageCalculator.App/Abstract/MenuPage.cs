using SchoolAverageCalculator.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Abstract
{
    public abstract class MenuPage : BasePage
    {
        public abstract string[] Options { get; }
        public override void Draw()
        {
            base.Draw();
            PresentChoice();
        }
        protected void PresentChoice(string message = "Choose what to do:")
        {
            HandleChoice(DrawManager.DrawMenu(message, Options));
        }
        public virtual void HandleChoice(int option)
        {
            switch (option)
            {
                default: throw new NotImplementedException($"Error occured, option does't exist: {Environment.NewLine}Option: {option}{Environment.NewLine}Options: {string.Join(" | ", Options)}");
            }
        }
    }
}
