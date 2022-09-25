using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("filme", Schema = "dbo")]
    public class Filmes 
    {
        [Key, Column("Id")]
        public int FilmeId { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("ClassificacaoIndicativa")]
        public int Classificacao_Indicativa { get; set; }

        [Column("Lancamento")]
        public bool Lancamento { get; set; }
    }
}