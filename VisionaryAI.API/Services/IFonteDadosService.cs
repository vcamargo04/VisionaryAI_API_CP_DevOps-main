using VisionaryAI.API.Models;

namespace VisionaryAI.API.Services
{
    public interface IFonteDadosService

    {
        Task<List<FonteDados>> BuscarTodasFonteDados();
        Task<FonteDados> BuscarPorId(int id);
        Task<FonteDados> Adicionar(FonteDados fonteDados);
        Task<FonteDados> Atualizar(FonteDados fonteDados, int id);
        Task<bool> Apagar(int id);
    }
}
