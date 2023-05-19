using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ServicePrice
    {
        [Key]
        public int ServiceId {get; set;}

        public double Price {get; set;}
    }
}