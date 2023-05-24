using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1.AnimalsGen
{
    class SortById : IComparer<Animal>
    {
        public int Compare(Animal a, Animal b)
        {
            return String.Compare(a.Id, b.Id);
        }
    }
}
