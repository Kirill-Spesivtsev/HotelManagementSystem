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
        
        [Required]
        [MaxLength(300)]   
        public string Info {get; set;}    


        public int EnrollmentServiceId { get; set; }
        public EnrollmentService EnrollmentService { get; set; }

        public int ServicePriceId { get; set; }
        public ServicePrice ServicePrice { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
