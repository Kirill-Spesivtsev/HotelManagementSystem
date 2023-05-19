using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ApartmentType
    {
        [Key]
        public int ApartmentTypeId {get; set;}
        
        [MaxLength(30)]
        public string TypeName {get; set;}
    }
}