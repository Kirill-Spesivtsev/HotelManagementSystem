using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Guest
    {
        [Key]
        public Guid GuestId {get; set;}

        [MaxLength(15)]
        public string? PhoneNumber {get; set;}

        public double Discont {get; set;} = 5d;

        [Required(ErrorMessage ="Please enter your first name")]
        public string FirtstName {get; set;}

        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName {get; set;}

        [Required(ErrorMessage ="Please enter passport number")]
        public string IdNumber {get; set;}

        [MaxLength(20)]
        public string? User {get; set;}
        public string? Country {get; set;}

        public DateTime? BirthDate {get; set;}

        [Required(ErrorMessage ="Please select your gender")]
        public int GenderId {get; set;}
        public Gender Gender {get; set;}

        [JsonIgnore]
        public List<EnrollmentGuest> EnrollmentGuests {get; set; }
    }
}
