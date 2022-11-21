using Microsoft.AspNetCore.Identity;
namespace WEB_053505_Pronin.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? Avatar { get; set; }
    }
}
