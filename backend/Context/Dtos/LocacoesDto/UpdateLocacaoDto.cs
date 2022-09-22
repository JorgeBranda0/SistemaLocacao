using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Context.Dtos.LocacoesDto
{
    public class UpdateLocacaoDto
    {
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        [Required(ErrorMessage = "Atenção! O campo Id_Cliente é obrigatório")]
        public virtual Clientes Id_Cliente { get; set; }

        [Required(ErrorMessage = "Atenção! O campo Id_Filme é obrigatório")]
        public virtual Filmes Id_Filme { get; set; }
    }
}