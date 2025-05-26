using System.Threading.Tasks;

namespace Braum.Core.SimpleCqrsMediator.Interface
{

    public interface IQueryProcessor
    {
        Task<TResult> ProcessAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery;
    }
}
