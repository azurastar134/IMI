using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;

namespace Asignment1
{
    class Hawk : Bird
    {
        private FoodSchedule foodSchedule;
        private string eating;

        public Hawk(double speed, double wingsLength) : base(speed, wingsLength) //same explanation as in Dove class.
        {
            eating = "";
            SetFoodSchedule();

        }

        public string Eating
        {
            get { return eating; }
            set { eating = value; }
        }

        public override string GetAnimalString()
        {
                
            string strOut = String.Format("Hawk");
            return strOut;
        }
        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nEating mice: {0}. ", eating);

            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Omnivorous;
            foodSchedule.Add("Morning: small birds");
            foodSchedule.Add("Lunch: small frog");
            foodSchedule.Add("Evening: any meat dish");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
