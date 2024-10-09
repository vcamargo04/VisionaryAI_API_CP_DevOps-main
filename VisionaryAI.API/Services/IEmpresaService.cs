using VisionaryAI.API.Models;

namespace VisionaryAI.API.Services
{
    public interface IEmpresaService
    {
        Task<List<Empresa>> BuscarTodasEmpresas();
        Task<Empresa> BuscarPorId(int id);
        Task<Empresa> Adicionar(Empresa empresa);
        Task<Empresa> Atualizar(Empresa empresa, int id);
        Task<bool> Apagar(int id);
    }
}
