using Ardalis.GuardClauses;
using Domain.Gebruikers;

namespace Domain.Posts;

public class Post : PostType
{
    public string Onderwerp { get; set; }
    public bool Archief { get; set; }
    public int BegeleiderId { get; set; }
    public string Url { get; set; }

    public Post(string tekst,string onderwerp, int gebruiker, int begeleiderId, bool archief,string url) : base(tekst,gebruiker)
    {
        Onderwerp = Guard.Against.Null(onderwerp, nameof(onderwerp));
        Archief= Guard.Against.Null(archief, nameof(archief));
        begeleiderId= Guard.Against.Null(begeleiderId, nameof(begeleiderId));
        Url= url ?? string.Empty;

    }

}
