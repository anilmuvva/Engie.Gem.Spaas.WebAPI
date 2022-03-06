using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Engie.Gem.Spaas.WebAPI.DomainModel
{
    public class Fuels
    {        
        
        [JsonPropertyName("gas(euro/MWh)")]
        public double? GasEuroMWh { get; set; }

        [JsonPropertyName("kerosine(euro/MWh)")]
        public double? KerosineEuroMWh { get; set; }

        [JsonPropertyName("co2(euro/ton)")]
        public int? Co2EuroTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public int? Wind { get; set; }
    }

}
