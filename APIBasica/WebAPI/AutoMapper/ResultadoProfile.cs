using AutoMapper;
using Domain.Models;
using Service.Dtos;

namespace WebAPI.AutoMapper
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile()
        {
            CreateMap<Resultado<Produto>, ResultadoDto<ProdutoDto>>().ReverseMap();
            CreateMap<Resultado<Categoria>, ResultadoDto<CategoriaDto>>().ReverseMap();
            CreateMap<Resultado<IEnumerable<Produto>>, ResultadoDto<IEnumerable<ProdutoDto>>>().ReverseMap();
            CreateMap<Resultado<IEnumerable<Categoria>>, ResultadoDto<IEnumerable<CategoriaDto>>>().ReverseMap();
        }
    }
}
