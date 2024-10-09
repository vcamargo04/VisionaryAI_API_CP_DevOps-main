using Microsoft.EntityFrameworkCore;
using VisionaryAI.API.Database;
using VisionaryAI.API.Models;

namespace VisionaryAI.API.Services
{
    public class FonteDadosService : IFonteDadosService
    {
        private readonly VisionaryAIDBContext _dbContext;
        public FonteDadosService(VisionaryAIDBContext visionaryAIDBContext)
        {
            _dbContext = visionaryAIDBContext;
        }
        public async Task<FonteDados> BuscarPorId(int id)
        {
            return await _dbContext.FonteDeDados.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<FonteDados>> BuscarTodasFonteDados()
        {
            return await _dbContext.FonteDeDados.ToListAsync();
        }
        public async Task<FonteDados> Adicionar(FonteDados fonteDados)
        {
            await _dbContext.FonteDeDados.AddAsync(fonteDados);
            await _dbContext.SaveChangesAsync();

            return fonteDados;
        }

        public async Task<FonteDados> Atualizar(FonteDados fonteDados, int id)
        {
            FonteDados fonteDadosPorId = await BuscarPorId(id);

            if (fonteDadosPorId == null)
            {
                throw new Exception($"A fonte de dados com o ID: {id} não foi encontrada no banco de dados. ");
            }

            fonteDadosPorId.Nome = fonteDados.Nome;
            fonteDadosPorId.Tipo = fonteDados.Tipo;

            _dbContext.FonteDeDados.Update(fonteDadosPorId);
            await _dbContext.SaveChangesAsync();

            return fonteDadosPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            FonteDados fonteDadosPorId = await BuscarPorId(id);

            if (fonteDadosPorId == null)
            {
                throw new Exception($"A fonte de dados com o ID: {id} não foi encontrada no banco de dados. ");
            }

            _dbContext.FonteDeDados.Remove(fonteDadosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
