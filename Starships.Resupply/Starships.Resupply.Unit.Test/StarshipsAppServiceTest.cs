using Moq;
using Starships.Resupply.Application;
using Starships.Resupply.Application.Interfaces;
using Starships.Resupply.Domain.Interfaces;
using Starships.Resupply.Unit.Test.Mock;
using System;
using System.Linq;
using Xunit;

namespace Starships.Resupply.Unit.Test
{
    public class StarshipsAppServiceTest
    {
        [Fact(DisplayName = "Calculate Resupply")]
        [Trait("Starship", "Functions StarshipsAppService")]
        public async void StarshipsAppService_CalculateResupplyForAListOfShips_MustReturnNotNull()
        {
            var starshipFaker = new StarshipFaker();
            var starshipsRepository = new Mock<IStarshipRepository>();
            var randomDistance = new Random().Next(1, 1000000000);
            starshipsRepository.Setup(r => r.GetAllStarships())
                .Returns(starshipFaker.getAllStarshipsMock());

            var starshipService = new StarshipsAppService(starshipsRepository.Object);

            // Act
            var starshipsResupply = await starshipService.CalculateResupplyRequiredForAllStarships(randomDistance);

            // Assert
            Assert.NotNull(starshipsResupply);
            Assert.NotNull(starshipsResupply.FirstOrDefault().StarshipName);
            Assert.NotNull(starshipsResupply.FirstOrDefault().StarshipUrl);
            Assert.NotNull(starshipsResupply.FirstOrDefault().TotalStopsRequired);
        }
    }
}
