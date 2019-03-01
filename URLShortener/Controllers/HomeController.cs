using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Data;
using URLShortener.Models;
using URLShortener.Services;

namespace URLShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShortenedUrlContext _context;
        private RandomShrotenedUrlGeneratorService _randomGeneratorService;

        public HomeController(ShortenedUrlContext context)
        {
            _context = context;
            _randomGeneratorService = new RandomShrotenedUrlGeneratorService();
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.GetRecentShortenedUrls();
            return View(model);
        }

        [HttpPost]
        public void CreateShortenedUrl(string targetUrl)
        {
            bool isCreationSuccess;
            do
            {
                string shortenedPath = _randomGeneratorService.GetRandomShortenedPath(4);
                isCreationSuccess = _context.CreateShortenedUrl(shortenedPath, targetUrl);
            } while (!isCreationSuccess);

            Response.Redirect("/");

        }

        public void GoToUrl(string hash)
        {
            string targetUrl = _context.GetTargetUrl(hash);
            Response.Redirect(targetUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
