using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.AccountDto;
namespace TalentHub.Business.Contracts
{
    public interface IAccountService
    {
        Task<CreateAccountDto> CreateAsync(CreateAccountDto account);
        Task<string> LogInAsync(string userName, string password);
    }
}
