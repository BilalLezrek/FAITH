using Domain.Gebruikers;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Posts
{
    public static class PostRequest
    {
        public class GetIndex
        {
            public int PostId { get; set; }
            public string Onderwerp { get; set; }
            public string Tekst { get; set; }
            public DateTime Datum { get; set; }
            public Gebruiker Gebruiker { get; set; }
            public string? Url { get; set; }
        }

        public class GetDetail
        {
            public int PostId { get; set; }
        }

        public class Delete
        {
            public int PostId { get; set; }
        }

        public class Create
        {
            public PostDto.Mutate Post { get; set; }
        }

        public class Edit
        {
            public int PostId { get; set; }
            public PostDto.Mutate Post { get; set; }
        }
    }
}
