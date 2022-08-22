using System.Threading.Tasks;

namespace Shared.Jongere
{
    public interface IJongereService
    {
        Task<JongereResponse.GetIndex> GetIndexAsync(JongereRequest.GetIndex request);
        Task<JongereResponse.Create> CreateAsync(JongereRequest.Create request);
    }
}
