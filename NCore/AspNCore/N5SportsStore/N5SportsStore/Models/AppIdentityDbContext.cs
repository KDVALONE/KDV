using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
namespace N5SportsStore.Models
{

    /// <summary>
    /// Класс контекст для связи AspNetCore.Identity с средствами EFWCore для
    /// обеспечения защиты и аутентификации сайта в будещем.
    /// IdentityUser - встроенный класс для представления параметров пользователей подробнее глава 28 
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base (options) 
        {
        
        }
       
    }
}

