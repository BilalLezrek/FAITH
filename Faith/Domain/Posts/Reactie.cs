using Ardalis.GuardClauses;
using Domain.Gebruikers;

namespace Domain.Posts;

public class Reactie : PostType
{
    public int Post { get; set; }
    public Reactie(string tekst,int gebruiker,int post) : base(tekst,gebruiker)
    {
        Tekst = Guard.Against.Null(tekst, nameof(tekst));
        Post = Guard.Against.Null(post, nameof(post));
        Datum = DateTime.Now;
    }

    
}
