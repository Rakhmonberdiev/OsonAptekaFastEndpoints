using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.ResponseDtos.ClassDto;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Class
{
    [HttpGet("api/classes"), AllowAnonymous]
    public class GetAll : EndpointWithoutRequest<IEnumerable<ClassDto>>
    {
        private readonly IBaseRepo _repo;
        public GetAll(IBaseRepo repo)
        {
            _repo = repo;

        }
        public override async Task HandleAsync(CancellationToken ct)
        {

            var models = await _repo.ClassRepos.GetAll();
            await SendAsync(models);
        }
    }
}
