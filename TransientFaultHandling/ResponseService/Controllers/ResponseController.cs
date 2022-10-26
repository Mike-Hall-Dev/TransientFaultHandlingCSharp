using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ResponseService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        //GET /api/response/5

        [HttpGet]
        [Route("{successResponseLikelihood:int}")]
        public ActionResult GetResponse(int successResponseLikelihood)
        {
            Random random = new Random();
            var randomNumber = random.Next(1, 101);
            if (randomNumber >= successResponseLikelihood)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(successResponseLikelihood);
        }
    }
}
