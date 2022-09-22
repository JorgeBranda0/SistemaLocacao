using AutoMapper;
using backend.Context.Dtos.ClientesDto;
using backend.Models;

namespace backend.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Clientes>();
            CreateMap<Clientes, ReadClienteDto>();
            CreateMap<UpdateClienteDto, Clientes>();
        }
    }
}