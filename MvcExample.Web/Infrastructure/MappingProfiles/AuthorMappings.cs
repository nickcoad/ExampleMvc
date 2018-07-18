using AutoMapper;
using MvcExample.Data.Entities;
using MvcExample.Domain.Models.Authors;

namespace MvcExample.Web.Infrastructure.MappingProfiles
{
    public class AuthorMappings : Profile
    {
        public AuthorMappings()
        {
            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
        }
    }
}
