using backend.Models;

namespace backend.Context.Dtos.LocacoesDto
{
    public class ReadLocacaoDto
    {
        public int Id { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public virtual Clientes Id_Cliente { get; set; }
        public virtual Filmes Id_Filme { get; set; }
    }
}