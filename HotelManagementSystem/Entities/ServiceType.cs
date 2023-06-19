using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceId {get; set;}

        [Required(ErrorMessage = "Please enter the name for service type")]
        [MaxLength(50)]
        public string TypeName {get; set;}

        [JsonIgnore]
        public List<Service> Services {get; set; }
    }
}
