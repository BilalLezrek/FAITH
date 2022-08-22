using Ardalis.GuardClauses;
using Domain.Gebruikers;

namespace Domain.Posts;

public class Post : PostType
{
    public String Onderwerp { get; set; }

    public string PhotoUrl { get; set; }

    public Post(string tekst, string onderwerp, Gebruiker gebruiker, string photoUrl) : base(gebruiker, tekst)
    {
        Onderwerp = Guard.Against.Null(onderwerp, nameof(onderwerp));
        Tekst = Guard.Against.Null(tekst, nameof(tekst));
        PhotoUrl = Guard.Against.Null(photoUrl, nameof(photoUrl));
        Gebruiker = Guard.Against.Null(gebruiker, nameof(gebruiker));
        Datum = DateTime.Now;

    }

}
