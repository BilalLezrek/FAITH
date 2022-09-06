using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Begeleider;
using Shared.Jongere;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Faith.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Begeleider")]
    public class GebruikerController : ControllerBase
    {
        private readonly ManagementApiClient _managementApiClient;

        public GebruikerController(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        [HttpGet]
        public async Task<IEnumerable<JongereDto.Index>> GetUsers()
        {
            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest());
            return users.Select(x => new JongereDto.Index
            {
                Email = x.Email,
                Voornaam = x.FirstName,
                Achternaam = x.LastName,
            });
        }
    }
}
