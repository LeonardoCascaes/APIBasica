using Domain.Interfaces;
using Domain.Models;
using Infra.Contexts;

namespace Infra.Repositories
{
    public class RepositorioCategoria : RepositorioBase<Categoria>, IRepositorioCategoria
    {
        public RepositorioCategoria(ContextBase context) : base(context)
        {
        }
    }
}
