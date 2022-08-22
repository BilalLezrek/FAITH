namespace Shared.Begeleider
{
    public static class BegeleiderRequest
    {
        public class GetIndex
        {
            public object GetQueryString()
            {
                throw new NotImplementedException();
            }
        }

        public class Create
        {
            public BegeleiderDto.Create User { get; set; }
        }
    }
}
