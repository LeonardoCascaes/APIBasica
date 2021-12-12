namespace Domain.Models
{
    public class Resultado<T> where T : class
    {
        public T? Entidade { get; private set; }
        public bool Sucesso { get; private set; }
        public List<string> Erros{ get; private set; }

        public Resultado()
        {
            Sucesso = false;
            Erros = new List<string>();
        }

        public void AddEntidade(T entidade)
        {
            Entidade = entidade;
        }

        public void ConfirmaSucesso()
        {
            Sucesso = true;
        }

        public void AddErro(string erro)
        {
            Erros.Add(erro);
        }

        public void AddListaErros(List<string> erros)
        {
            erros.AddRange(erros);
        }
    }
}
