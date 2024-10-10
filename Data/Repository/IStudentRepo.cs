using OsonAptekaFastEndpoints.RequestDtos.Students;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Data.Repository
{
    public interface IStudentRepo
    {
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task Create(StudentCreateReq dto);
        Task Delete(int id);
        Task Update(StudentUpdateReq dto);
    }
}
