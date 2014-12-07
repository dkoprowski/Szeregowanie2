using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SzeregowanieProjekt2.Models.BasicModels
{
    public class Color
    {
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }

        public Color()
        {
            Random randomizer = new Random();
            red = randomizer.Next(255);
            green = randomizer.Next(255);
            blue = randomizer.Next(255);
        }
    }
}
