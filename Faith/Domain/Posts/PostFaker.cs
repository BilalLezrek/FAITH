using Bogus;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Posts
{
    public class PostFaker : Faker<Post>
    {
        public PostFaker()
        {
            

        }
    }
}
