using Domain.Interfaces;
using Domain.Models;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : ModeloBase
    {
        private readonly ContextBase _context;

        public RepositorioBase(ContextBase context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async void Criar(T model)
        {
            try
            {
                await _context.AddAsync(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<Resultado<IEnumerable<T>>> BuscarTodos()
        {
            var resultado = new Resultado<IEnumerable<T>>();

            try
            {
                var resposta = await _context.Set<T>().ToListAsync();
                if(resposta != null)
                {
                    resultado.AddEntidade(resposta);
                    resultado.ConfirmaSucesso();
                }
                else
                {
                    resultado.AddErro("Não existe nenhum registro na base de dados.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }

        public virtual async Task<Resultado<T>> BuscarPorId(int id)
        {
            var resultado = new Resultado<T>();

            try
            {
                var resposta = await _context.Set<T>().FindAsync(id);
                if (resposta != null)
                {
                    resultado.AddEntidade(resposta);
                    resultado.ConfirmaSucesso();
                }
                else
                {
                    resultado.AddErro("Não foi encontrado nenhum registro com esse id.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }

        public virtual async Task<Resultado<T>> Atualizar(int id)
        {
            var resultado = new Resultado<T>();
            try
            {
                var resposta = await BuscarPorId(id);
                if(resposta.Entidade != null)
                {
                    _context.Entry<T>(resposta.Entidade).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    resposta.ConfirmaSucesso();
                }
                else
                {
                    resultado.AddErro("Não foi encontrado o registro com o id desejado para prosseguir com a atualização.");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return resultado;
        }
    }
}
