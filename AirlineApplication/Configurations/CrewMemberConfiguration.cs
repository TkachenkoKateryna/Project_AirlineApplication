using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Models;

namespace AirlineApplication.Configurations
{
    public class CrewMemberConfiguration : EntityTypeConfiguration<CrewMember>
    {
        public CrewMemberConfiguration()
        {
            HasKey<int>(s => s.CrewMemberId);

            Property(p => p.FullName)
           .IsRequired()
           .HasMaxLength(255);

            HasRequired(c => c.Profession)
           .WithMany(t => t.Members)
           .HasForeignKey(c => c.ProfessionId)
           .WillCascadeOnDelete(false);

        }
    }
}