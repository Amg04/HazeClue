using HazeClue.Core.Domain.Entities;
using System.Linq.Expressions;

namespace HazeClue.Core.Domain.Contracts
{
    public interface ISpecification<T> where T : BaseClass
    {
        public Expression<Func<T, bool>> Criteria { get;}
        public List<Expression<Func<T, object>>> Includes { get; }
        public List<Func<IQueryable<T>, IQueryable<T>>> ComplexIncludes { get; }
    }
}
