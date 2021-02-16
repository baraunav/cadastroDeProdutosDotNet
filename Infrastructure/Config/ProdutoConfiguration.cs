using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.id);

            builder.Property(e => e.codigo)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(e => e.descricao)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.quantidade)
                .IsRequired();

            builder.Property(e => e.preco)
                .IsRequired();

            builder.HasOne(e => e.TipoProduto)
                .WithMany(t => t.Produtos);

        }
    }
}