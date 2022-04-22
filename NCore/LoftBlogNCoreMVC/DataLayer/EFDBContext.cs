using System.Collections.Generic;
using System.Net.Http.Headers;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    /// <summary>
    /// Внутри прорисываются database sets (matchigs)
    /// </summary>
    public class EFDBContext : DbContext
    {
        //DbSet это ссылка, на данные из ДБ
        public DbSet<Directory> Directory { get; set; }
        public DbSet<Material> Materials { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
       
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;DataBase=loftBlogASPCoreDb;Trusted_Connection=True;MultipleActiveResultSets=true",b => b.MigrationsAssembly("DataLayer"));
            
            return  new EFDBContext(optionsBuilder.Options);
        }
    }

}