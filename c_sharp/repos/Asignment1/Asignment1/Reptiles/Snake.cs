using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;

namespace Asignment1
{
    class Snake : Reptile
    {
        private string length;
        private FoodSchedule foodSchedule;
        public Snake(double weight, string livesInWater) : base(weight, livesInWater) //same explanation as in dove class
        {
            length = "";
            SetFoodSchedule();
        }

        public string Length
        {
            get { return length; }
            set { length = value; }
        }

        public override string GetExtraInfo()
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nLength: {0} ", length);

            return strOut;
        }

        public override string GetAnimalString()
        {

            string strOut = String.Format("Snake");
            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Carnivora;
            foodSchedule.Add("Morning: mice");
            foodSchedule.Add("Lunch: 2 small birds");
            foodSchedule.Add("Evening: any meat dish");

        }
        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}
