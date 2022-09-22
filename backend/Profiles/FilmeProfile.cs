using AutoMapper;
using backend.Context.Dtos;
using backend.Models;

namespace backend.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filmes>();
            CreateMap<Filmes, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filmes>();
        }
    }
}