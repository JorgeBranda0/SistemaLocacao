namespace backend.Context.Dtos
{
    public class ReadFilmeDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Classificacao_Indicativa { get; set; }
        public bool Lancamento { get; set; }
    }
}