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
         
            var cliente = _context.Clientes.Where(p => p.ClienteId == locacoes.ClienteId).ToList();
            var filme = _context.Filmes.Where(p => p.FilmeId == locacoes.FilmeId).ToList();

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
                item.Cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == item.ClienteId);
                item.Filme = _context.Filmes.FirstOrDefault(p => p.FilmeId == item.FilmeId);
            }

            return locacoes;
        }

        [HttpGet]
        [Route("[controller]/ConsultaPorId/{id}")]
        public IActionResult RecuperaLocacaoPorId(int id)
        {
            var locacoes = _context.Locacoes.Where(p => p.LocacaoId == id).ToList();
            foreach (var item in locacoes)
            {
                item.Cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == item.ClienteId);
                item.Filme = _context.Filmes.FirstOrDefault(p => p.FilmeId == item.FilmeId);
                return Ok(locacoes);
            }

            return NotFound("Atenção! O Id da Locação que você procura não existe!");
        }

        [HttpPut]
        [Route("[controller]/Atualiza/{id}")]
        public async Task<IActionResult> AtualizaLocacao(int id, [FromBody] UpdateLocacaoDto locacaoDto)
        {
            Locacoes locacoes = _context.Locacoes.FirstOrDefault(p => p.LocacaoId == id);
            if (locacoes == null)
            {
                return NotFound("Atenção! O Id da Locação que você procura não existe!");
            }

            var cliente = _context.Clientes.Where(p => p.ClienteId == locacaoDto.ClienteId).ToList();
            var filme = _context.Filmes.Where(p => p.FilmeId == locacaoDto.FilmeId).ToList();

            if (cliente.Count == 0)
            {
                return NotFound("Atenção! O Id do cliente que você inseriu não existe!");
            }

            if (filme.Count == 0)
            {
                return NotFound("Atenção! O Id do filme que você inseriu não existe!");
            }

            _mapper.Map(locacaoDto, locacoes);
            _context.Locacoes.Update(locacoes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("[controller]/Remove")]
        public IActionResult DeletaLocacao(int id)
        {
            Locacoes locacoes = _context.Locacoes.FirstOrDefault(p => p.LocacaoId == id);
            if (locacoes == null)
            {
                return NotFound("Atenção! O Id da Locação que você procura não existe!");
            }

            _context.Remove(locacoes);
            _context.SaveChanges();
            return NoContent();
        }
    }
}