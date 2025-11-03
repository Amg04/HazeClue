using HazeClue.Core.Domain.Entities;
using HazeClue.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using HazeClue.Infrastructure.DbContext;
namespace HazeClue.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        public readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
           await  _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);

        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEvalutor<T>
                        .GetQuery(_dbContext.Set<T>(), spec)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await SpecificationEvalutor<T>
                        .GetQuery(_dbContext.Set<T>(), spec)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }
    }
}
