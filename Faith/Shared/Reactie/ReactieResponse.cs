using Domain.Gebruikers;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Reactie
{
    public static class ReactieResponse
    {
        public class GetIndex
        {
            public List<ReactieDto.Index> Posts { get; set; } = new();
        }

        public class Delete
        {
        }

        public class Create
        {
            public int PostId { get; set; }
            public string Tekst { get; set; }
            public DateTime datum { get; set; }
            public int gebruiker { get; set; }
            public int reactie { get; set; }
            public string? url { get; set; }
        }

        public class Edit
        {
            public int PostId { get; set; }
        }
    }
}
