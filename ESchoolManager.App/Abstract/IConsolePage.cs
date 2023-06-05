using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.App.Abstract
{
    public interface IConsolePage
    {
        string Title { get; }
        void Draw();

    }
}
