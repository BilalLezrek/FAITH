using System.Collections.Generic;

namespace Shared.Jongere
{
    public static class JongereResponse
    {
        public class GetIndex
        {
            public List<JongereDto.Index> Jongere { get; set; } = new();
        }

        public class Create
        {
            public string Auth0UserId { get; set; }
        }
    }
}
