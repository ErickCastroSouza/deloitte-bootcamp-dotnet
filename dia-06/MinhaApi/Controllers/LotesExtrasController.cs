using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Dtos;
using MinhaApi.Queue;
using MinhaApi.Services;
using Microsoft.Identity.Client;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/lotes")]
    public class LotesExtrasController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        private readonly LoteService _service;

        
        public LotesExtrasController(AppDbContext ctx, LoteService service)
        {
            _ctx = ctx;
            _service = service;
        }

        [HttpGet("{id}/classificar")]
        public IActionResult Classificar(int id)
        {
            var lote = _ctx.LotesMinerio.Find(id);
            if (lote == null) return NotFound();

            var qualidade = _service.ClassificarQualidade(lote);

            return Ok(new { lote.Id, lote.CodigoLote, qualidade });
        }

        [HttpGet("{id}/preco")]
        public IActionResult CalcularPreco(int id)
        {
            var lote = _ctx.LotesMinerio.Find(id);
            if (lote == null) return NotFound();

            return Ok(new 
            {
                lote.Id,
                lote.CodigoLote,
                qualidade = _service.ClassificarQualidade(lote),
                precoPorTonelada = _service.CalcularPrecoPorTonelada(lote),
                toneladas = lote.Toneladas,
                valorTotal = _service.CalcularValorTotal(lote)
            });
        }

        [HttpPost("{id}/mover")]
        public IActionResult Mover(int id, [FromBody] MovimentoDto dto)
        {
            var lote = _ctx.LotesMinerio.Find(id);
            if (lote == null) return NotFound();

            _service.RegistrarMovimentacao(lote, dto.Local, dto.Status);

            _ctx.SaveChanges();

            return Ok(lote);
        }

                [HttpPost("{id}/avancar-status")]
        public IActionResult AvancarStatus(int id)
        {
            var lote = _ctx.LotesMinerio.Find(id);
            if (lote == null) return NotFound();

            _service.AvancarStatus(lote);
            _ctx.SaveChanges();

            return Ok(lote);
        }

        [HttpGet("{id}/penalidade")]
        public IActionResult Penalidade(int id)
        {
            var lote = _ctx.LotesMinerio.Find(id);
            if (lote == null) return NotFound();

            var penalidade = _service.CalcularPenalidadeUmidade(lote);

            return Ok(new
            {
                lote.Id,
                lote.CodigoLote,
                lote.Umidade,
                penalidade
            });
        }
    }

    public class MovimentoDto
    {
        public string Local { get; set; } = "";
        public StatusLote Status { get; set; }
    }

}