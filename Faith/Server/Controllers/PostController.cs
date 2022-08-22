using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Gebruikers;
using Shared.Reactie;
using Shared.Posts;

namespace Faith.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize] 
public class PostController : ControllerBase
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IReactieService ReactieService;
        private readonly IPostService PostService;

        public GebruikerController(IReactieService ReactieService, IPostService PostService)
        {
            this.ReactieService = ReactieService;
            this.PostService = PostService;
        }

        [HttpGet]
        public Task<ReactieResponse.GetIndex> GetReactieIndexAsync([FromQuery] ReactieRequest.GetIndex request)
        {
            return ReactieService.GetIndexAsync(request);
        }

        [HttpPost]
        public Task<ReactieResponse.Create> CreateReactieAsync([FromBody] ReactieRequest.Create request)
        {
            return ReactieService.CreateAsync(request);
        }
        [HttpGet]
        public Task<PostResponse.GetIndex> GetPostIndexAsync([FromQuery] PostRequest.GetIndex request)
        {
            return PostService.GetIndexAsync(request);
        }

        [HttpPost]
        public Task<PostResponse.Create> CreatePostAsync([FromBody] PostRequest.Create request)
        {
            return PostService.CreateAsync(request);
        }
    }
}
