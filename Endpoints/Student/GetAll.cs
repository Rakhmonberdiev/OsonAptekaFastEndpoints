using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpGet("api/students"), AllowAnonymous]
    public class GetAll: EndpointWithoutRequest<IEnumerable<StudentDto>>
    {
        private readonly IBaseRepo _repo;
        public GetAll(IBaseRepo repo)
        {
            _repo = repo;

        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            
           var students = await _repo.StudentRepos.GetAll();
           await SendAsync(students);
        }
    }
}
