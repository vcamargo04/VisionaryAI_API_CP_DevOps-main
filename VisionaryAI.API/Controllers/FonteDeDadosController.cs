using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisionaryAI.API.Models;
using VisionaryAI.API.Services;

namespace VisionaryAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FonteDeDadosController : ControllerBase
    {
        private readonly IFonteDadosService _fonteDadosService;
        public FonteDeDadosController(IFonteDadosService fonteDadosService)
        {
            _fonteDadosService = fonteDadosService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FonteDados>>> BuscarTodasFonteDados()
        {
            List<FonteDados> fonteDadoss = await _fonteDadosService.BuscarTodasFonteDados();
            return Ok(fonteDadoss);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<FonteDados>>> BuscarPorId(int id)
        {
            FonteDados fonteDados = await _fonteDadosService.BuscarPorId(id);
            return Ok(fonteDados);
        }

        [HttpPost]
        public async Task<ActionResult<FonteDados>> Cadastrar([FromBody] FonteDados fonteDados)
        {
            FonteDados novaFonteDados = await _fonteDadosService.Adicionar(fonteDados);
            return Ok(novaFonteDados);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FonteDados>> Atualizar([FromBody] FonteDados fonteDados, int id)
        {
            fonteDados.Id = id;
            FonteDados fonteDadosAtualizada = await _fonteDadosService.Atualizar(fonteDados, id);
            return Ok(fonteDadosAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FonteDados>> Excluir(FonteDados fonteDados, int id)
        {
            bool fonteDadosExcluida = await _fonteDadosService.Apagar(id);
            return Ok(fonteDadosExcluida);
        }
    }
}
