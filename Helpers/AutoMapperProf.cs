using AutoMapper;
using OsonAptekaFastEndpoints.Entities;
using OsonAptekaFastEndpoints.ResponseDtos.StudentDtos;

namespace OsonAptekaFastEndpoints.Helpers
{
    public class AutoMapperProf : Profile
    {
        public AutoMapperProf()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d=>d.Class, o=>o.MapFrom(s=>s.Class.Name));
        }
    }
}
