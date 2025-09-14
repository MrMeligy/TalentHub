using AutoMapper;
using static TalentHub.Business.Dtos.AcademyDto;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.AcademyTeamDto;
using static TalentHub.Business.Dtos.PlayerDto;
using static TalentHub.Business.Dtos.PlayerSkillDto;
using static TalentHub.Business.Dtos.MatchDto;

namespace TalentHub.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Academy, AcademyReadDto>();
            CreateMap<AcademyCreateDto, Academy>();
            CreateMap<AcademyUpdateDto, Academy>();
            
            CreateMap<AcademyTeam, AcademyTeamReadDto>();
            CreateMap<AcademyTeamCreateDto, AcademyTeam>();
            CreateMap<AcademyTeamUpdateDto, AcademyTeam>();

            CreateMap<Player, PlayerReadDto>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.AcademyTeam.Academy.Name))
                .ForMember(dest => dest.AcademyImage, opt => opt.MapFrom(src => src.AcademyTeam.Academy.Image));
            CreateMap<PlayerCreateDto, Player>();

            CreateMap<PlayerSkill, PlayerSkillReadDto>();
            CreateMap<PlayerSkillCreateDto, PlayerSkill>();
            
            CreateMap<Match, MatchReadDto>();
            CreateMap<MatchCreateDto, Match>();
            CreateMap<MatchUpdateDto, Match>();
        }



    }
}
