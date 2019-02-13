using Microsoft.AspNetCore.Identity;

namespace Adolfo.AspNetIdentity.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
