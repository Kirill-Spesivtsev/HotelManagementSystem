using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class EnrollmentType
    {
        [Key]
        public int EnrollmentTypeId {get; set;}

        [MaxLength(30)]
        public int Name {get; set;}
    }
}
