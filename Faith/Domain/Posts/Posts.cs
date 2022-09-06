using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Gebruikers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Posts;

public abstract class PostType : Entity
{
    [ForeignKey("begeleider")]
    public int Gebruiker { get; set; }

    public string Tekst { get; set; }

    public DateTime Datum { get; set; }

    public PostType( string tekst, int gebruiker)
    {
        Tekst = Guard.Against.Null(tekst, nameof(tekst)); ;
        Datum = DateTime.Now;
        Gebruiker = Guard.Against.Null(gebruiker, nameof(gebruiker));
    }
}
