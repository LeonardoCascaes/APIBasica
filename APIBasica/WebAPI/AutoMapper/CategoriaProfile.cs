using AutoMapper;
using Domain.Models;
using Service.Dtos;

namespace WebAPI.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
        }
    }
}
