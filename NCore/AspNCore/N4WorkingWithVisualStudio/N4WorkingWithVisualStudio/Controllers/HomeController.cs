using Microsoft.AspNetCore.Mvc;
using N4WorkingWithVisualStudio.Models;
using System.Linq;

namespace N4WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() 
            => View(SimpleRepository.SharedRepository.Products.Where(p => p?.Price <50));
    }
}