using Shared.Reactie;
using System.Linq;
using Persistence.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Posts;

namespace Services.ReactieService
{
    public class ReactieService : IReactieService
    {
        public ReactieService(FaithDbContext dbContext)
        {
            _dbContext = dbContext;
            _reacties = dbContext.Reactie;
        }

        private readonly FaithDbContext _dbContext;
        private readonly DbSet<Reactie> _reacties;

        private IQueryable<Reactie> GetReactieById(int id) => _reacties
                .AsNoTracking()
                .Where(p => p.Id == id);

        public async Task<ReactieResponse.Create> CreateAsync(ReactieRequest.Create request)
        {
            ReactieResponse.Create response = new();
            var post = _reacties.Add(new Reactie(
                request.Reactie.Tekst,
                request.Reactie.Gebruiker,
                request.Reactie.Post
            ));
            await _dbContext.SaveChangesAsync();
            response.PostId = post.Entity.Id;
            return response;
        }

        public async Task DeleteAsync(ReactieRequest.Delete request)
        {
            _reacties.RemoveIf(p => p.Id == request.ReactieId);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ReactieResponse.Edit> EditAsync(ReactieRequest.Edit request)
        {
            ReactieResponse.Edit response = new();
            var post = await GetReactieById(request.ReactieId).SingleOrDefaultAsync();

            if (post is not null)
            {
                var model = request.Reactie;

                post.Tekst = model.Tekst;
                post.Gebruiker = model.Gebruiker;
                post.Post = model.Post;

                _dbContext.Entry(post).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                response.PostId = post.Id;
            }

            return response;
        }

        public async Task<ReactieResponse.GetIndex> GetIndexAsync(ReactieRequest.GetIndex request)
        {
            ReactieResponse.GetIndex response = new();
            var query = _reacties.AsQueryable().AsNoTracking();

            query.OrderBy(x => x.Datum);
            response.Posts = await query.Select(x => new ReactieDto.Index
            {
                Id = x.Id,
                Tekst = x.Tekst,
                Datum = x.Datum,
                Gebruiker = x.Gebruiker,
                Post = x.Post
            }).ToListAsync();
            return response;
        }
    }
}
