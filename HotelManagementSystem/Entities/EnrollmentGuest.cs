using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class EnrollmentGuest
    {
        [Key]
        public Guid EnrollmentGuestId {get;set;}

        public DateTime? Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please enter Enrollment")]
        public Guid EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        [Required(ErrorMessage = "Please enter Guest")]
        public Guid GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}