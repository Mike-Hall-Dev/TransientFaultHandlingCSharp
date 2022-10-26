using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RequestService.Policies;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RequestController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult> MakeRequest()
        {
            var client = _clientFactory.CreateClient("MyNamedClient");

             var response = await client.GetAsync("https://localhost:44361/api/response/30");

             //var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
             //   () => client.GetAsync("https://localhost:44361/api/response/30"));

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("---------- Response Service returned success! ----------");
                return Ok();
            }

            Console.WriteLine("---------- Response Service returned success! ----------");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
