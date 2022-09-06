using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Gebruikers;
using Domain.Posts;

namespace Persistence.Data
{
    public class FaithDataInitializer
    {
        private readonly FaithDbContext _dbContext;

        public FaithDataInitializer(FaithDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                SeedPosts();
            }
        }

        private void SeedPosts()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post("knl", "rggr", 1, 1, false, ""));
            posts.Add(new Post("knl", "rggr", 1, 1, false, ""));
            posts.Add(new Post("knl", "rggr", 1, 3, false, ""));
            posts.Add(new Post("knl", "rggr", 1, 1, false, ""));
            posts.Add(new Post("knl", "rggr", 1, 4, false, ""));
            var begeleiders = new BegeleiderFaker()
                .RuleFor(p => p.Id, () => 0) // Remove the id, database column is auto generated
                .Generate(6);
            var jongere = new JongereFaker()
                .RuleFor(p => p.Id, () => 0) // Remove the id, database column is auto generated
                .Generate(200);

            _dbContext.Posts.AddRange(posts);
            _dbContext.Begeleiders.AddRange(begeleiders);
            _dbContext.Jongeren.AddRange(jongere);
            Console.WriteLine(_dbContext.Posts);
            _dbContext.SaveChanges();
        }
    }
}
