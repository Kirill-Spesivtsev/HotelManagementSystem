using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class EnrollmentService
    {
        [Key]
        public int EnrollmentServiceId {get;set;}
        public List<Apartment> Apartments { get; set; }

        public List<Service> Services { get; set; }
    }
}
