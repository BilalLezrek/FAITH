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
        private readonly DbSet<Domain.Posts.Post> _posts;

        private IQueryable<Domain.Posts.Post> GetPostById(int id) => _posts
                .AsNoTracking()
                .Where(p => p.Id == id);

        public async Task<PostResponse.Create> CreateAsync(PostRequest.Create request)
        {
            PostResponse.Create response = new();
            var post = _posts.Add(new Domain.Posts.Post(
                request.Post.Tekst,
                request.Post.Onderwerp,
                request.Post.Gebruiker,
                request.Post.BegeleiderId,
                request.Post.Archief,
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
                post.Url = model.Url;

                _dbContext.Entry(post).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.PostsId = post.Id;
            }

            return response;
        }

        public async Task<PostResponse.GetIndex> GetIndexAsync(int begeleiderId)
        {
            PostResponse.GetIndex response = new();
            var query = _posts.AsQueryable().AsNoTracking();

            query = query.Where(x => x.Archief == false && x.BegeleiderId == begeleiderId );

            query.OrderBy(x => x.Datum);
            response.Posts = await query.Select(x => new PostDto.Index
            {
                Id = x.Id,
                Onderwerp = x.Onderwerp,
                Tekst = x.Tekst,
                Gebruiker = x.Gebruiker,
                BegeleiderId = x.BegeleiderId,
                Archief = x.Archief,
                Url = x.Url
            }).ToListAsync();
            return response;
        }
    }
}
