public class Ator
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }

    public virtual List<Filme> Filmes { get; set; }
}