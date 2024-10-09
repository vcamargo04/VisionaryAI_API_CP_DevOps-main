using Microsoft.EntityFrameworkCore;
using VisionaryAI.API.Mappings;
using VisionaryAI.API.Models;

namespace VisionaryAI.API.Database
{
    public class VisionaryAIDBContext(DbContextOptions<VisionaryAIDBContext> options) : DbContext(options)
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<FonteDados> FonteDeDados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMapping());
            modelBuilder.ApplyConfiguration(new CidadeMapping());
            modelBuilder.ApplyConfiguration(new FonteDadosMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
