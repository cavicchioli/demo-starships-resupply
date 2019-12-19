using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Starships.Resupply.Application.ResponseModels;

namespace Starships.Resupply.Application.Interfaces
{
    public interface IStarshipsAppService
    {
        Task<IEnumerable<ResupplyResponse>> CalculateResupplyRequiredForAllStarships(decimal distance);
    }
}
