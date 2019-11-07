using System.Data.Entity.ModelConfiguration;
using AirlineApplication.Core.Models;

namespace AirlineApplication.Configurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
         public NotificationConfiguration()
         {
            HasKey<int>(s => s.NotificationId);

             HasRequired(c => c.User)
            .WithMany(t => t.Notifications)
            .HasForeignKey(c => c.UserId)
            .WillCascadeOnDelete(false);
        }
    }
}