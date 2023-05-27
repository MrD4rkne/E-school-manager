using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Abstract
{
    public interface IConsolePage
    {
        string Title { get; }
        void Draw();

    }
}
