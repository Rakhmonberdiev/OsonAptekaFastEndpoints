using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.RequestDtos.Students;
using System.Net;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpPost("api/student/create"), AllowAnonymous]
    public class Create : Endpoint<StudentCreateReq>
    {
        private IBaseRepo _repo;
        public Create(IBaseRepo repo)
        {
            _repo = repo;
        }
        public override async Task HandleAsync(StudentCreateReq req, CancellationToken ct)
        {
            await _repo.StudentRepos.Create(req);
            if(await _repo.Complete())
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
