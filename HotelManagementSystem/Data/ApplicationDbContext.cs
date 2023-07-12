using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn;
using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Migrations;
using EntityFrameworkCore.EncryptColumn.Util;
using EntityFrameworkCore.EncryptColumn.Extension;

namespace HotelManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IEncryptionProvider _provider;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this._provider = new GenerateEncryptionProvider("d664adc09aa37b75e124cd64c7b33b30");
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseEncryption(this._provider);
            base.OnModelCreating(builder);
        }






    }
}