using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.AccountDto;

namespace TalentHub.Business.Services
{
    public class AccountService:IAccountService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuthService _authService;
        public AccountService(IUnitOfWork uow,IAuthService authService)
        {
            _uow = uow;
            _authService = authService;
        }

        public async Task<CreateAccountDto> CreateAsync(CreateAccountDto account)
        {
            Account acc = new Account()
            {
                UserName = account.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(account.Password),
                Role = account.Role,
                AcademyId = account.AcademyId
            }; 
            await _uow.Accounts.AddAsync(acc);
            await _uow.SaveChangesAsync();
            return account;
        }

        public async Task<string> LogInAsync(string userName, string password)
        {
            var user = await _uow.Accounts.FindAsync(x => x.UserName == userName);
            if (user == null)
            {
                return "Not Found";
            }
            var verified = _authService.Verify(password, user[0].Password);
            if (verified)
            {
                var token = _authService.GenerateToken(user[0]);
                return token.ToString();
            }
            return "not autherized";
        }
    }
}
