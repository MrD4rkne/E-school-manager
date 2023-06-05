using SchoolAverageCalculator.App.Abstract;
using SchoolAverageCalculator.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService() { 
            Items = new List<T>();
        }

        public virtual int AddItem(T item)
        {
            if (Items.Count > 0)
                item.Id = Items.Last().Id+1;
            else
                item.Id = 0;
            Items.Add(item);
            return item.Id;
        }

        public virtual bool RemoveItem(T item)
        {
            if (item == null)
                return false;
            return RemoveItem(item.Id);
        }

        public virtual bool RemoveItem(int id)
        {
            if (!Exists(id))
            {
                return false;
            }
            Items.Remove(GetItemById(id));
            return true;
        }

        public virtual bool UpdateItem(T item)
        {
            var itemToEdit = Items.FirstOrDefault(x => x.Id == item.Id);
            if (itemToEdit == null)
                return false;
            Items[(Items.IndexOf(itemToEdit))] = item;
            return true;
        }

        public virtual bool HasAnyItems()
        {
            return Items != null && Items.Any();
        }

        public virtual T? GetItemById(int id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public virtual bool Exists(T item)
        {
            if (item == null)
                return false;
            return Exists(item.Id);
        }

        public virtual bool Exists(int id)
        {
            return GetItemById(id) != null;
        }
    }
}
