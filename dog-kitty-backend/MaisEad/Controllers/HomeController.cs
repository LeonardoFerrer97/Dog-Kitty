using System;
using MaisEad.Utils.ConnectionStrings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MaisEad.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ConnectionStrings> config;

        public HomeController(IOptions<ConnectionStrings> config)
        {
            this.config = config;
        }

        // GET: /<controller>/
        public IActionResult Index() => View(config.Value);
    }
}
