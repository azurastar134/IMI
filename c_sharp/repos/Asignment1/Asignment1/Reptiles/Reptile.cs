using System;


namespace Asignment1
{
    abstract class Reptile : Animal
    {
        public double weight;
        public string livesInWater;

        public Reptile(double weight, string livesInWater)
        {
            this.weight = weight;
            this.livesInWater = livesInWater;
        }



        public override string GetExtraInfo()
        {
            string strOut = String.Format("{0,-15} {1,6}\n{2,-15} {3,6}\n{4,-15} {5,6}\n {6,-15} {7,6}",
                "Size: ", Size, "Category: ", CategoryType.Reptile, "Weight in kg:", weight, "Lives in water:", livesInWater);


            return strOut;
        }
    }


}
