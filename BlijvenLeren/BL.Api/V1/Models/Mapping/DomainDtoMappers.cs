using AutoMapper;
using BL.Domain.Models;

namespace BL.Api.V1.Models.Mapping
{
    public class DomainDtoMappers : Profile
    {
        public DomainDtoMappers()
        {
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}
