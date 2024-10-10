
using AutoMapper;

namespace OsonAptekaFastEndpoints.Data.Repository.Base
{
    public class BaseRepo : IBaseRepo
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public BaseRepo(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IStudentRepo StudentRepos => new StudentRepo(_db, _mapper);

        public IClassRepo ClassRepos => new ClassRepo(_db, _mapper);

        public async Task<bool> Complete()
        {
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
