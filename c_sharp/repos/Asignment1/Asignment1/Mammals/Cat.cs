using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;


namespace Asignment1
{
    class Cat : Mammal
    {
        private int cuteness;
        private FoodSchedule foodSchedule;

        public Cat(int numOfTeeth, double tailLength) : base(numOfTeeth, tailLength) //same explanation as in Dove class. Nothing new here.
        {
            cuteness = 0;
            SetFoodSchedule();
        }

        public int Cuteness
        {
            get { return cuteness; }
            set { cuteness = value; }
        }

        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nCuteness: {0}. ", cuteness);

            return strOut;
        }

        public override string GetAnimalString()
        {

            string strOut = String.Format("Cat");
            return strOut;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Omnivorous;
            foodSchedule.Add("Morning: Flakes and milk");
            foodSchedule.Add("Lunch: mice and water");
            foodSchedule.Add("Evening: any cat dish");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }

    }
}
