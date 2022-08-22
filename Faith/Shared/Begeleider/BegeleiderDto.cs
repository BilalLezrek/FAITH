using FluentValidation;

namespace Shared.Begeleider
{
    public static class BegeleiderDto
    {
        public class Index
        {
            public string Voornaam { get; set; }
            public string Achternaam { get; set; }
            public string Email { get; set; }
        }

        public class Create
        {
            public string Voornaam { get; set; }
            public string Achternaam { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Voornaam).NotEmpty().Length(1, 100);
                    RuleFor(x => x.Achternaam).NotEmpty().Length(1, 100);
                    RuleFor(x => x.Email).NotEmpty().EmailAddress();
                    RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
                }
            }
        }
    }
}
