using AutoMapper;
using backend.Context;
using backend.Context.Dtos.ClientesDto;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private ConexaoMySQL _context;
        private IMapper _mapper;

        public ClienteController(ConexaoMySQL context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("[controller]/Cadastro")]
        public async Task<IActionResult> CadastraCliente([FromBody] CreateClienteDto clienteDto)
        {
            Clientes clientes = _mapper.Map<Clientes>(clienteDto);
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = clientes.Id }, clientes);
        }

        [HttpGet]
        [Route("[controller]/Consulta")]
        public IEnumerable<Clientes> RecuperaCliente()
        {
            return _context.Clientes;
        }

        [HttpGet]
        [Route("[controller]/ConsultaPorId/{id}")]
        public IActionResult RecuperaClientePorId(int id)
        {
            Clientes clientes = _context.Clientes.FirstOrDefault(p => p.Id == id);
            if (clientes != null)
            {
                ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(clientes);
                return Ok(clienteDto);
            }
            
            return NotFound("Atenção! O Id do cliente que você procura não existe!");
        }

        [HttpPut]
        [Route("[controller]/Atualiza/{id}")]
        public async Task<IActionResult> AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            Clientes clientes = _context.Clientes.FirstOrDefault(p => p.Id == id);
            if (clientes == null)
            {
                return NotFound("Atenção! O Id do cliente que você procura não existe!");
            }

            _mapper.Map(clienteDto, clientes);
            _context.Clientes.Update(clientes);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("[controller]/Remove")]
        public IActionResult DeletaCliente(int id)
        {
            Clientes clientes = _context.Clientes.FirstOrDefault(p => p.Id == id);
            if (clientes == null)
            {
                return NotFound("Atenção! O Id do cliente que você procura não existe!");
            }

            _context.Remove(clientes);
            _context.SaveChanges();
            return NoContent();
        }
    }
}