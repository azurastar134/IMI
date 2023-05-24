using System;
using System.Collections.Generic;
using System.Text;

namespace Asignment1
{
    interface IAnimal
    {
        string Size { get; set; }
        string Name { get; set; }
        string Id { get; set; }

        GenderType Gender { get; set; }
        CategoryType Category { get; set; }

        FoodSchedule GetFoodSchedule();

        string GetExtraInfo();
    }
}
