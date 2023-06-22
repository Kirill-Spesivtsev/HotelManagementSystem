using HotelManagementSystem.Entities;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentCategory> ApartmentCategories { get; set; }
        public DbSet<ApartmentDailyPrice> ApartmentDailyPrices { get; set; }
        public DbSet<ApartmentStatus> ApartmentStatuses { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<EnrollmentService> EnrollmentServices { get; set; }
		public DbSet<EnrollmentGuest> EnrollmentGuests { get; set; }
        public DbSet<EnrollmentType> EnrollmentTypes { get; set; }
        public DbSet<EnrollmentStatus> EnrollmentStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServicePrice> ServicePrices { get; set; }




       

    }
}