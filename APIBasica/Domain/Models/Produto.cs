﻿namespace Domain.Models
{
    public class Produto : ModeloBase
    {
        public string Nome { get; set; }
        public float Peso { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public DateTime DataCadastro { get; set; }

        public Produto(string nome, float peso, Categoria categoria)
        {
            Nome = nome;
            Peso = peso;
            Categoria = categoria;
            DataCadastro = DateTime.Now;
        }

        public Produto(string nome, float peso)
        {
            Nome = nome;
            Peso = peso;
            DataCadastro = DateTime.Now;
        }
    }
}
