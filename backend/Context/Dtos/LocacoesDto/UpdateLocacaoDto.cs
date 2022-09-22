using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Context.Dtos.LocacoesDto
{
    public class UpdateLocacaoDto
    {
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        [Required(ErrorMessage = "Atenção! O campo ClienteId é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Atenção! O campo FilmeId é obrigatório")]
        public int FilmeId { get; set; }
    }
}