using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;

namespace Asignment1
{
    class Dog : Mammal  // same explanation as in Dove class. 
    {
        private string breed;
        private FoodSchedule foodSchedule;

        public Dog(int numOfTeeth, double tailLength) : base(numOfTeeth, tailLength)
        {
            breed = "uknown";
            SetFoodSchedule();

        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nBreed: {0}. ", breed);

            return strOut;
        }


        public override string GetAnimalString()
        {

            string strOut = String.Format("Dog");
            return strOut;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Omnivorous;
            foodSchedule.Add("Morning: Flakes and milk");
            foodSchedule.Add("Lunch: bones and flakes");
            foodSchedule.Add("Evening: any meat dish");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}