using Application.Services.Mapper;
using AutoMapper;

namespace Tests.Mapper;

public class MapperBuilder
{
    public static IMapper Instance()
    {
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperConfiguration());
        });
        return mockMapper.CreateMapper();
    }
}