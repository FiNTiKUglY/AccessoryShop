using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.AccessControl;
using WEB_053505_Pronin.Entities;

namespace WEB_053505_Pronin.Data
{
	public class DBObject
	{
		public static async Task Initial(AppDBContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			IdentityRole adminRole = new IdentityRole("admin");
			ApplicationUser admin = new ApplicationUser { UserName = "admin@gmail.com" };
            await userManager.CreateAsync(admin, "admin"); 
			await roleManager.CreateAsync(adminRole);
            await context.SaveChangesAsync();
		}
	}
}