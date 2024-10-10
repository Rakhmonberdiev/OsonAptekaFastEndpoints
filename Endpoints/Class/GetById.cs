using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.RequestDtos.Students;
using OsonAptekaFastEndpoints.ResponseDtos.ClassDto;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Class
{
    [HttpGet("api/class/{id:int}"), AllowAnonymous]
    public class GetById : Endpoint<StudentIdRequest, ClassDto>
    {
        private readonly IBaseRepo _repo;
        public GetById(IBaseRepo repo)
        {
            _repo = repo;

        }


        public override async Task HandleAsync(StudentIdRequest request, CancellationToken ct)
        {

            var model = await _repo.ClassRepos.GetById(request.Id);
            if (model == null)
            {
                await SendNotFoundAsync();
            }
            else
            {
                await SendAsync(model);
            }
        }
    }
}
