using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisionaryAI.API.Models;

namespace VisionaryAI.API.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("tb_cidades");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Uf)
                .HasColumnName("uf")
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
