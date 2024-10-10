using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using OsonAptekaFastEndpoints.Data.Repository.Base;
using OsonAptekaFastEndpoints.RequestDtos.Students;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpGet("api/student/{id:int}"), AllowAnonymous]
    public class GetById: Endpoint<StudentIdRequest,StudentDto>
    {
        private readonly IBaseRepo _repo;
        public GetById(IBaseRepo repo)
        {
            _repo = repo;

        }


        public override async Task HandleAsync(StudentIdRequest request,CancellationToken ct)
        {

            var student = await _repo.StudentRepos.GetById(request.Id);
            if (student == null)
            {
                await SendNotFoundAsync();
            }
            else
            {
                await SendAsync(student);
            }
        }
    }
}
