using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Data;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Endpoints.Student
{
    [HttpGet("api/students"), AllowAnonymous]
    public class GetAll: EndpointWithoutRequest<IEnumerable<StudentDto>>
    {
        private readonly AppDbContext _db;
        private readonly AutoMapper.IMapper _mapper;
        public GetAll(AppDbContext db, AutoMapper.IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }


        public override async Task HandleAsync(CancellationToken ct)
        {
           var students = await _db.Students.Include(c=>c.Class).ToListAsync();
           var studentsToReturn = _mapper.Map<List<StudentDto>>(students); 
           
           await SendAsync(studentsToReturn);
        }
    }
}
