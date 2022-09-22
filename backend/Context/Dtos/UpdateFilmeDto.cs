using System.ComponentModel.DataAnnotations;

namespace backend.Context.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "Atenção! O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Range(1, 18, ErrorMessage = "Atençao! A classificação deve ter entre 5 à 18 anos")]
        public int Classificacao_Indicativa { get; set; }
        public bool Lancamento { get; set; }
    }
}