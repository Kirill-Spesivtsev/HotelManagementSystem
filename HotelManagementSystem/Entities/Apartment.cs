using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Apartment
    {
        [Key]
        public int ApartmentId {get; set;}

        [Required(ErrorMessage = "Title is necessary")]
        [MaxLength(30)]
        public string ApartmentName {get; set;}

        [MaxLength(120)]
        public string? Description {get; set;}

        public string? ImageUrl {get; set;} = string.Empty;

        [Required(ErrorMessage = "Please enter the correct price")]
        [Range(5.0, double.MaxValue,ErrorMessage ="Price should be larger than 5$")]
        public double DailyPrice {get; set;}


        [Range(1,int.MaxValue,ErrorMessage ="Please select Apartment Type")]
        public int ApartmentTypeId {get; set;}
        public ApartmentType ApartmentType {get; set;}

        [Range(1,int.MaxValue,ErrorMessage ="Please select Apartment Category")]
        public int ApartmentCategoryId {get; set;}
        public ApartmentCategory ApartmentCategory {get; set;}

        [Range(1,int.MaxValue,ErrorMessage ="Please select Apartment Status")]
        public int ApartmentStatusId {get; set;}
        public ApartmentStatus ApartmentStatus {get; set;}
    }
}