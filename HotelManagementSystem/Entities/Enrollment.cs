using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Enrollment
    {

        [Key]
        public int EnrollmentId {get; set;}

        public DateTime Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please select the arrival date")]
        public DateTime DateStart {get; set;}

        [Required(ErrorMessage = "Please select the departure date")]
        public DateTime DateEnd {get; set;}

        [Range(1, 50,ErrorMessage ="Please select the corrent number of guests")]
        public int AdultsNumber {get; set;}

        public int ChildrenNumber {get; set;} = 0;

        public bool BookingOnly {get; set;} = false;

        public bool PrePaid {get; set;} = false;

        public int ApartmentId {get; set;}
        public Apartment Apartment {get; set;}

        public int EnrollmentTypeId {get; set;}
        public EnrollmentType EnrollmentType {get; set;}

        [JsonIgnore]
        public List<EnrollmentService> EnrollmentServices { get; set; }

        [JsonIgnore]
        public List<EnrollmentGuest> EnrollmentGuests {get; set; }

    }
}
