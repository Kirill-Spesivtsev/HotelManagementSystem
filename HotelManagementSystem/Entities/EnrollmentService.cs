using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class EnrollmentService
    {
        [Key]
        public Guid EnrollmentServiceId {get;set;}

        public DateTime? Created { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Please enter Enrollment")]
        public Guid EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }


        [Required(ErrorMessage = "Please enter Guest")]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
