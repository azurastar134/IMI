using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    abstract class Bird : Animal   // inheritance Bird --> Animal
    {
        public double speed;
        public double wingsLength;

        public Bird() { }  //make the constructors
        public Bird(double speed, double wingsLength)
        {
            this.speed = speed;
            this.wingsLength = wingsLength;

        }
        

        /// <summary>
        /// Same method as in Animal class. Prints something
        /// </summary>
        /// <returns>strOut</returns>
        public override string GetExtraInfo()
        {
            string strOut = String.Format("{0,-15} {1,6}\n{2,-15} {3,6}\n{4,-15} {5,6} \n {6,-15} {7,6}", 
                "Size: ", Size, "Category: ", CategoryType.Bird, "Wings Length (cm):", wingsLength, "No. of (km):", speed);
            

            return strOut;
        }

        
    }
}
