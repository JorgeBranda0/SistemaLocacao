using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("locacao", Schema = "dbo")]
    public class Locacoes
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("DataLocacao")]
        public DateTime DataLocacao { get; set; }

        [Column("DataDevolucao")]
        public DateTime DataDevolucao { get; set; }

        [ForeignKey("Id_Cliente")]
        public virtual Clientes Id_Cliente { get; set; }

        [ForeignKey("Id_Filme")]
        public virtual Filmes Id_Filme { get; set; }
    }
}