using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoftBlogNCoreMVC.Models;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;

namespace LoftBlogNCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EFDBContext _context ;
        public HomeController(EFDBContext context)
        {
            _context = context;
        }
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HelloModel _model = new HelloModel() {HelloMessage = "Az Buki Vedi"};
            List<Directory> _dirs = _context.Directory.Include(x =>x.Materials).ToList();
            return View(_dirs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
