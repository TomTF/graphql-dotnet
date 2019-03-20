using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("graphql")]
    public class GraphQlController : Controller
    {
        private readonly ISchema schema;

        public GraphQlController(ISchema schema)
        {
            this.schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(o =>
            {
                o.Schema = this.schema;
                o.Query = query.Query;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
