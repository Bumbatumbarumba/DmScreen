using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreen.classes
{
    class City
    {
        public string Name { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int PartyPopularity { get; set; }
        public string CityDescription { get; set; }

        public City(string name, int xpos, int ypos, string desc)
        {
            this.Name = name;
            this.Xpos = xpos;
            this.Ypos = ypos;
            this.PartyPopularity = 50;
            this.CityDescription = desc;
        }
    }
}
