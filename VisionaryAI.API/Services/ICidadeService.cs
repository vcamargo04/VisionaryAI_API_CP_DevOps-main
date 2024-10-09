using VisionaryAI.API.Models;

namespace VisionaryAI.API.Services
{
    public interface ICidadeService
    {
        Task<List<Cidade>> BuscarTodasCidades();
        Task<Cidade> BuscarPorId(int id);
        Task<Cidade> Adicionar(Cidade cidade);
        Task<Cidade> Atualizar(Cidade cidade, int id);
        Task<bool> Apagar(int id);
    }
}
