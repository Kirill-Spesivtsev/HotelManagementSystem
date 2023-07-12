using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class ApartmentDailyPrice
    {
        [Key]
        public int ApartmentDailyPriceId {get; set;}
        
        public double DailyPrice {get; set;}

    }
}