using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.App.Abstract
{
    public abstract class BasePage : IConsolePage
    {
        public BasePage() { }

        public abstract string Title { get; }

        /// <summary>
        /// Method executed before Drawing the page, determines if it can be shown
        /// On default page doesn't need to be prepared, otherwise override
        /// Should entry data be invalid, throw InvalidDataException
        /// </summary>
        /// <returns></returns>
        public virtual bool Prepare()
        {
            return true;
        }

        /// <summary>
        /// Clear screen, then execute Action()
        /// </summary>
        public virtual void Draw()
        {
            Console.Clear();
            Action();
        }

        /// <summary>
        /// Main action executed in Draw()
        /// </summary>
        public virtual void Action() { }

    }
}
