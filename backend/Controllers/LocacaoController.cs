using AutoMapper;
using backend.Context;
using backend.Context.Dtos.LocacoesDto;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class LocacaoController : ControllerBase
    {
        private ConexaoMySQL _context;
        private IMapper _mapper;

        public LocacaoController(ConexaoMySQL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[controller]/Cadastro")]
        public async Task<IActionResult> CadastraLocacao([FromBody] CreateLocacaoDto locacaoDto)
        {
            Locacoes locacoes = _mapper.Map<Locacoes>(locacaoDto);
         
            var cliente = _context.Clientes.Where(p => p.Id == locacoes.ClienteId).ToList();
            var filme = _context.Filmes.Where(p => p.Id == locacoes.FilmeId).ToList();

            if (cliente.Count == 0)
            {
                return NotFound("Atenção! O Id do cliente que você inseriu não existe!");
            }

            if (filme.Count == 0)
            {
                return NotFound("Atenção! O Id do filme que você inseriu não existe!");
            }

            _context.Locacoes.Add(locacoes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        [Route("[controller]/Consulta")]
        public IEnumerable<Locacoes> RecuperaLocacao()
        {
            var locacoes = _context.Locacoes.ToList();
            foreach (var item in locacoes)
            {
                item.Cliente = _context.Clientes.FirstOrDefault(p => p.Id == item.ClienteId);
                item.Filme = _context.Filmes.FirstOrDefault(p => p.Id == item.FilmeId);
            }

            return locacoes;
        }

        [HttpGet]
        [Route("[controller]/ConsultaPorId/{id}")]
        public IActionResult RecuperaLocacaoPorId(int id)
        {
            var locacoes = _context.Locacoes.Where(p => p.Id == id).ToList();
            foreach (var item in locacoes)
            {
                item.Cliente = _context.Clientes.FirstOrDefault(p => p.Id == item.ClienteId);
                item.Filme = _context.Filmes.FirstOrDefault(p => p.Id == item.FilmeId);
                return Ok(locacoes);
            }

            return NotFound("Atenção! O Id da Locação que você procura não existe!");
        }
    }
}