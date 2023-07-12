using EntityFrameworkCore.EncryptColumn.Attribute;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class Guest
    {
        [Key]
        public Guid GuestId {get; set;}

        [MaxLength(15)]
        public string? PhoneNumber {get; set;}

        public double Discont {get; set;} = 5d;

        [EncryptColumn]
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName {get; set;}

        [EncryptColumn]
        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName {get; set;}

        [EncryptColumn]
        [Required(ErrorMessage ="Please enter passport number")]
        public string IdNumber {get; set;}

        [EncryptColumn]
        public string? Country {get; set;}

        [EncryptColumn]
        public DateTime? BirthDate {get; set;}

        [EncryptColumn]
        [Required(ErrorMessage ="Please select your gender")]
        public int GenderId {get; set;}
        public Gender Gender {get; set;}

        [JsonIgnore]
        public List<EnrollmentGuest> EnrollmentGuests {get; set; }
    }
}
