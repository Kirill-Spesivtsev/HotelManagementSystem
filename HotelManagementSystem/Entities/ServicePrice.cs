using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class ServicePrice
    {
        [Key]
        public int ServiceId {get; set;}

        public double Price {get; set;}

    }
}