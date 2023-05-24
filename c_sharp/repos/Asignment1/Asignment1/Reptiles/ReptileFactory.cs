using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    class ReptileFactory
    {
        /// <summary>
        /// Here is the method for creating a reptile object. With using switch again and cases so we can always be able to choose the right category.
        /// </summary>
        /// <param name="species"></param>
        /// <param name="weight"></param>
        /// <param name="livesInWater"></param>
        /// <returns>reptile</returns>
        public static Reptile CreateReptile(ReptileSpecies species, double weight , string livesInWater)
        {
            Reptile reptile = null;

            switch (species)
            {
                case ReptileSpecies.Snake:
                    reptile = new Snake(weight, livesInWater);
                    break;
                case ReptileSpecies.Frog:
                    reptile = new Frog(weight, livesInWater);
                    break;
                case ReptileSpecies.Lizard:
                    reptile = new Lizard(weight, livesInWater);
                    break;
            }
            return reptile;
        }

    }
}
