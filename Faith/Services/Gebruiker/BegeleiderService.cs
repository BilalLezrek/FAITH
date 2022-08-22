using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Shared.Begeleider;
using System.Linq;
using System.Threading.Tasks;

namespace Services.BegeleiderService
{
    public class BegeleiderService : IBegeleiderService
    {
        private readonly ManagementApiClient _managementApiClient;

        public BegeleiderService(ManagementApiClient managementApiClient)
        {
            _managementApiClient = managementApiClient;
        }

        public async Task<BegeleiderResponse.GetIndex> GetIndexAsync(BegeleiderRequest.GetIndex request)
        {
            BegeleiderResponse.GetIndex response = new();
            var users = await _managementApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());
            response.Begeleiders = users.Select(x => new BegeleiderDto.Index
            {
                Email = x.Email,
                Voornaam = x.FirstName,
                Achternaam = x.LastName,
            }).ToList();

            return response;
        }

        public async Task<BegeleiderResponse.Create> CreateAsync(BegeleiderRequest.Create request)
        {
            BegeleiderResponse.Create response = new();

            var auth0Request = new UserCreateRequest
            {
                Email = request.User.Email,
                FirstName = request.User.Voornaam,
                LastName = request.User.Achternaam,
                Password = request.User.Password,
                Connection = "Begeleidername-Password-Authentication" // Name of the Database connection
            };

            var createdBegeleider = await _managementApiClient.Users.CreateAsync(auth0Request);

            // Caching might be nice here
            var allRoles = await _managementApiClient.Roles.GetAllAsync(new GetRolesRequest());
            var adminRole = allRoles.First(x => x.Name == "Administrator");

            var assignRoleRequest = new AssignRolesRequest
            {
                Roles = new string[] { adminRole.Id }
            };
            await _managementApiClient.Users.AssignRolesAsync(createdBegeleider?.UserId, assignRoleRequest);

            response.Auth0UserId = createdBegeleider.UserId;

            return response;

        }
    }
}
