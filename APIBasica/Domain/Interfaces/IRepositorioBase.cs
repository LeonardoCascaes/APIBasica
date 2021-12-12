using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositorioBase<T> where T : ModeloBase
    {
        Task<Resultado<T>> Criar(T model);
        Task<Resultado<IEnumerable<T>>> BuscarTodos();
        Task<Resultado<T>> BuscarPorId(int id);
        Task<Resultado<T>> Atualizar(T model);
        Task<Resultado<T>> Deletar(int id);
    }
}
