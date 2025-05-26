using System.Threading.Tasks;

namespace Braum.Core.SimpleCqrsMediator.Interface
{
    public interface ICommandProcessor
    {
        Task ProcessAsync<TCommand>(TCommand command)
            where TCommand : ICommand;

        Task<TResult> ProcessAsync<TCommand, TResult>(TCommand command)
            where TCommand : ICommand;
    }
}
