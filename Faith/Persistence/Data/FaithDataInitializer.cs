using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SeedProducts();
            }
        }

        private void SeedProducts()
        {
            var posts = new PostFaker()
                .Generate(100);
            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();
        }
    }
}
