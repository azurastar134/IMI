using System;
using System.Collections.Generic;
using System.Text;
using static Asignment1.FoodSchedule;

namespace Asignment1
{
    class Dove : Bird // here is the class of Dove where is also a Bird.
    {
        private string colors;
        private FoodSchedule foodSchedule;

        public Dove(double speed, double wingsLength) : base(speed, wingsLength) // constructor for Dove class. Access base class
        {
            colors = " ";
            SetFoodSchedule();

        }

        public string Colors //setter and getter method for color
        {
            get { return colors; }
            set { colors = value; }
        }

        public override string GetExtraInfo() // ToStrinf method in order to update
        {
            string strOut = base.GetExtraInfo();
            strOut += String.Format("\nColor/s: {0}. ", colors );

            return strOut;
        }

        public override string GetAnimalString()
        {

            string strOut = String.Format("Dove");
            return strOut;
        }

        private void SetFoodSchedule()
        {
            foodSchedule = new FoodSchedule();
            foodSchedule.Eatertype = EaterType.Carnivora;
            foodSchedule.Add("Morning: Flakes and seed");
            foodSchedule.Add("Lunch: ants");
            foodSchedule.Add("Evening: any veggie dish");

        }

        public override FoodSchedule GetFoodSchedule()
        {
            return foodSchedule;
        }
    }
}

