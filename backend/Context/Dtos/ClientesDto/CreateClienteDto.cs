using System.ComponentModel.DataAnnotations;

namespace backend.Context.Dtos.ClientesDto
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = "Atenção! O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [MinLength(11, ErrorMessage = "Atenção! É necessário o campo CPF ter 11 carácteres"), 
        MaxLength(11, ErrorMessage = "Atenção! É necessário o campo CPF ter no máximo 11 carácteres")]
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}