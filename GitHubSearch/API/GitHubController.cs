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
        [HttpGet]
        public async Task<IActionResult> GetReps()
        {
            var client = new GitHubClient(new ProductHeaderValue("Olga"));
            var tokenAuth = new Credentials("token", AuthenticationType.Anonymous);
            client.Credentials = tokenAuth;
            var url = "https://github.com/search?q=angular&type=repositories";
            url = "https://api.github.com/repositories";
            var credentials = new Credentials("epolga", "cueryuc3141", AuthenticationType.Basic);
            var res = await client.Search.SearchRepo(new SearchRepositoriesRequest("angular university"));
            var t = res.GetType();
            var repo = res.Items.FirstOrDefault();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
         [Route("{name}")]
        public async Task<IActionResult> GetReps(string name)
        {
            var client = new GitHubClient(new ProductHeaderValue("Olga"));
           
            var url = "https://github.com/search?q=angular&type=repositories";
            url = "https://api.github.com/repositories";
            var credentials = new Credentials("epolga", "*******", AuthenticationType.Basic);
            var res = await client.Search.SearchRepo(new SearchRepositoriesRequest("angular university"));
            var t = res.GetType();
            var repo = res.Items.FirstOrDefault();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(repo);
        }

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
