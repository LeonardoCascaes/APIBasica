namespace Domain.Models
{
    public class Categoria : ModeloBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }

        public Categoria(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            Produtos = new List<Produto>();
        }
    }
}
