using Microsoft.AspNetCore.Identity;

namespace LinQ_practice_18_05.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string firstName;
        public string lastName;
    }
}
