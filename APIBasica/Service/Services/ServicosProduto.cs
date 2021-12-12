using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Service.Dtos;
using Service.Interfaces;

namespace Service.Services
{
    public class ServicosProduto : IServicosProduto
    {
        private readonly IRepositorioProduto _repositorioProduto;
        private readonly IMapper _mapper;

        public ServicosProduto(IRepositorioProduto repositorioProduto, IMapper mapper)
        {
            _repositorioProduto = repositorioProduto ?? throw new ArgumentNullException(nameof(repositorioProduto));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultadoDto<ProdutoDto>> Criar(ProdutoDto produtoDto)
        {
            try
            {
                var produto = _mapper.Map<Produto>(produtoDto);
                var resposta = await _repositorioProduto.Criar(produto);
                var resultadoDto = _mapper.Map<ResultadoDto<ProdutoDto>>(resposta);
                resultadoDto.AddEntidade(produtoDto);
                return resultadoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResultadoDto<IEnumerable<ProdutoDto>>> BuscarTodos()
        {
            try
            {
                var resposta = await _repositorioProduto.BuscarTodos();
                var resultadoDto = _mapper.Map<ResultadoDto<IEnumerable<ProdutoDto>>>(resposta);
                return resultadoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResultadoDto<ProdutoDto>> BuscarPorId(int id)
        {
            try
            {
                var resposta = await _repositorioProduto.BuscarPorId(id);
                var resultadoDto = _mapper.Map<ResultadoDto<ProdutoDto>>(resposta);
                return resultadoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResultadoDto<ProdutoDto>> Atualizar(ProdutoDto produtoDto)
        {
            try
            {
                var produto = _mapper.Map<Produto>(produtoDto);
                var resposta = await _repositorioProduto.Atualizar(produto);
                var resultadoDto = _mapper.Map<ResultadoDto<ProdutoDto>>(resposta);
                return resultadoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResultadoDto<ProdutoDto>> Deletar(int id)
        {
            try
            {
                var resposta = await _repositorioProduto.Deletar(id);
                var resultadoDto = _mapper.Map<ResultadoDto<ProdutoDto>>(resposta);
                return resultadoDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
