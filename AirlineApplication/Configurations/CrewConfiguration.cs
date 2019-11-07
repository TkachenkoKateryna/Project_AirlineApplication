using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Configurations 
{
    public class CrewConfiguration : EntityTypeConfiguration<Crew>
{
        public CrewConfiguration()
        {
            HasKey(um => um.CrewtId)
           .ToTable("Crew");

            HasRequired(um => um.Flight).WithMany(g => g.CrewMembers)
            .HasForeignKey(um => um.FlightId);

            HasRequired(um => um.CrewMember).WithMany(g => g.Flights)
            .HasForeignKey(um => um.CrewMemberId);
        }
    }
}