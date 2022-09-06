using Shared.Jongere;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Users
{
    public class GebruikerService : IJongereService
    {
        private readonly HttpClient authenticatedClient;
        private const string endpoint = "api/Gebruiker";

        public GebruikerService(HttpClient authenticatedClient)
        {
            this.authenticatedClient = authenticatedClient;
        }
        public async Task<JongereResponse.GetIndex> GetIndexAsync(JongereRequest.GetIndex request)
        {
            var response = await authenticatedClient.GetFromJsonAsync<JongereResponse.GetIndex>($"{endpoint}?");
            return response;
        }

        public async Task<JongereResponse.Create> CreateAsync(JongereRequest.Create request)
        {
            var response = await authenticatedClient.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<JongereResponse.Create>();
        }
    }
}
