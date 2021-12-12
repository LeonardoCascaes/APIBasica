namespace Service.Dtos
{
    public class CategoriaDto : ModeloBaseDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public CategoriaDto(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
