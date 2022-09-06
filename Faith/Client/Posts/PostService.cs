using Client.Extensions;
using Client.Infrastructure;
using Shared.Posts;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Users
{
    public class PostService : IPostService
    {
        private readonly HttpClient authenticatedClient;
        private readonly PublicClient publicClient;
        private const string endpoint = "api/Post";

        public PostService(HttpClient authenticatedClient, PublicClient publicClient)
        {

            this.publicClient = publicClient;
            this.authenticatedClient = authenticatedClient;
        }

        public async Task<PostResponse.GetIndex> GetIndexAsync(int begeleiderId)
        {
            Console.WriteLine("ping van PostService");
            var response = await publicClient.Client.GetFromJsonAsync<PostResponse.GetIndex>($"{endpoint}/{begeleiderId}");
            return response;
        }

        public Task DeleteAsync(PostRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse.Create> CreateAsync(PostRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse.Edit> EditAsync(PostRequest.Edit request)
        {
            throw new NotImplementedException();
        }
    }
}
