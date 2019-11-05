using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using AirlineApplication.Configurations;

namespace AirlineApplication.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<FlightStatus> FlightStatuses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AirportConfiguration());
            modelBuilder.Configurations.Add(new ProfessionConfiguration());
            modelBuilder.Configurations.Add(new FlightConfiguration());
            modelBuilder.Configurations.Add(new CrewConfiguration());
            modelBuilder.Configurations.Add(new RouteConfiguration());
            modelBuilder.Configurations.Add(new FlightStatusConfiguration());
            modelBuilder.Configurations.Add(new CrewMemberConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}