using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class ApartmentCategory
    {
        [Key]
        public int ApartmentCategoryId {get; set;}
        
        [Required]
        [MaxLength(30)]
        public string CategoryName {get; set;}

        [JsonIgnore]
        public List<Apartment> Apartments {get; set; }
    }
}