using System.Collections.Generic;

namespace Shared.Begeleider
{
    public static class BegeleiderResponse
    {
        public class GetIndex
        {
            public List<BegeleiderDto.Index> Begeleiders { get; set; } = new();
        }

        public class Create
        {
            public string Auth0UserId { get; set; }
        }
    }
}
