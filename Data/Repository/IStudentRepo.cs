using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Data.Repository
{
    public interface IStudentRepo
    {
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
       
    }
}
