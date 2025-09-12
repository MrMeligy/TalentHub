using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Business.Contracts;
using static TalentHub.Business.Dtos.AcademyDto;
using TalentHub.Core.Entities;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademyController : ControllerBase
    {
        private readonly IAcademyService _service;
        private readonly IMapper _mapper;
        public AcademyController(IAcademyService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademyReadDto>>> GetAll()
        {
            var academies = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AcademyReadDto>>(academies));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<AcademyReadDto>> GetById(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(_mapper.Map<AcademyReadDto>(item));
        }

        [HttpPost]
        public async Task<ActionResult<AcademyReadDto>> Create(AcademyCreateDto dto)
        {
            var model = _mapper.Map<Academy>(dto);
            var created = await _service.CreateAsync(model);
            var read = _mapper.Map<AcademyReadDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<AcademyReadDto>> Update(Guid id,AcademyUpdateDto dto)
        {
            var model = _mapper.Map<Academy>(dto);
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
