using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("filme", Schema = "dbo")]
    public class Filmes 
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("ClassificacaoIndicativa")]
        public int Classificacao { get; set; }

        [Column("Lancamento")]
        public byte Lancamento { get; set; }
    }
}