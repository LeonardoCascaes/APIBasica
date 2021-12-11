using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Descricao).HasColumnType("varchar").HasMaxLength(255).IsRequired();
        }
    }
}
