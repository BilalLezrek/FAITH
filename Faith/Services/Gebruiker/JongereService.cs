using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Shared.Jongere;
using System.Linq;
using System.Threading.Tasks;

namespace Services.JongereService
{
    public class JongereService : IJongereService
    {
        private readonly ManagementApiClient _managementApiClient;

        public JongereService(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        public async Task<JongereResponse.GetIndex> GetIndexAsync(JongereRequest.GetIndex request)
        {
            JongereResponse.GetIndex response = new();
            var jongeren = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            response.Jongere = jongeren.Select(x => new JongereDto.Index
            {
                Email = x.Email,
                Voornaam = x.FirstName,
                Achternaam = x.LastName,
            }).ToList();

            return response;
        }

        public async Task<JongereResponse.Create> CreateAsync(JongereRequest.Create request)
        {
            JongereResponse.Create response = new();

            var auth0Request = new UserCreateRequest
            {
                Email = request.User.Email,
                FirstName = request.User.Voornaam,
                LastName = request.User.Achternaam,
                Password = request.User.Password,
                Connection = "Jongerename-Password-Authentication"
            };

            var createdJongere = await _managementApiClient.Users.CreateAsync(auth0Request);

            var allRoles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest());
            var adminRole = allRoles.First(x => x.Name == "Administrator");

            var assignRoleRequest = new AssignRolesRequest
            {
                Roles = new string[] { adminRole.Id }
            };
            await _managementApiClient.Users.AssignRolesAsync(createdJongere?.UserId, assignRoleRequest);

            response.Auth0UserId = createdJongere.UserId;

            return response;

        }
    }
}
