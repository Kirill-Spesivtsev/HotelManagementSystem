using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ApartmentStatus
    {
        [Key]
        public int ApartmentStatusId {get; set;}
        
        [MaxLength(30)]
        public string StatusName {get; set;}
    }
}