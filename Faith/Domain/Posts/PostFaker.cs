using Bogus;
using Domain.Gebruikers;

namespace Domain.Posts
{
    public class PostFaker : Faker<Post>
    {
        public PostFaker()
        {
            CustomInstantiator(f => new Post(f.Lorem.Text(),f.Lorem.Word(),f.UniqueIndex,f.UniqueIndex,false,f.Image.PlaceholderUrl(3,5)));
            RuleFor(x => x.Id, f => f.Random.Int());
        }
    }
}
