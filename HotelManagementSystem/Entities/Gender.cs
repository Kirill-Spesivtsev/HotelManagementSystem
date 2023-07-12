using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class Gender
    {
        [Key]
        public int GenderId {get; set;}

        [Required]
        [MaxLength(70)]   
        public string GenderName {get; set;}

        [JsonIgnore]
        public List<Guest> Guests {get; set; }
    }
}
