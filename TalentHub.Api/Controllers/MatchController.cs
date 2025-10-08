using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Api.Helpers;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.MatchDto;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;
        private readonly IMapper _mapper;
        public MatchController(IMatchService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchReadDto>>> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("{pageSize:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MatchReadDto>>> GetAllKPAsync(int pageSize,
            DateTime? key = null,
            Guid? lastId = null,
            bool forward = true,
            CancellationToken ct = default) => Ok(await _service.GetAllAsyncKP(pageSize, key, lastId, forward, ct));

        
        [HttpGet("{academyId:Guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MatchReadDto>>> GetById(Guid academyId)
        {
            return  Ok( await _service.GetAcademyMatches(academyId));
        }

        [HttpPost]
        [Authorize (Roles ="Admin")]
        public async Task<ActionResult<MatchReadDto>> Create(MatchCreateDto dto)
        {
            var model = _mapper.Map<Match>(dto);
            var created = await _service.CreateAsync(model);
            var read = _mapper.Map<MatchReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }
        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MatchReadDto>> Update(Guid id, MatchCreateDto dto)
        {
            var model = _mapper.Map<Match>(dto);
            var ok = await _service.UpdateAsync(id, model);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}