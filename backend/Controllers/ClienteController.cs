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
        public async Task<IActionResult> CadastrarCliente([FromBody] CreateClienteDto clienteDto)
        {
            Clientes clientes = _mapper.Map<Clientes>(clienteDto);
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return NotFound();
        }
    }
}