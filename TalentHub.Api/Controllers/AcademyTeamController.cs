using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TalentHub.Api.Helpers;
using TalentHub.Business.Contracts;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.AcademyTeamDto;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcademyTeamController : ControllerBase
    {
        private readonly IAcademyTeamService _service;
        private readonly IMapper _mapper;
        public AcademyTeamController(IAcademyTeamService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{academy:Guid}")]
        public async Task<ActionResult<IEnumerable<AcademyTeamReadDto>>> GetAll(Guid academy)
        {

            if (!User.IsAuthorizedForAcademy(academy))
            {
                return Forbid();
            }
            var items = await _service.GetAcademyTeams(academy);
            return Ok(_mapper.Map<IEnumerable<AcademyTeamReadDto>>(items));
        }
        [HttpGet("Team/{id:Guid}")]
        public async Task<ActionResult<AcademyTeamReadDto>> GetById(Guid id)
        {
            var academyTeam = await _service.GetAcademyTeamById(id);
            if(academyTeam is null) return NotFound();
            return Ok(_mapper.Map<AcademyTeamReadDto>(academyTeam));
        }
        [HttpPost]
        public async Task<ActionResult<AcademyTeamReadDto>> Create(AcademyTeamCreateDto dto)
        {
            var model = _mapper.Map<AcademyTeam>(dto);
            var created = await _service.CreateAsync(model);
            var read = _mapper.Map<AcademyTeamReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Update(Guid id, AcademyTeamUpdateDto dto)
        {
            var model = _mapper.Map<AcademyTeam>(dto);
            var ok = await _service.UpdateAsync(id, model);
            return ok ? NoContent() : NotFound();
        }
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
