using Domain.Gebruikers;

namespace Domain.Posts;

public abstract class PostType
{
    public int Id { get; init; }
    public Gebruiker Gebruiker { get; set; }
    public string Tekst { get; set; }
    public DateTime Datum { get; set; }

    public PostType(Gebruiker gebruiker, string tekst)
    {
        Gebruiker = gebruiker;
        Tekst = tekst;
        Datum = DateTime.Now;

    }
}
