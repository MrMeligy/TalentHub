using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Api.Helpers;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.PlayerSkillDto;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayerSkillController : ControllerBase
    {
        private readonly IPlayerSkillService _service;
        private readonly IMapper _mapper;
        public PlayerSkillController(IPlayerSkillService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{playerId:Guid}")]
        public async Task<ActionResult<IEnumerable<PlayerSkillReadDto>>> GetAllAsync(Guid playerId)
        {
            var skills = await _service.GetAllAsync(playerId);
            return Ok(_mapper.Map<IEnumerable<PlayerSkillReadDto>>(skills));

        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PlayerSkillReadDto>> Create(PlayerSkillCreateDto dto)
        {
            var model = _mapper.Map<PlayerSkill>(dto);
            //navigation problem
            //if (!User.IsAuthorizedForAcademy(model.Player.AcademyTeam.AcademyId))
            //{
            //    return Forbid();
            //}
            var created = await _service.CreateAsync(model);
            return Ok(_mapper.Map<PlayerSkillReadDto>(created));
        }
        [HttpPut("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id , PlayerSkillCreateDto dto)
        {
            var model = _mapper.Map<PlayerSkill>(dto);
            //navigation problem
            //if (!User.IsAuthorizedForAcademy(model.Player.AcademyTeam.AcademyId))
            //{
            //    return Forbid();
            //}
            var ok = await _service.UpdateAsync(id, model);
            return ok ? NoContent() : NotFound();
        }
        [HttpDelete("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

    }
}
