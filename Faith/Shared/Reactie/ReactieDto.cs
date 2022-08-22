using Domain.Gebruikers;
using Domain.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Reactie
{
    public static class ReactieDto
    {
            public class Index
            {
                public int Id { get; set; }
                public string Tekst { get; set; }
                public DateTime Datum { get; set; }
                public Gebruiker Gebruiker { get; set; }
                public Post post { get; set; }
                public string? Url { get; set; }
            }
            
            public class Mutate
            {
                public string Tekst { get; set; }
                public DateTime Datum { get; set; }
                public Gebruiker Gebruiker { get; set; }
                public Post Post { get; set; }
                public string? Url { get; set; }
            }

                public class Validator : AbstractValidator<Mutate>
                {
                    public Validator()
                    {
                        RuleFor(x => x.Tekst).NotEmpty().Length(1, 360);
                        RuleFor(x => x.Datum).NotEmpty();
                        RuleFor(x => x.Gebruiker).NotEmpty();
                        RuleFor(x => x.Post).NotEmpty();
                        RuleFor(x => x.Url);
                    }
                }
            }
        }

