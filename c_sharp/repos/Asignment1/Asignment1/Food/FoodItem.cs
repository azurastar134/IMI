using Asignment1.AnimalsGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1.Food
{
    public class FoodItem
    {
        private string name;

        private ListManager<string> ingredients;


        public FoodItem()
        {
            ingredients = new ListManager<string>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ListManager<string> Ingredients
        {
            get { return ingredients; }
        }

        public override string ToString()
        {
            string strItem = string.Empty; 

            for(int i = 0; i < ingredients.Count; i++)
            {
                strItem += ingredients.GetAt(i);
                if(i != ingredients.Count - 1)
                {
                    strItem += ", ";
                }
                else
                {
                    strItem += ".";
                }
            }
            strItem = $"{name, -12}{strItem}";

            return strItem;
        }
       
    }
}
