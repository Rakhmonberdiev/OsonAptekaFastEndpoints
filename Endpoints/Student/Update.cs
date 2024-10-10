using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.RequestDtos.Students;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpPut("api/student/edit/{id:int}"), AllowAnonymous]
    public class Update : Endpoint<StudentUpdateReq>
    {
        private readonly IBaseRepo _repo;
        public Update(IBaseRepo repo)
        {
            _repo = repo;
        }
        public override async Task HandleAsync(StudentUpdateReq req, CancellationToken ct)
        {
            await _repo.StudentRepos.Update(req);
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
