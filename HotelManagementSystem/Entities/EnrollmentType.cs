using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class EnrollmentType
    {
        [Key]
        public int EnrollmentTypeId {get; set;}

        [Required]
        [MaxLength(30)]
        public int Name {get; set;}

        [JsonIgnore]
        public List<Enrollment> Enrollments {get; set; }
    }
}
