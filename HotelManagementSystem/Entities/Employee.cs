using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId {get; set;}

        [MaxLength(15)]
        public string? PhoneNumber {get; set;}

        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName {get; set;}

        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName {get; set;}

        public string? Education {get; set;}

        public string? Position {get; set;}

        public string? Country {get; set;}

        public DateTime? BirthDate {get; set;}

        [Required(ErrorMessage ="Please enter passport number")]
        public string IdNumber {get; set;}

        [Required(ErrorMessage ="Please select your gender")]
        public int GenderId {get; set;}
        public Gender Gender {get; set;}

        [JsonIgnore]
        public List<EnrollmentGuest> EnrollmentGuests {get; set; }
    }
}
