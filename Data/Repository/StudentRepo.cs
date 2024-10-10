using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Entities;
using OsonAptekaFastEndpoints.RequestDtos.Students;
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

        public async Task Create(StudentCreateReq dto)
        {
            var classExists = await _db.Classes.AnyAsync(x => x.Id == dto.ClassId);
            if (classExists)
            {
                var mapping = _mapper.Map<Student>(dto);
                await _db.Students.AddAsync(mapping);
            }
        }

        public async Task Delete(int id)
        {
           var model = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (model != null)
            {
                _db.Students.Remove(model);
            }
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            var models = await _db.Students.Include(x=>x.Class).ToListAsync();
            var modelsToReturn = _mapper.Map<IEnumerable<StudentDto>>(models);
            return modelsToReturn;
        }

        public async Task<StudentDto> GetById(int id)
        {
            var model = await _db.Students.Include(x=>x.Class).SingleOrDefaultAsync(x => x.Id == id);
            var modelToReturn = _mapper.Map<StudentDto>(model);
            return modelToReturn;

        }

        public async Task Update(StudentUpdateReq req)
        {
            var modelEx = await _db.Students.FirstOrDefaultAsync(x=>x.Id== req.Id);
            if(modelEx != null)
            {
                _mapper.Map(req,modelEx);
                _db.Students.Update(modelEx);
            }
        }
    }
}
