using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.RequestDtos.Classes;
using OsonAptekaFastEndpoints.RequestDtos.Students;

namespace OsonAptekaFastEndpoints.Endpoints.Class
{
    [HttpPost("api/class/create"), AllowAnonymous]
    public class Create : Endpoint<CreateClassReq>
    {
        private IBaseRepo _repo;
        public Create(IBaseRepo repo)
        {
            _repo = repo;
        }
        public override async Task HandleAsync(CreateClassReq req, CancellationToken ct)
        {
            await _repo.ClassRepos.Create(req);
            if (await _repo.Complete())
            {
                await SendNoContentAsync();
            }
            else
            {
                await SendErrorsAsync();
            }
        }
    }
}
