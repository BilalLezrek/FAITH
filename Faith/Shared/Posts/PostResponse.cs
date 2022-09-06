using Domain.Gebruikers;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Posts
{
    public static class PostResponse
    {
        public class GetIndex
        {
            public List<PostDto.Index> Posts { get; set; } = new();
        }

        public class Delete
        {
        }

        public class Create
        {
            public int PostId { get; set; }
            public string Onderwerp { get; set; }
            public string Tekst { get; set; }
            public DateTime Datum { get; set; }
            public Gebruiker Gebruiker { get; set; }
            public bool Archied { get; set; }
            public string Url { get; set; }
        }

        public class Edit
        {
            public int PostsId { get; set; }
        }
    }
}
