using Ardalis.GuardClauses;
using Domain.Gebruikers;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Gebruikers
{
    public class Jongere : Gebruiker
    {
        public List<Post> Posts { get; set; }

        public Jongere(string voornaam, string achternaam, string email, DateTime? geboortedatum, string? geslacht) : base(voornaam, achternaam, email,geboortedatum, geslacht)
        {
            Voornaam = Guard.Against.Null(voornaam, nameof(voornaam));
            Achternaam = Guard.Against.Null(achternaam, nameof(achternaam));
            Email = Guard.Against.Null(email, nameof(email));
            Geboortedatum = geboortedatum;
            Geslacht = geslacht;
            Posts = new List<Post>();

        }

        public Post PlaatsPost(string tekst, string onderwerp, Gebruiker gebruiker, string? photoUrl)
        {
            var post = new Post(tekst, onderwerp, gebruiker, photoUrl);
            Posts.Add(post);
            return post;
        }
    }
}
