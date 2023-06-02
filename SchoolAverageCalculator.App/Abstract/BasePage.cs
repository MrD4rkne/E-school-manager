using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        /// Main action executed in Draw()
        /// </summary>
        public virtual void Action() { }

        /// <summary>
        /// Method executed before Drawing the page, determines if it can be shown
        /// Defaulty page doesn't need to be prepared, otherwise override
        /// Should entry data be invalid, throw InvalidDataException
        /// </summary>
        /// <returns></returns>
        public virtual bool Prepare()
        {
            return true;
        }

    }
}
