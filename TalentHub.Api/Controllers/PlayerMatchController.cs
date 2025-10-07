using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.MatchDto;
using static TalentHub.Business.Dtos.PlayerDto;
using static TalentHub.Business.Dtos.PlayerMatchDto;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerMatchController : ControllerBase
    {
        private readonly IPlayerMatchService _service;
        private readonly IMapper _mapper;
        public PlayerMatchController(IPlayerMatchService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PlayerMatchReadDto>> GetById(Guid id)
        {
           var pm = await _service.GetByIdAsync(id);
           return Ok(_mapper.Map<PlayerMatchReadDto>(pm));
        }
        [HttpGet("Match/{matchId:Guid}")]
        public async Task<ActionResult<IEnumerable<PlayerMatchReadDto>>> GetByMatch(Guid matchId)
        {
           var pm = await _service.GetByMatchAsync( matchId);
           return Ok(_mapper.Map<IEnumerable<PlayerMatchReadDto>>(pm));
        }
        [HttpGet("Player/{playerId:Guid}")]
        public async Task<ActionResult<IEnumerable<PlayerMatchReadDto>>> GetByPlayer(Guid playerId)
        {
           var pm = await _service.GetByPlayerAsync(playerId);
           return Ok(_mapper.Map<IEnumerable<PlayerMatchReadDto>>(pm));
        }
        [HttpPost]
        public async Task<ActionResult<PlayerMatchReadDto>> Create(PlayerMatchCreateDto dto)
        {
            var model = _mapper.Map<PlayerMatch>(dto);
            var created = await _service.CreateAsync(model);
            var read = _mapper.Map<PlayerMatchReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }
        //[HttpPut("{id:Guid}")]
        //public async Task<IActionResult> Update(Guid id, PlayerMatchCreateDto dto)
        //{
        //    var model = _mapper.Map<PlayerMatch>(dto);
        //    await _service.DeleteAsync(id);
        //    await _service.CreateAsync(model);
        //    return NoContent();
        //}

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

    }
}
