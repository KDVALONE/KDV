using System;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Model;
using System.Linq;

namespace PartyInvites.Controllers
{
public class HomeController : Controller {
        private IRepository repository;
        public HomeController(IRepository repo) => this.repository = repo;

        public ViewResult Index() {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Goode Morning" : "Goode Afternoon";
            return View("MyView"); 
        } 

        [HttpGet]
        public ViewResult RsvpForm() => View();

        [HttpPost]
        public ViewResult ResvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid){
                repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
                }else{
                    //Имеется ошибка проверки достоверности
                    return View();
                }
        }

        public ViewResult ListResponse() =>
         View(repository.Responses.Where(r => r.WillAttend == true));
        }

}

