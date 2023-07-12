using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class EnrollmentStatus
    {
        [Key]
        public int EnrollmentStatusId {get; set;}

        [Required]
        [MaxLength(30)]
        public string Name {get; set;}

        [JsonIgnore]
        public List<Enrollment> Enrollments {get; set; }
    
    }
}