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
                public int Gebruiker { get; set; }
                public int Post { get; set; }
            }
            
            public class Mutate
            {
                public string Tekst { get; set; }
                public DateTime Datum { get; set; }
                public int Gebruiker { get; set; }
                public int Post { get; set; }
            }

                public class Validator : AbstractValidator<Mutate>
                {
                    public Validator()
                    {
                        RuleFor(x => x.Tekst).NotEmpty().Length(1, 360);
                        RuleFor(x => x.Datum).NotEmpty();
                        RuleFor(x => x.Gebruiker).NotEmpty();
                        RuleFor(x => x.Post).NotEmpty();
                    }
                }
            }
        }

