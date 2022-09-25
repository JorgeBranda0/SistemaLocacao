using backend.Models;

namespace backend.Context.Dtos.LocacoesDto
{
    public class ReadLocacaoDto
    {
        public int LocacaoId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
    }
}