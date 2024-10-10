using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;
using OsonAptekaFastEndpoints.Data.Repository;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpGet("api/students"), AllowAnonymous]
    public class GetAll: EndpointWithoutRequest<IEnumerable<StudentDto>>
    {
        private readonly IStudentRepo _repo;
        public GetAll(IStudentRepo repo)
        {
            _repo = repo;

        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            
           var students = await _repo.GetAll();
           await SendAsync(students);
        }
    }
}
