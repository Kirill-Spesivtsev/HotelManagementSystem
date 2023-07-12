using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class Enrollment
    {

        [Key]
        public Guid EnrollmentId {get; set;}

        public DateTime? Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please select the arrival date")]
        public DateTime DateStart {get; set;}

        [Required(ErrorMessage = "Please select the departure date")]
        public DateTime DateEnd {get; set;}

        [Range(1, 50, ErrorMessage ="Please select the correct number of guests")]
        public int AdultsNumber {get; set;} = 1;

        public int ChildrenNumber {get; set;} = 0;

        public bool BookingOnly {get; set;} = false;

        public bool PrePaid {get; set;} = false;

        [Required(ErrorMessage = "Please select the Apartment")]
        public Guid ApartmentId {get; set;}
        public Apartment Apartment {get; set;}

        [Required(ErrorMessage = "Please select the Enrollment Type")]
        public int EnrollmentTypeId {get; set;}
        public EnrollmentType EnrollmentType {get; set;}

        [Required(ErrorMessage = "Please select the Enrollment Status")]
        public int EnrollmentStatusId {get; set;}
        public EnrollmentStatus EnrollmentStatus {get; set;}

        [JsonIgnore]
        public List<EnrollmentService> EnrollmentServices { get; set; }

        [JsonIgnore]
        public List<EnrollmentGuest> EnrollmentGuests {get; set; }

    }
}
