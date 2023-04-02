using Microsoft.EntityFrameworkCore;
using FlightBookingSystemFolder.Models;

namespace FlightBookingSystemFolder.DataAccessLayer
{
    public class flightContext : DbContext
    {
         public flightContext(DbContextOptions<flightContext> options): base(options)
    {
    }
        public DbSet<Flight> dbsetflight { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<CheckIn> checkIns { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<Booking>()
                          .HasOne<CheckIn>(s => s.CheckIn)
                          .WithOne(a => a.Booking)
                          .HasForeignKey<CheckIn>(a => a.Booking_id);
                          
              modelBuilder.Entity<Booking>().HasOne<Registration>(d => d.Registration)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__Book__Registration_I__1273C1CD");            

              
         
            
        }
    }
}
