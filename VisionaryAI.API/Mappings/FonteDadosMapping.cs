using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisionaryAI.API.Models;

namespace VisionaryAI.API.Mappings
{
    public class FonteDadosMapping : IEntityTypeConfiguration<FonteDados>
    {
        public void Configure(EntityTypeBuilder<FonteDados> builder)
        {
            builder.ToTable("tb_fonte_dados");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasColumnName("nome")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Tipo)
                .HasColumnName("tipo")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
