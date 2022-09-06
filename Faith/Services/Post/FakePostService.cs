
using Domain.Posts;
using Services.Common;
using Shared.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FakePostService
{
    internal class FakePostService : IPostService
    {
        private static readonly List<Domain.Posts.Post> posts = new();
        private readonly IStorageService storageService;

        static FakePostService()
        {
            var postFaker = new PostFaker();
            posts = postFaker.Generate(50);
        }

        public FakePostService(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async Task<PostResponse.Create> CreateAsync(PostRequest.Create request)
        {
            PostResponse.Create response = new();

            var model = request.Post;
            var imageFilename = Guid.NewGuid().ToString();
            var imagePath = $"{storageService.StorageBaseUri}{imageFilename}";
            var post = new Domain.Posts.Post(model.Tekst,model.Onderwerp,model.Gebruiker,model.BegeleiderId,model.Archief,model.Url)
            {
                Id = posts.Max(x => x.Id) + 1
            };


            posts.Add(post);
            var uploadUri = storageService.CreateUploadUri(imageFilename);
            response.PostId = post.Id;
            response.Url = uploadUri.ToString();

            return response;
        }

        public async Task DeleteAsync(PostRequest.Delete request)
        {
            var p = posts.SingleOrDefault(x => x.Id == request.PostId);
            posts.Remove(p);
        }

        public async Task<PostResponse.Edit> EditAsync(PostRequest.Edit request)
        {
            PostResponse.Edit response = new();
            var post = posts.SingleOrDefault(x => x.Id == request.PostId);

            var model = request.Post;

            
            post.Onderwerp = model.Onderwerp;
            post.Tekst = model.Tekst;
            post.Archief = model.Archief;
            post.Url = model.Url;

            response.PostsId = post.Id;
            return response;
        }

        public async Task<PostResponse.GetIndex> GetIndexAsync(int begeleiderId)
        {
            PostResponse.GetIndex response = new();
            var query = posts.AsQueryable();

            query = query.Where(x => x.Archief == false && x.BegeleiderId == begeleiderId);

            query.OrderBy(x => x.Datum);
            response.Posts = query.Select(x => new PostDto.Index
            {
                Id = x.Id,
                Onderwerp = x.Onderwerp,
                Tekst = x.Tekst,
                Archief = x.Archief,
                Url = x.Url
            }).ToList();
            return response;
        }
    }
}
