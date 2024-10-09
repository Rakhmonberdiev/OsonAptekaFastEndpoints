using AutoMapper;
using OsonAptekaFastEndpoints.Entities;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;
using OsonAptekaFastEndpoints.Helpers;
namespace OsonAptekaFastEndpoints.Helpers
{
    public class AutoMapperProf : Profile
    {
        public AutoMapperProf()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.Class, o => o.MapFrom(s => s.Class.Name))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.BirthDate.Calculate()));
        }
    }
}
