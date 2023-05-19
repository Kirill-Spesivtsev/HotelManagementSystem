using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Guest
    {
        [Key]
        public int GuestId {get; set;}

        [MaxLength(15)]
        public string? PhoneNumber {get; set;}

        public double Discont {get; set;} = 0d;

        public int PassportInfoId {get; set;}
        public PassportInfo PassportInfo {get; set;}
    }
}
