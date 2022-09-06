using Domain.Gebruikers;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Reactie
{
    public static class ReactieRequest
    {
        public class GetIndex
        {
            public int ReactieId { get; set; }
            public string Tekst { get; set; }
            public int? Gebruiker { get; set; }
            public int post { get; set; }
            
        }

        public class GetDetail
        {
            public int PostId { get; set; }
            public int ReactieId { get; set; }
            public string Tekst { get; set; }
            public DateTime Datum { get; set; }
            public int? Gebruiker { get; set; }
            public int post { get; set; }
            public string? Url { get; set; }
        }

        public class Delete
        {
            public int ReactieId { get; set; }
        }

        public class Create
        {
            public ReactieDto.Mutate Reactie { get; set; }
        }

        public class Edit
        {
            public int ReactieId { get; set; }
            public ReactieDto.Mutate Reactie { get; set; }
        }
    }
}
