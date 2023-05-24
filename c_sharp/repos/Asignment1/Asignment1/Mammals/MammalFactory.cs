using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    class MammalFactory
    {
        /// <summary>
        /// The mammal factory helps in order to get the correct enum each time.
        /// </summary>
        /// <param name="species"></param>
        /// <param name="numOfTeeth"></param>
        /// <param name="tailLength"></param>
        /// <returns>mammal</returns>
        public static Mammal CreateMammal(MammalSpecies species, int numOfTeeth, double tailLength )
        {
            Mammal mammal = null;

            switch(species)
            {
                case MammalSpecies.Cat:
                    mammal = new Cat(numOfTeeth, tailLength);
                    break;
                case MammalSpecies.Dog:
                    mammal = new Dog(numOfTeeth, tailLength);
                    break;
            }
            return mammal;
        }

    }
}
