using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool NewsletterSubscriber {get;set;} = false;


        public string? User {get;set;} = string.Empty;
    }
}
