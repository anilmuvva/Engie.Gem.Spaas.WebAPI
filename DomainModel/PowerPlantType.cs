using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Engie.Gem.Spaas.WebAPI.DomainModel
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PowerPlantType
    {       
       gasfired,
       turbojet,
       windturbine       
    }
}
