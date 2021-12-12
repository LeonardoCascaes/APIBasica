using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRepositorioBase<T> where T : ModeloBase
    {
        Task<Resultado<T>> Atualizar(int id);
        Task<Resultado<T>> BuscarPorId(int id);
        Task<Resultado<IEnumerable<T>>> BuscarTodos();
        void Criar(T model);
    }
}
