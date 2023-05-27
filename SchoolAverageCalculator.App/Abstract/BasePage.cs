using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Abstract
{
    public abstract class BasePage : IConsolePage
    {
        public BasePage() { }
        public abstract string Title { get; }

        public virtual void Draw()
        {
            Console.Clear();
            Action();
        }

        public virtual void Action() { }

        public abstract bool Prepare();
    }
}
