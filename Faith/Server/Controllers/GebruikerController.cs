using Microsoft.AspNetCore.Mvc;
using Shared.Begeleider;
using Shared.Jongere;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Faith.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly IBegeleiderService begeleiderService;
        private readonly IJongereService jongereService;

        public GebruikerController(IBegeleiderService begeleiderService,IJongereService jongereService)
        {
            this.begeleiderService = begeleiderService;
            this.jongereService = jongereService;
        }

        [HttpGet]
        public Task<BegeleiderResponse.GetIndex> GetBegeleiderIndexAsync([FromQuery] BegeleiderRequest.GetIndex request)
        {
            return begeleiderService.GetIndexAsync(request);
        }

        [HttpPost]
        public Task<BegeleiderResponse.Create> CreateBegeleiderAsync([FromBody] BegeleiderRequest.Create request)
        {
            return begeleiderService.CreateAsync(request);
        }
        [HttpGet]
        public Task<JongereResponse.GetIndex> GetJongereIndexAsync([FromQuery] JongereRequest.GetIndex request)
        {
            return jongereService.GetIndexAsync(request);
        }

        [HttpPost]
        public Task<JongereResponse.Create> CreateJongereAsync([FromBody] JongereRequest.Create request)
        {
            return jongereService.CreateAsync(request);
        }
    }
}
