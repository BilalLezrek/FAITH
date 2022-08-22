using Domain.Posts;
using Microsoft.AspNetCore.Components;
using Shared.Posts;

namespace Client.Posts
{
    public partial class Detail
    {
        private List<PostDto.Index> post;
        private bool isRequestingDelete;
        [Parameter] public int Id { get; set; }
        [Inject] public IPostService PostService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        private void RequestDelete()
        {
            isRequestingDelete = true;
        }

        private void CancelDeleteRequest()
        {
            isRequestingDelete = false;
        }

        private async Task DeletePostAsync()
        {
            var request = new PostRequest.Delete { PostId = Id };
            await PostService.DeleteAsync(request);
            NavigationManager.NavigateTo("/");
        }

        private async Task GetPostAsync()
        {
            PostRequest.GetIndex request = new() { PostId = Id };
            var response = await PostService.GetIndexAsync(request);
            post = response.Posts;
        }
    }
}
