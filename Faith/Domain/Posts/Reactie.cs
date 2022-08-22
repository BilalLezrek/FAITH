using Ardalis.GuardClauses;
using Domain.Gebruikers;

namespace Domain.Posts;

public class Reactie : PostType
{
    public PostType? Post { get; set; }
    public Reactie(string tekst, Gebruiker gebruiker, Post? post) : base(gebruiker, tekst)
    {
        Tekst = Guard.Against.Null(tekst, nameof(tekst));
        Gebruiker = Guard.Against.Null(gebruiker, nameof(gebruiker));
        Post = Guard.Against.Null(post, nameof(post));
        Datum = DateTime.Now;
    }

    
}
