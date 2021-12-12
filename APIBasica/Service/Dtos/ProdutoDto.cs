namespace Service.Dtos
{
    public class ProdutoDto : ModeloBaseDto
    {
        public string Nome { get; set; }
        public float Peso { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto? Categoria { get; set; }
        public DateTime DataCadastro { get; set; }

        public ProdutoDto(string nome, float peso)
        {
            Nome = nome;
            Peso = peso;
            DataCadastro = DateTime.UtcNow;
        }
    }
}
