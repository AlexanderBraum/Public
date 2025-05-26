using Braum.Core.SimpleCqrsMediator.Interface;

namespace Braum.Core.SimpleCqrsMediator.ExampleProject.Example;

public class ExampleQueryHandler: IQueryHandler<ExampleQuery, string>
{
    public Task<string> HandleAsync(ExampleQuery query)
    {
        return Task.FromResult("Hello from ExampleQueryHandler");
    }
}
