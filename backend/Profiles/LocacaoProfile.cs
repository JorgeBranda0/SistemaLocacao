using AutoMapper;
using backend.Context.Dtos.LocacoesDto;
using backend.Models;

namespace backend.Profiles
{
    public class LocacaoProfile : Profile
    {
        public LocacaoProfile()
        {
            CreateMap<CreateLocacaoDto, Locacoes>();
            CreateMap<Locacoes, ReadLocacaoDto>();
            CreateMap<UpdateLocacaoDto, Locacoes>();
        }
    }
}