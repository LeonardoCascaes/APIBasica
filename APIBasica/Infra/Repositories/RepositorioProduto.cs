using Domain.Interfaces;
using Domain.Models;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class RepositorioProduto : RepositorioBase<Produto>, IRepositorioProduto
    {
        private readonly ContextBase _context;
        public RepositorioProduto(ContextBase context) : base(context)
        {
            _context = context;
        }

        public async override Task<Resultado<IEnumerable<Produto>>> BuscarTodos()
        {
            var resultado = new Resultado<IEnumerable<Produto>>();

            try
            {
                var resposta = await _context.Produtos.Include(p => p.Categoria).ToListAsync();
                if (resposta != null)
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

        public async override Task<Resultado<Produto>> BuscarPorId(int id)
        {
            var resultado = new Resultado<Produto>();

            try
            {
                var resposta = await _context.Produtos.Include(p => p.Categoria).Where(p => p.Id == id).FirstOrDefaultAsync();
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
    }
}
