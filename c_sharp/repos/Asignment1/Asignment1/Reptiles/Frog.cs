using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;

namespace Asignment1
{
    class Frog : Reptile
    {
        private string venomous;
        private FoodSchedule foodSchedule;

        public Frog(double weight, string livesInWater) : base(weight, livesInWater) //same explanation as in dove class. 
        {
            venomous = "";
            SetFoodSchedule();
        }

        public string Venomous
        {
            get { return venomous; }
            set { venomous = value; }
        }

        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nVenomous: {0} ", venomous);

            return strOut;
        }

        public override string GetAnimalString()
        {

            string strOut = String.Format("Frog");
            return strOut;
        }
        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Omnivorous;
            foodSchedule.Add("Morning: ants and ladybugs");
            foodSchedule.Add("Lunch: mosquitos");
            foodSchedule.Add("Evening: any bug");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
