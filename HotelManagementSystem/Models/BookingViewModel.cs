using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class BookingViewModel
    {
        [Key]
        public Guid BookingId {get; set;}

        public double Discont {get; set;} = 5d;

        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName {get; set;}

        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName {get; set;}

        [Required(ErrorMessage ="Please enter passport number")]
        public string IdNumber {get; set;}

        public string? Country {get; set;}

        public DateTime? BirthDate {get; set;}

        [Required(ErrorMessage ="Please select your gender")]
        public int GenderId {get; set;}
        public Gender Gender {get; set;}

        //---------------------------------------------------------------
        [Required(ErrorMessage = "Please select the arrival date")]
        public DateTime DateStart {get; set;}

        [Required(ErrorMessage = "Please select the departure date")]
        public DateTime DateEnd {get; set;}

        [Range(1, 50,ErrorMessage ="Please select the corrent number of guests")]
        public int AdultsNumber {get; set;}

        public int ChildrenNumber {get; set;} = 0;

        public bool BookingOnly {get; set;} = false;

        public bool PrePaid {get; set;} = false;

        public Guid ApartmentId {get; set;}
        public Apartment Apartment {get; set;}

        public int EnrollmentTypeId {get; set;} = 1;
        public EnrollmentType EnrollmentType {get; set;}
    }
}
