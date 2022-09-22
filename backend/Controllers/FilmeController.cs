using AutoMapper;
using backend.Context;
using backend.Context.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private ConexaoMySQL _context;
        private IMapper _mapper;

        public FilmeController(ConexaoMySQL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[controller]/Cadastro")]
        public async Task<IActionResult> CadastraFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filmes filmes = _mapper.Map<Filmes>(filmeDto);
            _context.Filmes.Add(filmes);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filmes.Id }, filmes);
        }

        [HttpGet]
        [Route("[controller]/Consulta")]
        public IEnumerable<Filmes> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet]
        [Route("[controller]/ConsultaPorId/{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            Filmes filme = _context.Filmes.FirstOrDefault(p => p.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(filmeDto);
            }

            return NotFound("Atenção! O Id do filme que você procura não existe!");
        }

        [HttpPut]
        [Route("[controller]/Atualiza")]
        public async Task<IActionResult> AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filmes filmes = _context.Filmes.FirstOrDefault(p => p.Id == id);
            if (filmes == null)
            {
                return NotFound("Atenção! O Id do filme que você procura não existe!");
            }

            _mapper.Map(filmeDto, filmes);
            _context.Filmes.Update(filmes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("[controller]/Remove")]
        public IActionResult DeletaFilme(int id)
        {
            Filmes filmes = _context.Filmes.FirstOrDefault(p => p.Id == id);
            if (filmes == null)
            {
                return NotFound("Atenção! O Id do filme que você procura não existe!");
            }

            _context.Remove(filmes);
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}