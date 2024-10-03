using AutoMapper;
using jjournal.Application.Services.Mapper;

namespace jjournal.CommonTestUtilities.Services
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            return new MapperConfiguration(options =>
            {
                options.AddProfile(new MappingConfig());
            }).CreateMapper();
        }
    }
}
