using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Octokit;
using System.Net;

namespace GitHubSearch.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        public async Task<IActionResult> Index(string searchString)
        {
            
            return Ok();
        }

        [HttpPost]
        [Route("bookmark/{name}")]
        public async Task<IActionResult> SetBookmark([FromRoute]string name, [FromQuery] string result)
        {
            var res = HttpContext.Session.GetString(name);
            HttpContext.Session.SetString(name, result);
            
          
            if (res == null)
            {
                return NotFound();
            }
            return Ok("OK");
        }
    }
}
