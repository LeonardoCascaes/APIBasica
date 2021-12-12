using Domain.Interfaces;
using Domain.Models;
using Infra.Contexts;

namespace Infra.Repositories
{
    public class RepositorioProduto : RepositorioBase<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(ContextBase context) : base(context)
        {
        }
    }
}
