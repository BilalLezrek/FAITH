using Ardalis.GuardClauses;
using Domain.Posts;

namespace Domain.Gebruikers;

public abstract class Gebruiker
{
    public int Id { get; init; }
    public string Voornaam { get; set; }
    public string Achternaam { get; set; }
    public string Email { get; set; }
    public DateTime? Geboortedatum { get; set; }
    public string? Geslacht { get; set; }

    public Gebruiker(string voornaam , string achternaam,string email, DateTime? geboortedatum, string? geslacht)
    {
        Voornaam = Guard.Against.Null(voornaam, nameof(voornaam));
        Achternaam = Guard.Against.Null(achternaam, nameof(achternaam));
        Email = Guard.Against.Null(email, nameof(email));
        Geboortedatum = geboortedatum;
        Geslacht = geslacht;
    }

}
