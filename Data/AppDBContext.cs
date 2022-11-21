using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_053505_Pronin.Entities;

namespace WEB_053505_Pronin.Data
{
	public class AppDBContext : IdentityDbContext<ApplicationUser>
	{
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<WEB_053505_Pronin.Entities.Accessory> Accessory { get; set; }
        public DbSet<WEB_053505_Pronin.Entities.AccessoryCategory> AccessoryCategory { get; set; }
    }
}
