using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    class BirdFactory
    {
        /// <summary>
        /// Make a function that creates an objects and gives the attributes that are written as parameters. There is a switch where it helps us to choose the our desired result every time.
        /// </summary>
        /// <param name="species"></param>
        /// <param name="speed"></param>
        /// <param name="wingsLength"></param>
        /// <returns>bird</returns>
        public static Bird CreateBird(BirdSpecies species, double speed , double wingsLength)
        {
            Bird bird = null;

            switch (species)
            {
                case BirdSpecies.Hawk:
                    bird = new Hawk(speed, wingsLength);
                    break;
                case BirdSpecies.Dove:
                    bird = new Dove(speed, wingsLength);
                    break;
            }
            return bird;
        }

    }
}
