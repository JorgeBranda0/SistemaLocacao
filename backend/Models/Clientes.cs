using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("cliente", Schema = "dbo")]
    public class Clientes
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        public int CPF { get; set; }

        [Column("DataNascimento")]
        public DateTime DataDeNascimento { get; set; }
    }
}   