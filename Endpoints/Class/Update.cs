using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.RequestDtos.Classes;
using OsonAptekaFastEndpoints.RequestDtos.Students;

namespace OsonAptekaFastEndpoints.Endpoints.Class
{

    [HttpPut("api/class/edit/{id:int}"), AllowAnonymous]
    public class Update : Endpoint<UpdateClassReq>
    {
        private readonly IBaseRepo _repo;
        public Update(IBaseRepo repo)
        {
            _repo = repo;
        }
        public override async Task HandleAsync(UpdateClassReq req, CancellationToken ct)
        {
            await _repo.ClassRepos.Update(req);
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
