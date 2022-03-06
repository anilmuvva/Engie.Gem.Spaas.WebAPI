using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engie.Gem.Spaas.WebAPI.DomainModel;

namespace Engie.Gem.Spaas.WebAPI.DTO
{
    public class RequestPayload
    {
        public int? Load { get; set; }
        public Fuels Fuels { get; set; }
        public List<PowerPlant> Powerplants { get; set; }
    }
}
