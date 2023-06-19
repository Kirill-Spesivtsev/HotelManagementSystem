using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ApartmentStatus
    {
        [Key]
        public int ApartmentStatusId {get; set;}
        
        [Required]
        [MaxLength(30)]
        public string StatusName {get; set;}

        [JsonIgnore]
        public List<Apartment> Apartments {get; set; }
    }
}