using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ApartmentDailyPrice
    {
        [Key]
        public int ApartmentDailyPriceId {get; set;}
        
        public double DailyPrice {get; set;}

    }
}