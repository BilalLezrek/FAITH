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
    public class Begeleider : Gebruiker
    {
        public List<Reactie> Reacties { get; set; }
        public List<Jongere> Leefgroep { get; set; }
        public Begeleider(string voornaam, string achternaam, string email, DateTime? geboortedatum, string? geslacht) : base(voornaam, achternaam,email, geboortedatum, geslacht)
        {
            Voornaam = Guard.Against.Null(voornaam, nameof(voornaam));
            Achternaam = Guard.Against.Null(achternaam, nameof(achternaam));
            Email = Guard.Against.Null(email, nameof(email));
            Geboortedatum =geboortedatum;
            Geslacht = geslacht;
            Reacties = new List<Reactie>();
        }
        public Reactie PlaatsReactie(string tekst, Gebruiker gebruiker,Post post)
        {
            var reactie = new Reactie(tekst, this, post);
            Reacties.Add(reactie);
            return reactie;
        }
        public void VoegJongereToe(Jongere jongere)
        {
            Leefgroep.Add(jongere);
        }
    }
}
