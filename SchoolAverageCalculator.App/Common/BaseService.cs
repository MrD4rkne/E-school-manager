using SchoolAverageCalculator.App.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAverageCalculator.App.Common
{
    public class BaseService<T> : IService<T> where T : Domain.Common.BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService() { 
            Items = new List<T>();
        }

        public virtual int AddItem(T item)
        {
            item.Id = Items.Count; 
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
            if (!Items.Any(x => x.Id == id))
            {
                return false;
            }
            Items.Remove(Items.Find(x => x.Id == id));
            return true;
        }

        public virtual bool UpdateItem(T item)
        {
            var toEdit = Items.FirstOrDefault(x => x.Id == item.Id);
            if (toEdit == null)
                return false;

            Items[(Items.IndexOf(toEdit))] = item;
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
            if (item == null || item.Id==null)
                return false;
            return Exists(item.Id);
        }

        public virtual bool Exists(int id)
        {
            return GetItemById(id) != null;
        }
    }
}
