using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Models;

namespace AirlineApplication.Configurations
{
    public class FlightStatusConfiguration : EntityTypeConfiguration<FlightStatus>
    {
        public FlightStatusConfiguration()
        {
            HasKey<int>(s => s.StatusId);

            Property(p => p.Value)
            .IsRequired()
            .HasMaxLength(3);
        }
    }
}