using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engie.Gem.Spaas.WebAPI.DTO;

namespace Engie.Gem.Spaas.WebAPI.BusinessService
{
    public interface IPowerGenerationService
    {
       Task<IList<ResponsePayload>> GetproductionPlanAsync(RequestPayload request);
    }
}
