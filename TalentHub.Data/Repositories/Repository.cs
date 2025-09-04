using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TalentHub.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _ctx;
        public Repository(ApplicationDbContext ctx) => _ctx = ctx;
        public async Task<T?> GetByIdAsync(Guid id) => await _ctx.Set<T>().FindAsync(id);
        public async Task<IReadOnlyList<T>> GetAllAsync() => await _ctx.Set<T>().AsNoTracking().ToListAsync();
        public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _ctx.Set<T>().Where(predicate).ToListAsync();
        public async Task AddAsync(T entity) => await _ctx.Set<T>().AddAsync(entity);
        public void Update(T entity) => _ctx.Set<T>().Update(entity);
        public void Remove(T entity) => _ctx.Set<T>().Remove(entity);
    }
}
