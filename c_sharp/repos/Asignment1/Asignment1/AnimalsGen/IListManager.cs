using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    public interface IListManager<T>
    {
        int Count { get; }

        bool Add(T type);

        bool ChangeAt(T type, int index);

        bool CheckIndex(int index);

        void DeleteAll();

        bool DeleteAt(int index);

        T GetAt(int index);

        string[] ToStringArray();

        List<string> ToStringList();
    }
}
