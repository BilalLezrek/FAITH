using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Infrastructure
{
    public class FakeAuthenticationProvider : AuthenticationStateProvider
    {
        public static ClaimsPrincipal Anonymous => new(new ClaimsIdentity());
        public static ClaimsPrincipal Administrator => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Begeleider"),
            new Claim(ClaimTypes.Email, "fake@gmail.com"),
            new Claim(ClaimTypes.Role, Roles.Begeleider),
        }, "Fake Authentication"));

        public static ClaimsPrincipal Customer => new(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "Fake Jongere"),
            new Claim(ClaimTypes.Email, "fake-Jongere@gmail.com"),
            new Claim(ClaimTypes.Role, Roles.Jongere),
        }, "Fake Authentication"));

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(Administrator));
        }
    }
}
