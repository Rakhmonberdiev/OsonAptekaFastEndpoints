using OsonAptekaFastEndpoints.RequestDtos.Classes;
using OsonAptekaFastEndpoints.RequestDtos.Students;
using OsonAptekaFastEndpoints.ResponseDtos.ClassDto;

namespace OsonAptekaFastEndpoints.Data.Repository
{
    public interface IClassRepo
    {
        Task<IEnumerable<ClassDto>> GetAll();
        Task<ClassDto> GetById(int id);
        Task Create(CreateClassReq dto);
        Task Delete(int id);
        Task Update(UpdateClassReq dto);
    }
}
