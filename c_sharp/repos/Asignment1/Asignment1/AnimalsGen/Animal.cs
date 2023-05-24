using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    abstract class Animal : IAnimal
    {
        private string name;
        private GenderType gender;
        private CategoryType category;
        private double age;
        private string id;
        private string size;
        

        public Animal()  // use to reset the name, gender, age
        {
            Reset();
        }

        public void Reset()  // construct the function void because it does not return something
        {
            this.name = " ";
            this.gender = GenderType.uknown;
            this.age = 0;
            this.size = " ";
            category = CategoryType.Mammal; //default values
        }

        public string Id
        {
            get {return id;}
            set
            {
                if (value.Length > 0)
                    id = value;
            }
        }
            
        public string Size  // set and getters
        {
            get { return size; }
            set { size = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Age
        {
            get { return age; }
            set { age = value; }
        }



        public CategoryType Category
        {
            get { return category; }
            set { category = value; }
        }

        public GenderType Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public override string ToString() // To string method in order to print later some results
        {
            string strOut = string.Format("{0,-8} {1,-20} {2,-6} {3,-9}", id, name, age, gender.ToString());

           

            return strOut;
        }
       
        public virtual string GetAnimalString()
        {
            string strOut = string.Empty;

            return strOut;
        }
        public abstract FoodSchedule GetFoodSchedule();

        public virtual string GetExtraInfo()
        {
            string strOut = string.Empty;

            strOut = string.Format("{0,-15} {1,10}\n, {1, -15} {2,10}", "Category:", category.ToString(), "Size: " , size);

            return strOut;
        }



    }
}
