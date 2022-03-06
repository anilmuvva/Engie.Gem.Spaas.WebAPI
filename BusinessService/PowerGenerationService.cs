using Engie.Gem.Spaas.WebAPI.DomainModel;
using Engie.Gem.Spaas.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Engie.Gem.Spaas.WebAPI.BusinessService
{
    public class PowerGenerationService : IPowerGenerationService
    {
        private readonly ILogger<PowerGenerationService> _logger;
        public PowerGenerationService(ILogger<PowerGenerationService> logger)
        {
            this._logger = logger;
        }

        public async Task<IList<ResponsePayload>> GetproductionPlanAsync(RequestPayload request)
        {
            _logger.LogInformation("Started Here");

            var response = new List<ResponsePayload>();

            //Get the load
            var load = request.Load;

            //Calculate merit order
            var meritPowerPlants = await GetMeritOrder(request.Powerplants, request.Fuels);

            // after based on cost asc get the pmax and pmin with load and get the responseoutput.

            foreach (var p in meritPowerPlants)
            {
                if ( load > p.Pmax )
                {
                    response.Add(new ResponsePayload { Name = p.Name, P = p.Pmax });
                    load -= p.Pmax;
                  
                }
                else if(load > p.Pmin && load < p.Pmax)
                {
                    response.Add(new ResponsePayload { Name = p.Name, P = load });
                    load = 0;
                   
                }
                else
                {
                    response.Add(new ResponsePayload { Name = p.Name, P = 0 });                   
                }
              
            }

            return response;
        }


        public async Task<IEnumerable<PowerPlant>> GetMeritOrder(List<PowerPlant> powerPlants, Fuels fuels)
        {
            
            //cost for each power plant
            foreach (var p in powerPlants)
            {
                if (p.Type == PowerPlantType.gasfired)
                {
                    var cost = fuels.GasEuroMWh / p.Efficiency;
                    p.Cost = cost;                   
                    
                }
                else if(p.Type == PowerPlantType.turbojet )
                {
                    var cost =  fuels.KerosineEuroMWh / p.Efficiency;
                    p.Cost = cost;
                    
                }
                else
                {
                    var cost = 0;
                    p.Cost = cost;
                   
                }
                
            }
            return await Task.Run(() => powerPlants.OrderBy(m => m.Cost));

        }
    }
}
