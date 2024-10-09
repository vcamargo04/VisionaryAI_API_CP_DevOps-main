using Microsoft.AspNetCore.Mvc;
using VisionaryAI.API.Models;
using VisionaryAI.API.Services;

namespace VisionaryAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        public EmpresasController(IEmpresaService empresaService)
        {
            _empresaService= empresaService;
        }

        [HttpGet]
        public async Task< ActionResult<List<Empresa>>> BuscarTodasEmpresas()
        {
            List<Empresa> empresas= await _empresaService.BuscarTodasEmpresas();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Empresa>>> BuscarPorId(int id)
        {
            Empresa empresa = await _empresaService.BuscarPorId(id);
            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> Cadastrar([FromBody] Empresa empresa)
        {
            Empresa novaEmpresa = await _empresaService.Adicionar(empresa);
            return Ok(novaEmpresa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Empresa>> Atualizar([FromBody] Empresa empresa, int id)
        {
            empresa.Id = id;
            Empresa empresaAtualizada= await _empresaService.Atualizar(empresa, id);
            return Ok(empresaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresa>> Excluir(Empresa empresa, int id)
        {
            bool empresaExcluida = await _empresaService.Apagar(id);
            return Ok (empresaExcluida);
        }
    }
}
