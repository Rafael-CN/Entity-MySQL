public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public float Duracao { get; set; }
    public int Nota { get; set; }

    public virtual List<Ator> Atores { get; set; }
}