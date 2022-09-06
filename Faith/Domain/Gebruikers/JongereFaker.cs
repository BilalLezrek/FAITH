using Bogus;

namespace Domain.Gebruikers
{
    public class JongereFaker : Faker<Jongere>
    {
        public JongereFaker()
        {
            CustomInstantiator(f => new Jongere(f.Person.FirstName, f.Person.LastName, f.Person.Email, f.Person.DateOfBirth, f.UniqueIndex, f.Person.Gender.ToString()));
            RuleFor(x => x.Id, f => f.Random.Int());
        }
    }
}
