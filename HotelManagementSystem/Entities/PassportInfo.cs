using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class PassportInfo
    {
        [Key]
        public int PassportInfoId {get; set;}

        public string FirtstName {get; set;}

        public string LastName {get; set;}

    }
}
