﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Gender
    {
        [Key]
        public int GenderId {get; set;}

        [Required]
        [MaxLength(70)]   
        public string GenderName {get; set;}
    }
}