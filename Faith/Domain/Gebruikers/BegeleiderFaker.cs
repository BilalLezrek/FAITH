using Bogus;

namespace Domain.Gebruikers
{
    public class BegeleiderFaker : Faker<Begeleider>
    {
        public BegeleiderFaker()
        {
            CustomInstantiator(f => new Begeleider(f.Person.FirstName, f.Person.LastName,f.Person.Email,f.Person.DateOfBirth, f.Person.Gender.ToString()));
            RuleFor(x => x.Id, f => f.Random.Int());
        }
    }
}
