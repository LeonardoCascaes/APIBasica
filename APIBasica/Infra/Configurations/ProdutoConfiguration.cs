using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(p => p.Peso).HasColumnType("real").IsRequired();
            builder.Property(p => p.DataCadastro).HasColumnType("timestamp with time zone").IsRequired();

            builder.HasOne(p => p.Categoria).WithMany(c => c.Produtos).HasForeignKey(p => p.CategoriaId);
        }
    }
}
