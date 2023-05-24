using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1.AnimalsGen
{
    class SortByName : IComparer<Animal>
    {
        public int Compare(Animal a, Animal b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }
}
