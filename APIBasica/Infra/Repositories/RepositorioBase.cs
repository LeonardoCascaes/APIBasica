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

        public virtual async Task<Resultado<T>> Criar(T model)
        {
            var resultado = new Resultado<T>();
            try
            {
                var resposta = _context.AddAsync(model);
                if (resposta.IsCompleted)
                {
                    await _context.SaveChangesAsync();
                    resultado.ConfirmaSucesso();
                }
                else
                {
                    resultado.AddErro("Ocorreu um erro ao criar o registro.");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
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

        public virtual async Task<Resultado<T>> Atualizar(T model)
        {
            var resultado = new Resultado<T>();
            try
            {
                var resposta = await BuscarPorId(model.Id);
                if(resposta.Entidade != null)
                {
                    _context.Entry(resposta.Entidade).CurrentValues.SetValues(model);
                    await _context.SaveChangesAsync();
                    resultado.ConfirmaSucesso();
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

        public virtual async Task<Resultado<T>> Deletar(int id)
        {
            var resultado = new Resultado<T>();
            try
            {
                var resposta = await BuscarPorId(id);
                if (resposta.Entidade != null)
                {
                    _context.Entry(resposta.Entidade).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    resultado.ConfirmaSucesso();
                }
                else
                {
                    resultado.AddErro("Não foi encontrado o registro com o id desejado para deletar.");
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
