using GitHubSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System.Web.Providers.Entities;
using static System.Net.WebRequestMethods;


namespace GitHubSearch.Controllers
{
    public class ReposController : Controller
    {
        [Route("[controller]")]
                
        public async Task<IActionResult> Index(string name)
        {
            var client = new GitHubClient(new ProductHeaderValue("Olga"));
    
            var credentials = new Credentials("epolga", "******", AuthenticationType.Basic);
            var result = await client.Search.SearchRepo(new SearchRepositoriesRequest(name));
            
            
            if (result == null)
            {
                return NotFound();
            }
            Octokit.Repository repository = null;
            var repos = new List<Repo>();
            foreach(var sourceRepo in result.Items)
            {   
                repos.Add( new Repo
                {
                    Id = sourceRepo.Id,
                    Name = sourceRepo.Name,
                    Avatar = $"https://avatars.githubusercontent.com/u/{sourceRepo.Id}" ,
                    Url = $"{sourceRepo.Url}"
                });
            }
           

            return View(repos);
        }

    }
}
