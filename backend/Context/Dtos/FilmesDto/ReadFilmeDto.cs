namespace backend.Context.Dtos.FilmesDto
{
    public class ReadFilmeDto
    {
        public int FilmeId { get; set; }
        public string Titulo { get; set; }
        public int Classificacao_Indicativa { get; set; }
        public bool Lancamento { get; set; }
    }
}