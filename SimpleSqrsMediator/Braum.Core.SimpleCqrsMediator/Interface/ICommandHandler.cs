﻿using System.Threading.Tasks;

namespace Braum.Core.SimpleCqrsMediator.Interface
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<TResult> HandleAsync(TCommand command);
    }
}
