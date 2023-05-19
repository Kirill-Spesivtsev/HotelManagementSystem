using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Enrollment
    {

        [Key]
        public int EnrollmentId {get; set;}

        public DateTime DateStart {get; set;}

        public DateTime DateEnd {get; set;}

        public int AdultsNumber {get; set;}

        public int ChildrenNumber {get; set;}

        public double CheckSum {get; set;}

        public int GuestId {get; set;}
        public Guest Guest {get; set;}

        public int ApartmentId {get; set;}
        public Apartment Apartment {get; set;}

        public int EnrollmentTypeId {get; set;}
        public EnrollmentType EnrollmentTypeGuest {get; set;}

        public int EnrollmentServiceId { get; set; }
        public EnrollmentService EnrollmentService { get; set; }

    }
}
