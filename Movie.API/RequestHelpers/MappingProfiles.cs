using AutoMapper;
using Movie.API.Models;
using Movie.API.Models.Dto;

namespace Movie.API.RequestHelpers
{
    public class MappingProfiles: Profile
    {

        public MappingProfiles()
        {
            CreateMap<Platform, PlatformDto>();
            CreateMap<PlatformDto, Platform>();
            CreateMap<Movies, CreateMovieDto>();
            CreateMap<CreateMovieDto, Movies>();
        }
    }       
}
