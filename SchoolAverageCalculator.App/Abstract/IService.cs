using SchoolAverageCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Abstract
{
    internal interface IService<T> where T : BaseEntity
    {
        List<T> Items { get; set; }
        int AddItem(T item);
        bool RemoveItem(T item);
        bool UpdateItem(T item);
        bool HasAnyItems();
        T GetItemById(int id);

    }
}
