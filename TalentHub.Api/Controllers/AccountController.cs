using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentHub.Business.Contracts;
using static TalentHub.Business.Dtos.AccountDto;
using TalentHub.Core.Entities;

namespace TalentHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service,IMapper mapper)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateAccountDto>> CreateAsync(CreateAccountDto account)
        {
            if (User.IsInRole("Admin"))
            {
                var created = await _service.CreateAsync(account);
                return Ok(created);
            }
            else 
                return BadRequest();
        }
        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogIn([FromBody]LoginDto dto)
        {
            try
            {
                var Token = await _service.LogInAsync(dto.UserName, dto.Password);
                return Ok(Token);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }

        }
    }
}
