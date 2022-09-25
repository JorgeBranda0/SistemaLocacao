using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("cliente", Schema = "dbo")]
    public class Clientes
    {
        [Key, Column("Id")]
        public int ClienteId { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }
    }
}   