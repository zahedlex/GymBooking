using Microsoft.AspNetCore.Identity;

namespace GymBooking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserGymClass> AttendingClasses { get; set; }
    }
}
