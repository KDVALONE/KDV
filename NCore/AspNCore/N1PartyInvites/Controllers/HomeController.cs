using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using N1PartyInvites.Models;

namespace N1PartyInvites.Controllers
{
    public class HomeController : Controller    
    {
        public string Index()
        {
            return "Hello World";
        }

    }
}
