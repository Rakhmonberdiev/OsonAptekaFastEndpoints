using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpGet("students"), AllowAnonymous]
    public class GetAll: EndpointWithoutRequest<List<StudentDto>>
    {
        private readonly AppDbContext _db;
        public GetAll(AppDbContext db)
        {
            _db = db;
        }


        public override async Task HandleAsync(CancellationToken ct)
        {
            var students = await _db.Students.Include(c=>c.Class).ToListAsync();
            var studentDtos = students.Select(s => new StudentDto
            {
                FullName = s.FullName,
                BirthDate = s.BirthDate,
                Class = s.Class.Name
                
            }).ToList();
           
           await SendAsync(studentDtos);
        }
    }
}
