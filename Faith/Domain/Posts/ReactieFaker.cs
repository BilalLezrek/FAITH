using Bogus;
using Domain.Gebruikers;

namespace Domain.Posts
{
    public class ReactieFaker : Faker<Reactie>
    {
        public ReactieFaker()
        {
            CustomInstantiator(f => new Reactie(f.Lorem.Text(), f.UniqueIndex,f.UniqueIndex));
            RuleFor(x => x.Id, f => f.Random.Int());
        }
    }
}
