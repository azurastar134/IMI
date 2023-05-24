using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;

namespace Asignment1
{
    class Lizard : Reptile
    {
        private string continent;
        private FoodSchedule foodSchedule;

        public Lizard(double weight, string livesInWater) : base(weight, livesInWater)  //same explanation as in dove class
        {
            continent = "";
            SetFoodSchedule();
        }

        public string Continent
        {
            get { return continent; }
            set { continent = value; }
        }

        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nContinent: {0} ", continent);

            return strOut;
        }
        public override string GetAnimalString()
        {

            string strOut = String.Format("Lizard");
            return strOut;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Omnivorous;
            foodSchedule.Add("Morning: ants");
            foodSchedule.Add("Lunch: flies");
            foodSchedule.Add("Evening: any bug");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
