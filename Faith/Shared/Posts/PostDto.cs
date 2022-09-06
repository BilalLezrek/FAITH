using Domain.Gebruikers;
using Domain.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Posts
{
    public static class PostDto
    {
            public class Index
            {
                public int Id { get; set; }
                public string Onderwerp { get; set; }
                public string Tekst { get; set; }
                public DateTime Datum { get; set; }
                public int Gebruiker { get; set; }
                public int BegeleiderId { get; set; }
                public bool Archief { get; set; }
                public string? Url { get; set; }
            }

            public class Mutate
            {
                public string Onderwerp { get; set; }
                public string Tekst { get; set; }
                public DateTime Datum { get; set; }
                public int Gebruiker { get; set; }
                public Boolean Archief { get; set; }
                public string? Url { get; set; }
            public int BegeleiderId { get; set; }

            public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Tekst).NotEmpty().Length(1, 360);
                    RuleFor(x => x.Onderwerp).NotEmpty().Length(1, 50);
                    RuleFor(x => x.Datum).NotEmpty();
                    RuleFor(x => x.Gebruiker).NotEmpty();
                    RuleFor(x => x.Archief).NotEmpty();

                }
            }
        }

                
            }
        }

