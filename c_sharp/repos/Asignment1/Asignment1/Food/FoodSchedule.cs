using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    class FoodSchedule
    {
        private EaterType eaterType;
        private List<string> foodList;


        public FoodSchedule()
        {
            foodList = new List<string>();
        }

        public enum EaterType
        {
            // meat eater
            Carnivora,
            // plant eaters
            Herbivore,
            // all eaters
            Omnivorous
        }

        public EaterType Eatertype
        {
            get { return eaterType; }
            set { eaterType = value; }
        }

        public void Add(string item)
        {
            foodList.Add(item);
        }

        public int Count
        {
            get { return foodList.Count; }
        }


        public bool CheckIndex(int index)
        {
            return (index >= 0) && (index < foodList.Count);
        }

        public string Title()
        {
            return "Food details and the feeding schedule are as follows: ";
        }



        public bool DeleteAt(int index)
        {
            bool ok = true;
            if (CheckIndex(index))
            {
                foodList.RemoveAt(index);
            }
            else
                ok = false;
            return ok;
        }

        public bool ChangeAt(int index, string item)
        {
            bool ok = true;
            if (CheckIndex(index))
            {
                foodList[index] = item;
            }
            else
                ok = false;
            return ok;
        }

        public override string ToString()
        {
            if (Count > 0)
            {
                string text = "";

                for (int i = 0; i < Count; i++)
                {
                    text += foodList[i] + "\n";
                }
                return text;
            }
            return null;
        }


        /// <summary>
        /// Provide an array of strings in which each string gives information about an
        /// object in the collection.  The function calls every object's ToString method.
        /// </summary>
        /// <returns>Array of strings containing info about the animal object.</returns>
        /// <remarks></remarks>
        public string[] GetFoodInfoStringArray()
        {
            string[] infoStrings = foodList.ToArray();

            return infoStrings;
        }
    }
}
