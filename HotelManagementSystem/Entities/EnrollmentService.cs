using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class EnrollmentService
    {
        [Key]
        public int EnrollmentServiceId {get;set;}

        public DateTime Created { get; set; } = DateTime.Now;

        [Range(1,int.MaxValue,ErrorMessage ="Please enter Enrollment")]
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Please enter Guest")]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
