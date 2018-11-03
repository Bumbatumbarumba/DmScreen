using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreen.classes
{
    //
    // Read this list for an idea as to what might be encompassed by the enums:
    // https://en.wikipedia.org/wiki/List_of_building_types
    enum StructureType
    {
        Agricultural,
        Commercial,
        Residential,
        Medical,
        Educational,
        Civic,
        Religious,
        Government,
        Industrial,
        Military,
        Parking_or_storage,
        Transportation,
        NonBuildings,
        Infrastructure,
        Power,
        Other
    }

    class Structure
    {
        public StructureType StructureType { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }

        public Structure(StructureType type, string name, string owner, string desc)
        {
            this.StructureType = type;
            this.Name = name;
            this.Owner = owner;
            this.Description = desc;
        }
    }
}
