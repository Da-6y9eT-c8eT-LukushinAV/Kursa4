using HotelBooking.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class ApplicationDbContext : DbContext //IdentityDbContext<AspNetUser, AspNetRole, string>
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<AmenityRoom> AmenityRooms { get; set; }
        public DbSet<AspNetUserClaim> UserClaims { get; set; }
        public DbSet<AspNetUserLogin> UserLogins { get; set; }
        public DbSet<AspNetUserRole> UserRoles { get; set; }
        public DbSet<AspNetUserToken> UserTokens { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>()
            .HasOne(r => r.Hotel)
            .WithMany(h => h.Rooms)
            .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<AmenityRoom>()
                .HasKey(ar => new { ar.RoomId, ar.AmenityId });

            modelBuilder.Entity<AspNetUserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<AspNetUserLogin>()
                .HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

            modelBuilder.Entity<AspNetUserToken>()
                .HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
        }
    }

}
