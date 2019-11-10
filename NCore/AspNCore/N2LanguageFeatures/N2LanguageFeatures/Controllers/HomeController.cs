using  Microsoft.AspNetCore.Mvc;
namespace N2LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(new string[] {"C#", "Language", "Features"});
        }
    }
}