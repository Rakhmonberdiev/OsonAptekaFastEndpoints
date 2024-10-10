using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OsonAptekaFastEndpoints.Entities;
using OsonAptekaFastEndpoints.RequestDtos.Classes;
using OsonAptekaFastEndpoints.ResponseDtos.ClassDto;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;
using static FastEndpoints.Ep;

namespace OsonAptekaFastEndpoints.Data.Repository
{
    public class ClassRepo : IClassRepo
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        public ClassRepo(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task Create(CreateClassReq dto)
        {
            var mapping = _mapper.Map<Class>(dto);
            await _db.Classes.AddAsync(mapping);
        }

        public async Task Delete(int id)
        {
            var model = await _db.Classes.FirstOrDefaultAsync(x => x.Id == id);
            if (model != null)
            {
                _db.Classes.Remove(model);
            }
        }

        public async Task<IEnumerable<ClassDto>> GetAll()
        {
            var models = await _db.Classes.ToListAsync();
            var modelsToReturn = _mapper.Map<IEnumerable<ClassDto>>(models);
            return modelsToReturn;
        }

        public async Task<ClassDto> GetById(int id)
        {
            var model = await _db.Classes.SingleOrDefaultAsync(x => x.Id == id);
            var modelToReturn = _mapper.Map<ClassDto>(model);
            return modelToReturn;
        }

        public async Task Update(UpdateClassReq dto)
        {
            var modelEx = await _db.Classes.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (modelEx != null)
            {
                _mapper.Map(dto, modelEx);
                _db.Classes.Update(modelEx);
            }
        }
    }
}
