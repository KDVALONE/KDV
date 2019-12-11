using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace N5SportsStore.Models
{
    /// <summary>
    /// Контекст данных служит прослойкой для взаимодействия модели и ДБ в EFCore
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base()
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
