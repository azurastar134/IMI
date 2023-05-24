using System;
using System.Collections.Generic;
using System.Text;


namespace Asignment1
{
     abstract class Mammal: Animal
     {
        public int numOfTeeth;
        public double tailLength;

        public Mammal(int numOfTeeth, double tailLength)
        {
            this.numOfTeeth = numOfTeeth;
            this.tailLength = tailLength;

        }

 

        public override string GetExtraInfo()
        {
            string strOut = String.Format("{0,-15} {1,6}\n{2,-15} {3,6}\n{4,-15} {5,6}\n {6,-15} {7,6}",
                "Size: ", Size, "Category: ", CategoryType.Mammal, "Tail Length (cm):", tailLength, "No.of teeth:", numOfTeeth);


            return strOut;
        }

       


     }
}
