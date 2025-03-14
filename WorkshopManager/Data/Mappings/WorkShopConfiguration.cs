using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopManager.Api.Entities;

namespace WorkshopManager.Api.Data.Mappings
{
    public class WorkShopConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.ToTable("Workshop");
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(w => w.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(w => w.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(w=> w.EventDate)
                .HasColumnName("event_date")
                .HasColumnType("datetime")
                .IsRequired();

           builder.HasOne(w => w.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);


            // Relacionamento Workshop - Employee (N:N)
            builder.HasMany(w => w.Employees)
                .WithMany(e => e.Workshops)
                .UsingEntity<Dictionary<string, object>>
                (
                    "Workshop_Employee",
                    x => x.HasOne<Employee>().WithMany().HasForeignKey("employeeId"),
                    x => x.HasOne<Workshop>().WithMany().HasForeignKey("workshopId")
                );

               

        }
    }
}
