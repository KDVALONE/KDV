using Microsoft.EntityFrameworkCore;
namespace PartyInvites.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() {}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
           builder.UseSqlite("Filename=./PartyInvites.db");
        }
        
        public DbSet<GuestResponse> Invites {get;set;}
    }
}