using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starships.Resupply.Application.Interfaces;
using Starships.Resupply.Application.ResponseModels;
using Starships.Resupply.Domain;
using Starships.Resupply.Domain.Interfaces;

namespace Starships.Resupply.Application
{
    public class StarshipsAppService : IStarshipsAppService
    {
        private readonly IStarshipRepository _starshipRepository;
        public StarshipsAppService(IStarshipRepository starshipRepository)
        {
            _starshipRepository = starshipRepository;
        }

        public async Task<IEnumerable<ResupplyResponse>> CalculateResupplyRequiredForAllStarships(decimal distance)
        {
            var starships = await _starshipRepository.GetAllStarships();
            var calculedResupplies = new List<ResupplyResponse>();

            foreach (var starship in starships)
            {
                calculedResupplies.Add(CalculateResupplyStops(starship, distance));
            }

            return calculedResupplies;
        }


        private ResupplyResponse CalculateResupplyStops(Starship starship, decimal distance)
        {
            var response = new ResupplyResponse
            {
                StarshipName = starship.Name,
                StarshipUrl = starship.Url
            };


            if (!int.TryParse(starship.Mglt, out int starshipSpeed)
                || string.IsNullOrWhiteSpace(starship.Consumables)
                || starship.Consumables.Contains("unknown"))
            {
                response.TotalStopsRequired = "unknown";
                return response;
            }

            var dateFrom = DateTime.Now.Date;
            DateTime dateTo;
            var timeLabel = starship.Consumables.Split(" ")[1].Replace("s", "");
            int.TryParse(starship.Consumables.Split(" ")[0], out int timeValue);

            var performance = 0.0;

            switch (timeLabel)
            {
                case "year":
                    dateTo = dateFrom.AddYears(timeValue);
                    performance = dateTo.Subtract(dateFrom).TotalHours;
                    break;
                case "month":
                    dateTo = dateFrom.AddMonths(timeValue);
                    performance = dateTo.Subtract(dateFrom).TotalHours;
                    break;
                case "week":
                    dateTo = dateFrom.AddDays(timeValue * 7);
                    performance = dateTo.Subtract(dateFrom).TotalHours;
                    break;
                case "day":
                    dateTo = dateFrom.AddDays(timeValue);
                    performance = dateTo.Subtract(dateFrom).TotalHours;
                    break;
                case "hour":
                    performance = timeValue;
                    break;

                default:
                    break;
            }

            var totalHoursNeeded = distance / starshipSpeed;

            //if(totalHoursNeeded > (decimal)performance)
            //{
            var totalResupplysNeeded = totalHoursNeeded / (decimal)performance;
            response.TotalStopsRequired = (totalResupplysNeeded > 0 ? Math.Round(totalResupplysNeeded) : 0).ToString();

            //    return response;
            //}


            //response.TotalStopsRequired = "0";

            return response;
        }

    }
}
