using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Configurations
{
    public class AirportConfiguration : EntityTypeConfiguration<Airport>
    {
        public AirportConfiguration()
        {
            HasKey<int>(s => s.AirportId);

            Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

            Property(p => p.City)
               .IsRequired()
               .HasMaxLength(255);
        }
    }
}