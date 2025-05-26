using System.Threading.Tasks;

namespace Braum.Core.SimpleCqrsMediator.Interface
{
    public interface IQueryHandler<TQuery, TResult>
            where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
