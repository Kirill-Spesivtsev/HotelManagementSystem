using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Service
    { 
        [Key]
        public int ServiceId {get; set;}

        [Required]
        [MaxLength(60)]   
        public string Name {get; set;}      
        
        [MaxLength(600)]   
        public string? Info {get; set;}    

        [Required(ErrorMessage = "Please enter the correct price")]
        [Range(0.5, double.MaxValue,ErrorMessage ="Price should be larger than 0.5$")]
        public double Price {get; set;}    

        [Required(ErrorMessage = "Please select the service type")]
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        [JsonIgnore]
        public List<EnrollmentService> EnrollmentServices { get; set; }
    }
}
