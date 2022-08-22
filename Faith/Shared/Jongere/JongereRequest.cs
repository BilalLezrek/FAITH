namespace Shared.Jongere
{
    public static class JongereRequest
    {
        public class GetIndex
        {
        }

        public class Create
        {
            public JongereDto.Create User { get; set; }
        }
    }
}
