using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceId {get; set;}


        [MaxLength(50)]
        public string TypeName {get; set;}
    }
}
