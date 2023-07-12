using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class EnrollmentType
    {
        [Key]
        public int EnrollmentTypeId {get; set;}

        [Required]
        [MaxLength(30)]
        public string Name {get; set;}

        [JsonIgnore]
        public List<Enrollment> Enrollments {get; set; }
    }
}
