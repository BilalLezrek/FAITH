using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Posts
{
    public interface IPostService
    {
        Task<PostResponse.GetIndex> GetIndexAsync(PostRequest.GetIndex request);
        Task DeleteAsync(PostRequest.Delete request);
        Task<PostResponse.Create> CreateAsync(PostRequest.Create request);
        Task<PostResponse.Edit> EditAsync(PostRequest.Edit request);
    }
}
