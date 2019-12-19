using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starships.Resupply.Domain.Interfaces
{
    public interface IStarshipRepository
    {
        Task<IEnumerable<Starship>> GetAllStarships();
    }
}
