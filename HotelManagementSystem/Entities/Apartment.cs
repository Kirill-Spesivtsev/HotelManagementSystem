using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.ViewModels
{
    public class Apartment
    {
        [Key]
        public Guid ApartmentId {get; set;}

        [MaxLength(30)]
        [Required(ErrorMessage = "Number is necessary")]
        public string ApartmentName {get; set;}

        [MaxLength(30)]
        [Required(ErrorMessage = "Title is necessary")]
        public string ApartmentTitle {get; set;}

        [MaxLength(120)]
        public string? Description {get; set;}

        public string? ImageUrl {get; set;} = string.Empty;

        [Required(ErrorMessage = "Please enter the correct price")]
        [Range(5.0, double.MaxValue,ErrorMessage = "Price should be larger than 5$")]
        public double DailyPrice {get; set;}

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Apartment Type")]
        public int ApartmentTypeId {get; set;}
        public ApartmentType ApartmentType {get; set;}

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Apartment Category")]
        public int ApartmentCategoryId {get; set;}
        public ApartmentCategory ApartmentCategory {get; set;}

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select Apartment Status")]
        public int ApartmentStatusId {get; set;}
        public ApartmentStatus ApartmentStatus {get; set;}
    }
}