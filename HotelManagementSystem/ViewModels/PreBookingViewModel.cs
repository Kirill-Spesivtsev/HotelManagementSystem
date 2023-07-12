using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class PreBookingViewModel
    {
        [Range(1, 50,ErrorMessage ="Please select the corrent number of guests")]
        public int AdultsNumber {get; set;}

        [Required(ErrorMessage = "Please select the arrival date")]
        public DateTime DateStart {get; set;}

        [Required(ErrorMessage = "Please select the departure date")]
        public DateTime DateEnd {get; set;}

        public Guid? ApartmentId {get; set;}
    }
}
