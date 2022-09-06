using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Gebruikers;
using Shared.Reactie;
using Shared.Posts;

namespace Faith.Server.Controllers;

[Route("api/[controller]")]
public class PostController : ControllerBase
{
        private readonly IReactieService ReactieService;
        private readonly IPostService PostService;

        public PostController(IReactieService ReactieService, IPostService PostService)
        {
            this.ReactieService = ReactieService;
            this.PostService = PostService;
        }

        /*[HttpGet]
        public Task<ReactieResponse.GetIndex> GetReactieIndexAsync([FromQuery] ReactieRequest.GetIndex request)
        {
            return ReactieService.GetIndexAsync(request);
        }*/

        [HttpPost]
        public Task<ReactieResponse.Create> CreateReactieAsync([FromBody] ReactieRequest.Create request)
        {
            return ReactieService.CreateAsync(request);
        }
        [HttpGet("{begeleiderId}")]
        public Task<PostResponse.GetIndex> GetPostIndexAsync(int begeleiderId)
        {
        Console.WriteLine("ping in erver");
        var posts = PostService.GetIndexAsync(begeleiderId);
        Console.WriteLine(posts);
        return posts;
        }
    }
