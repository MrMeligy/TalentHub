using AutoMapper;
using static TalentHub.Business.Dtos.AcademyDto;
using TalentHub.Core.Entities;

namespace TalentHub.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Academy, AcademyReadDto>();
            CreateMap<AcademyCreateDto, Academy>();
            CreateMap<AcademyUpdateDto, Academy>();
        }

    }
}
