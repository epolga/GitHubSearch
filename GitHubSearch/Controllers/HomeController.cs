using GitHubSearch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Providers.Entities;

namespace GitHubSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
 
        public IActionResult Bookmarks()
        {
            var bookmarks = new List<Bookmark>();
            foreach (string key in HttpContext.Session.Keys)
            {
                bookmarks.Add( new Bookmark
                {
                    Id = key,
                    Url = HttpContext.Session.GetString(key)
                });
            }
            return View(bookmarks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}