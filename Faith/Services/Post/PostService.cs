using Shared.Posts;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Posts;

namespace Services.PostService
{
    public class PostService : IPostService
    {
        public PostService(FaithDbContext dbContext)
        {
            _dbContext = dbContext;
            _posts = dbContext.Posts;
        }

        private readonly FaithDbContext _dbContext;
        private readonly DbSet<Post> _posts;

        private IQueryable<Post> GetPostById(int id) => _posts
                .AsNoTracking()
                .Where(p => p.Id == id);

        public async Task<PostResponse.Create> CreateAsync(PostRequest.Create request)
        {
            PostResponse.Create response = new();
            var post = _posts.Add(new Post(
                request.Post.Tekst,
                request.Post.Onderwerp,
                request.Post.Gebruiker,
                request.Post.Url
            ));
            await _dbContext.SaveChangesAsync();
            response.PostId = post.Entity.Id;
            return response;
        }

        public async Task DeleteAsync(PostRequest.Delete request)
        {
            _posts.RemoveIf(p => p.Id == request.PostId);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PostResponse.Edit> EditAsync(PostRequest.Edit request)
        {
            PostResponse.Edit response = new();
            var post = await GetPostById(request.PostId).SingleOrDefaultAsync();

            if (post is not null)
            {
                var model = request.Post;

                post.Tekst = model.Tekst;
                post.Onderwerp = model.Onderwerp;
                post.Gebruiker = model.Gebruiker;
                post.PhotoUrl = model.Url;

                _dbContext.Entry(post).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.PostsId = post.Id;
            }

            return response;
        }

        public async Task<PostResponse.GetIndex> GetIndexAsync(PostRequest.GetIndex request)
        {
            PostResponse.GetIndex response = new();
            var query = _posts.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Onderwerp))
                query = query.Where(x => x.Onderwerp.Contains(request.Onderwerp));

            query.OrderBy(x => x.Datum);
            response.Posts = await query.Select(x => new PostDto.Index
            {
                Id = x.Id,
                Tekst = x.Tekst,
                Onderwerp = x.Onderwerp,
                Datum = x.Datum,
                Gebruiker = x.Gebruiker,
                Url = x.PhotoUrl
            }).ToListAsync();
            return response;
        }
    }
}
