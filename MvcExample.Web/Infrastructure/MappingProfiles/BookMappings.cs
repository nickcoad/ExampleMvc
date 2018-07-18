using System.Linq;
using AutoMapper;
using MvcExample.Data.Entities;
using MvcExample.Domain.Models.Books;

namespace MvcExample.Web.Infrastructure.MappingProfiles
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.AuthorFirstName, opt => opt.MapFrom(src => src.Author.FirstName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(src => src.Author.LastName))
                .ForMember(dest => dest.OtherBooksByAuthor, opt => opt.MapFrom(src => src.Author.Books.Where(_ => _.Id != src.Id)))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
