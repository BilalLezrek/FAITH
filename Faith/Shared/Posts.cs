namespace Faith.Shared;

public abstract class Posts
{
    public Gebruiker Gebruiker { get; set; }
    public string Tekst { get; set; }
    public DateTime Datum { get; set; }
    public string? PhotoUrl { get; set; }
}
