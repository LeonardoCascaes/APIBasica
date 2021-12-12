using Service.Dtos;

namespace Service.Interfaces
{
    public interface IServicosProduto
    {
        Task<ResultadoDto<ProdutoDto>> Atualizar(ProdutoDto produtoDto);
        Task<ResultadoDto<ProdutoDto>> BuscarPorId(int id);
        Task<ResultadoDto<IEnumerable<ProdutoDto>>> BuscarTodos();
        Task<ResultadoDto<ProdutoDto>> Criar(ProdutoDto produtoDto);
        Task<ResultadoDto<ProdutoDto>> Deletar(int id);
    }
}
