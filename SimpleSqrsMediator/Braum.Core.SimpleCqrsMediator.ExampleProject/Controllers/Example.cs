using Braum.Core.SimpleCqrsMediator.ExampleProject.Example;
using Braum.Core.SimpleCqrsMediator.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Braum.Core.SimpleCqrsMediator.ExampleProject.Controllers;

[ApiController]
[Route("[controller]")]
public class Example(
    IQueryProcessor QueryProcessor) : ControllerBase
{
    [HttpGet]
    [Route("/Index")]
    public async Task<IActionResult> Index()
    {
        var query = new ExampleQuery();
        var result = await QueryProcessor.ProcessAsync<ExampleQuery, string>(query);
        return Ok(result);
    }
}
