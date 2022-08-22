using System.Threading.Tasks;

namespace Shared.Begeleider
{
    public interface IBegeleiderService
    {
        Task<BegeleiderResponse.GetIndex> GetIndexAsync(BegeleiderRequest.GetIndex request);
        Task<BegeleiderResponse.Create> CreateAsync(BegeleiderRequest.Create request);
    }
}
