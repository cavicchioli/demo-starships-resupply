using AutoMapper;

namespace Starships.Resupply.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new DomainToResponseProfile());
                //cfg.AddProfile(new ResponseToDomainProfile());
            });
        }
    }
}
