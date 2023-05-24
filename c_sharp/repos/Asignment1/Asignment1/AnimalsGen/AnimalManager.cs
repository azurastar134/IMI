using Asignment1.AnimalsGen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    class AnimalManager : ListManager<Animal>
    {
       
        private static int startID = 100;

        public bool AddAnimal(Animal animal)
        {
            bool ok = false;

            if (animal != null)
            {
                animal.Id = GetNewId(animal.Category);
                Add(animal);
                ok = true;
            }
            return ok;
        }


        //public class SortByID : IComparer<Animal>
        //{

        //    public int Compare(Animal a, Animal b)
        //    {
        //        return String.Compare(a.Id, b.Id);
        //    }
        //}

        //public class SortByName : IComparer<Animal>
        //{
            
        //    public int Compare(Animal a, Animal b)
        //    {
        //        return String.Compare(a.Name, b.Name);
        //    }
        //}

        //public void Sort(IComparer<Animal> sorter) 
        //{ 
        //    animalList.Sort(sorter); 
        //}

        public string GetNewId(CategoryType category)
        {

            string generatedID = "";


            switch (category)
            {
                case CategoryType.Mammal:
                    generatedID = "M" + (startID++).ToString();
                    break;
                case CategoryType.Reptile:
                    generatedID = "R" + (startID++).ToString();
                    break;
                case CategoryType.Bird:
                    generatedID = "B" + (startID++).ToString();
                    break;
            }
            return generatedID;

        }

        
    }
}
