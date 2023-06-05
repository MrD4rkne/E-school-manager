using ESchoolManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ESchoolManager.App.Abstract
{
    internal interface IService<T> where T : BaseEntity
    {
        List<T> Items { get; set; }
        int AddItem(T item);
        bool RemoveItem(T item);
        bool RemoveItem(int id);
        bool UpdateItem(T item);
        bool Exists(T item);
        bool Exists(int id);
        bool HasAnyItems();
        T? GetItemById(int id);

    }
}
