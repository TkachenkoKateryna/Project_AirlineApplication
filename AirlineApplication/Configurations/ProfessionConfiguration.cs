using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Configurations
{
    public class ProfessionConfiguration : EntityTypeConfiguration<Profession>
    {
        public ProfessionConfiguration()
        {

            HasKey<int>(s => s.ProfessionId);

            Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);
        }
    }
}