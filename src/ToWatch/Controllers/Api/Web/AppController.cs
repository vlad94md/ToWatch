using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ToWatch.Controllers.Web
{
    public class AppController : Controller
    {
        private IConfigurationRoot _config;

        public AppController(IConfigurationRoot config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
