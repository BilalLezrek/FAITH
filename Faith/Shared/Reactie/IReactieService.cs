using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Reactie
{
    public interface IReactieService
    {
        Task<ReactieResponse.GetIndex> GetIndexAsync(ReactieRequest.GetIndex request);
        Task DeleteAsync(ReactieRequest.Delete request);
        Task<ReactieResponse.Create> CreateAsync(ReactieRequest.Create request);
        Task<ReactieResponse.Edit> EditAsync(ReactieRequest.Edit request);
    }
}
