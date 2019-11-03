using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Models;

namespace AirlineApplication.Configurations
{
    public class RouteConfiguration : EntityTypeConfiguration<Route>
    {
        public RouteConfiguration()
        {
            HasKey(um => um.RouteId)
           .ToTable("Routes");

            HasRequired(um => um.Flight).WithMany(g => g.Airports)
            .HasForeignKey(um => um.FlightId);

            HasRequired(um => um.Airport).WithMany(g => g.Flights)
            .HasForeignKey(um => um.AirportId);
        }
    }
}