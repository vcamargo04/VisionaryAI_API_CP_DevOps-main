using Microsoft.AspNetCore.Mvc;
using VisionaryAI.API.Models;
using VisionaryAI.API.Services;

namespace VisionaryAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;
        public CidadesController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cidade>>> BuscarTodasCidades()
        {
            List<Cidade> cidades = await _cidadeService.BuscarTodasCidades();
            return Ok(cidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cidade>>> BuscarPorId(int id)
        {
            Cidade cidade = await _cidadeService.BuscarPorId(id);
            return Ok(cidade);
        }

        [HttpPost]
        public async Task<ActionResult<Cidade>> Cadastrar([FromBody] Cidade cidade)
        {
            Cidade novaCidade = await _cidadeService.Adicionar(cidade);
            return Ok(novaCidade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cidade>> Atualizar([FromBody] Cidade cidade, int id)
        {
            cidade.Id = id;
            Cidade cidadeAtualizada = await _cidadeService.Atualizar(cidade, id);
            return Ok(cidadeAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cidade>> Excluir(Cidade cidade, int id)
        {
            bool cidadeExcluida = await _cidadeService.Apagar(id);
            return Ok(cidadeExcluida);
        }
    }
}
