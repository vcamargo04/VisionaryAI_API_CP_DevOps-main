using Microsoft.EntityFrameworkCore;
using VisionaryAI.API.Database;
using VisionaryAI.API.Models;

namespace VisionaryAI.API.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly VisionaryAIDBContext _dbContext;
        public CidadeService(VisionaryAIDBContext visionaryAIDBContext)
        {
            _dbContext = visionaryAIDBContext;
        }
        public async Task<Cidade> BuscarPorId(int id)
        {
            return await _dbContext.Cidades.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Cidade>> BuscarTodasCidades()
        {
            return await _dbContext.Cidades.ToListAsync();
        }
        public async Task<Cidade> Adicionar(Cidade cidade)
        {
            await _dbContext.Cidades.AddAsync(cidade);
            await _dbContext.SaveChangesAsync();

            return cidade;
        }

        public async Task<Cidade> Atualizar(Cidade cidade, int id)
        {
            Cidade cidadePorId = await BuscarPorId(id);

            if (cidadePorId == null)
            {
                throw new Exception($"A cidade com o ID: {id} não foi encontrada no banco de dados. ");
            }

            cidadePorId.Nome = cidade.Nome;
            cidadePorId.Uf = cidade.Uf;

            _dbContext.Cidades.Update(cidadePorId);
            await _dbContext.SaveChangesAsync();

            return cidadePorId;
        }
        public async Task<bool> Apagar(int id)
        {
            Cidade cidadePorId = await BuscarPorId(id);

            if (cidadePorId == null)
            {
                throw new Exception($"A cidade com o ID: {id} não foi encontrada no banco de dados. ");
            }

            _dbContext.Cidades.Remove(cidadePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
