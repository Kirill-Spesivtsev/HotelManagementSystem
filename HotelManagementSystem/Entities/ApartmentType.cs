using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class ApartmentType
    {
        [Key]
        public int ApartmentTypeId {get; set;}
        
        [Required]
        [MaxLength(30)]
        public string TypeName {get; set;}

        [JsonIgnore]
        public List<Apartment> Apartments {get; set; }
    }
}