namespace Shared.Begeleider
{
    public static class BegeleiderRequest
    {
        public class GetIndex
        {
        }

        public class Create
        {
            public BegeleiderDto.Create User { get; set; }
        }
    }
}
