﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Apartment
    {
        [Key]
        public int ApartmentId {get; set;}

        public int ApartmentName {get; set;}

        public int DaysOccupied {get; set;} = 1;

        public int ApartmentTypeId {get; set;}
        public ApartmentType EnrollmentTypeGuest {get; set;}

        public int ApartmentCategoryId {get; set;}
        public ApartmentCategory ApartmentCategory {get; set;}

        public int ApartmentStatusId {get; set;}
        public ApartmentStatus ApartmentStatus {get; set;}

        public int ApartmentDailyPriceId {get; set;}
        public ApartmentDailyPrice ApartmentDailyPrice {get; set;}
    }
}