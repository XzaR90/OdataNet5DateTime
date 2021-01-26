using AutoMapper;

namespace OdataNet5DateTime
{
    public class MappingToDtoProfile : Profile
    {
        public MappingToDtoProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDto>().ReverseMap();
        }
    }
}
