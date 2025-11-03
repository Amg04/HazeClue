using HazeClue.Core.Domain.Contracts;
using HazeClue.Core.Domain.Entities;
using HazeClue.Infrastructure.DbContext;
namespace HazeClue.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Dictionary<string, object> _repositories = new();

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseClass
        {
            var typeName = typeof(T).Name;
            if (!_repositories.ContainsKey(typeName))
            {
                _repositories[typeName] = new GenericRepository<T>(_dbContext);
            }
            return (IGenericRepository<T>)_repositories[typeName];
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
