using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ApartmentCategory
    {
        [Key]
        public int ApartmentCategoryId {get; set;}
        
        [MaxLength(30)]
        public string CategoryName {get; set;}
    }
}