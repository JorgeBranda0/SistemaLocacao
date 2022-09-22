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

        [ForeignKey("Id_Cliente"), Column("Id_Cliente")]
        public int ClienteId { get; set; }
        public virtual Clientes Cliente { get; set; }

        [ForeignKey("Id_Filme"), Column("Id_Filme")]
        public int FilmeId { get; set; }
        public virtual Filmes Filme { get; set; }
    }
}