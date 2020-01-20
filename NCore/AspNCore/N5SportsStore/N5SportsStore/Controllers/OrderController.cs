using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N5SportsStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace N5SportsStore.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new Order());
    }
}
