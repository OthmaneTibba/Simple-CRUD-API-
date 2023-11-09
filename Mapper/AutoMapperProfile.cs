
using AutoMapper;
using snof.Dtos;
using snof.Model;

namespace snof.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();

        }
    }
}