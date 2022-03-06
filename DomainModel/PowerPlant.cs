using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Engie.Gem.Spaas.WebAPI.DomainModel
{
    public class PowerPlant
    {
        public string Name { get;set;}
        
        public PowerPlantType? Type { get; set;}

        public double? Efficiency { get; set; }

        public int? Pmin { get; set; }

        public int? Pmax { get; set; }

        public double? Cost { get; set; }

    }
}
