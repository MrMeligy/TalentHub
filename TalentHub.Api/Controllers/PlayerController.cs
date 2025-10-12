using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Api.Helpers;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.AcademyDto;
using static TalentHub.Business.Dtos.PlayerDto;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetAll(int skip, int pageSize)
        {
            var players = await _service.GetAllPlayersAsync(skip, pageSize);
            return Ok(players);
        }
        [HttpGet("{teamId:Guid}")]
        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetAllByTeam(Guid teamId)
        {
            var players = await _service.GetPlayersByTeamAsync(teamId);
            if (players is null) return NotFound();
            return Ok(players);
        }
        [HttpGet("Match/{matchId:Guid}")]
        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetAllByMatch(Guid matchId)
        {
            var players = await _service.GetPlayersByMatchAsync(matchId);
            if (players is null) return NotFound();
            return Ok(players);
        }
        [HttpGet("Details/{id:Guid}")]
        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetById(Guid id)
        {
            var player = await _service.GetPlayerByIdAsync(id);
            if(player is null) return NotFound();
            return Ok(player);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PlayerReadDto>> Create(PlayerCreateDto dto)
        {
            var model = _mapper.Map<Player>(dto);
            //navigation problem
            //if (!User.IsAuthorizedForAcademy(model.AcademyTeam.AcademyId))
            //{
            //    return Forbid();
            //}
            var created = await _service.CreatePlayerAsync(model);
            var read = _mapper.Map<PlayerReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }
        [HttpPut("{id:Guid}")]
        [Authorize]
        public async Task<ActionResult<PlayerReadDto>> Update(Guid id, PlayerCreateDto dto)
        {
            var model = _mapper.Map<Player>(dto);
            //navigation problem
            //if (!User.IsAuthorizedForAcademy(model.AcademyTeam.AcademyId))
            //{
            //    return Forbid();
            //}
            var ok = await _service.UpdatePlayerAsync(id, model);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeletePlayerAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
