
using Bogus;
using Starships.Resupply.Application.ResponseModels;
using Starships.Resupply.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Starships.Resupply.Unit.Test.Mock
{
    public class StarshipFaker
    {
        //COULD BE RANDON STRINGS.
        private int numberOfStarships;
        readonly IEnumerable<string> starshipsNames;
        readonly IEnumerable<string> starshipsModels;
        readonly IEnumerable<string> starshipManufacturer;
        readonly IEnumerable<string> starshipClasses;
        readonly IEnumerable<string> timeLabel;

        public StarshipFaker()
        {
            numberOfStarships = new Random().Next(1,50);

            starshipsNames = new List<string>() { "Executor", "Sentinel-class landing craft", "Death Star", "Millennium Falcon", "Y-wing", "X-wing", "TIE Advanced x1", "Slave 1", "Imperial shuttle", "EF76 Nebulon-B escort frigate", "Calamari Cruiser", "A-wing", "B-wing", "Republic Cruiser", "Naboo fighter", "Naboo Royal Starship", "Scimitar", "J-type diplomatic barge", "AA-9 Coruscant freighter", "Jedi starfighter", "H-type Nubian yacht", "Star Destroyer", "Trade Federation cruiser", "Theta-class T-2c shuttle", "T-70 X-wing fighter", "Rebel transport", "Droid control ship", "Republic Assault ship", "Solar Sailer", "Republic attack cruiser", "Naboo star skiff", "Jedi Interceptor", "arc-170", "Belbullab-22 starfighter", "V-wing", "CR90 corvette", "Banking clan frigate" };
            starshipsModels = new List<string>() { "Executor-class star dreadnought", "Sentinel-class landing craft", "DS-1 Orbital Battle Station", "YT-1300 light freighter", "BTL Y-wing", "T-65 X-wing", "Twin Ion Engine Advanced x1", "Firespray-31-class patrol and attack", "Lambda-class T-4a shuttle", "EF76 Nebulon-B escort frigate", "MC80 Liberty type Star Cruiser", "RZ-1 A-wing Interceptor", "A/SF-01 B-wing starfighter", "Consular-class cruiser", "N-1 starfighter", "J-type 327 Nubian royal starship", "Star Courier", "J-type diplomatic barge", "Botajef AA-9 Freighter-Liner", "Delta-7 Aethersprite-class interceptor", "H-type Nubian yacht", "Imperial I-class Star Destroyer", "Providence-class carrier/destroyer", "Theta-class T-2c shuttle", "T-70 X-wing fighter", "GR-75 medium transport", "Lucrehulk-class Droid Control Ship", "Acclamator I-class assault ship", "Punworcca 116-class interstellar sloop", "Senator-class Star Destroyer", "J-type star skiff", "Eta-2 Actis-class light interceptor", "Aggressive Reconnaissance-170 starfighte", "Belbullab-22 starfighter", "Alpha-3 Nimbus-class V-wing starfighter", "CR90 corvette", "Munificent-class star frigate" };
            starshipManufacturer = new List<string>() { "Kuat Drive Yards, Fondor Shipyards", "Sienar Fleet Systems, Cyngus Spaceworks", "Imperial Department of Military Research, Sienar Fleet Systems", "Corellian Engineering Corporation", "Koensayr Manufacturing", "Incom Corporation", "Sienar Fleet Systems", "Kuat Systems Engineering", "Kuat Drive Yards", "Mon Calamari shipyards", "Alliance Underground Engineering, Incom Corporation", "Slayn & Korpil", "Theed Palace Space Vessel Engineering Corps", "Theed Palace Space Vessel Engineering Corps, Nubia Star Drives", "Republic Sienar Systems", "Botajef Shipyards", "Rendili StarDrive, Free Dac Volunteers Engineering corps.", "Cygnus Spaceworks", "Incom", "Gallofree Yards, Inc.", "Hoersch-Kessel Drive, Inc.", "Rothana Heavy Engineering", "Huppla Pasa Tisc Shipwrights Collective", "Kuat Drive Yards, Allanteen Six shipyards", "Theed Palace Space Vessel Engineering Corps/Nubia Star Drives, Incorporated", "Incom Corporation, Subpro Corporation", "Feethan Ottraw Scalable Assemblies", "Hoersch-Kessel Drive, Inc, Gwori Revolutionary Industries" };
            starshipClasses = new List<string>() { "Star dreadnought", "landing craft", "Deep Space Mobile Battlestation", "Light freighter", "assault starfighter", "Starfighter", "Patrol craft", "Armed government transport", "Escort ship", "Star Cruiser", "Assault Starfighter", "Space cruiser", "yacht", "Space Transport", "Diplomatic barge", "freighter", "Star Destroyer", "capital ship", "transport", "fighter", "Medium transport", "Droid control ship", "assault ship", "star destroyer", "starfighter", "corvette", "cruiser" };
            timeLabel = new List<string>() { "year", "month", "week", "day", "hour" };
        }

        public async Task<IEnumerable<Starship>> getAllStarshipsMock()
        {
            var starshipFaker = new Faker<Starship>()
                .RuleFor(s => s.Name, f => f.PickRandom(starshipsNames))
                .RuleFor(s => s.Model, f => f.PickRandom(starshipsModels))
                .RuleFor(s => s.Manufacturer, f => f.PickRandom(starshipManufacturer))
                .RuleFor(s => s.CostInCredits, f => f.Random.ULong(1000,100000000000).ToString())
                .RuleFor(s => s.Length, f => f.Random.Float(1, 100000).ToString())
                .RuleFor(s => s.MaxAtmospheringSpeed, f => f.Random.UInt(1000,100000).ToString())
                .RuleFor(s => s.Crew, f => f.Random.UInt(1000, 1000000).ToString())
                .RuleFor(s => s.Passengers, f => f.Random.UInt(1000, 1000000).ToString())
                .RuleFor(s => s.CargoCapacity, f => f.Random.ULong(0,1000000000000).ToString())
                .RuleFor(s => s.Consumables, f => $"{f.Random.UInt(1, 1000)} {f.PickRandom(timeLabel)}")
                .RuleFor(s => s.HyperdriveRating, f => f.Random.Float(1, 10).ToString())
                .RuleFor(s => s.Mglt, f => f.Random.UInt(1000, 100000).ToString())
                .RuleFor(s => s.StarshipClass, f => f.PickRandom(starshipClasses))
                .RuleFor(s => s.Pilots, f => f.Make(f.Random.Int(0, 10), () => new Uri(f.Internet.Url())))
                .RuleFor(s => s.Films, f => f.Make(f.Random.Int(0, 100), () => new Uri(f.Internet.Url())))
                .RuleFor(s => s.Created, f => f.Date.Past())
                .RuleFor(s => s.Edited, f => f.Date.Recent())
                .RuleFor(s => s.Url, f => new Uri(f.Internet.Url()));

            return await Task.FromResult<IEnumerable<Starship>>(starshipFaker.Generate(numberOfStarships));
        }


        public async Task<IEnumerable<ResupplyResponse>> getAllStarshipsCalculedResupplyMock()
        {
            var resupplyFaker = new Faker<ResupplyResponse>()
                    .RuleFor(s => s.StarshipName, f => f.PickRandom(starshipsNames))
                    .RuleFor(s => s.StarshipUrl, f => new Uri(f.Internet.Url()))
                    .RuleFor(s => s.TotalStopsRequired, f => f.Random.Int(0, 10000000).ToString());

            return await Task.FromResult<IEnumerable<ResupplyResponse>>(resupplyFaker.Generate(numberOfStarships));
        }
    }
}
