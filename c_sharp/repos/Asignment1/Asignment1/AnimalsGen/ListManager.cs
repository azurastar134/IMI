using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1.AnimalsGen
{
    public class ListManager<T> : IListManager<T>
    {

        private List<T> list;

        public ListManager()
        {
            list = new List<T>();
        }

        public bool Add(T type)
        {
            list.Add(type);
            return true;
        }

        public void Sort(IComparer<T> sorter)
        {
            list.Sort(sorter);
        }

        public bool ChangeAt(T type, int index)
        {
            if(CheckIndex(index) && (type !=null))
            {
                DeleteAt(index);
                list.Insert(index, type);
                return true;
            }

            return false;
        }



        public bool DeleteAt(int index)
        {
            bool ok = false;
            if(CheckIndex(index))
            {
                list.RemoveAt(index);
                ok = true;
            }

            return ok;
        }


        public T GetAt(int index)
        {
            if(CheckIndex(index))
            {
                return list[index];
            }

            return default(T);
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool CheckIndex(int index)
        {
            return (index >= 0) && (index < list.Count);
        }

        public void DeleteAll()
        {
            list.Clear();
        }

        public string[] ToStringArray()
        {
            if (Count > 0)
            {
                string[] infoStrings = new string[Count];

                for (int i = 0; i< Count; i++)
                {
                    infoStrings[i] = list[i].ToString();
                }

                return infoStrings;
            }

            return null;
        }

        public List<string> ToStringList()
        {
            if ( Count > 0)
            {
                List<string> infolist = new List<string>();

                for (int i = 0; i< Count; i++)
                {
                    infolist.Add(list[i].ToString());
                }
                return infolist;
            }
            return null;
        }


    }
}
