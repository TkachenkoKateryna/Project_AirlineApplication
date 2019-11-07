using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Configurations
{
    public class FlightConfiguration : EntityTypeConfiguration<Flight>
    {
        public FlightConfiguration()
        {
            HasKey<int>(s => s.FlightId);

            Property(p => p.Date)
            .IsRequired();

            Property(p => p.StatusId)
            .IsRequired();

            Property(p => p.Code)
            .IsRequired()
            .HasMaxLength(4);

            HasRequired(c => c.FlightStatus)
           .WithMany(t => t.Flights)
           .HasForeignKey(c => c.StatusId)
           .WillCascadeOnDelete(false);
        }
    }
}