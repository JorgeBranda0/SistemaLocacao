namespace backend.Context.Dtos.ClientesDto
{
    public class ReadClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}