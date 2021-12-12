using AutoMapper;
using Domain.Models;
using Service.Dtos;

namespace WebAPI.AutoMapper
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDto>().ReverseMap();
        }
    }
}
