using HazeClue.Core.Domain.Entities;
namespace HazeClue.Core.Domain.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseClass;
        Task<int> CompleteAsync();
    }
}
