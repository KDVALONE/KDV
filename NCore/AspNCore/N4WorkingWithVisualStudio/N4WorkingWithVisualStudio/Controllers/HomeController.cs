using Microsoft.AspNetCore.Mvc;
using N4WorkingWithVisualStudio.Models;

namespace N4WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View(SimpleRepository.SharedRepository.Products);
    }
}