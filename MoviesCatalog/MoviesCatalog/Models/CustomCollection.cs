using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviesCatalog.Models
{
    public class CustomCollection<T> : ObservableCollection<T>
    {

        public CustomCollection() : base()
        {
            System.Diagnostics.Debug.WriteLine("Test");
        }

        bool IsElementDuplicate(T element)
        {
            foreach (T elementInList in this)
            {
                if (elementInList.Equals(element))
                    return true;
            }
            return false;
        }

        public void PushNonDuplicate(T obj)
        {
            if (IsElementDuplicate(obj)) return;
            this.Add(obj);
        }

        public void Pop(T obj)
        {
            this.Remove(obj);
        }

        public void PopAt(int index)
        {
            this.RemoveAt(index);
        }

        public T ElementAt(int index)
        {
            return this[index];
        }

        public int FindIndex(T obj)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ElementAt(i).Equals(obj)) return i;
            }
            return -1;
        }        

        
    }
}
