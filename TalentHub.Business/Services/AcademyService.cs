using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Services
{
    public class AcademyService : IAcademyService
    {
        private readonly IUnitOfWork _uow;
        public AcademyService(IUnitOfWork uow)=> _uow = uow;
        public async Task<Academy> CreateAsync(Academy academy)
        {
            await _uow.Academies.AddAsync(academy);
            await _uow.SaveChangesAsync();
            return academy;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.Academies.GetByIdAsync(id);
            if (existing is null) return false;
            _uow.Academies.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }
        public Task<IReadOnlyList<Academy>> GetAllAsync()=>_uow.Academies.GetAllAsync();

        public Task<Academy?> GetByIdAsync(Guid id)=>_uow.Academies.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(Guid id, Academy updated)
        {
            var existing = await _uow.Academies.GetByIdAsync(id);
            if (existing is null) return false;
            existing.Email = updated.Email;
            existing.Describtion = updated.Describtion;
            existing.Rating = updated.Rating;
            existing.Is_Partner = updated.Is_Partner;
            existing.Phone = updated.Phone;
            existing.Name = updated.Name;
            existing.City = updated.City;
            existing.Country = updated.Country;
            existing.Image = updated.Image;
            _uow.Academies.Update(existing);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}
