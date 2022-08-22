using Shared.Posts;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Users
{
    public class PostService : IPostService
    {
        private readonly HttpClient authenticatedClient;
        private const string endpoint = "api/Post";

        public PostService(HttpClient authenticatedClient)
        {
            this.authenticatedClient = authenticatedClient;
        }
        public async Task<PostResponse.GetIndex> GetIndexAsync(PostRequest.GetIndex request)
        {
            var response = await authenticatedClient.GetFromJsonAsync<PostResponse.GetIndex>($"{endpoint}?");
            return response;
        }

        public async Task<PostResponse.Create> CreateAsync(PostRequest.Create request)
        {
            var response = await authenticatedClient.PostAsJsonAsync(endpoint, request);
            return await response.Content.ReadFromJsonAsync<PostResponse.Create>();
        }

        public Task DeleteAsync(PostRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse.Edit> EditAsync(PostRequest.Edit request)
        {
            throw new NotImplementedException();
        }
    }
}
