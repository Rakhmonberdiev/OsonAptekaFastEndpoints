using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Data.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public StudentRepo(AppDbContext db,IMapper mapper)
        {

            _db = db;
            _mapper = mapper;

        }
        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            var models = await _db.Students.Include(x=>x.Class).ToListAsync();
            var modelsToReturn = _mapper.Map<IEnumerable<StudentDto>>(models);
            return modelsToReturn;
        }

        public async Task<StudentDto> GetById(int id)
        {
            var model = await _db.Students.SingleOrDefaultAsync(x => x.Id == id);
            var modelToReturn = _mapper.Map<StudentDto>(model);
            return modelToReturn;

        }
    }
}
