using Ardalis.GuardClauses;
using Domain.Gebruikers;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Gebruikers
{
    public class Jongere : Gebruiker
    {
        [ForeignKey("begeleider")]
        public int Begeleider { get; set; }
        public List<Post> Posts { get; set; }


        public Jongere(string voornaam, string achternaam, string email, DateTime? geboortedatum, int begeleider,string? geslacht) : base(voornaam, achternaam, email,geboortedatum, geslacht)
        {
            Voornaam = Guard.Against.Null(voornaam, nameof(voornaam));
            Achternaam = Guard.Against.Null(achternaam, nameof(achternaam));
            Email = Guard.Against.Null(email, nameof(email));
            Geboortedatum = geboortedatum;
            Geslacht = geslacht;
            Begeleider = Guard.Against.Null(begeleider,nameof(begeleider));
            Posts = new List<Post>();

        }

        public Post PlaatsPost(string tekst, string onderwerp, string? photoUrl)
        {
            var post = new Post(tekst, onderwerp, this.Id,this.Begeleider, false, photoUrl);
            Posts.Add(post);
            return post;
        }
    }
}
